<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ErrorVoucher.aspx.cs" Inherits="tp_web_equipo_9A.ErrorVoucher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container mt-4">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card text-center">
                    <div class="card-body">
                        <h5 class="card-title text-danger">Error en el código de voucher</h5>
                        <p class="card-text">El código de voucher ingresado es incorrecto o ya ha sido utilizado.</p>
                        <asp:Button ID="btnInicio" runat="server" CssClass="btn btn-primary w-100" Text="Volver al inicio" OnClick="btnInicio_Click" style="background-color: #28a745;"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
