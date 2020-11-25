using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
    private readonly Document _documentInvalid = new Document("123456789101");
    private readonly Document _documentValid = new Document("51468226037");

        [TestMethod]
        public void DeveRetornarNotificacaoSeDocumentoForInvalido()
        {
            Assert.AreEqual(false, _documentInvalid.Valid);
            // Assert.Fail();
        }

        [TestMethod]
        public void NaoDeveRetornarNotificacaoSeDocumentoForValido()
        {
            Assert.AreEqual(true, _documentValid.Valid);
            // Assert.Fail();
        }
    }
}