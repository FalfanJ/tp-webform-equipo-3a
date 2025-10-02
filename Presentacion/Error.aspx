<%@ Page Title="Error" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="PromoGana.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="alert alert-danger text-center shadow p-4">
            <h2>❌ Error con el voucher</h2>
            <asp:Label ID="lblErrorMsg" runat="server" CssClass="h5 d-block mb-3"></asp:Label>
            <a href="MainForm.aspx" class="btn btn-primary">Volver al inicio</a>
        </div>
    </div>
</asp:Content>

