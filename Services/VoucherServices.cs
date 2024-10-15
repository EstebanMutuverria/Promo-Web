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
    public class VoucherServices
    {
        private DataBaseAccess DB = new DataBaseAccess();

        public void add(Voucher newVoucher)
        {
            try
            {
                DB.clearParameters();
                DB.setQuery("Insert into Vouchers (CodigoVoucher, IdCliente, FechaCanje, IdArticulo) values (@CodigoVoucher, @IdCliente, @FechaCanje, @IdArticulo)");

                DB.setParameter("@CodigoVoucher", newVoucher.CodigoVoucher);
                DB.setParameter("@IdCliente", newVoucher.IdCliente);
                DB.setParameter("@FechaCanje", newVoucher.FechaCanje);
                DB.setParameter("@IdArticulo", newVoucher.IdArticulo);


                DB.excecuteAction();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar Voucher. Comuníquese con el Soporte.", "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DB.CloseConnection();
            }
        }

        public void modify(Voucher voucher)
        {
            try
            {
                DB.clearParameters();
                DB.setQuery("UPDATE Vouchers set  IdCliente = @IdCli, FechaCanje = @FechaCan, IdArticulo = @IdArt where CodigoVoucher = @CodVoucher");

                DB.setParameter("@CodVoucher", voucher.CodigoVoucher);
                DB.setParameter("@IdCli", voucher.IdCliente);
                DB.setParameter("@FechaCan", voucher.FechaCanje);
                DB.setParameter("@IdArt", voucher.IdArticulo);


                DB.excecuteAction();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Error al modificar Voucher. Comuníquese con el Soporte.", "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DB.CloseConnection();
            }
        }

        public void delete(string CodigoVoucher)
        {
            try
            {
                DB.clearParameters();
                DB.setQuery("Delete from Vouchers where CodigoVoucher = @CodigoVoucher");
                DB.setParameter("@CodigoVoucher", CodigoVoucher);
                DB.excecuteAction();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar Voucher. Comuníquese con el Soporte.", "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DB.CloseConnection();
            }
        }

        public bool usedVoucherCode(string codVoucher)
        {
            try
            {
                bool response = true;
                DB.clearParameters();
                DB.setQuery("Select IdCliente from Vouchers where CodigoVoucher = @codVoucher");
                DB.setParameter("@codVoucher", codVoucher);
                DB.excecuteQuery();

                while (DB.Reader.Read())
                {
                    if (DB.Reader.IsDBNull(DB.Reader.GetOrdinal("IdCliente")))
                    {
                        response = false;
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar Voucher. Comuníquese con el Soporte.", "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            finally
            {
                DB.CloseConnection();
            }
        }
    }
}
