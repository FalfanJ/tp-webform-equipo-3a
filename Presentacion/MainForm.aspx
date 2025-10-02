<%@ Page Title="Ingreso de Voucher" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MainForm.aspx.cs" Inherits="PromoGana.MainForm" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row justify-content-center mt-5">
        <div class="col-md-6">
            <div class="card shadow-lg p-4">
                <div class="card-body">
                    <h2 class="text-center mb-4">🎉 Promo Ganá!</h2>
                    <p class="text-muted text-center">Ingresá el código de tu voucher para participar</p>

                    <div class="mb-3">
                        <label for="txtVoucher" class="form-label">Código del Voucher</label>
                        <asp:TextBox ID="txtVoucher" runat="server" CssClass="form-control" placeholder="Ej: Codigo01"></asp:TextBox>
                    </div>

                    <asp:Button ID="btnSiguiente" runat="server" Text="Validar Voucher" CssClass="btn btn-primary w-100" OnClick="btnSiguiente_Click" />

                    <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger mt-3 d-block text-center"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
