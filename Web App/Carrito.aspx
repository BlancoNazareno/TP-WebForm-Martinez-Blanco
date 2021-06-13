<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Web_App.Formulario_web11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <header>
        <nav class="navbar navbar-expand-lg navbar-light <%--bg-light--%> btn-secondary">
            <a class="navbar-brand" href="Inicio.aspx ">Home </a><%--aca va el nombre del head o eso de la pag--%>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <%--checkear por que el boton no es responsi cuando se achica la pantalla--%>
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



<%--    Se quiso usar repeater, pero, ante la complicación de la implementación, se descartó     --%>


<%--    <table class="table">
        <tr>
            <td>Nombre</td>
            <td>Descripción</td>
            <td>Imagen</td>
            <td>Eliminar</td>
        </tr>

        <asp:Repeater runat="server" ID="Repetidor">
            <ItemTemplate>
                <tr>
                    <td><%#Eval("ID")%></td>
                     <td><%#Eval("Nombre")%></td>
                     <td>   <img src="<%#Eval("ImgURL")%>" alt="imgProducto" width="100" height="100" />  </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>--%>


 <%--    Uso del foreach     --%>
 <div class="container">
        <table class="table">
            <tr>
                <td>Nombre</td>
                <td>Descripción</td>
                <td>Imagen</td>
                <td>Cantidad</td>
                <td>Acción</td>
            </tr>
            <%foreach (Dominio2.Articulo item in ListaCarrito)
                { %>

            <tr>
                <td><%=item.Nombre%></td>
                <td><%=item.Descripcion%></td>
                <td>
                    <img src="<%=item.ImgURL%>" alt="imgProducto" width="100" height="100" />
                </td>
                <td>
                    <form action="/action_page.php">
                        <%--<label for="quantity"> Cantidad: </label>--%>
                       <input type="number" id="Cantidad" name="Cantidad" min="1" value="1">
                    </form>  
                </td>
                <td>
                 <a href="Carrito.aspx?ID= <%= item.ID.ToString() %>&productoRepetido=  <%=1.ToString()%>"   class="btn btn-primary">Eliminar</a>
                     <a href="Productos.aspx?" class="btn btn-primary">Volver al catálogo</a>
                   <%-- <asp:Button runat="server" ID="btnEliminar" CssClass="btn btn-primary" Text="Eliminar Item" OnClick="EliminarItem(<%=item.%>)"/>--%>
                     <%--<asp:Button CommandArgument=<%item.ID%>runat="server" ID="btnEliminar" CssClass="btn btn-primary" Text="Eliminar Item" OnClick="EliminarItem(<%=item.%>)"/>--%>
                </td>

            </tr>



            <% } %>
        </table>

        <asp:Label Text="Cantidad de artículos: " ID="lblCantidadFinal" runat="server" />
     <br />
    <asp:Label Text="IMporte acumulado: $ " ID="lblImporteFinal" runat="server" /> 
 </div>

 



</asp:Content>
