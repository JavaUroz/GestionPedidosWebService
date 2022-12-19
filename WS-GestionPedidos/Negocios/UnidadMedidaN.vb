Imports WS_GestionPedidos.AccesoDatos
Namespace Entidades
    Public Class UnidadMedidaN
        Dim oSqlDataProvider As New SQLDataProvider
        Public Function UnidadMedidaN_Add(ByVal objUnidadMedida As UnidadMedidaE) As Integer
            Return oSqlDataProvider.UnidadMedida_Add(objUnidadMedida)
        End Function

        Public Function UnidadMedidaN_Update(ByVal objUnidadMedida As UnidadMedidaE) As Integer
            Return oSqlDataProvider.UnidadMedida_Update(objUnidadMedida)
        End Function

        Public Function UnidadMedidaN_Delete(ByVal objUnidadMedida As UnidadMedidaE) As Integer
            Return oSqlDataProvider.UnidadMedida_Delete(objUnidadMedida)
        End Function

        Public Function UnidadMedidaN_GetByField(ByVal field As String, ByVal value As String) As UnidadMedidaE
            Return oSqlDataProvider.UnidadMedida_GetByField(field, value)
        End Function
        Public Function UnidadMedidaN_GetAll() As DataSet
            Return oSqlDataProvider.UnidadMedida_GetAll
        End Function

    End Class
End Namespace
