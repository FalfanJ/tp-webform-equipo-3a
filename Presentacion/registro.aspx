<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registro.aspx.cs"
    Inherits="Presentacion.registro" 
    MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Registro de Cliente</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="mb-4">Ingresá tus datos</h2>

    <asp:Label ID="lblError" runat="server"></asp:Label>

    <div class="mb-3">
        <label for="txtDni" class="form-label">DNI</label>
        <asp:TextBox ID="txtDni" runat="server" CssClass="form-control"></asp:TextBox>
        <div class="invalid-feedback">Ingrese un DNI válido.</div>
    </div>

    <asp:Button ID="btnBuscar" runat="server" Text="Buscar DNI" CssClass="btn btn-secondary mb-3" OnClick="btnBuscar_Click" />

    <div class="row">
        <div class="col-md-6 mb-3">
            <label for="txtNombre" class="form-label">Nombre</label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            <div class="invalid-feedback">El nombre es obligatorio y solo puede contener letras.</div>
        </div>

        <div class="col-md-6 mb-3">
            <label for="txtApellido" class="form-label">Apellido</label>
            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
            <div class="invalid-feedback">El apellido es obligatorio y solo puede contener letras.</div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-6 mb-3">
            <label for="txtEmail" class="form-label">Email</label>
            <div class="input-group has-validation">
                <span class="input-group-text">@</span>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                <div class="invalid-feedback">Ingrese un email válido.</div>
            </div>
        </div>

        <div class="col-md-6 mb-3">
            <label for="txtCp" class="form-label">CP</label>
            <asp:TextBox ID="txtCp" runat="server" CssClass="form-control"></asp:TextBox>
            <div class="invalid-feedback">Debe ingresar un código postal.</div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-6 mb-3">
            <label for="txtDireccion" class="form-label">Dirección</label>
            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
            <div class="invalid-feedback">Debe ingresar una dirección.</div>
        </div>

        <div class="col-md-6 mb-3">
            <label for="txtCiudad" class="form-label">Ciudad</label>
            <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control"></asp:TextBox>
            <div class="invalid-feedback">Debe ingresar una ciudad.</div>
        </div>
    </div>

    <div class="form-check mb-3">
        <asp:CheckBox ID="chkTerminos" runat="server" CssClass="form-check-input" />
        <label class="form-check-label" for="chkTerminos">
            Acepto los términos y condiciones.
        </label>
        <div class="invalid-feedback">
            Debe aceptar los términos antes de continuar.
        </div>
    </div>

    <div class="d-flex gap-2">
        <asp:Button ID="btnParticipar" runat="server" Text="Participar!" CssClass="btn btn-primary" OnClick="btnParticipar_Click" />
        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar formulario" CssClass="btn btn-outline-secondary" OnClick="btnLimpiar_Click" CausesValidation="false" />
    </div>
</asp:Content>
