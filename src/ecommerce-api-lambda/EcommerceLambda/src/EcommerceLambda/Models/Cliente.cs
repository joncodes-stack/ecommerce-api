using Amazon.DynamoDBv2.DataModel;

namespace EcommerceLambda.Models
{
    public class Cliente
    {
        public string? Documento { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public Endereco? Endereco { get; set; }
    }
}
