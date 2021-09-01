using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoManager.Data
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
