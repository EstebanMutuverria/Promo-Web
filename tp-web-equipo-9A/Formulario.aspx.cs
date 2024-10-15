using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utils;

namespace tp_web_equipo_9A
{
    public partial class Formulario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnParticipar_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                ClienteServices clienteServices = new ClienteServices();
                VoucherServices voucherServices = new VoucherServices();
                try
                {
                    Cliente cliente = new Cliente();
                    Voucher voucher = new Voucher();
                    Articulo articulo = new Articulo();

           
                    cliente.Documento = txtDni.Text;
                    cliente.Nombre = txtNombre.Text;
                    cliente.Apellido = txtApellido.Text;
                    cliente.Email = txtEmail.Text;
                    cliente.Direccion = txtDireccion.Text;
                    cliente.Ciudad = txtCiudad.Text;
                    cliente.CP = int.Parse(txtCp.Text);


                    if (!clienteServices.repeatedCode(cliente.Documento))
                    {
                        clienteServices.add(cliente);
                    }

                    int idCliente = clienteServices.ObtenerId(cliente.Documento);
                    if (idCliente <= 0)
                    {
                        throw new Exception("ID de cliente no válido.");
                    }
                    else
                    {
                        string CodVoucher = Session["CodVoucherSs"] != null ? Session["CodVoucherSs"].ToString() : "";
                        int idArticulo = Session["IdArticuloSs"] != null ? Convert.ToInt32(Session["IdArticuloSs"]) : 0;

                        voucher.IdCliente = idCliente;
                        voucher.FechaCanje = DateTime.Now;
                        voucher.CodigoVoucher = CodVoucher;
                        voucher.IdArticulo = idArticulo;
                        voucherServices.modify(voucher);
                        lblExito.Text = "Registro agregado correctamente";
                        lblError.Visible = false;
                        Response.Redirect("~/FormExito.aspx");
                    }


                }
                catch (Exception ex)
                {
                    lblExito.Visible = false;
                    lblError.Text = "Ocurrio un error" + ex;

                }
            }
        }

        protected void txtDni_TextChanged(object sender, EventArgs e)
        {
            DataBaseAccess dbAccess = new DataBaseAccess();
            string dni = txtDni.Text;

            try
            {

                dbAccess.setQuery("SELECT Nombre, Apellido, Email, Direccion, Ciudad, CP FROM Clientes WHERE Documento = @dni");


                dbAccess.setParameter("@dni", dni);

                dbAccess.excecuteQuery();

                if (dbAccess.Reader.Read())
                {

                    txtNombre.Text = dbAccess.Reader["Nombre"].ToString();
                    txtApellido.Text = dbAccess.Reader["Apellido"].ToString();
                    txtEmail.Text = dbAccess.Reader["Email"].ToString();
                    txtDireccion.Text = dbAccess.Reader["Direccion"].ToString();
                    txtCiudad.Text = dbAccess.Reader["Ciudad"].ToString();
                    txtCp.Text = dbAccess.Reader["CP"].ToString();


                    btnParticipar.Text = "Participar";
                    lblExito.Visible = true;
                    lblExito.Text = "Datos precargados correctamente.";

                }
                else
                {

                    txtNombre.Text = "";
                    txtApellido.Text = "";
                    txtEmail.Text = "";
                    txtDireccion.Text = "";
                    txtCiudad.Text = "";
                    txtCp.Text = "";

                    lblExito.Visible = false;
                    btnParticipar.Text = "Registrar y participar";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Ocurrió un error: " + ex.Message;
            }
            finally
            {
                dbAccess.CloseConnection();
                dbAccess.clearParameters();
            }
        }

        protected void cvTerminos_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = cboxTerminos.Checked;
        }
    }
}