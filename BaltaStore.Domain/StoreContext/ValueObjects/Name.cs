using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(FirstName, 3, "FirstName", "Deve conter no mínimo 3 caracteres")
                .HasMaxLen(FirstName, 30, "FirstName", "Deve conter no máximo 30 caracteres")
                .HasMinLen(LastName, 3, "LastName", "Deve conter no mínimo 3 caracteres")
                .HasMaxLen(LastName, 30, "LastName", "Deve conter no máximo 30 caracteres")
            );
        }
        public string FirstName { get; private set; }    
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName}{LastName}";
        }
    }
}