using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;

namespace Dominio2
{
    public class Carrito
    {
        public SqlMoney ImporteFinal { get; set; }
        public int CantidadFinal { get; set; }

        public Carrito()
        {
            ImporteFinal = 0;
            CantidadFinal = 0;
        }
    }
}
    