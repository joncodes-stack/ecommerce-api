using Amazon.SQS;
using Amazon.SQS.Model;
using Ecommerce.Lambda.Domain.Entities;
using System.Text.Json;

namespace EcommerceLambda.Service
{
    public class PedidoService : IPedidoService
    {
        private readonly IAmazonSQS sqsClient;

        public PedidoService(IAmazonSQS sqsClient)
        {
            this.sqsClient = sqsClient;
        }

        public async Task EnviarPedido(Pedido pedido)
        {
            var request = new SendMessageRequest
            {
                MessageBody = JsonSerializer.Serialize(pedido),
                QueueUrl = "https://sqs.us-east-1.amazonaws.com/940935648410/pedido-criado-sqs"
            };

            await this.sqsClient.SendMessageAsync(request);
        }
    }
}
