<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="tp_web_equipo_9A.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title text-center">Ingresa tu código de voucher</h5>
                        <asp:TextBox ID="txtVoucherCode" CssClass="form-control" runat="server" Placeholder="Ejemplo: Codigo00" />
                        <asp:RequiredFieldValidator ID="rfvVoucherCode" runat="server" ControlToValidate="txtVoucherCode" ErrorMessage="El código de voucher es requerido" CssClass="text-danger" Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="revVoucherCode" runat="server" ControlToValidate="txtVoucherCode" ErrorMessage="El código de voucher solo puede contener caracteres alfanuméricos." ValidationExpression="^[a-zA-Z0-9]*$" CssClass="text-danger" Display="Dynamic" />
                        <asp:Button ID="btnValidarVoucher" runat="server" CssClass="btn btn-primary w-100 mt-3" Text="Validar Voucher" OnClick="btnValidarVoucher_Click" Style="background-color: #28a745;" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
