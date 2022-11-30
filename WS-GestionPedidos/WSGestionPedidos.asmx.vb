Imports System.ComponentModel
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports WS_GestionPedidos.Entidades
Imports WS_GestionPedidos.Negocios


' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WSGestionPedidos
    Inherits System.Web.Services.WebService
#Region "Clientes"
    <WebMethod>
    Public Function Cliente_Agregar(ObjCliente As ClienteE) As Integer
        Dim ObjClienteN As New ClienteN
        Return ObjClienteN.ClienteN_Add(ObjCliente)
    End Function
    <WebMethod>
    Public Function Cliente_Actualizar(ObjCliente As ClienteE) As Integer
        Dim ObjClienteN As New ClienteN
        Return ObjClienteN.ClienteN_Update(ObjCliente)
    End Function
    <WebMethod>
    Public Function Cliente_ObtenerPorCampo(ByVal field As String, ByVal value As String) As ClienteE
        Dim ObjClienteN As New ClienteN
        Return ObjClienteN.ClienteN_GetByField(field, value)
    End Function
    <WebMethod>
    Public Function Cliente_ObtenerTodo() As DataSet
        Dim ObjClienteN As New ClienteN
        Return ObjClienteN.ClienteN_GetAll()
    End Function
    <WebMethod>
    Public Function Cliente_Borrar(ObjCliente As ClienteE) As Integer
        Dim ObjClienteN As New ClienteN
        Return ObjClienteN.ClienteN_Delete(ObjCliente)
    End Function
#End Region
#Region "Productos"
    <WebMethod>
    Public Function Producto_Agregar(ObjProducto As ProductoE) As Integer
        Dim ObjProductoN As New ProductoN
        Return ObjProductoN.ProductoN_Add(ObjProducto)
    End Function
    <WebMethod>
    Public Function Producto_Actualizar(ObjProducto As ProductoE) As Integer
        Dim ObjProductoN As New ProductoN
        Return ObjProductoN.ProductoN_Update(ObjProducto)
    End Function
    <WebMethod>
    Public Function Producto_ObtenerPorCampo(ByVal field As String, ByVal value As String) As ProductoE
        Dim ObjProductoN As New ProductoN
        Return ObjProductoN.ProductoN_GetByField(field, value)
    End Function
    <WebMethod>
    Public Function Producto_ObtenerTodo() As DataSet
        Dim ObjProductoN As New ProductoN
        Return ObjProductoN.ProductoN_GetAll()
    End Function
    <WebMethod>
    Public Function Producto_Borrar(ObjProducto As ProductoE) As Integer
        Dim ObjProductoN As New ProductoN
        Return ObjProductoN.ProductoN_Delete(ObjProducto)
    End Function
#End Region
#Region "Productos pedidos"
    <WebMethod>
    Public Function ProductosPedidos_Agregar(ObjProductosPedidos As ProductosPedidosE) As Integer
        Dim ObjProductosPedidosN As New ProductosPedidosN
        Return ObjProductosPedidosN.ProductosPedidosN_Add(ObjProductosPedidos)
    End Function
    <WebMethod>
    Public Function ProductosPedidos_Actualizar(ObjProductosPedidos As ProductosPedidosE) As Integer
        Dim ObjProductosPedidosN As New ProductosPedidosN
        Return ObjProductosPedidosN.ProductosPedidosN_Update(ObjProductosPedidos)
    End Function
    <WebMethod>
    Public Function ProductosPedidos_ObtenerPorCampo(ByVal field As String, ByVal value As String) As ProductosPedidosE
        Dim ObjProductosPedidosN As New ProductosPedidosN
        Return ObjProductosPedidosN.ProductosPedidosN_GetByField(field, value)
    End Function
    <WebMethod>
    Public Function ProductosPedidos_ObtenerTodo() As DataSet
        Dim ObjProductosPedidosN As New ProductosPedidosN
        Return ObjProductosPedidosN.ProductosPedidosN_GetAll()
    End Function
    <WebMethod>
    Public Function ProductosPedidos_Borrar(ObjProducto As ProductoE) As Integer
        Dim ObjProductoN As New ProductoN
        Return ObjProductoN.ProductoN_Delete(ObjProducto)
    End Function
#End Region
#Region "Unidades de medida"
    <WebMethod>
    Public Function UnidadMedida_ObtenerTodo() As DataSet
        Dim ObjUnidadMedidaN As New UnidadMedidaN
        Return ObjUnidadMedidaN.UnidadMedidaN_GetAll()
    End Function
#End Region
End Class