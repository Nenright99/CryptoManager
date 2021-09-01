using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoManager.Data
{
    public class Investment
    {
        [Key]
        public int InvestmentId { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public int CryptoId { get; set; }
        public decimal Tokens { get; set; }
        public decimal InvPrice { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
