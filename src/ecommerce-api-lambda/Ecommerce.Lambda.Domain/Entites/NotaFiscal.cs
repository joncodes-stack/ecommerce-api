using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Lambda.Domain.Entites
{
    public class NotaFiscal
    {
        public string DocumentoCliente { get; set; }
        public string IdNotaFiscal { get; set; }
        public decimal BaseCalculo { get; set; }
        public decimal AliquotaTributo { get; set; }
        public string Descricao { get; set; }
        public decimal ValorTributo
        {
            get
            {
                return BaseCalculo * AliquotaTributo / 100;
            }
            private set
            {
                ValorTributo = value;
            }
        }
    }
}
