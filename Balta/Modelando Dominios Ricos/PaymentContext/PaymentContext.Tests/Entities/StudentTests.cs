using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enum;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        private readonly Name _name;
        private readonly Document _document;
        private readonly Email _email;
        private readonly Address _address;
        private readonly Student _student;
        private readonly Subscription _subscription;
        public StudentTests()
        {
            _name = new Name("Caneta", "Azul");
            _document = new Document("35864654646", EDocumentType.CPF);
            _email = new Email("canetaazul@azulcaneta.com");
            _address = new Address("rua tres", "3655", "ticotico", "malacacheta", "terrinha", "brasil", "4565878");

            _subscription = new Subscription(null);
            _student = new Student(_name, _document, _email);

        }
        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {
            var payment = new PayPalPayment(DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Manuel Gomes", _document, _address, _email, Guid.NewGuid().ToString().Replace("-", "").Substring(10));
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);

        }
        [TestMethod]
        public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
        {
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Invalid);
        }
        [TestMethod]
        public void ShouldReturnSuccessWhenAddSubscription()
        {
            var payment = new PayPalPayment(DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Manuel Gomes", _document, _address, _email, Guid.NewGuid().ToString().Replace("-", "").Substring(10));
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Valid);
        }


    }
}
