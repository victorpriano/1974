using System;
using System.Collections.Generic;
using System.Linq;
using BaltaStore.Domain.StoreContext.Enum;
using FluentValidator;

namespace BaltaStore.Domain.StoreContext
{
    public class Order : Notifiable
    {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;
        public Order(Customer customer)
        {
            Customer = customer;
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }
        public Customer Customer { get; set; }
        public string Number { get; set; }
        public DateTime CreateDate { get; set; }
        public EOrderStatus Status { get; set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();

        public void AddItem(Product product, decimal quantity)
        {
            if(quantity > product.QuantityOnHand)
                AddNotification("OrderItem", $"Produto {product.Title} não tem {quantity} em estoque");
            
            var item = new OrderItem(product, quantity);
            _items.Add(item);
        }
        public void AddDelivery(Delivery delivery)
        {
            _deliveries.Add(delivery);
        }
        // Criar o pedido
        public void Place()
        {
            // Gera o número do pedido
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0,8).ToUpper();
            
            // Validar
            if(_items.Count == 0)
                AddNotification("Order", "Este pedido não possui itens");

        }

        // Pagar um pedido
        public void Pay()
        {
            Status = EOrderStatus.Paid;
        }

        // Enviar um pedido
        public void Ship()
        {
            // A cada 5 produtos é uma entrega
            var deliveries = new List<Delivery>();
            //deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
            var count = 1;

            // Quebra as entregas
            foreach(var item in _items)
            {
                if(count == 5)
                {
                    count = 1;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }
                count ++;
            }

            // Envia todas as entregas
            deliveries.ForEach(x => x.Ship()); // percorrendo as entregas
            deliveries.ForEach(x => _deliveries.Add(x)); // adiciona as entregas ao pedido

        }

        // Cancelar um pedido
        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
            _deliveries.ToList().ForEach(x => x.Cancel());
        }
    }
}