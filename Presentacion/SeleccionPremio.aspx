<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SeleccionPremio.aspx.cs" Inherits="Presentacion.SeleccionPremio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container text-center">
        <h1>Elija su premio</h1>
    </div>

    <div class="row row-cols-1 row-cols-md-3 g-4">

        <asp:Repeater runat="server" ID="Repetidor">
            <ItemTemplate>
                <div class="col">
                    <div class="card h-100">
                        <img src="<%# Eval("Imagenes[0].ImagenURL") %>" class="card-img-top d-block w-100" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("Nombre") %></h5>
                        </div>
                        <div class="card-footer">
                            <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#artModal<%#Eval("Id") %>">Detalle</button>
                        </div>
                    </div>
                </div>

                <div class="modal fade" id="artModal<%#Eval("Id") %>" tabindex="-1" aria-labelledby="artModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h1 class="modal-title fs-5" id="artModalLabel"><%# Eval("Nombre") %></h1>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <div class="container-fluid text-center">
                                    <div class="row row-cols-2">
                                        <div class="col">

                                            <div id="carousel<%#Eval("Id") %>" class="carousel slide">
                                                <div class="carousel-inner">
                                                    <%--<div class="carousel-item active">
                                                        <img src="..." class="d-block w-100" alt="...">
                                                    </div>
                                                    <div class="carousel-item">
                                                        <img src="..." class="d-block w-100" alt="...">
                                                    </div>--%>
                                                    <asp:Repeater runat="server" ID="RepetidorIMG" DataSource='<%# Eval("Imagenes") %>'>
                                                        <ItemTemplate>
                                                            <div class="carousel-item <%# Active(Container.ItemIndex)%>">
                                                                <img src="<%# Eval("ImagenURL") %>" alt="Alternate Text" class="d-block w-100" />
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </div>
                                                <button class="carousel-control-prev" type="button" data-bs-target="#carousel<%#Eval("Id") %>" data-bs-slide="prev">
                                                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                                    <span class="visually-hidden">Previous</span>
                                                </button>
                                                <button class="carousel-control-next" type="button" data-bs-target="#carousel<%#Eval("Id") %>" data-bs-slide="next">
                                                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                                    <span class="visually-hidden">Next</span>
                                                </button>
                                            </div>
                                            
                                        </div>
                                        <div class="col text-start">
                                            <p><strong>Codigo Producto: </strong><%#Eval("Codigo") %></p>
                                            <p><strong>Marca: </strong><%#Eval("Marca.Marca") %></p>
                                            <p><strong>Categoria: </strong><%#Eval("Categoria.Descripcion") %></p>
                                        </div>
                                    </div>
                                    <div class="container text-start">
                                        <p class="card-text text-"><strong>Descripcion: </strong><%#Eval("Descripcion") %></p>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>
                </div>

            </ItemTemplate>
        </asp:Repeater>

    </div>
</asp:Content>
