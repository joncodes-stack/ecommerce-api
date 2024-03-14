using Ecommerce.Lambda.Domain.Entites;
using Ecommerce.Lambda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessarPedidoPago.Services
{
    public class ProcessarPedidoPago : IProcessarPedidoPago
    {
        private readonly IStorageService storage;

        public ProcessarPedidoPago(IStorageService storage)
        {
            this.storage = storage;
        }

        public async Task Processar(Pedido pedido)
        {
            var notaFiscal = new NotaFiscal
            {
                DocumentoCliente = pedido.DocumentoCliente,
                IdNotaFiscal = Guid.NewGuid().ToString(),
                BaseCalculo = pedido.ValorTotal,
                AliquotaTributo = 20,
                Descricao = $"Nota Fiscal Relativa ao pedido {pedido.PedidoId}"
            };

            await this.storage.SalvarNotaFiscal(notaFiscal);

        }
    }
}
