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

        [Display (Name ="Crypto ID")]
        public int CryptoId { get; set; }
        [Required]
        [Display (Name ="Currency")]
        public string Name { get; set; }
        [Required]
        [MaxLength (5, ErrorMessage="The ticker is too long")]
        public string Ticker { get; set; }
        public decimal Price { get; set; }
    }
}
