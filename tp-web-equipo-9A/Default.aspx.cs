using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_web_equipo_9A
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnValidarVoucher_Click(object sender, EventArgs e)
        {
            VoucherServices service = new VoucherServices();

            try
            {
                string voucherCode = HttpUtility.HtmlEncode(txtVoucherCode.Text);
                if (service.usedVoucherCode(voucherCode))
                {
                    Response.Redirect("~/ErrorVoucher.aspx");
                }
                else
                {
                    Session.Add("CodVoucherSs", txtVoucherCode.Text);
                    Response.Redirect("~/Premio.aspx");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }   
    }
}