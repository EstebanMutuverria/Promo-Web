using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;

namespace Services
{
    public class MarcaServices
    {
        private DataBaseAccess dato = new DataBaseAccess();
        public List<Marca> listar()
        {
            List<Marca> lista = new List<Marca>();

            try
            {
                dato.setQuery("SELECT Id, Descripcion from MARCAS");
                dato.excecuteQuery();
                while (dato.Reader.Read())
                {
                    Marca auxiliar = new Marca();
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
          public void add(Marca newMarca)
          {
              try
              {
                  dato.clearParameters();
                  dato.setQuery("INSERT into MARCAS (Descripcion) values(@Descripcion)");
                  dato.setParameter("@Descripcion", newMarca.Descripcion);
                  dato.excecuteAction();
              }
              catch (Exception ex)
              {
                MessageBox.Show("Error al agregar Marca. Comuníquese con el Soporte.", "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
              }
              finally
              {
                  dato.CloseConnection();
              }
          }

          public void modify(Marca marca)
          {
              try
              {
                  dato.clearParameters();
                  dato.setQuery("UPDATE MARCAS set Descripcion = @Descripcion where id = @Id");
                  dato.setParameter("@Descripcion", marca.Descripcion);
                  dato.setParameter("@Id", marca.Id);

                  dato.excecuteAction();
              }
              catch (Exception ex)
              {

                MessageBox.Show("Error al modificar Marca. Comuníquese con el Soporte.", "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                  dato.setQuery("DELETE from MARCAS where id = @Id");
                  dato.setParameter("@Id", Id);

                  dato.excecuteAction();
              }
              catch (Exception ex)
              {

                MessageBox.Show("Error al eliminar Marca. Comuníquese con el Soporte.", "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                dato.setQuery("Select Descripcion from MARCAS where Descripcion = @Descripcion");
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

        public IEnumerable<ValidationResult> ValidateTypes(Marca marca)
        {
            var resultados = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(marca.Descripcion))
            {
                resultados.Add(new ValidationResult("Se debe especificar una Descripción", new[] { nameof(marca.Descripcion) }));
            }

            if (!marca.Descripcion.All(char.IsLetter))
            {
                resultados.Add(new ValidationResult("Ingrese solo letras en la Descripción.", new[] { nameof(marca.Descripcion) }));
            }

            return resultados;
        }

    }
}

