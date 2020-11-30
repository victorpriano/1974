using System;
using System.Collections.Generic;
using BaltaStore.Domain.StoreContext;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace BaltaStore.Api.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        [Route("customers")]
        public List<Customer> Get()
        {
            var nome = new Name("Victor", "Oliveira");
            var document = new Document("51468226037");
            var email = new Email("vic@curu.com");
            var cliente = new Customer(nome, document, email, "85998855");
            var clientes = new List<Customer>();
            clientes.Add(cliente);
            
            return clientes;
        }

        [HttpGet]
        [Route("customers/{id}")]
        public Customer GetById(Guid id)
        {
            var nome = new Name("Victor", "Oliveira");
            var document = new Document("51468226037");
            var email = new Email("vic@curu.com");
            var cliente = new Customer(nome, document, email, "85998855");

            return cliente;
        }

        [HttpGet]
        [Route("customers/{id}/orders")]
        public List<Order> GetOrders(Guid id)
        {
            var nome = new Name("Victor", "Oliveira");
            var document = new Document("51468226037");
            var email = new Email("vic@curu.com");
            var cliente = new Customer(nome, document, email, "85998855");

            var pedido = new Order(cliente);

            var mouse = new Product("Mouse", "Mouse", "mouse.jpg", 100M, 10);
            var keyboard = new Product("Teclado", "Teclado", "teclado.jpg", 100M, 10);
            pedido.AddItem(mouse, 5);
            pedido.AddItem(keyboard, 5);

            var pedidos = new List<Order>();
            pedidos.Add(pedido);

            return pedidos;
        }

        [HttpPost]
        [Route("customers")]
        public Customer Post([FromBody] CreateCustomerCommand command)
        {
            var nome = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var cliente = new Customer(nome, document, email, command.Phone);
            
            return cliente;    
        }

        [HttpPut]
        [Route("customers/{id}")]
        public Customer Put([FromBody] CreateCustomerCommand command)
        {
            var nome = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var cliente = new Customer(nome, document, email, command.Phone);
            
            return cliente;    
        }

        [HttpDelete]
        [Route("customers/{id}")]
        public object Delete()
        {
            return new { message = "Cliente removido com sucesso!"};
        }
    }
}