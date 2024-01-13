using Amazon.Lambda.SQSEvents;
using Amazon.Lambda.TestUtilities;
using AprovarPedidoLambda;
using Ecommerce.Lambda.Domain.Entities;
using Ecommerce.Lambda.Domain.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AprovarPedido.Lambda.Tests
{
    public class FunctionTest
    {
        [Fact]
        public void DeveSalvarUmPedidoComSucesso()
        {
            var pedido = new Pedido
            {
                Cliente = new Cliente
                {
                    Nome = "Jonatas",
                    Documento = "111111111",
                    Email = "jonatasdamiao@hotmail.com",
                    Endereco = new Endereco
                    {
                        Cidade = "Rio de Janeiro",
                        Estado = "RJ",
                        Logradouro = "Rua 1",
                        Numero = 158,
                        Complemento = "Teste"
                    }
                },

                PedidoId = Guid.NewGuid(),
                StatusPedido = StatusPedidoEnum.AGUANRDANDO_PAGAMENTO,
                ItensPedido = new List<ItemPedido>
                {
                    new ItemPedido
                    {
                        ProdutoId = 1,
                        Quantidade = 2,
                        ValorUnitario = 50
                    }
                }
            };
            

            var input = new SQSEvent
            {
                Records = new List<SQSEvent.SQSMessage>
                {
                    new SQSEvent.SQSMessage
                    {
                        Body = JsonSerializer.Serialize(pedido)
                    }
                }
            };

            var context = new TestLambdaContext
            {
                Logger = new TestLambdaLogger()
            };


            var function = new Function();
            function.FunctionHandler(input, context);
        }
    }
}
