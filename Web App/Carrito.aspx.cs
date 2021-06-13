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
        //public List<Articulo> listado = new List<Articulo>();
        //public List<Articulo> listado2 = new List<Articulo>();
        public List<Articulo> ListaCarrito;
        public Articulo articuloBuscado;
        int idAux;
        int productoRepetido;
        Carrito carritoAux;

        protected void Page_Load(object sender, EventArgs e)
        {
            //CheckList();
            ArticuloNegocio negocioAux = new ArticuloNegocio();
            carritoAux = new Carrito();
            List<Articulo> listaAux;
            productoRepetido = Convert.ToInt32(Request.QueryString["productoRepetido"]);
            idAux = Convert.ToInt32(Request.QueryString["ID"]);
            listaAux = negocioAux.Listar();
            articuloBuscado = listaAux.Find(x => x.ID == idAux);
            if (idAux != 0 && productoRepetido == 1)
                try
                {
                    ListaCarrito = ((List<Articulo>)Session["ListaCarrito"]);
                    foreach (Articulo Item in ListaCarrito)
                    {
                        if (Item.ID == idAux)
                        {
                            ListaCarrito.Remove(Item);
                            Session.Add("ListaCarrito", ListaCarrito);
                            Response.Redirect("Carrito.aspx");
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }


            else if (idAux == 0)                /*  -> para cuando ingresa al carrito sin añadir productos, sólo para ver los productos cargados*/
            {
                if (Session["ListaCarrito"] == null)               /* -> si no hay instancia de la lista*/
                {
                    ListaCarrito = new List<Articulo>();
                    Session["ListaCarrito"] = ListaCarrito;

                }
                else
                {
                    ListaCarrito = (List<Articulo>)Session["ListaCarrito"];
                    foreach (Articulo item in ListaCarrito)
                    {
                        carritoAux.ImporteFinal += item.Precio;
                        carritoAux.CantidadFinal++;
                        Session.Add("ImporteFinal", carritoAux.ImporteFinal);
                        if (Session[Session.SessionID + "ImporteFinal"] != null)
                        {
                            carritoAux.ImporteFinal = (int)Session[Session.SessionID + "ImporteFinal"];//
                        }
                    }
                    lblCantidadFinal.Text += (carritoAux.CantidadFinal);
                    lblImporteFinal.Text += (carritoAux.ImporteFinal);
                }


            }


            else                                                       /*-> para agregar productos al carrito*/

            {
                try
                {
                    if (Session["ListaCarrito"] == null)        /*-> si se trata del primer producto*/
                    {
                        ListaCarrito = new List<Articulo>();
                        ListaCarrito.Add(articuloBuscado);
                        Session["ListaCarrito"] = ListaCarrito;
                    }

                    else                                                      /*-> si el carrito ya tiene productos*/
                    {
                        ListaCarrito = (List<Articulo>)Session["ListaCarrito"];
                        ListaCarrito.Add(articuloBuscado);
                        Session["ListaCarrito"] = ListaCarrito;
                    }
                }

                catch(Exception)
                {
                    Response.Redirect("Error.aspx");
                }

                foreach(Articulo item in ListaCarrito)
                {
                    carritoAux.ImporteFinal += item.Precio;
                    carritoAux.CantidadFinal++;
                    Session.Add("ImporteFinal",carritoAux.ImporteFinal);
                    if(Session[Session.SessionID + "ImporteFinal"] != null)
                    {
                        carritoAux.ImporteFinal = (int)Session[Session.SessionID + "ImporteFinal"];
                    }
                    
                }
                lblCantidadFinal.Text += (carritoAux.CantidadFinal);
                lblImporteFinal.Text += (carritoAux.ImporteFinal);
            }
        }


        //public void AgregarLista (Articulo art)
        //{
        //    if ( Session[Session.SessionID + "List" ] != null) {

        //        listado2 = (List<Articulo>)Session[Session.SessionID + "List"];
        //        listado2.Add(art);
        //        Session[Session.SessionID + "List"] = listado2;
        //    }
        //    else {
        //        listado2.Add(art);
        //        Session[Session.SessionID + "List"] = listado2;
        //    }
        //}


        //public void CheckList ()
        //{
        //    var ID = Convert.ToInt32(Request.QueryString["ID"]);
        //    if (ID!=0)
        //    {

        //        /*como se operará con IDs, se castea el string ID*/
        //        listado = (List<Articulo>)Session["Productos"];      /*listado tendrá la lista de artículos, alojada en Productos, del session*/
        //        Articulo seleccionado = listado.Find(x => x.ID == ID);             /*se toma el ID para buscar, y el artículo se guarda en seleccionado*/
        //        AgregarLista(seleccionado);                                                             /*se pone el nombre del producto en el label específico*/
        //    }
        //    else {
                
        //        if (Session[Session.SessionID + "List"] != null) {
        //            listado2 = (List<Articulo>)Session[Session.SessionID + "List"];
        //        }
        //    }
        //}


        ///*No hace falta un check, porque si puede ingresar a Eliminar, es porque ya se creo primaramente la lista. */
        //public void EliminarItem(Articulo art)
        //{
        //    listado2 = (List<Articulo>)Session[Session.SessionID + "List"];  
        //    listado2.Remove(art);
        //    Session[Session.SessionID + "List"] = listado2;

        //}


    }
}