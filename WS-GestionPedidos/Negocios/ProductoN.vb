Imports WS_GestionPedidos.AccesoDatos
Imports WS_GestionPedidos.Entidades

Namespace Negocios
    Public Class ProductoN
        Dim oSqlDataProvider As New SQLDataProvider

        Public Function ProductoN_Add(ByVal objProducto As ProductoE) As Integer
            Return oSqlDataProvider.Producto_Add(objProducto)
        End Function

        Public Function ProductoN_Update(ByVal objProducto As ProductoE) As Integer
            Return oSqlDataProvider.Producto_Update(objProducto)
        End Function

        Public Function ProductoN_Delete(ByVal objProducto As ProductoE) As Integer
            Return oSqlDataProvider.Producto_Delete(objProducto)
        End Function

        Public Function ProductoN_GetByField(ByVal field As String, ByVal value As String) As ProductoE
            Return oSqlDataProvider.Producto_GetByField(field, value)
        End Function

        Public Function ProductoN_GetAll() As DataSet
            Return oSqlDataProvider.Producto_GetAll()
        End Function
    End Class
End Namespace

