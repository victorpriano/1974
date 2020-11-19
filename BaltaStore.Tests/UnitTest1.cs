using BaltaStore.Domain.StoreContext;
using BaltaStore.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = new Name("Victor", "Oliveira");
            var document = new Document("12345678911");
            var email = new Email("victor@oioi");

            var cliente = new Customer(name, document, email, "123456");
            var mouse = new Product("Mouse", "mouse", "img.png", 10, 10);
            var teclado = new Product("Teclado", "teclado", "img.png", 10, 10);
            var monitor = new Product("Monitor", "monitor", "img.png", 10, 10);
            var impressora = new Product("Impressora", "impressora", "img.png", 10, 10);

            var pedido = new Order(cliente);
            // pedido.AddItem(new OrderItem(mouse, 5));
            // pedido.AddItem(new OrderItem(teclado, 5));
            // pedido.AddItem(new OrderItem(monitor, 5));
            // pedido.AddItem(new OrderItem(impressora, 5));

            //Realizar pedido
            pedido.Place();

            //Verificar se o pedido é válido
            var valid = pedido.Valid;

            //Simular pagamento
            pedido.Pay();

            //Simular o envio
            pedido.Ship();

            //Cancelar o pedido
            pedido.Cancel();
        }
    }
}
