
using Ecommerce.Lambda.Domain.Entities;

namespace EcommerceLambda.Service
{
    public interface IPedidoService
    {
        Task EnviarPedido(Pedido pedido);
    }
}
