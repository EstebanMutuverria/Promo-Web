<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="tp_web_equipo_9A.Formulario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row justify-content-center mt-5">
        <div class="col-md-6">
            <h1 class="text-center">Ingrese sus datos</h1>

            <!-- Fila para DNI -->
            <div class="mb-3">
                <label for="txtDni" class="form-label">DNI</label>
                <asp:TextBox ID="txtDni" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtDni_TextChanged" placeholder="00000000" runat="server"></asp:TextBox>

                <asp:RequiredFieldValidator ID="rfvDni" runat="server"
                    ControlToValidate="txtDni"
                    ErrorMessage="El DNI es obligatorio."
                    CssClass="text-danger"
                    Display="Dynamic" />

                <asp:RegularExpressionValidator ID="revDni" runat="server"
                    ControlToValidate="txtDni"
                    ErrorMessage="El DNI debe contener exactamente 8 dígitos sin puntos ni caracteres especiales."
                    CssClass="text-danger"
                    Display="Dynamic"
                    ValidationExpression="^\d{8}$" />

            </div>

            <!-- Fila para Nombre, Apellido y Email -->
            <div class="row mb-3">
                <div class="col">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:TextBox ID="txtNombre" CssClass="form-control" placeholder="Ingrese su nombre" runat="server"></asp:TextBox>

                    <!-- Valida que haya algo en el campo -->
                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server"
                        ControlToValidate="txtNombre"
                        ErrorMessage="El Nombre es obligatorio."
                        CssClass="text-danger"
                        Display="Dynamic" />

                    <!-- Valida que lo que se ingrese sea correcto -->
                    <asp:RegularExpressionValidator ID="revNombre" runat="server"
                        ControlToValidate="txtNombre"
                        ErrorMessage="El Nombre solo debe contener letras."
                        ValidationExpression="^[a-zA-Z\s]+$"
                        CssClass="text-danger"
                        Display="Dynamic" />
                </div>
                <div class="col">
                    <label for="txtApellido" class="form-label">Apellido</label>
                    <asp:TextBox ID="txtApellido" CssClass="form-control" placeholder="Ingrese su apellido" runat="server"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="rfvApellido" runat="server"
                        ControlToValidate="txtApellido"
                        ErrorMessage="El Apellido es obligatorio."
                        CssClass="text-danger"
                        Display="Dynamic" />

                    <asp:RegularExpressionValidator ID="revApellido" runat="server"
                        ControlToValidate="txtApellido"
                        ErrorMessage="El Apellido solo debe contener letras."
                        ValidationExpression="^[a-zA-Z\s]+$"
                        CssClass="text-danger"
                        Display="Dynamic" />
                </div>
                <div class="col">
                    <label for="txtEmail" class="form-label">Email</label>
                    <asp:TextBox ID="txtEmail" CssClass="form-control" placeholder="email@email.com" type="email" runat="server"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server"
                        ControlToValidate="txtEmail"
                        ErrorMessage="El Email es obligatorio."
                        CssClass="text-danger"
                        Display="Dynamic" />

                    <asp:RegularExpressionValidator ID="revEmail" runat="server"
                        ControlToValidate="txtEmail"
                        ErrorMessage="El Email debe contener un '@'."
                        CssClass="text-danger"
                        ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"
                        Display="Dynamic" />
                </div>
            </div>

            <!-- Fila para Dirección, Ciudad y CP -->
            <div class="row mb-3">
                <div class="col">
                    <label for="txtDireccion" class="form-label">Dirección</label>
                    <asp:TextBox ID="txtDireccion" CssClass="form-control" placeholder="Calle 111" runat="server"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="rfvDireccion" runat="server"
                        ControlToValidate="txtDireccion"
                        ErrorMessage="La Dirección es obligatoria."
                        CssClass="text-danger"
                        Display="Dynamic" />

                    <asp:RegularExpressionValidator ID="revDireccion" runat="server"
                        ControlToValidate="txtDireccion"
                        ErrorMessage="La Dirección debe contener al menos un número."
                        CssClass="text-danger"
                        ValidationExpression=".*\d.*"
                        Display="Dynamic" />

                </div>
                <div class="col">
                    <label for="txtCiudad" class="form-label">Ciudad</label>
                    <asp:TextBox ID="txtCiudad" CssClass="form-control" placeholder="Ingrese su ciudad" runat="server"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="rfvCiudad" runat="server"
                        ControlToValidate="txtCiudad"
                        ErrorMessage="La Ciudad es obligatoria."
                        CssClass="text-danger"
                        Display="Dynamic" />
                </div>
                <div class="col">
                    <label for="txtCp" class="form-label">CP</label>
                    <asp:TextBox ID="txtCp" CssClass="form-control" placeholder="Codigo postal" runat="server"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="rfvCp" runat="server"
                        ControlToValidate="txtCp"
                        ErrorMessage="El Codigo postal es obligatorio."
                        CssClass="text-danger"
                        Display="Dynamic" />

                    <asp:RegularExpressionValidator ID="revCp" runat="server"
                        ControlToValidate="txtCp"
                        ErrorMessage="El Código Postal solo debe contener números."
                        CssClass="text-danger"
                        ValidationExpression="^\d+$"
                        Display="Dynamic" />
                </div>
            </div>

            <!-- Checkbox de Términos -->

            <asp:CheckBox ID="cboxTerminos" runat="server" />
            <label class="form-check-label" for="cboxTerminos">Acepto los términos y condiciones.</label>
            <asp:CustomValidator
                ID="cvTerminos"
                runat="server"
                ErrorMessage="Debe aceptar los términos y condiciones."
                OnServerValidate="cvTerminos_ServerValidate"
                CssClass="text-danger"
                Display="Dynamic"></asp:CustomValidator>


            <!-- Botón de Participar -->
            <div>

                <asp:Button ID="btnParticipar" CssClass="btn btn-primary btn-block" OnClick="btnParticipar_Click" runat="server" Text="Participar" />
                <asp:Label ID="lblError" runat="server" ForeColor="Red" />
                <asp:Label ID="lblExito" runat="server" ForeColor="Green" />
            </div>

        </div>
    </div>


</asp:Content>
