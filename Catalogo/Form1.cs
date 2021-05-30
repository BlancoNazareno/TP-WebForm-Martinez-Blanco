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
    public partial class Form1 : Form
    {
        private List<Articulo> listaOriginal;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void cargar()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaOriginal = negocio.listar();
            dgvLista.DataSource = listaOriginal;
            dgvLista.Columns[0].Visible = false;
            //dgvLista.Columns[4].Visible = false;
            //dgvLista.Columns[5].Visible = false;
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
                Agregar alta = new Agregar();
                alta.ShowDialog();
                cargar();
        }

        private void dgvLista_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Articulo articulo = (Articulo)dgvLista.CurrentRow.DataBoundItem;
                pbArticulo.Load(articulo.ImgURL);
            }
            catch (Exception)
            {

            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo artic;
            artic = (Articulo)dgvLista.CurrentRow.DataBoundItem;

            
            Agregar modificar = new Agregar(artic);     // el nuevo constructor pasa los datos del actual elemento 
            modificar.Text = "Modificar";
            modificar.ShowDialog();
            cargar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            negocio.eliminar(((Articulo)dgvLista.CurrentRow.DataBoundItem).ID);
            cargar();
        }


        private void btnVerDetalle_Click_1(object sender, EventArgs e)
        {
            Articulo artic1 = new Articulo();
            MessageBox.Show(((Articulo)dgvLista.CurrentRow.DataBoundItem).Descripcion);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            List<Articulo> lista = (List<Articulo>)dgvLista.DataSource;
            List<Articulo> listaFiltrada = listaOriginal.FindAll(x => x.Codigo.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dgvLista.DataSource = listaFiltrada;


        }
    }

}
