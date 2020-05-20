using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public Address(string street, string number, string neighborhood, string city, string state, string country, string zipCode)
        {
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Street, 2, "Address.Street", "Rua deve ter no minimo 3 caracteres")
                .HasMaxLen(Street, 40, "Address.Street", "Rua deve conter 40 caracteres.")
                .HasMinLen(Number, 1, "Address.Number", "Number deve ter no minimo 1 caracteres")
                .HasMaxLen(Number, 6, "Address.Number", "Rua deve conter 6 caracteres.")
                .HasMinLen(Neighborhood, 2, "Address.Neighborhood", "Bairro deve ter no minimo 3 caracteres")
                .HasMaxLen(Neighborhood, 40, "Address.Neighborhood", "Bairro deve conter 40 caracteres.")
                .HasMinLen(City, 2, "Address.City", "Cidade deve ter no minimo 3 caracteres")
                .HasMaxLen(City, 40, "Address.City", "Cidade deve conter 40 caracteres.")
                .HasMinLen(State, 2, "Address.State", "Estado deve ter no minimo 3 caracteres")
                .HasMaxLen(State, 40, "Address.State", "Estado deve conter 40 caracteres.")
                .HasMinLen(Country, 2, "Address.Country", "País deve ter no minimo 3 caracteres")
                .HasMaxLen(Country, 40, "Address.Country", "País deve conter 40 caracteres.")
                .HasMinLen(ZipCode, 2, "Address.ZipCode", "CEP deve ter no minimo 3 caracteres")
                .HasMaxLen(ZipCode, 40, "Address.ZipCode", "CEP deve conter 40 caracteres.")


                );
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }


    }
}
