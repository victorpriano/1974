using System;
using System.Collections.Generic;
using BaltaStore.Domain.StoreContext;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Queries;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace BaltaStore.Api.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;
        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("customers")]
        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("customers/{id}")]
        public GetCustomerQueryResult GetById(Guid id)
        {
            return _repository.Get(id);
        }

        [HttpGet]
        [Route("customers/{id}/orders")]
        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id)
        {
            return _repository.GetOrders(id);
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