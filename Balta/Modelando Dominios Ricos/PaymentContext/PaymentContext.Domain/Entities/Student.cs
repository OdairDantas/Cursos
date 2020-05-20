﻿using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private IList<Subscription> _subscription;
        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscription = new List<Subscription>();

            AddNotifications(Name, Document, Email);
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscription.ToArray(); } }

        public void AddSubscription(Subscription subscription)
        {
            var hasSubscriptionActive = false;

            foreach (var sub in Subscriptions)
            {
                if (sub.Active)
                    hasSubscriptionActive = true;
            }

            if (!subscription.Payments.Any())
                AddNotification("Student.Subscription.Payments", "Esta assinatura não possui pagamentos");

            if (!hasSubscriptionActive && subscription.Payments.Any())
                _subscription.Add(subscription);


            AddNotifications(
                new Contract().Requires().IsFalse(hasSubscriptionActive, "Student.Subscription", "Você já tem uma assinatura")
                );

        }

    }
}
