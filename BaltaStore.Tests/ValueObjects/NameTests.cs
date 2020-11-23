using BaltaStore.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests.ValueObjects
{
    [TestClass]
    public class NameTests
    {
        [TestMethod]
        public void DeveRetornarNotificacaoQuandoNomeForInvalido()
        {
            var name = new Name("", "Cipriano");
            Assert.AreEqual(false, name.Valid);
            Assert.AreEqual(1, name.Notifications.Count);
        }
    }
}