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
            if (Session[Session.SessionID + "List"] == null)
            {
                listado2.Add(art);
                Session[Session.SessionID + "List"] = listado2;
            }
        }

        public bool CheckRepetido(List<Articulo> ListaCheckRepetido, int x)
        {
            foreach (Articulo item in ListaCheckRepetido)
            {
                if (item.ID == x)
                {
                    return true;
                }
            }

            return false;
        }

        public void CheckList()
        {
            bool primero = true;
            var ID = Convert.ToInt32(Request.QueryString["ID"]);
            if (ID != 0)
            {

                /*como se operará con IDs, se castea el string ID*/
                listado = (List<Articulo>)Session["Productos"];      /*listado tendrá la lista de artículos, alojada en Productos, del session*/
                listado2 = (List<Articulo>)Session[Session.SessionID + "List"];


                if ((listado2 == null) && (primero == true))
                {
                    Articulo seleccionado = listado.Find(x => x.ID == ID);             /*se toma el ID para buscar, y el artículo se guarda en seleccionado*/
                    AgregarLista(seleccionado);
                    primero = false;
                }

                if ((listado2 !=null)  && (primero==false) && ((!(CheckRepetido(listado2, ID)))))
                {
                    Articulo seleccionado = listado.Find(x => x.ID == ID);             /*se toma el ID para buscar, y el artículo se guarda en seleccionado*/
                    AgregarLista(seleccionado);
                }

               
                //if (listado2 != null)
                //{
                //    if (!(CheckRepetido(listado2, ID)) /*&& primero*/)                  /*  -> revisa que el ID del artículo no exista ya en la lista, si existe, lo ignora y lo no suma nuevamente*/
                //    {
                //        Articulo seleccionado = listado.Find(x => x.ID == ID);             /*se toma el ID para buscar, y el artículo se guarda en seleccionado*/
                //        AgregarLista(seleccionado);                                                             /*se pone el nombre del producto en el label específico*/
                //        //primero = false;
                //    }
                //}

            }
            else
            {

                if (Session[Session.SessionID + "List"] != null)
                {
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