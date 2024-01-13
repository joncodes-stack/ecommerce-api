﻿using Amazon.DynamoDBv2.DataModel;
using Ecommerce.Lambda.Domain.Convertions;
using Ecommerce.Lambda.Domain.enums;

namespace Ecommerce.Lambda.Domain.Entities
{
    public class Pedido
    {
        [DynamoDBHashKey(typeof(DynamoDBEnumStringConverter<StatusPedidoEnum>))]
        public StatusPedidoEnum StatusPedido { get; set; }
        public string DocumentoCliente
        {
            get
            {
                return this.Cliente.Documento;
            }
            private set
            {
                this.DocumentoCliente = value;
            }
        }
        public Guid PedidoId { get; set; }
        public Cliente Cliente { get; set; }
        public decimal ValorTotal
        {
            get
            {
                return this.ItensPedido.Sum(x => x.ValorUnitario * x.Quantidade);
            }
            private set
            {
                this.ValorTotal = value;
            }
        }
        public List<ItemPedido> ItensPedido { get; set; }
    }
}
