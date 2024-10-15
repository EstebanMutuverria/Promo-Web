using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;

namespace Services
{
    public class ClienteServices
    {
        private DataBaseAccess DB = new DataBaseAccess();

        public void add(Cliente newCliente)
        {
            try
            {
                DB.clearParameters();
                DB.setQuery("Insert into Clientes (Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP) values (@Documento, @Nombre, @Apellido, @Email, @Direccion, @Ciudad, @CP)");


                DB.setParameter("@Documento", newCliente.Documento);
                DB.setParameter("@Nombre", newCliente.Nombre);
                DB.setParameter("@Apellido", newCliente.Apellido);
                DB.setParameter("@Email", newCliente.Email);
                DB.setParameter("@Direccion", newCliente.Direccion);
                DB.setParameter("@Ciudad", newCliente.Ciudad);
                DB.setParameter("@CP", newCliente.CP);

                DB.excecuteAction();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar Cliente. Comuníquese con el Soporte.", "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DB.CloseConnection();
            }
        }

        public void modify(Cliente cliente)
        {
            try
            {
                DB.clearParameters();
                DB.setQuery("Update Clientes set Id = @Id, Documento = @Documento, Nombre = @Nombre, Apellido = @Apellido, Email = @Email, Direccion = @Direccion, Ciudad = @Ciudad, CP = @CP Where Id = @Id");

                DB.setParameter("@Id", cliente.Id);
                DB.setParameter("@Documento", cliente.Documento);
                DB.setParameter("@Nombre", cliente.Nombre);
                DB.setParameter("@Apellido", cliente.Apellido);
                DB.setParameter("@Email", cliente.Email);
                DB.setParameter("@Direccion", cliente.Direccion);
                DB.setParameter("@Ciudad", cliente.Ciudad);
                DB.setParameter("@CP", cliente.CP);

                DB.excecuteAction();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar Cliente. Comuníquese con el Soporte.", "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DB.CloseConnection();
            }
        }

        public void delete(int Id)
        {
            try
            {
                DB.clearParameters();
                DB.setQuery("Delete from Clientes where Id = @Id");
                DB.setParameter("@Id", Id);
                DB.excecuteAction();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar Cliente. Comuníquese con el Soporte.", "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DB.CloseConnection();
            }
        }

        public bool repeatedCode(string Dni)
        {
            try
            {
                bool response = false;
                DB.setQuery("select Documento from Clientes where Documento = @Dni");
                DB.setParameter("@Dni", Dni);
                DB.excecuteQuery();
                if (DB.Reader.Read())
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
                DB.CloseConnection();
            }
        }
        public int ObtenerId(string dni)
        {
            try
            {
                DB.clearParameters();
                DB.setQuery("select Id from Clientes where Documento = @dni");
                DB.setParameter("@dni", dni);
                DB.excecuteQuery();

                if (DB.Reader.Read())
                {
                    return Convert.ToInt32(DB.Reader["Id"]);
                }
                else
                {
                    throw new Exception("cliente no encontrado");
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al obtener el ID del cliente: " + ex.Message);
            }
            finally
            {
                DB.CloseConnection();
                DB.clearParameters();
            }
        }
       
    }

    
}
