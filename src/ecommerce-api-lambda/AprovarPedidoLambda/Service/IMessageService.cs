using Ecommerce.Lambda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprovarPedidoLambda.Service
{
    public interface IMessageService
    {
        Task SendMessage(Pedido pedido);
    }
}
