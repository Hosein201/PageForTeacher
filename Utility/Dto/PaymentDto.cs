using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Dto
{
    public class PaymentDto
    {
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public int TypePayment { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Dcs { get; set; }
        public int UserId { get; set; }
    }
}
