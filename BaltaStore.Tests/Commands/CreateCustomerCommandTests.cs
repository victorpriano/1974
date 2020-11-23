using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests.Commands
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
        [TestMethod]
        public void DeveRetornarTrueQuandoCommandForValido()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Victor";
            command.LastName = "Cipriano";
            command.Email = "victor@cc.com";
            command.Document = "11111111111";
            command.Phone = "85999999999";

            Assert.AreEqual(true, command.IsValid());
        }
    }
}