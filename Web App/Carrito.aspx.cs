using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio2;

namespace Web_App
{
    public partial class Formulario_web11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int ID = int.Parse(Request.QueryString["ID"]);                     /*como se operará con IDs, se castea el string ID*/
            List<Articulo> listado = (List<Articulo>)Session["Productos"];     /*listado tendrá la lista de artículos, alojada en Productos, del session*/
            Articulo seleccionado = listado.Find(x => x.ID == ID);             /*se toma el ID para buscar, y el artículo se guarda en seleccionado*/
            //lblSelected.Text = ID;
            //string algo = (string)session["producto"];
            lblNombreProducto.Text = seleccionado.Nombre;                      /*se pone el nombre del producto en el label específico*/
        }
    }
}