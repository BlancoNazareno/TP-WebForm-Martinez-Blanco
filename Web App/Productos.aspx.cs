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
        
       
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio Productos = new ArticuloNegocio();
            
            try
            {
                if (Productos != null)
                {
                    
                    dgvProductos.DataSource = Productos.listar();
                    dgvProductos.DataBind();
                }
            }
            catch (Exception ex)
            {

                Response.Redirect("Error.aspx");
            }
        }
    }
}