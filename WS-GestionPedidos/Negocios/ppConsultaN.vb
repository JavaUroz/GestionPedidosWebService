Imports WS_GestionPedidos.AccesoDatos
Imports WS_GestionPedidos.Entidades
Namespace Negocios
    Public Class ppConsultaN
        Dim oSqlDataProvider As New SQLDataProvider
        Public Function PpConsultaN_GetAll() As DataSet
            Return oSqlDataProvider.PpConsulta_GetAll()
        End Function
    End Class
End Namespace

