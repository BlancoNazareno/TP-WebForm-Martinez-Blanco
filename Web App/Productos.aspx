<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Web_App.Formulario_web1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server"> <%--Error 1--%>
     
    <header>
        <nav class="navbar navbar-expand-lg navbar-light <%--bg-light--%> btn-secondary">
            <a class="navbar-brand" href="Inicio.aspx ">Home </a> <%--aca va el nombre del head o eso de la pag--%>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
            </button> <%--checkear por que el boton no es responsi cuando se achica la pantalla--%>
        <div class="collapse navbar-collapse" id="navbarNav">
            <ul class="navbar-nav">
                <li class="nav-item active">
                    <%--<a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>--%>
                     <%--<a class="nav-link" href="About.aspx">About.aspx</a> --%><%--esto en las lineas de abajo para alinear lo que falta--%>
                     <a class="nav-link" href="Productos.aspx">Productos</a><%-- productios debe llevar a una pestaña con el producto seleccionado para ver en detalle el producto--%>
                <%--tambien debera ofrecer para agregar el producto al carrito--%>
                </li>
                <li class="nav-item">
          <%--debera ver en otra pesaña el producto, ya incluido en el carro--%>
                    <a class="nav-link" href="Carrito.aspx">Carrito</a> <%--posicionarlo en otro sector de la pag en lo posible por tema estetico--%>
                </li>
            </ul>
       </div>
    
        </nav>
    </header>
    <h1>Aqui productos-cambio</h1>

    <%--aca el producto seleccionado en detalle logica del codigo en menu contextual y "darle a ver codigo" --%>
    
    
    <div class="container">
        <div class="row">
            <%foreach (Dominio2.Articulo item in Lista)
                {%>
            <div class="col">
                <div class="card" style="width: 18rem;">
                    <img src="<% = item.ImgURL %>" class="card-img-top" alt="Error_Carga_codigo + <% = item.Codigo %>">
                    <div class="card-body">
                        <h5 class="card-title"><% = item.Nombre %></h5>
                        <p class="card-text"><% = item.Descripcion %></p>
                        <a href="Carrito.aspx?ID= <%= item.ID %>" class="btn btn-primary">Agregar al carrito</a> <%--con este boton deberiamos poder añadir al carro las cosas (agregar funcionalidad)--%>
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
