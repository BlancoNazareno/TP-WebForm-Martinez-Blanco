using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio2;
using System.Data.SqlClient;
using System.Data.SqlTypes;
        

namespace Negocio2
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {

            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            List<Articulo> lista = new List<Articulo>();

            conexion.ConnectionString = "data source=.\\sqlexpress; initial catalog=CATALOGO_DB; integrated security=sspi";
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select A.ID, A.Codigo Codigo, A.Nombre, A.Descripcion, A.ImagenUrl, Precio, C.Descripcion Categoria, C.Id IdCategoria, M.Id IdMarca, M.Descripcion Marca From ARTICULOS A join CATEGORIAS C on A.IdCategoria = C.Id join MARCAS M on A.IdMarca = M.Id";
            //comando.CommandText = "Select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.ImagenUrl, A.Precio, M.Descripcion Marca, C.Descripcion Categoria From ARTICULOS A join CATEGORIAS C on A.IdCategoria = C.Id join MARCAS M on A.IdMarca = M.Id";
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            while (lector.Read())
            {
                Articulo aux = new Articulo();

                
                aux.ID = (int)lector["Id"];
                aux.Codigo = (string)lector["Codigo"];
               
                aux.Nombre = (string)lector["Nombre"];
                
                aux.Descripcion = (string)lector["Descripcion"];
              
                aux.ImgURL = (string)lector["ImagenUrl"];
                
                aux.Precio = lector.GetSqlMoney(5);
               


                aux.Categoria = new Categoria();
                aux.Categoria.Descripcion = (string)lector["Categoria"];
                aux.Categoria.ID = (int)lector["IdCategoria"];

                aux.Marca = new Marca();
                aux.Marca.Descripcion = (string)lector["Marca"];
                aux.Marca.ID = (int)lector["IdMarca"];

                lista.Add(aux);
            }

            conexion.Close();

            return lista;


            }

            catch (Exception ex)
            {
                throw;
            }

            finally
            {
                conexion.Close();
            }
        }
        public void agregar(Articulo nuevo)
        {


            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            List<Articulo> lista = new List<Articulo>();

            try
            {
                conexion.ConnectionString = "data source=. \\ sqlexpress; initial catalog= CATALOGO_DB ; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Insert into ARTICULOS (Codigo, Nombre, Descripcion, Precio, ImagenUrl, IdCategoria, IdMarca) Values (@Codigo, @Nombre, @Descripcion, @Precio, @ImagenUrl, @IdCategoria, @IdMarca)";
                comando.Parameters.AddWithValue("@Codigo", nuevo.Codigo);
                comando.Parameters.AddWithValue("@Nombre", nuevo.Nombre);
                comando.Parameters.AddWithValue("@Descripcion", nuevo.Descripcion);
                comando.Parameters.AddWithValue("@Precio", nuevo.Precio);
                comando.Parameters.AddWithValue("@ImagenUrl", nuevo.ImgURL);
                comando.Parameters.AddWithValue("@IdCategoria", nuevo.Categoria.ID);
                comando.Parameters.AddWithValue("@IdMarca", nuevo.Marca.ID);
                comando.Connection = conexion;


                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }



        public List<Categoria> listarCategorias()
        {
            List<Categoria> categoria = new List<Categoria>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            conexion.ConnectionString = "data source=.\\sqlexpress; initial catalog=CATALOGO_DB; integrated security=sspi";
            comando.CommandType = System.Data.CommandType.Text;
            
            comando.CommandText = "SELECT * FROM CATEGORIAS";
            comando.Connection = conexion;
            try
            {
                conexion.Open();


                
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Categoria CA = new Categoria();
                    //aux.ID = (int)lector["Id"];
                    CA.Descripcion = (string)lector["Descripcion"];
                    CA.ID = (int)lector["Id"];
                    
                    categoria.Add(CA);
                }
             }
            catch (Exception ex)
            {

                throw;
            }


            return categoria;
        }

        public List<Marca> listarMarca()
        {
            List<Marca> marca = new List<Marca>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            conexion.ConnectionString = "data source=.\\sqlexpress; initial catalog=CATALOGO_DB; integrated security=sspi";
            comando.CommandType = System.Data.CommandType.Text;

            comando.CommandText = "SELECT * FROM MARCAS";
            comando.Connection = conexion;
            try
            {
                conexion.Open();



                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Marca CA = new Marca();
                    //aux.ID = (int)lector["Id"];
                    CA.Descripcion = (string)lector["Descripcion"];
                    CA.ID = (int)lector["Id"];

                    marca.Add(CA);

                }

                return marca;
            }

            catch (Exception)
            {
                throw;
            }

            

            finally
            {
                conexion.Close();
            }
        }
        public void modificar(Articulo artic)
        {

            try
            {
                SqlConnection conexion = new SqlConnection();
                SqlCommand comando = new SqlCommand();
                List<Articulo> lista = new List<Articulo>();

                conexion.ConnectionString = "data source=.\\sqlexpress; initial catalog=CATALOGO_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Update ARTICULOS set Codigo=@Codigo, Nombre=@Nombre, Descripcion=@Descripcion, Precio=@Precio, ImagenUrl=@ImagenUrl, IdCategoria=@IdCategoria, IdMarca=@IdMarca where Id=@Id";

                comando.Parameters.AddWithValue("@Id", artic.ID);
                comando.Parameters.AddWithValue("@Codigo", artic.Codigo);
                comando.Parameters.AddWithValue("@Nombre", artic.Nombre);
                comando.Parameters.AddWithValue("@Descripcion", artic.Descripcion);
                comando.Parameters.AddWithValue("@Precio", artic.Precio);
                comando.Parameters.AddWithValue("@ImagenUrl", artic.ImgURL);
                comando.Parameters.AddWithValue("@IdCategoria", artic.Categoria.ID);
                comando.Parameters.AddWithValue("@IdMarca", artic.Marca.ID);
                comando.Connection = conexion;

                conexion.Open();
                comando.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                throw;
            }
            
        }

        public void eliminar(int id)
        {
            try
            {
                SqlConnection conexion = new SqlConnection();
                SqlCommand comando = new SqlCommand();

                conexion.ConnectionString = "data source=.\\sqlexpress; initial catalog=CATALOGO_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Delete From ARTICULOS Where Id=@Id";

                comando.Parameters.AddWithValue("@Id", id);
                comando.Connection = conexion;

                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ;
            }

        }
    }



}
