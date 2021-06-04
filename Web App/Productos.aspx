<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Web_App.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server"> <%--ERROR1--%>

    <header>
<nav class="navbar navbar-expand-lg navbar-light bg-light">
  <a class="navbar-brand" href="Inicio.aspx">Home </a> <%--aca va el nombre del head o eso de la pag--%>
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
    <asp:GridView ID="dgvProductos" runat="server"></asp:GridView> <%--ERROR1--%>



    <%--aca el producto seleccionado en detalle logica del codigo en menu contextual y "darle a ver codigo" --%>
</asp:Content>
