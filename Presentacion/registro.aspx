<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registro.aspx.cs" Inherits="Presentacion.registro" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registro de Cliente</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" class="container mt-4">
        <h2 class="mb-3">Registro de Cliente</h2>

        <div class="mb-3">
            <label for="txtDni" class="form-label">DNI</label>
            <asp:TextBox ID="txtDni" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label for="txtNombre" class="form-label">Nombre</label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label for="txtApellido" class="form-label">Apellido</label>
            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label for="txtEmail" class="form-label">Email</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label for="txtTelefono" class="form-label">Teléfono</label>
            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <asp:Button ID="btnParticipar" runat="server" Text="¡Participar!" CssClass="btn btn-primary" OnClick="btnParticipar_Click" />
    </form>
</body>
</html>
