<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Web_App.Formulario_web12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<%--aca el home: ver todos los objetos o productos y que cuando se cliqueen vayan a los productos para poder ver el producto en detalle --%>
    <!DOCTYPE html>

<%--<html lang="en">--%>

    <h1>Aqui inicio-Cambio</h1>

    <%--ERROR 2: Revisar los siguientes errores:
    La carga de Productos.aspx es correcta, pero cuando se da click en "Agregar al carrito", direcciona a Carrito.aspx, pero no muestra la info del producto
    Sólo muestra el botón Eliminar

    ERROR 3: En primer momento, aparecía un error que indicaba que el btnEliminar tenía que estar entre etiquetas de Form (Carrito.aspx, línea 46), haciendo esto, compila y permite dar click en el botón Eliminar, pero,
    si se selecciona otro artículo en el catálogo con el botón "Agregar al carrito", lanza un error que indica que sólo se puede haber 1 elemento de tipo Form.--%>

    <%--ERROR 4: Una vez que se agregó en Carrito.aspx.cs para que actualice la lista del session, después de eliminar un artículo, tira el error:
    "Object reference not set to an instance of an object.' El cuial indica que el valor buscado en X es null (Carrito.aspx.cs, línea 50)--%>


<%--</html>--%>
</asp:Content>
