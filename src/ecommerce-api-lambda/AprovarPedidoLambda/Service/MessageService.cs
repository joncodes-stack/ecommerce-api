using Amazon.Runtime.SharedInterfaces;
using Amazon.SQS;
using Amazon.SQS.Model;
using Ecommerce.Lambda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AprovarPedidoLambda.Service
{
    public class MessageService : IMessageService
    {
        private readonly IAmazonSQS sqsClient;

        public MessageService(IAmazonSQS sqsClient)
        {
            this.sqsClient = sqsClient;
        }

        public async Task SendMessage(Pedido pedido)
        {
            try
            {
                var request = new SendMessageRequest
                {
                    MessageBody = JsonSerializer.Serialize(pedido),
                    QueueUrl = "https://sqs.us-east-1.amazonaws.com/940935648410/pedido-pago-sqs"
                };

                await this.sqsClient.SendMessageAsync(request);
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}
