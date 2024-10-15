using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Models;
using Utils;

namespace Services
{
    public class CategoriaServices
    {
        private DataBaseAccess dato = new DataBaseAccess();
        public List<Categoria> listar()
        {
            List<Categoria> lista = new List<Categoria>();

            try
            {
                dato.setQuery("SELECT Id, Descripcion from CATEGORIAS");
                dato.excecuteQuery();
                while (dato.Reader.Read())
                {
                    Categoria auxiliar = new Categoria();
                    auxiliar.Id = dato.Reader.GetInt32(0);
                    auxiliar.Descripcion = (string)dato.Reader["Descripcion"];

                    lista.Add(auxiliar);
                }


                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                dato.CloseConnection();
            }
        }

        public void add(Categoria NewCategoria)
        {
            try
            {
                dato.clearParameters();
                dato.setQuery("INSERT into CATEGORIAS (Descripcion) values(@Descripcion)");
                dato.setParameter("@Descripcion", NewCategoria.Descripcion);

                dato.excecuteAction();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar Categoría. Comuníquese con el Soporte.", "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dato.CloseConnection();
            }
        }

        public void modify(Categoria categoria)
        {
            try
            {
                dato.clearParameters();
                dato.setQuery("UPDATE CATEGORIAS set Descripcion = @Descripcion where id = @Id");
                dato.setParameter("@Descripcion", categoria.Descripcion);
                dato.setParameter("@Id", categoria.Id);

                dato.excecuteAction();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al modificar Categoría. Comuníquese con el Soporte.", "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dato.CloseConnection();
            }
        }

        public void delete(int Id)
        {
            try
            {
              dato.clearParameters();
              dato.setQuery("DELETE from CATEGORIAS where id = @Id");
              dato.setParameter("@Id",Id);

              dato.excecuteAction();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar Categoría. Comuníquese con el Soporte.", "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dato.CloseConnection();
            }
        }

        public bool ExistsName(string descripcion)
        {
            try
            {
                dato.setQuery("SELECT COUNT(*) FROM CATEGORIAS WHERE Descripcion = @Descripcion");
                dato.setParameter("@Descripcion", descripcion);
                dato.excecuteQuery();

                if (dato.Reader.Read())
                {
                    int count = dato.Reader.GetInt32(0);
                    return count > 0;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dato.CloseConnection();
            }
        }

        public bool repeatedDescripcion(string descripcion)
        {
            try
            {
                bool response = false;
                dato.setQuery("Select Descripcion from CATEGORIAS where Descripcion = @Descripcion");
                dato.setParameter("@Descripcion", descripcion);
                dato.excecuteQuery();

                if (dato.Reader.Read())
                {
                    response = true;
                }

                return response;
            }
            catch (Exception ex)
            {
                return true;
            }
            finally
            {
                dato.CloseConnection();
            }
        }

        public IEnumerable<ValidationResult> ValidateTypes(Categoria categoria)
        {
            var resultados = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(categoria.Descripcion))
            {
                resultados.Add(new ValidationResult("Se debe especificar una Descripción", new[] { nameof(categoria.Descripcion) }));
            }

            if (!categoria.Descripcion.All(char.IsLetter))
            {
                resultados.Add(new ValidationResult("Ingrese solo letras en la Descripción.", new[] { nameof(categoria.Descripcion) }));
            }

            return resultados;
        }
    }
}
