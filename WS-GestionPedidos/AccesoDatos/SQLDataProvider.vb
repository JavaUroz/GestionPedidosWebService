Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports WS_GestionPedidos.Entidades

Namespace AccesoDatos
    Public Class SQLDataProvider
        Dim query As String = ""
        Dim result As Integer = -99
        Dim cnn As New SqlConnection("Data Source=DESKTOP-23SOU87\SQLEXPRESS;Initial Catalog=Almacen;Integrated Security=SSPI")
#Region "Cliente"
        Public Function Cliente_Add(ByVal objCliente As ClienteE) As Integer
            query = String.Format("INSERT INTO [dbo].[Clientes]
           ([clCuit],[clRazonSocial],[clDireccion],[clTelefono],[clEmail])
            VALUES 
           ('{0}','{1}','{2}','{3}','{4}')", objCliente.ClCuit1, objCliente.ClRazonSocial1, objCliente.ClDireccion1, objCliente.ClTelefono1, objCliente.ClEmail1)
            result = SqlHelper.ExecuteNonQuery(cnn, CommandType.Text, query)
            cnn.Close()
            Return result
        End Function
        Public Function Cliente_Update(ByVal objCliente As ClienteE) As Integer
            Dim _result = -99
            Try
                Dim _query = String.Format("UPDATE [dbo].[Clientes]
                   SET [clCuit] = '{1}',
                       [clRazonSocial] = '{2}',
                       [clDireccion] = '{3}',
                       [clTelefono] = '{4}',
                       [clEmail] = '{5}'
                 WHERE clId = '{0}'", objCliente.ClId1, objCliente.ClCuit1.Replace("'", "''"), objCliente.ClRazonSocial1.Replace("'", "''"), objCliente.ClDireccion1.Replace("'", "''"), objCliente.ClTelefono1.Replace("'", "''"), objCliente.ClEmail1.Replace("'", "''"))
                _result = SqlHelper.ExecuteNonQuery(cnn, CommandType.Text, _query)
                cnn.Close()
            Catch ex As Exception
                Console.Write(ex)
            End Try
            Return _result
        End Function
        Public Function Cliente_Delete(ByVal objCliente As ClienteE) As Integer
            Dim _result = -99
            Try
                Dim _query = String.Format("DELETE FROM [dbo].[Clientes]
                                            WHERE clId = {0}", objCliente.ClId1)
                _result = SqlHelper.ExecuteNonQuery(cnn, CommandType.Text, _query)
                cnn.Close()
            Catch ex As Exception
                Console.Write(ex)
            End Try
            Return _result
        End Function
        Public Function Cliente_GetByField(ByVal field As String, ByVal value As String) As ClienteE
            Dim objCliente As New ClienteE
            Try
                Dim reader As IDataReader = CType(SqlHelper.ExecuteReader(cnn, CommandType.Text, String.Format("SELECT * FROM Clientes WHERE {0} = '{1}'", field, value)), IDataReader)
                While reader.Read()
                    objCliente.ClId1 = CInt(reader("clId"))
                    objCliente.ClCuit1 = reader("clCuit").ToString
                    objCliente.ClRazonSocial1 = reader("clRazonSocial").ToString
                    objCliente.ClDireccion1 = reader("clDireccion").ToString
                    objCliente.ClTelefono1 = reader("clTelefono").ToString
                    objCliente.ClEmail1 = reader("clEmail").ToString
                End While
                reader.Dispose()
                cnn.Close()
            Catch ex As Exception
                Console.Write(ex)
            End Try
            Return objCliente
        End Function
        Public Function Cliente_GetAll() As DataSet
            Dim _result As DataSet = Nothing
            Dim _query As String
            Try
                _query = String.Format("Select * FROM Clientes")
                Dim ds As DataSet = CType(SqlHelper.ExecuteDataset(cnn, CommandType.Text, _query), DataSet)
                Return ds
            Catch ex As Exception
                Console.Write(ex)
                Return _result
            End Try
        End Function
#End Region

#Region "Producto"
        Public Function Producto_Add(ByVal objProducto As ProductoE) As Integer
            Dim _query = String.Format("
INSERT INTO [dbo].[Productos]
           ([prCodigo]
           ,[prDescripcion]
           ,[prUnidadMedida]
           ,[prPrecioCompra]
           ,[prPrecioVenta])
     VALUES
           ('{0}','{1}','{2}','{3}','{4}','{5}')", objProducto.PrCodigo1, objProducto.PrDescripcion1, objProducto.PrUnidadMedida1, objProducto.PrPrecioCompra1, objProducto.PrPrecioVenta1)
            Dim _result = SqlHelper.ExecuteNonQuery(cnn, CommandType.Text, _query)
            Return _result
            cnn.Close()
        End Function
        Public Function Producto_Update(ByVal objProducto As ProductoE) As Integer
            Dim _result = -99
            Try
                Dim _query = String.Format("
UPDATE [dbo].[Productos]
   SET [prCodigo] = '{1}',
       [prDescripcion] = '{2}',
       [prUnidadMedida] = '{3}',
       [prPrecioCompra] = '{4}',
       [prPrecioVenta] = '{5}',
 WHERE prId ='{0}'", objProducto.PrId1, objProducto.PrCodigo1.Replace("'", "''"), objProducto.PrDescripcion1.Replace("'", "''"), objProducto.PrUnidadMedida1.Replace("'", "''"), objProducto.PrPrecioCompra1.ToString.Replace("'", "''"), objProducto.PrPrecioVenta1.ToString.Replace("'", "''"))
                cnn.Close()
            Catch ex As Exception
                Console.Write(ex)
            End Try
            Return _result
        End Function
        Public Function Producto_Delete(ByVal objProducto As ProductoE) As Integer
            Dim _result = -99
            Try
                Dim _query = String.Format("
DELETE FROM [dbo].[Productos]
      WHERE clId = '{0}'", objProducto.PrId1)
                cnn.Close()
            Catch ex As Exception
                Console.Write(ex)
            End Try
            Return _result
        End Function
        Public Function Producto_GetByField(ByVal field As String, ByVal value As String) As ProductoE
            Dim objProducto As New ProductoE
            Try
                Dim reader As IDataReader = CType(SqlHelper.ExecuteReader(cnn, CommandType.Text, String.Format("SELECT * FROM Productos WHERE {0} = '{1}'", field, value)), IDataReader)
                While reader.Read()
                    objProducto.PrId1 = CInt(reader("prId"))
                    'objProducto.PrCodigo1 = reader("prCodigo").ToString
                    objProducto.PrDescripcion1 = reader("prDescripcion").ToString
                    objProducto.PrUnidadMedida1 = reader("prUnidadMedida").ToString
                    objProducto.PrPrecioCompra1 = CDec(reader("prPrecioCompra"))
                    objProducto.PrPrecioVenta1 = CDec(reader("prPrecioVenta"))
                End While
                reader.Dispose()
                cnn.Close()
            Catch ex As Exception
                Console.Write(ex)
            End Try
            Return objProducto
        End Function

        Public Function Producto_GetAll() As DataSet
            Dim _result As DataSet = Nothing
            Dim _query As String
            Try
                _query = String.Format("Select * FROM Productos")
                Dim ds As DataSet = CType(SqlHelper.ExecuteDataset(cnn, CommandType.Text, _query), DataSet)
                Return ds
            Catch ex As Exception
                Console.Write(ex)
                Return _result
            End Try
        End Function
#End Region
#Region "ProductoPedidos"
        Public Function ProductosPedidos_Add(ByVal objProductosPedidos As ProductosPedidosE) As Integer
            Dim _query = String.Format("
INSERT INTO [dbo].[ProductosPedidos]
           ([ppIdProducto]
           ,[ppIdCliente]
           ,[ppCantidad]
           ,[ppPrecioVenta])     
     VALUES
           ('{0}','{1}','{2}','{3}')", objProductosPedidos.PpIdProducto1, objProductosPedidos.PpIdCliente1, objProductosPedidos.PpCantidad1, objProductosPedidos.PpPrecioVenta1)
            Dim _result = SqlHelper.ExecuteNonQuery(cnn, CommandType.Text, _query)
            cnn.Close()
            Return _result
        End Function
        Public Function ProductosPedidos_Update(ByVal objProductosPedidos As ProductosPedidosE) As Integer
            Dim _result = -99
            Try
                Dim _query = String.Format("
UPDATE [dbo].[ProductosPedidos]
   SET [ppIdProducto] = '{1}',
       [ppIdCliente] = '{2}',
       [ppCantidad] = '{3}',       
       [ppPrecioVenta] = '{4}',
 WHERE ppId ='{0}'", objProductosPedidos.PpId1, objProductosPedidos.PpIdProducto1.ToString.Replace("'", "''"), objProductosPedidos.PpIdCliente1.ToString.Replace("'", "''"), objProductosPedidos.PpCantidad1.ToString.Replace("'", "''"), objProductosPedidos.PpPrecioVenta1.ToString.Replace("'", "''"))
                cnn.Close()
            Catch ex As Exception
                Console.Write(ex)
            End Try
            Return _result
        End Function
        Public Function ProductosPedidos_Delete(ByVal objProductosPedidos As ProductosPedidosE) As Integer
            Dim _result = -99
            Try
                Dim _query = String.Format("
DELETE FROM [dbo].[ProductosPedidos]
      WHERE clId = '{0}'", objProductosPedidos.PpId1)
                cnn.Close()
            Catch ex As Exception
                Console.Write(ex)
            End Try
            Return _result
        End Function
        Public Function ProductosPedidos_GetByField(ByVal field As String, ByVal value As String) As ProductosPedidosE
            Dim objProductosPedidos As New ProductosPedidosE
            Try
                Dim reader As IDataReader = CType(SqlHelper.ExecuteReader(cnn, CommandType.Text, String.Format("SELECT * FROM ProductosPedidos WHERE {0} = '{1}'", field, value)), IDataReader)
                While reader.Read()
                    objProductosPedidos.PpId1 = CInt(reader("ppId"))
                    objProductosPedidos.PpIdProducto1 = CInt(reader("ppIdProducto"))
                    objProductosPedidos.PpIdCliente1 = CInt(reader("ppIdCliente"))
                    objProductosPedidos.PpCantidad1 = CDbl(reader("ppCantidad"))
                    objProductosPedidos.PpPrecioVenta1 = CDec(reader("ppPrecioVenta"))
                End While
                reader.Dispose()
                cnn.Close()
            Catch ex As Exception
                Console.Write(ex)
            End Try
            Return objProductosPedidos
        End Function
#End Region
#Region "Unidades de medida"
        Public Function UnidadMedida_GetAll() As DataSet
            Dim _result As DataSet = Nothing
            Dim _query As String
            Try
                _query = String.Format("Select * FROM UnidadesMedida")
                Dim ds As DataSet = CType(SqlHelper.ExecuteDataset(cnn, CommandType.Text, _query), DataSet)
                Return ds
            Catch ex As Exception
                Console.Write(ex)
                Return _result
            End Try
        End Function
#End Region
    End Class
End Namespace

