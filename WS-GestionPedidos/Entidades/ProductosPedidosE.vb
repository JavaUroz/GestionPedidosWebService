Namespace Entidades
    Public Class ProductosPedidosE
#Region "Miembros"
        Private ppId As Integer
        Private ppDescripcionProducto As String
        Private ppRazonSocialCliente As String
        Private ppCantidad As Double
        Private ppPrecioVenta As Decimal
#End Region
#Region "Propiedades"
        Public Property PpId1 As Integer
            Get
                Return ppId
            End Get
            Set(value As Integer)
                ppId = value
            End Set
        End Property
        Public Property PpDescripcionProducto1 As String
            Get
                Return ppDescripcionProducto
            End Get
            Set(value As String)
                ppDescripcionProducto = value
            End Set
        End Property

        Public Property PpRazonSocialCliente1 As String
            Get
                Return ppRazonSocialCliente
            End Get
            Set(value As String)
                ppRazonSocialCliente = value
            End Set
        End Property

        Public Property PpCantidad1 As Double
            Get
                Return ppCantidad
            End Get
            Set(value As Double)
                ppCantidad = value
            End Set
        End Property

        Public Property PpPrecioVenta1 As Decimal
            Get
                Return ppPrecioVenta
            End Get
            Set(value As Decimal)
                ppPrecioVenta = value
            End Set
        End Property
#End Region
    End Class
End Namespace
