using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Vouchers
    {
        public string CodigoVoucher { get; set; }
        public Clientes Cliente { get; set; }
        public Articulos Articulo { get; set; }
        public DateTime  FechaCanje { get; set; }
    }
}
