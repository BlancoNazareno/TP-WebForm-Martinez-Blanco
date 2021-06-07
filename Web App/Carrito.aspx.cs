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
    public partial class Formulario_web11 : System.Web.UI.Page
    {
        public List<Articulo> Carrito;
        protected void Page_Load(object sender, EventArgs e)
        {
            //int ID = int.Parse(Request.QueryString["ID"]);                     /*como se operará con IDs, se castea el string ID*/
            //List<Articulo> listado = (List<Articulo>)Session["Productos"];     /*listado tendrá la lista de artículos, alojada en Productos, del session*/
            //Articulo se                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   leccionado = listado.Find(x => x.ID == ID);             /*se toma el ID para buscar, y el artículo se guarda en seleccionado*/
            ////lblSelected.Text = ID;
            ////string algo = (string)session["producto"];
            //lblNombreProducto.Text = seleccionado.Nombre;                      /*se pone el nombre del producto en el label específico*/

            Carrito = (List<Articulo>)Session["listaCarrito"];                   /*el carrito trae la lista propia en session. Si no existe, la crea*/
            if (Carrito == null)
                Carrito = new List<Articulo>();

            if (!IsPostBack)                                 /*el Repetidor permite ser usado en el front en reemplazo del foreach, actualizando la información*/
            {
                if (Request.QueryString["ID"] != null)                                          /*valida que no esté vació, sino, pincha por buscar en una lista que devuelve null*/
                {
                    List<Articulo> listaProductos = (List<Articulo>)Session["Productos"];                     /*utiliza la lista inicial del session, en el load de Productos.aspx*/
                    Carrito.Add(listaProductos.Find(x => x.ID.ToString() == Request.QueryString["ID"]));      /*en la lista Carrito guarda busca y guarda el ID del producto de la lista del session*/
                }

                Repetidor.DataSource = Carrito;
                Repetidor.DataBind();
            }


            Session.Add("listaCarrito", Carrito);
            
        }

        protected void btnEliminar2_Click(object sender, EventArgs e)   /*utilizado por el repeater cuando se da click en "eliminar"*/
        {
            var argument = ((Button)sender).CommandArgument;

            List<Articulo> Carrito = (List<Articulo>)Session["listaCarrito"];    /*elimina el producto seleccionado, del session Carrito*/
            Articulo eliminado = Carrito.Find(x => x.ID.ToString() == argument);
            Carrito.Remove(eliminado);

            Session.Add("listaCarrito", Carrito);                    /*una vez eliminado el producto del session, este se actualiza con los productos restantes*/
            Repetidor.DataSource = null;
            Repetidor.DataSource = Carrito;
            Repetidor.DataBind();
        }
    }
}