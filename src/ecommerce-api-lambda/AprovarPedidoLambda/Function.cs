using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;
using AprovarPedidoLambda.Repositories;
using AprovarPedidoLambda.Service;
using Ecommerce.Lambda.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AprovarPedidoLambda
{
    public class Function
    {
        private readonly IAProvarPedidoService _service;

        public Function()
        {
            var _serviceCollection = new ServiceCollection();
            _serviceCollection.AddScoped<IAmazonDynamoDB, AmazonDynamoDBClient>();
            _serviceCollection.AddScoped<IDynamoDBContext, DynamoDBContext>();
            _serviceCollection.AddScoped<IAProvarPedidoService, AprovarPedidoService>();
            _serviceCollection.AddScoped<IPedidoRepository, PedidoRepository>();

            var serviceProvider = _serviceCollection.BuildServiceProvider();

            _service = serviceProvider.GetRequiredService<IAProvarPedidoService>();
        }

        public async Task FunctionHandler(SQSEvent input, ILambdaContext context)
        {
            foreach (var message in input.Records)
            {
                await ProcessarMensaagem(message, context);
            }
        }

        private async Task ProcessarMensaagem(SQSEvent.SQSMessage message, ILambdaContext context)
        {
            context.Logger.Log("Mensagem crua");
            context.Logger.Log(JsonSerializer.Serialize(message));

            context.Logger.Log("ApproximateReceiveCount");
            context.Logger.Log(message.Attributes["ApproximateReceiveCount"]);

            context.Logger.Log("Body");
            context.Logger.Log(message.Body);

            var pedido = JsonSerializer.Deserialize<Pedido>(message.Body);

            await _service.AprovarPedido(pedido);

            await Task.CompletedTask;
        }
    }
}
