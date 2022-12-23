Namespace Entidades
    Public Class ppConsultaE
#Region "Miembros"
        Private ppId As Integer
        Private clRazonSocial As String
        Private prDescripcion As String
        Private ppCantidad As Double
        Private ppUnidadMedida As String
        Private ppPrecioTotal As Decimal
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

        Public Property ClRazonSocial1 As String
            Get
                Return clRazonSocial
            End Get
            Set(value As String)
                clRazonSocial = value
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

        Public Property PpCantidad1 As Double
            Get
                Return ppCantidad
            End Get
            Set(value As Double)
                ppCantidad = value
            End Set
        End Property

        Public Property PpUnidadMedida1 As String
            Get
                Return ppUnidadMedida
            End Get
            Set(value As String)
                ppUnidadMedida = value
            End Set
        End Property

        Public Property PpPrecioTotal1 As Decimal
            Get
                Return ppPrecioTotal
            End Get
            Set(value As Decimal)
                ppPrecioTotal = value
            End Set
        End Property
#End Region
    End Class
End Namespace


