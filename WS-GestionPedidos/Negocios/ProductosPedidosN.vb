Imports WS_GestionPedidos.AccesoDatos
Imports WS_GestionPedidos.Entidades

Namespace Negocios
    Public Class ProductosPedidosN
        Dim oSqlDataProvider As SQLDataProvider

        Public Function ProductosPedidosN_Add(ByVal objProductosPedidos As ProductosPedidosE) As Integer
            Return oSqlDataProvider.ProductosPedidos_Add(objProductosPedidos)
        End Function

        Public Function ProductosPedidosN_Update(ByVal objProductosPedidos As ProductosPedidosE) As Integer
            Return oSqlDataProvider.ProductosPedidos_Update(objProductosPedidos)
        End Function

        Public Function ProductosPedidosN_Delete(ByVal objProductosPedidos As ProductosPedidosE) As Integer
            Return oSqlDataProvider.ProductosPedidos_Delete(objProductosPedidos)
        End Function

        Public Function ProductosPedidosN_GetByField(ByVal field As String, ByVal value As String) As ProductosPedidosE
            Return oSqlDataProvider.ProductosPedidos_GetByField(field, value)
        End Function
    End Class
End Namespace

