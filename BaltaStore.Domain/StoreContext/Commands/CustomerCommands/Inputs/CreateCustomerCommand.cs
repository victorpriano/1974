using BaltaStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs
{
    public class CreateCustomerCommand : Notifiable, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        // Fail Fast Validation
        public bool IsValid()
        {
            AddNotifications(new ValidationContract()
                .HasMinLen(FirstName, 3, "FirstName", "Deve conter no mínimo 3 caracteres")
                .HasMaxLen(FirstName, 30, "FirstName", "Deve conter no máximo 30 caracteres")
                .HasMinLen(LastName, 3, "LastName", "Deve conter no mínimo 3 caracteres")
                .HasMaxLen(LastName, 30, "LastName", "Deve conter no máximo 30 caracteres")
                .IsEmail(Email, "Email", "Este e-mail não é válido!")
                .HasLen(Document, 11, "Document", "CPF inválido!")
            );

            return Valid;
        }
    }
}