using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_App
{
    public partial class Formulario_web13 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = Session["Error"] == null ? "No hay error" : (string)Session["Error"];   /*uso de operador ternario para validar el null, y, en todo caso
                                                                                                     usar el ex contenido en la variable Error del session*/ 
        }
    }
}