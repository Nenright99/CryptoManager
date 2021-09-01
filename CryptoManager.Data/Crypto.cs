using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoManager.Data
{
    public class Crypto
    {
        [Key]
        public int CryptoId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Ticker { get; set; }
        public decimal Price { get; set; }
    }
}
