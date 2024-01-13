using AprovarPedidoLambda.Repositories;
using Ecommerce.Lambda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprovarPedidoLambda.Service
{
    public class AprovarPedidoService : IAProvarPedidoService
    {
        private readonly IPedidoRepository pedidoRepository;

        public AprovarPedidoService(IPedidoRepository pedidoRepository)
        {
            this.pedidoRepository = pedidoRepository;
        }

        public async Task AprovarPedido(Pedido pedido)
        {
            await this.pedidoRepository.SalvarPedido(pedido);
        }
    }
}
