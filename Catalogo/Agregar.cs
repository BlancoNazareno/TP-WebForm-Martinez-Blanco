using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace Catalogo
{
    public partial class Agregar : Form
    {

        private Articulo articulo = null;

        public Agregar()
        {
            InitializeComponent();
        }

        public Agregar(Articulo artic)
        {
            InitializeComponent();
            articulo = artic;
        }


        private void btnAceptarAgregar_Click_1(object sender, EventArgs e)
        {
            try
            {
                //Articulo nuevo = new Articulo();
                ArticuloNegocio negocio = new ArticuloNegocio();

                if (articulo == null)

                    articulo = new Articulo();  //  si está vacio (porque no existe) lo crea. Sino, lo "recarga"

                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Marca = (Marca)cboMarca.SelectedItem;
                articulo.Categoria = (Categoria)cboCategoria.SelectedItem;
                articulo.Precio = Convert.ToDecimal(txtPrecio.Text);
                articulo.ImgURL = txtImagenUrl.Text;

                if (articulo.ID == 0)
                {
                    negocio.agregar(articulo);
                }
                else
                {
                    negocio.modificar(articulo);
                }

                MessageBox.Show("Operación realizada exitosamente", "Éxito");
                Close();
            }

            catch (Exception ex)
            {
                throw;
            }


        }

        private void Agregar_Load(object sender, EventArgs e)
        {
            
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            cboMarca.DataSource = articuloNegocio.listarMarca();
            cboMarca.ValueMember = "ID";
            cboMarca.DisplayMember = "Descripcion";
            

            //CategoriaNegocio negocio = new CategoriaNegocio();
            cboCategoria.DataSource = articuloNegocio.listarCategorias();
            cboCategoria.ValueMember = "ID";
            cboCategoria.DisplayMember = "Descripcion";



            if (articulo != null)
            {
                txtCodigo.Text = articulo.Codigo;
                txtNombre.Text = articulo.Nombre;
                txtDescripcion.Text = articulo.Descripcion;
                cboMarca.SelectedValue = articulo.Marca.ID;
                cboCategoria.SelectedValue = articulo.Categoria.ID;
                Text = "Modificar artículo";
                txtPrecio.Text =Convert.ToString(articulo.Precio);
                txtImagenUrl.Text = articulo.ImgURL;
            }
            /*else { 
                cboCategoria.SelectedIndex = -1;
                cboMarca.SelectedIndex = -1;
            }*/

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

    }

}

