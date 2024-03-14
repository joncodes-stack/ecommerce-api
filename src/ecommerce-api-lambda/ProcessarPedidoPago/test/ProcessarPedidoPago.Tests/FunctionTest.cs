using Xunit;
using Amazon.Lambda.TestUtilities;
using Amazon.Lambda.SQSEvents;
using Ecommerce.Lambda.Domain.Entities;
using Ecommerce.Lambda.Domain.enums;
using System.Text.Json;

namespace ProcessarPedidoPago.Tests;

public class FunctionTest
{
    [Fact]
    public async Task TestSQSEventLambdaFunction()
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
                        Body = JsonSerializer.Serialize(pedido),
                        Attributes = new Dictionary<string, string>()
                        {
                            { "ApproximateReceiveCount", "1" }
                        }
                    }
                }
        };

        var logger = new TestLambdaLogger();
        var context = new TestLambdaContext
        {
            Logger = logger
        };

        var function = new Function();
        await function.FunctionHandler(input, context);

        Assert.Contains("Processed message foobar", logger.Buffer.ToString());
    }
}