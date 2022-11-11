Namespace Entidades
    Public Class ProductoE
#Region "Miembros"
        Private prId As Integer
        Private prCodigo As Integer
        Private prDescripcion As String
        Private prUnidadMedida As String
        Private prPrecioVenta As Decimal
        Private prPrecioCompra As Decimal
        Private prFechaActPrecioVenta As Date
        Private prFechaActPrecioCompra As Date
#End Region
#Region "Propiedades"
        Public Property PrId1 As Integer
            Get
                Return prId
            End Get
            Set(value As Integer)
                prId = value
            End Set
        End Property

        Public Property PrCodigo1 As String
            Get
                Return prCodigo
            End Get
            Set(value As String)
                prCodigo = value
            End Set
        End Property

        Public Property PrDescripcion1 As String
            Get
                Return prDescripcion
            End Get
            Set(value As String)
                prDescripcion = value
            End Set
        End Property

        Public Property PrUnidadMedida1 As String
            Get
                Return prUnidadMedida
            End Get
            Set(value As String)
                prUnidadMedida = value
            End Set
        End Property

        Public Property PrPrecioVenta1 As Decimal
            Get
                Return prPrecioVenta
            End Get
            Set(value As Decimal)
                prPrecioVenta = value
            End Set
        End Property

        Public Property PrPrecioCompra1 As Decimal
            Get
                Return prPrecioCompra
            End Get
            Set(value As Decimal)
                prPrecioCompra = value
            End Set
        End Property

        Public Property PrFechaActPrecioVenta1 As Date
            Get
                Return prFechaActPrecioVenta
            End Get
            Set(value As Date)
                prFechaActPrecioVenta = value
            End Set
        End Property

        Public Property PrFechaActPrecioCompra1 As Date
            Get
                Return prFechaActPrecioCompra
            End Get
            Set(value As Date)
                prFechaActPrecioCompra = value
            End Set
        End Property
#End Region
    End Class
End Namespace
