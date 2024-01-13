using Amazon.DynamoDBv2.DataModel;
using Ecommerce.Lambda.Domain.Entities;

namespace EcommerceLambda.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IDynamoDBContext context;

        public ClienteRepository(IDynamoDBContext context)
        {
            this.context = context;
        }

        public async Task Adicionar(Cliente cliente)
        {
            await this.context.SaveAsync(cliente);
        }

        public async Task Atualizar(Cliente cliente)
        {
            await this.context.SaveAsync(cliente);
        }

        public async Task<Cliente> Buscar(string documento)
        {
            return await this.context.LoadAsync<Cliente>(documento);
        }

        public async Task Deletar(string documento)
        {
            await this.context.DeleteAsync<Cliente>(documento);
        }
    }
}
