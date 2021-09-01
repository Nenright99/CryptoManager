using CryptoManager.Data;
using CryptoManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoManager.Services
{
    public class TransactionService
    {
        private readonly Guid _userId;

        public TransactionService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateTransaction(TransactionCreate model)
        {
            var entity =
                new Transaction()
                {
                    OwnerId = _userId,
                    Amount = model.Amount,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Transactions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<TransactionListItem> GetTransactions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Transactions
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new TransactionListItem
                        {
                            TransactionId = e.TransactionId,
                            Amount = e.Amount,
                            CreatedUtc = e.CreatedUtc
                        }
                        );
                return query.ToArray();
            }
        }
        public TransactionDetail GetTransactionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Transactions
                    .Single(e => e.TransactionId == id && e.OwnerId == _userId);
                return
                    new TransactionDetail
                    {
                        TransactionId = entity.TransactionId,
                        Amount = entity.Amount,
                        CreatedUtc = entity.CreatedUtc,
                    };
            }
        }
        public bool UpdateTransaction(TransactionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Transactions
                    .Single(e => e.TransactionId == model.TransactionId && e.OwnerId == _userId);
                entity.Amount = model.Amount;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteTransaction(int TransactionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Transactions
                    .Single(e => e.TransactionId == TransactionId && e.OwnerId == _userId);
                ctx.Transactions.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
