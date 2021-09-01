using CryptoManager.Data;
using CryptoManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoManager.Services
{
    public class InvestmentService
    {
        private readonly Guid _userId;

        public InvestmentService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateInvestment(InvestmentCreate model)
        {
            var crypto = new CryptoService();
            var entity =
                new Investment()
                {
                    OwnerId = _userId,
                    Amount = model.Amount,
                    CryptoId = model.CryptoId,
                    CreatedUtc = DateTimeOffset.Now,
                    InvPrice = crypto.GetCryptoById(model.CryptoId).Price,
                    Tokens = model.Amount / crypto.GetCryptoById(model.CryptoId).Price
                };
            var collateral =
                new Transaction()
                {
                    OwnerId = _userId,
                    Amount = -model.Amount,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Transactions.Add(collateral);
                ctx.SaveChanges();
            }
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Investments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<InvestmentListItem> GetInvestments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Investments
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new InvestmentListItem
                        {
                            InvestmentId = e.InvestmentId,
                            Amount = e.Amount,
                            CryptoId = e.CryptoId,
                            Tokens = e.Tokens,
                            OwnerId = e.OwnerId,
                            InvPrice = e.InvPrice,
                            CreatedUtc = e.CreatedUtc,
                            ModifiedUtc = e.ModifiedUtc
                        }
                        );
                return query.ToArray();
            }
        }
        public InvestmentDetail GetInvestmentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Investments
                    .Single(e => e.InvestmentId == id && e.OwnerId == _userId);
                return
                    new InvestmentDetail
                    {
                        InvestmentId = entity.InvestmentId,
                        Amount = entity.Amount,
                        CryptoId = entity.CryptoId,
                        Tokens = entity.Tokens,
                        OwnerId = entity.OwnerId,
                        InvPrice = entity.InvPrice,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public bool UpdateInvestment(InvestmentEdit model)
        {
            var collateral =
                new Transaction()
                {
                    OwnerId = _userId,
                    Amount = model.Amount,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Transactions.Add(collateral);
                ctx.SaveChanges();
            }
            using (var ctx = new ApplicationDbContext())
            {
                var crypto = new CryptoService();
                var entity =
                    ctx
                    .Investments
                    .Single(e => e.InvestmentId == model.InvestmentId && e.OwnerId == _userId);
                entity.Amount = entity.Amount - model.Amount;
                entity.Tokens = entity.Tokens - model.Amount/crypto.GetCryptoById(entity.CryptoId).Price;
                entity.ModifiedUtc = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteInvestment(int InvestmentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Investments
                    .Single(e => e.InvestmentId == InvestmentId && e.OwnerId == _userId);
                ctx.Investments.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
