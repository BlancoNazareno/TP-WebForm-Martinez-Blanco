<%@ Page EnableEventValidation="true" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Web_App.Formulario_web11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--aca toda la parte visual del carro--%>
    
<%--<body>
    <header>

    </header>
    <h1>Aqui carrito-cambio</h1>

    <asp:Label Text ="NombreProducto" ID="lblNombreProducto" runat="server" />
   
</body>--%>



       <%-- Esto reemplaza el foreach. Vean que cambia la forma de pasar el argumento a cada tag.
            En este caso se usa el numeral (#) y la función Eval que recibe por parámetro como string
            el nombre de la property de tu objeto. El repeater va a iterar lo que esté dentro de la colección
             que le asignamos en el LOAD. Se lo asignamos directamente por ID, en este caso, repetidor.--%>
        <%--        <asp:Repeater runat="server" ID="repetidor">
            <ItemTemplate>
                <div class="card">
                    <img src="<%#Eval("UrlImagen") %>" class="card-img-top" alt="...">
                    <div class="card-body">
                        <h5 class="card-title"><%#Eval("Nombre")%></h5>
                        <p class="card-text"><%#Eval("Descripcion")%></p>
                    </div>
                    <a class="btn btn-primary" href="PokemonDetail.aspx?idpkm=<%#Eval("Id")%>">Seleccionar</a>
                    <asp:Button ID="btnArgumento" CssClass="btn btn-primary" Text="Argumento to Back" CommandArgument='<%#Eval("Id")%>' CommandName="idPokemon" runat="server" OnClick="btnArgumento_Click" />
                </div>
            </ItemTemplate>
        </asp:Repeater>--%>


    <table class="table">
        
        <%-- el repetidor actúa a modo de foreach --%>
        <asp:Repeater runat="server" ID="Repetidor">
            <ItemTemplate>
                <tr>
                    <td><%#Eval("ID")%></td>               <%--  ERROR2 /*no está llegando, ni mostrando la info del artículo*/--%>
                    <td>
                      <form id="from" runat="server">  <%--se añadieron los form tag para que compile el btnEliminar--%>
                            <%--<asp:Button ID="btnEliminar" Text="Eliminar"  CssClass="btn btn-primary" CommandArgument='<%#Eval("ID")%>' CommandName="IDProducto" runat="server" OnClick="btnEliminar_Click" /> --%>
                            <asp:Button Text="Eliminar" CssClass="btn btn-primary" ID="btnEliminar2" OnClick="btnEliminar2_Click" CommanArgument='<%#Eval("ID")%>'   runat="server" />                      
                      </form>     
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>



</asp:Content>
