using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enum;
using PaymentContext.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Commands
{
    public class CreateCreditCardSubscriptionCommand: Notifiable, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string LastTransactionNumber { get; set; }
        public string PaymentNumber { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public string Payer { get; set; }
        public string PayerDocument { get; set; }
        public EDocumentType PayerDocumentType { get; set; }
        public string PayerEmail { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
               .Requires()
               .HasMinLen(FirstName, 2, "CreateCreditCardSubscriptionCommand.FirstName", "FirstName inválido")
               .HasMaxLen(FirstName, 40, "CreateCreditCardSubscriptionCommand.FirstName", "FirstName deve conter 40 caracteres.")
               .HasMinLen(LastName, 2, "CreateCreditCardSubscriptionCommand.LastName", "LastName inválido")
               .HasMaxLen(LastName, 40, "CreateCreditCardSubscriptionCommand.LastName", "LastName deve conter 40 caracteres.")
               .IsEmail(Email, "CreateCreditCardSubscriptionCommand.Email", "Email inválido")
               .IsEmail(PayerEmail, "CreateCreditCardSubscriptionCommand.PayerEmail", "Email inválido")
               .IsLowerOrEqualsThan(0, Total, "CreateCreditCardSubscriptionCommand.Total", "O total não pode ser zero.")
               .IsGreaterOrEqualsThan(Total, TotalPaid, "CreateCreditCardSubscriptionCommand.TotalPaid", "O valor pago é menor que o valor do pagamento.")
               .HasMinLen(Street, 2, "CreateCreditCardSubscriptionCommand.Street", "Rua deve ter no minimo 3 caracteres")
               .HasMaxLen(Street, 40, "CreateCreditCardSubscriptionCommand.Street", "Rua deve conter 40 caracteres.")
               .HasMinLen(Number, 1, "CreateCreditCardSubscriptionCommand.Number", "Number deve ter no minimo 1 caracteres")
               .HasMaxLen(Number, 6, "CreateCreditCardSubscriptionCommand.Number", "Rua deve conter 6 caracteres.")
               .HasMinLen(Neighborhood, 2, "CreateCreditCardSubscriptionCommand.Neighborhood", "Bairro deve ter no minimo 3 caracteres")
               .HasMaxLen(Neighborhood, 40, "CreateCreditCardSubscriptionCommand.Neighborhood", "Bairro deve conter 40 caracteres.")
               .HasMinLen(City, 2, "CreateCreditCardSubscriptionCommand.City", "Cidade deve ter no minimo 3 caracteres")
               .HasMaxLen(City, 40, "CreateCreditCardSubscriptionCommand.City", "Cidade deve conter 40 caracteres.")
               .HasMinLen(State, 2, "CreateCreditCardSubscriptionCommand.State", "Estado deve ter no minimo 3 caracteres")
               .HasMaxLen(State, 40, "CreateCreditCardSubscriptionCommand.State", "Estado deve conter 40 caracteres.")
               .HasMinLen(Country, 2, "CreateCreditCardSubscriptionCommand.Country", "País deve ter no minimo 3 caracteres")
               .HasMaxLen(Country, 40, "CreateCreditCardSubscriptionCommand.Country", "País deve conter 40 caracteres.")
               .HasMinLen(ZipCode, 2, "CreateCreditCardSubscriptionCommand.ZipCode", "CEP deve ter no minimo 3 caracteres")
               .HasMaxLen(ZipCode, 40, "CreateCreditCardSubscriptionCommand.ZipCode", "CEP deve conter 40 caracteres.")
               );
        }
    }
}
