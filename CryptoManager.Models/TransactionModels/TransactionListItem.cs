using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoManager.Models
{
    public class TransactionListItem
    {
        public int TransactionId { get; set; }
        public Guid OwnerId { get; set; }
        public decimal Amount { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
