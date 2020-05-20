﻿using Flunt.Validations;
using PaymentContext.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PaymentContext.Domain.Entities
{
    public class Subscription : Entity
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
            AddNotifications(new Contract().Requires().IsGreaterThan(DateTime.Now, payment.PaidDate, "Subscription.Payments", "A data do pagamento deve ser futura."));
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
