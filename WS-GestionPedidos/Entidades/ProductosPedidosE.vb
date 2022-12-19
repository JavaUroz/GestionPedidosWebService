Namespace Entidades
    Public Class ProductosPedidosE
#Region "Miembros"
        Private ppId As Integer
        Private ppIdProducto As Integer
        Private ppIdCliente As Integer
        Private ppCantidad As Double
        Private ppIdUnidadMedida As Integer
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
        Public Property PpIdProducto1 As Integer
            Get
                Return ppIdProducto
            End Get
            Set(value As Integer)
                ppIdProducto = value
            End Set
        End Property

        Public Property PpIdCliente1 As Integer
            Get
                Return ppIdCliente
            End Get
            Set(value As Integer)
                ppIdCliente = value
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

        Public Property PpIdUnidadMedida1 As Integer
            Get
                Return ppIdUnidadMedida
            End Get
            Set(value As Integer)
                ppIdUnidadMedida = value
            End Set
        End Property
#End Region
    End Class
End Namespace
