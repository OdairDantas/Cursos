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
    public class CreatePayPalSubscriptionCommand : Notifiable, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string TransactionCode { get; set; }
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
               .HasMinLen(FirstName, 2, "CreatePayPalSubscriptionCommand.FirstName", "FirstName inválido")
               .HasMaxLen(FirstName, 40, "CreatePayPalSubscriptionCommand.FirstName", "FirstName deve conter 40 caracteres.")
               .HasMinLen(LastName, 2, "CreatePayPalSubscriptionCommand.LastName", "LastName inválido")
               .HasMaxLen(LastName, 40, "CreatePayPalSubscriptionCommand.LastName", "LastName deve conter 40 caracteres.")
               .IsEmail(Email, "CreatePayPalSubscriptionCommand.Email", "Email inválido")
               .IsEmail(PayerEmail, "CreatePayPalSubscriptionCommand.PayerEmail", "Email inválido")
               .IsLowerOrEqualsThan(0, Total, "CreatePayPalSubscriptionCommand.Total", "O total não pode ser zero.")
               .IsGreaterOrEqualsThan(Total, TotalPaid, "CreatePayPalSubscriptionCommand.TotalPaid", "O valor pago é menor que o valor do pagamento.")
               .HasMinLen(Street, 2, "CreatePayPalSubscriptionCommand.Street", "Rua deve ter no minimo 3 caracteres")
               .HasMaxLen(Street, 40, "CreatePayPalSubscriptionCommand.Street", "Rua deve conter 40 caracteres.")
               .HasMinLen(Number, 1, "CreatePayPalSubscriptionCommand.Number", "Number deve ter no minimo 1 caracteres")
               .HasMaxLen(Number, 6, "CreatePayPalSubscriptionCommand.Number", "Rua deve conter 6 caracteres.")
               .HasMinLen(Neighborhood, 2, "CreatePayPalSubscriptionCommand.Neighborhood", "Bairro deve ter no minimo 3 caracteres")
               .HasMaxLen(Neighborhood, 40, "CreatePayPalSubscriptionCommand.Neighborhood", "Bairro deve conter 40 caracteres.")
               .HasMinLen(City, 2, "CreatePayPalSubscriptionCommand.City", "Cidade deve ter no minimo 3 caracteres")
               .HasMaxLen(City, 40, "CreatePayPalSubscriptionCommand.City", "Cidade deve conter 40 caracteres.")
               .HasMinLen(State, 2, "CreatePayPalSubscriptionCommand.State", "Estado deve ter no minimo 3 caracteres")
               .HasMaxLen(State, 40, "CreatePayPalSubscriptionCommand.State", "Estado deve conter 40 caracteres.")
               .HasMinLen(Country, 2, "CreatePayPalSubscriptionCommand.Country", "País deve ter no minimo 3 caracteres")
               .HasMaxLen(Country, 40, "CreatePayPalSubscriptionCommand.Country", "País deve conter 40 caracteres.")
               .HasMinLen(ZipCode, 2, "CreatePayPalSubscriptionCommand.ZipCode", "CEP deve ter no minimo 3 caracteres")
               .HasMaxLen(ZipCode, 40, "CreatePayPalSubscriptionCommand.ZipCode", "CEP deve conter 40 caracteres.")
               );
        }
    }
}
