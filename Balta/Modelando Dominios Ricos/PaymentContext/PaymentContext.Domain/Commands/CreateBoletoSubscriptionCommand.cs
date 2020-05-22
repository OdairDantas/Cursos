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
    public class CreateBoletoSubscriptionCommand: Notifiable, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string BarCode { get; set; }
        public string BoletoNumber { get; set; }
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
               .HasMinLen(FirstName, 2, "CreateBoletoSubscriptionCommand.FirstName", "FirstName inválido")
               .HasMaxLen(FirstName, 40, "CreateBoletoSubscriptionCommand.FirstName", "FirstName deve conter 40 caracteres.")
               .HasMinLen(LastName, 2, "CreateBoletoSubscriptionCommand.LastName", "LastName inválido")
               .HasMaxLen(LastName, 40, "CreateBoletoSubscriptionCommand.LastName", "LastName deve conter 40 caracteres.")
               .IsEmail(Email, "CreateBoletoSubscriptionCommand.Email", "Email inválido")
               .IsEmail(PayerEmail, "CreateBoletoSubscriptionCommand.PayerEmail", "Email inválido")
               .IsLowerOrEqualsThan(0, Total, "CreateBoletoSubscriptionCommand.Total", "O total não pode ser zero.")
               .IsGreaterOrEqualsThan(Total, TotalPaid, "CreateBoletoSubscriptionCommand.TotalPaid", "O valor pago é menor que o valor do pagamento.")
               .HasMinLen(Street, 2, "CreateBoletoSubscriptionCommand.Street", "Rua deve ter no minimo 3 caracteres")
               .HasMaxLen(Street, 40, "CreateBoletoSubscriptionCommand.Street", "Rua deve conter 40 caracteres.")
               .HasMinLen(Number, 1, "CreateBoletoSubscriptionCommand.Number", "Number deve ter no minimo 1 caracteres")
               .HasMaxLen(Number, 6, "CreateBoletoSubscriptionCommand.Number", "Rua deve conter 6 caracteres.")
               .HasMinLen(Neighborhood, 2, "CreateBoletoSubscriptionCommand.Neighborhood", "Bairro deve ter no minimo 3 caracteres")
               .HasMaxLen(Neighborhood, 40, "CreateBoletoSubscriptionCommand.Neighborhood", "Bairro deve conter 40 caracteres.")
               .HasMinLen(City, 2, "CreateBoletoSubscriptionCommand.City", "Cidade deve ter no minimo 3 caracteres")
               .HasMaxLen(City, 40, "CreateBoletoSubscriptionCommand.City", "Cidade deve conter 40 caracteres.")
               .HasMinLen(State, 2, "CreateBoletoSubscriptionCommand.State", "Estado deve ter no minimo 3 caracteres")
               .HasMaxLen(State, 40, "CreateBoletoSubscriptionCommand.State", "Estado deve conter 40 caracteres.")
               .HasMinLen(Country, 2, "CreateBoletoSubscriptionCommand.Country", "País deve ter no minimo 3 caracteres")
               .HasMaxLen(Country, 40, "CreateBoletoSubscriptionCommand.Country", "País deve conter 40 caracteres.")
               .HasMinLen(ZipCode, 2, "CreateBoletoSubscriptionCommand.ZipCode", "CEP deve ter no minimo 3 caracteres")
               .HasMaxLen(ZipCode, 40, "CreateBoletoSubscriptionCommand.ZipCode", "CEP deve conter 40 caracteres.")
               );
        }
    }
}
