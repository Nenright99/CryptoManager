using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoManager.Services
{
    class Scraper
    {
        System.Net.WebClient wc = new System.Net.WebClient();
        public string PullData()
        {
            string webData = wc.DownloadString("https://cryptocurrencynews.com/coinmarketcap");
            return webData;
        }

        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                int Start, End;
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }

            return "";
        }
        public decimal getPrice(string strSource, string strStart, string strEnd)
        {
            string cryptoData = getBetween(strSource, strStart, strEnd);
            decimal cryptoPrice = decimal.Parse(getBetween(cryptoData, "\"coin-price-value\">", "</span>"));
            return cryptoPrice;
        }
    }
}
