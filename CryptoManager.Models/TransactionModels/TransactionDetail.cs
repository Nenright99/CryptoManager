using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoManager.Models
{
    public class TransactionDetail
    {
        public int TransactionId { get; set; }
        //Remove from details
        public Guid OwnerId { get; set; }
        public decimal Amount { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
