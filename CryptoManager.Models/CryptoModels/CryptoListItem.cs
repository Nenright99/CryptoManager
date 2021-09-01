using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoManager.Models
{
    public class CryptoListItem
    {
        public int CryptoId { get; set; }
        public string Name { get; set; }
        public string Ticker { get; set; }
        public decimal Price { get; set; }
    }
}
