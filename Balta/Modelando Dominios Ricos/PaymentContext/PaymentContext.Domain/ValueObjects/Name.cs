﻿using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 2, "Name.FirstName", "FirstName inválido")
                .HasMaxLen(FirstName,40, "Name.FirstName", "FirstName deve conter 40 caracteres.")
                .HasMinLen(LastName, 2, "Name.LastName", "LastName inválido")
                .HasMaxLen(LastName, 40, "Name.LastName", "LastName deve conter 40 caracteres.")

                );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}
