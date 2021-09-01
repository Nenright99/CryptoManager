using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoManager.Models
{
    public class TransactionCreate
    {
        [Required]
        public decimal Amount { get; set; }
    }
}
