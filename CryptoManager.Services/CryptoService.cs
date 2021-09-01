using CryptoManager.Data;
using CryptoManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoManager.Services
{
    public class CryptoService
    {
        public bool CreateCrypto(CryptoCreate model)
        {
            Scraper scraper = new Scraper();
            string data = scraper.PullData();
            string strStart = "coinmarketcap/" + model.Ticker.ToLower();
            string strEnd = "24h % Change";
            decimal price = scraper.getPrice(data, strStart, strEnd);
            var entity =
                new Crypto()
                {
                    Name = model.Name,
                    Ticker = model.Ticker,
                    Price = price
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Cryptos.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CryptoListItem> GetCryptos()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Cryptos
                    .Select(
                        e =>
                        new CryptoListItem
                        {
                            CryptoId = e.CryptoId,
                            Name = e.Name,
                            Ticker = e.Ticker,
                            Price = e.Price
                        }
                        );
                return query.ToArray();
            }
        }
        public CryptoDetail GetCryptoById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Cryptos
                    .Single(e => e.CryptoId == id);
                return
                    new CryptoDetail
                    {
                        CryptoId = entity.CryptoId,
                        Name = entity.Name,
                        Ticker = entity.Ticker,
                        Price = entity.Price
                    };
            }
        }
        public bool UpdateCrypto(CryptoEdit model)
        {
            Scraper scraper = new Scraper();
            string data = scraper.PullData();
            string strStart = "coinmarketcap/" + model.Ticker.ToLower();
            string strEnd = "24h % Change";
            decimal price = scraper.getPrice(data, strStart, strEnd);

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Cryptos
                    .Single(e => e.CryptoId == model.CryptoId);
                entity.Name = model.Name;
                entity.Ticker = model.Ticker;
                entity.Price = price;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteCrypto(int CryptoId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Cryptos
                    .Single(e => e.CryptoId == CryptoId);
                ctx.Cryptos.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
