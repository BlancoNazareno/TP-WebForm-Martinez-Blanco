<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Web_App.Formulario_web1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server"> <%--Error 1--%>
     
    <header>

    </header>
    <h1>Aqui productos-cambio</h1>

    <%--aca el producto seleccionado en detalle logica del codigo en menu contextual y "darle a ver codigo" --%>
    
    
        <div class="container">
        <div class="row">
            <%foreach  (Dominio2.Articulo item in Lista)
                {%>
                    <div class="col">
                        <div class="card" style="width: 18rem;">
                            <img src="<% = item.ImgURL %>" class="card-img-top" alt="Error_Carga_codigo + <% = item.Codigo %>">
                            <div class="card-body">
                            <h5 class="card-title"><% = item.Nombre %></h5>
                            <p class="card-text"><% = item.Descripcion %></p>
                            <a href="Carrito.aspx?ID= <%= item.ID %>"  class="btn btn-primary">Agregar al carrito</a> <%--con este boton deberiamos poder añadir al carro las cosas (agregar funcionalidad)--%>
                          <%-- <asp:Button Text:"Agregar al carrito" ID="btnAgregar" OnClick="btnAgregar_click" runat="server" /> --%>
                                </div>
                        </div>
                     </div>
                <%} %>
                </div>
            </div>

<%--    <form id="from" runat="server">
    <asp:GridView id="dgvProductos" runat="server"></asp:GridView--%>><%--ERROR1--%>
<%--        <asp:Label Text="Lista" ID="lblSeleccionado" runat="server"></asp:Label>
    </form>--%>
</asp:Content>
