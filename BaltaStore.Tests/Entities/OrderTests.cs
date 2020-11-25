using BaltaStore.Domain.StoreContext;
using BaltaStore.Domain.StoreContext.Enum;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests.Entities
{
    [TestClass]
    public class OrderTests
    {
        private Product _mouse;
        private Product _keyboard;
        private Product _chair;
        private Product _monitor;
        private Customer _cliente;
        private Order _pedido; 

        public OrderTests()
        {
            var nome = new Name("Victor", "Oliveira");
            var document = new Document("51468226037");
            var email = new Email("vic@curu.com");
            _cliente = new Customer(nome, document, email, "85998855");
            _pedido = new Order(_cliente);

            _mouse = new Product("Mouse", "Mouse", "mouse.jpg", 100M, 10);
            _keyboard = new Product("Teclado", "Teclado", "teclado.jpg", 100M, 10);
            _chair = new Product("Cadeira", "Cadeira", "cadeira.jpg", 100M, 10);
            _monitor = new Product("Monitor", "Monitor", "mouse.jpg", 100M, 10);
        }

        // Consigo criar um novo pedido
        [TestMethod]
        public void ConsigoCriarUmPedido()
        {
            Assert.AreEqual(true, _pedido.Valid);
        }
        // Ao criar um pedido o status deve ser created
        [TestMethod]
        public void AoCriarPedidoStatusDeveSerCreated()
        {      
            Assert.AreEqual(EOrderStatus.Created, _pedido.Status);
        }

        // Ao adicionar um novo item a quantidade deve mudar
        // Retornar dois items 
        [TestMethod]
        public void AoAdicionarUmNovoItemQuantidadeDeveMudar()
        {
            _pedido.AddItem(_mouse, 5);
            _pedido.AddItem(_keyboard, 5);
            Assert.AreEqual(2, _pedido.Items.Count);
        }

        // Ao adicionar um novo item deve subtrair a quantidade do produto
        [TestMethod]
        public void AoAdicionarUmNovoItemDeveSubtrairQuantidadeDoProduto()
        {
            _pedido.AddItem(_mouse, 5);
            Assert.AreEqual(_mouse.QuantityOnHand, 5);
        }

        // Ao confirmar o pedido, deve gerar um número
        [TestMethod]
        public void AoConfirmarPedidoDeveGerarUmNumero()
        {
            _pedido.Place();
            Assert.AreNotEqual("", _pedido.Number);
        }

        // Ao pagar o pedido, o status deve ser pago
        [TestMethod]
        public void AoPagarPedidoStatusDeveSerPago()
        {
            _pedido.Pay();
            Assert.AreEqual(EOrderStatus.Paid, _pedido.Status);
        }

        // Dados mais 10 produtos devem haver duas entregas
        [TestMethod]
        public void DadoDezProdutosDevemHaverDuasEntregas()
        {
            _pedido.AddItem(_mouse, 1);
            _pedido.AddItem(_mouse, 1);
            _pedido.AddItem(_mouse, 1);
            _pedido.AddItem(_mouse, 1);
            _pedido.AddItem(_mouse, 1);
            _pedido.AddItem(_mouse, 1);
            _pedido.AddItem(_mouse, 1);
            _pedido.AddItem(_mouse, 1);
            _pedido.AddItem(_mouse, 1);
            _pedido.AddItem(_mouse, 1);
            _pedido.Ship();

            Assert.AreEqual(2, _pedido.Deliveries.Count);
        }

        // Ao cancelar o pedido o status deve ser cancelado
        [TestMethod]
        public void AoCancelarPedidoStatusDeveSerCancelado()
        {
            _pedido.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, _pedido.Status);
        }

        // Ao cancelar o pedido, deve cancelar as entregas
        [TestMethod]
        public void AoCancelarPedidoDeveCancelarAsEntregas()
        {
            _pedido.AddItem(_mouse, 1);
            _pedido.AddItem(_mouse, 1);
            _pedido.AddItem(_mouse, 1);
            _pedido.AddItem(_mouse, 1);
            _pedido.AddItem(_mouse, 1);
            _pedido.AddItem(_mouse, 1);
            _pedido.AddItem(_mouse, 1);
            _pedido.AddItem(_mouse, 1);
            _pedido.AddItem(_mouse, 1);
            _pedido.AddItem(_mouse, 1);
            _pedido.Ship();

            _pedido.Cancel();

            foreach(var x in _pedido.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Canceled, x.Status);
            }
        }
    }
}