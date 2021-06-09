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
        public List<Articulo> listado = new List<Articulo>();
        public List<Articulo> listado2 = new List<Articulo>();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckList();
        }

        public void AgregarLista (Articulo art)
        {
            if ( Session[Session.SessionID + "List" ] != null) {

                listado2 = (List<Articulo>)Session[Session.SessionID + "List"];
                listado2.Add(art);
                Session[Session.SessionID + "List"] = listado2;
            }
            else {
                listado2.Add(art);
                Session[Session.SessionID + "List"] = listado2;
            }
        }


        public void CheckList ()
        {
            var ID = Convert.ToInt32(Request.QueryString["ID"]);
            if (ID!=0)
            {

                /*como se operará con IDs, se castea el string ID*/
                listado = (List<Articulo>)Session["Productos"];      /*listado tendrá la lista de artículos, alojada en Productos, del session*/
                Articulo seleccionado = listado.Find(x => x.ID == ID);             /*se toma el ID para buscar, y el artículo se guarda en seleccionado*/
                AgregarLista(seleccionado);                                                             /*se pone el nombre del producto en el label específico*/
            }
            else {
                
                if (Session[Session.SessionID + "List"] != null) {
                    listado2 = (List<Articulo>)Session[Session.SessionID + "List"];
                }
            }
        }


        /*No hace falta un check, porque si puede ingresar a Eliminar, es porque ya se creo primaramente la lista. */
        public void EliminarItem(Articulo art)
        {
            listado2 = (List<Articulo>)Session[Session.SessionID + "List"];  
            listado2.Remove(art);
            Session[Session.SessionID + "List"] = listado2;
        }


    }
}