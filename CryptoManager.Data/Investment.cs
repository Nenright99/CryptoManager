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
        [Display (Name ="Investment ID")]
        public int InvestmentId { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Display (Name ="Currency")]
        public int CryptoId { get; set; }
        public decimal Tokens { get; set; }
        [Display (Name ="Initial Investment Price")]
        public decimal InvPrice { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        [Display (Name ="Investment Date")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display (Name ="Bought/Sold")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
