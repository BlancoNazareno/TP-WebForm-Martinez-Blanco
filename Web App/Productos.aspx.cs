using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio2;
using Negocio2;


namespace Web_App
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {

        public List<Articulo> Lista; /*necesita el public antes*/
        protected void Page_Load(object sender, EventArgs e)
        {

            ArticuloNegocio Productos = new ArticuloNegocio();
            
            
            try
            {
                Lista = Productos.Listar();

                Session.Add("Productos", Lista); /*la Lista de Listar, se guarda en el session con el nombre Productos*/
            }
            catch (Exception ex)
            {

                Session.Add("Error",ex.ToString());  /*el error ex se guarda en session, con el nombre Error*/
                Response.Redirect("Error.aspx");
            }
        }
    }
}