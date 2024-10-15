<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="FormExito.aspx.cs" Inherits="tp_web_equipo_9A.FormExito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
        .container {
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
            height: 100vh; 
            text-align: center; 
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1 class="display-4">¡Estás participando!</h1>
        <h2 class="mb-4">Registro agregado con éxito</h2>
        <h3>Presiona el botón para volver al inicio</h3>
        <asp:Button ID="btnRedirect" CssClass="btn btn-primary btn-lg mt-4" runat="server" Text="Inicio" OnClick="btnRedirect_Click" />
    </div>
</asp:Content>
