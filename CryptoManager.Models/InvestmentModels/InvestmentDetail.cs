using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoManager.Models
{
    public class InvestmentDetail
    {
        public int InvestmentId { get; set; }
        public decimal Amount { get; set; }
        public int CryptoId { get; set; }
        public decimal Tokens { get; set; }
        public decimal InvPrice { get; set; }
        public Guid OwnerId { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
