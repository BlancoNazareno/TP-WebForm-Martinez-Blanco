using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
namespace Dominio2
{
    public class Articulo
    {
        public int ID { get; set; }
        public string  Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public string ImgURL { get; set; }
        public SqlMoney Precio { get; set; }
        //public string Precio { get; set; }

    }
}
