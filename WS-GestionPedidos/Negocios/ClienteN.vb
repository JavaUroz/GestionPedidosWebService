Imports WS_GestionPedidos.AccesoDatos
Imports WS_GestionPedidos.Entidades

Namespace Negocios
    Public Class ClienteN
        Dim oSqlDataProvider As New SQLDataProvider

        Public Function ClienteN_Add(ByVal objCliente As ClienteE) As Integer
            Return oSqlDataProvider.Cliente_Add(objCliente)
        End Function

        Public Function ClienteN_Update(ByVal objCliente As ClienteE) As Integer
            Return oSqlDataProvider.Cliente_Update(objCliente)
        End Function

        Public Function ClienteN_Delete(ByVal objCliente As ClienteE) As Integer
            Return oSqlDataProvider.Cliente_Delete(objCliente)
        End Function

        Public Function ClienteN_GetByField(ByVal field As String, ByVal value As String) As ClienteE
            Return oSqlDataProvider.Cliente_GetByField(field, value)
        End Function
        Public Function ClienteN_GetAll() As DataSet
            Return oSqlDataProvider.Cliente_GetAll()
        End Function
    End Class
End Namespace

