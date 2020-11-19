using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string address)
        {
            Address = address;

            AddNotifications(new ValidationContract()
                .Requires()
                .IsEmail(Address, "Email", "Este e-mail não é válido!")
            );
            
        }
        public string Address { get; private set; }
    }
}