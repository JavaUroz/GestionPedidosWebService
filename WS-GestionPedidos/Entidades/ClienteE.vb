Namespace Entidades
    Public Class ClienteE
#Region "Miembros"
        Private clId As Integer
        Private clCuit As String
        Private clRazonSocial As String
        Private clDireccion As String
        Private clTelefono As String
        Private clEmail As String
#End Region
#Region "Propiedades"
        Public Property ClId1 As Integer
            Get
                Return clId
            End Get
            Set(value As Integer)
                clId = value
            End Set
        End Property

        Public Property ClCuit1 As String
            Get
                Return clCuit
            End Get
            Set(value As String)
                clCuit = value
            End Set
        End Property

        Public Property ClRazonSocial1 As String
            Get
                Return clRazonSocial
            End Get
            Set(value As String)
                clRazonSocial = value
            End Set
        End Property

        Public Property ClDireccion1 As String
            Get
                Return clDireccion
            End Get
            Set(value As String)
                clDireccion = value
            End Set
        End Property

        Public Property ClTelefono1 As String
            Get
                Return clTelefono
            End Get
            Set(value As String)
                clTelefono = value
            End Set
        End Property

        Public Property ClEmail1 As String
            Get
                Return clEmail
            End Get
            Set(value As String)
                clEmail = value
            End Set
        End Property
#End Region

    End Class
End Namespace
