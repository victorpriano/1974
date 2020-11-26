using BaltaStore.Domain.StoreContext;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using BaltaStore.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests.Handlers
{
    [TestClass]
    public class CustomerHandlerTests
    {
        [TestMethod]
        public void RegistraClienteQuandoComandoForValido()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Victor";
            command.LastName = "Cipriano";
            command.Email = "victor@cc.com";
            command.Document = "11111111111";
            command.Phone = "85999999999";

            Assert.AreEqual(true, command.IsValid());

            var handler = new CustomerHandler(new MockCustomerRepository(), new MockServiceRepository());

            var result = handler.Handle(command);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, handler.Valid);
        }
    }
}