using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class Payment
    {
        public Payment()
        {
            RegisterDate = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int TypePayment { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Dcs { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
