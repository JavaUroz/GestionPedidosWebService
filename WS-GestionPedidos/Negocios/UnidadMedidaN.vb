Imports WS_GestionPedidos.AccesoDatos
Namespace Entidades
    Public Class UnidadMedidaN
        Dim oSqlDataProvider As New SQLDataProvider
        Public Function UnidadMedidaN_GetAll() As DataSet
            Return oSqlDataProvider.UnidadMedida_GetAll
        End Function
    End Class
End Namespace
