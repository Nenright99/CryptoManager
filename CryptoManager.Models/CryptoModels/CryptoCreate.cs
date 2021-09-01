using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoManager.Models
{
    public class CryptoCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Ticker { get; set; }
        public decimal Price { get; set; }
    }
}
