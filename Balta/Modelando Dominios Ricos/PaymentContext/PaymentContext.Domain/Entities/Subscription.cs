using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Entities
{
    public class Subscription
    {
        private IList<Payment> _payments;
        public Subscription(DateTime? expireDate)
        {
            CreteDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
            ExpireDate = expireDate;
            Active = true;
            _payments = new List<Payment>();
        }

        public DateTime CreteDate { get;private set; }
        public DateTime LastUpdateDate { get;private set; }
        public DateTime? ExpireDate { get;private set; }
        public bool Active { get; private set; }
        public IReadOnlyCollection<Payment> Payments { get { return _payments.ToArray(); } }

        public void AddPayment(Payment payment)
        {
            _payments.Add(payment);
        }

        public void Ativate()
        {
            Active = true;
            LastUpdateDate = DateTime.Now;
        }
        public void Inativate()
        {
            Active = false;
            LastUpdateDate = DateTime.Now;
        }
    }
}
