Imports System.Text
Imports GestionPedidos.ServiceReferenceGP
Imports Microsoft.Office.Interop.Excel
Imports OfficeOpenXml.Sorting

Public Class CargaPedidos
    Dim oProductosPedidos As New ProductosPedidosE
    Dim oCliente As New ClienteE
    Dim oProducto As New ProductoE
    Dim oUnidadMedida As New UnidadMedidaE
    'Dim query As String
    Dim result As String = -99
    Dim msj As DialogResult
    Dim posicionEnGrilla As Integer = 0
    Dim idProductoSeleccionado = 0
    Dim idClienteSeleccionado = 0
    Dim idUnidadMedidaSeleccionado = 0
    'Dim buttonClickedConsulta As String = ""
    Dim ws As New ServiceReferenceGP.WSGestionPedidosSoapClient
    Private Sub CargaPedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InicializarComponentes()
        CargarCombos()
    End Sub

    Private Sub InicializarComponentes()
        'dgvPedido.Rows.Clear()
        cbRazonSocial.Text = ""
        cbDescripcionProducto.Text = ""
        tbCantidad.Text = ""
        tbUnidadMedida.Text = ""
        tbPrecioUnitario.Text = ""
    End Sub
    Private Sub CargarCombos()
        Dim ds As DataSet
        Try
            ds = ws.Producto_ObtenerTodo()
            If ds IsNot Nothing Then
                cbDescripcionProducto.DataSource = ds.Tables(0)
                cbDescripcionProducto.DisplayMember = "prDescripcion"
                cbDescripcionProducto.ValueMember = "prId"
                cbDescripcionProducto.SelectedValue = "1"
                obtenerIdProducto()
            End If
        Catch ex As Exception
            Utilidades.ShowBalloon(cbDescripcionProducto, "Atención", "No se pudieron cargar los productos", ToolTipIcon.Error)
        End Try
        Try
            ds = ws.Cliente_ObtenerTodo()
            If ds IsNot Nothing Then
                cbRazonSocial.DataSource = ds.Tables(0)
                cbRazonSocial.DisplayMember = "clRazonSocial"
                cbRazonSocial.ValueMember = "clId"
                cbRazonSocial.SelectedValue = "1"
                obtenerIdCliente()
            End If
        Catch ex As Exception
            Utilidades.ShowBalloon(cbDescripcionProducto, "Atención", "No se pudieron cargar los clientes", ToolTipIcon.Error)
        End Try
    End Sub
    Public Function obtenerIdProducto() As Integer
        Try
            oProducto = ws.Producto_ObtenerPorCampo(cbDescripcionProducto.DisplayMember, cbDescripcionProducto.Text)
            idProductoSeleccionado = oProducto.PrId1
        Catch ex As Exception
            msj = MessageBox.Show("Error", ex.Message, MessageBoxButtons.OKCancel)
        End Try
        Return idProductoSeleccionado
    End Function
    Public Function obtenerIdCliente() As Integer
        Try
            oCliente = ws.Cliente_ObtenerPorCampo(cbRazonSocial.DisplayMember, cbRazonSocial.Text)
            idClienteSeleccionado = oCliente.ClId1
        Catch ex As Exception
            msj = MessageBox.Show("Error", ex.Message, MessageBoxButtons.OKCancel)
        End Try
        Return idClienteSeleccionado
    End Function
    Public Function obtenerIdUnidadMedida() As Integer
        Try
            oUnidadMedida = ws.UnidadMedida_ObtenerPorCampo("Codigo", tbUnidadMedida.Text)
            idUnidadMedidaSeleccionado = oUnidadMedida.Codigo1
        Catch ex As Exception
            msj = MessageBox.Show("Error", ex.Message, MessageBoxButtons.OKCancel)
        End Try
        Return idUnidadMedidaSeleccionado
    End Function
    Private Sub cbRazonSocial_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbRazonSocial.SelectedIndexChanged
        obtenerIdCliente()
    End Sub
    Private Sub cbDescripcionProducto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDescripcionProducto.SelectedIndexChanged
        obtenerIdProducto()
        Dim ds As DataSet
        Try
            ds = ws.Producto_ObtenerTodo
            tbUnidadMedida.Text = ds.Tables(0).Rows(cbDescripcionProducto.SelectedIndex)(2)
        Catch ex As Exception
            Utilidades.ShowBalloon(cbDescripcionProducto, "Atención", "No se pudieron cargar las U.M. de los productos", ToolTipIcon.Error)
        End Try
    End Sub

    Private Sub tbPrecioUnitario_LostFocus(sender As Object, e As EventArgs) Handles tbPrecioUnitario.LostFocus
        Dim cantidad As Double
        Dim precio As Decimal
        Dim subtotal As Decimal
        Try
            cantidad = CDbl(tbCantidad.Text)
            precio = CDec(tbPrecioUnitario.Text)
            If cantidad <> 0 Then
                subtotal = cantidad * precio
                tbSubtotal.Text = subtotal
            End If
        Catch ex As Exception
            Utilidades.ShowBalloon(tbSubtotal, "Atención", "En Cantidad o Precio Unitario ingresaron un dato no numérico", ToolTipIcon.Error)
        End Try
    End Sub
    Private Sub tbCantidad_tbPrecio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbCantidad.KeyPress, tbPrecioUnitario.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not Char.IsPunctuation(e.KeyChar)
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If tbCantidad.Text IsNot "" Then
            'Try
            '    dgvPedido.Rows.Add("", cbDescripcionProducto.Text, tbCantidad.Text, tbUnidadMedida.Text, tbSubtotal.Text)
            '    If dgvPedido IsNot Nothing Then
            '        btnQuitar.Enabled = True
            '    End If
            'Catch ex As Exception
            '    msj = MessageBox.Show("No se han podido cargar los productos ingresados.", "Error!", MessageBoxButtons.OK)
            'End Try
            oProductosPedidos.PpIdCliente1 = idClienteSeleccionado
            oProductosPedidos.PpIdProducto1 = idProductoSeleccionado
            oProductosPedidos.PpCantidad1 = CDbl(tbCantidad.Text)
            oProductosPedidos.PpIdUnidadMedida1 = idUnidadMedidaSeleccionado
            oProductosPedidos.PpPrecioVenta1 = CDec(tbPrecioUnitario.Text)
            result = ws.ProductosPedidos_Agregar(oProductosPedidos)
            Select Case result
                Case -99 ' Error al guardar en la base de datos
                    Utilidades.ShowBalloon(btnAgregar, "Lo siento", "No se pudo cargar el pedido", ToolTipIcon.Error)
                    InicializarComponentes()
                Case Else
                    msj = MessageBox.Show("Pedido cargado exitosamente!", "Ok", MessageBoxButtons.OK)
                    InicializarComponentes()
            End Select
        Else
            Utilidades.ShowBalloon(tbCantidad, "Atención", "Ingrese la cantidad!", ToolTipIcon.Error)
        End If
        tbCantidad.Text = ""
        tbUnidadMedida.Text = ""
        tbPrecioUnitario.Text = ""
        tbSubtotal.Text = ""
    End Sub

    'Private Sub btnQuitar_Click(sender As Object, e As EventArgs)
    '    Dim FilaSeleccionada As Integer = dgvPedido.CurrentRow.Index
    '    Try
    '        dgvPedido.Rows.Remove(dgvPedido.Rows(FilaSeleccionada))
    '        If dgvPedido.Rows.Count = 0 Then
    '            btnQuitar.Enabled = False
    '        End If
    '    Catch ex As Exception
    '        msj = MessageBox.Show("No se han podido borrar las filas indicadas.", "Error!", MessageBoxButtons.OK)
    '    End Try
    'End Sub

    'Private Sub btnCancelar_Click(sender As Object, e As EventArgs)
    '    InicializarComponentes()
    'End Sub
    'Private Sub copiarAlPortapapeles()
    '    Try
    '        dgvPedido.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
    '        dgvPedido.MultiSelect = True
    '        dgvPedido.SelectAll()
    '        Dim dataObj As DataObject = dgvPedido.GetClipboardContent()
    '        If dataObj IsNot DBNull.Value Then
    '            Clipboard.SetDataObject(dataObj)
    '        End If
    '    Catch ex As Exception
    '        msj = MessageBox.Show("Error", ex.Message, MessageBoxButtons.OKCancel)
    '    End Try
    'End Sub
    'Private Sub btnImprimir_Click(sender As Object, e As EventArgs)
    '    Try
    '        copiarAlPortapapeles()
    '        Dim objLibroExcel As Workbook
    '        Dim objLibrosExcel As Workbooks
    '        Dim objHojaExcel As Worksheet
    '        Dim objHojasExcel As Sheets
    '        Dim objExcel As Application
    '        objExcel = New Application
    '        objExcel.Visible = False
    '        objExcel.DisplayAlerts = False
    '        objLibroExcel = CType(objExcel.Workbooks.Add(), Workbook)
    '        objLibrosExcel = objExcel.Workbooks
    '        objHojasExcel = objLibroExcel.Worksheets
    '        objLibroExcel = objLibrosExcel.Item(1)
    '        objHojaExcel = CType(objHojasExcel.Item(1), Worksheet)
    '        objHojaExcel.Name = "Pedido"
    '        Dim CR As Range = objHojaExcel.Cells(1, 1)
    '        CR.Select()
    '        objHojaExcel.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, True)
    '        objHojaExcel.Range("A1", Chr(dgvPedido.ColumnCount - 1 + 65) & dgvPedido.RowCount + 1).Borders.Color = 0
    '        objHojaExcel.Range("A1", Chr(dgvPedido.ColumnCount - 1 + 65) & dgvPedido.RowCount + 1).Borders.LineStyle = XlLineStyle.xlContinuous
    '        objHojaExcel.Range("A1", Chr(dgvPedido.ColumnCount - 1 + 65) & dgvPedido.RowCount + 1).Borders.Weight = 2
    '        objHojaExcel.Columns.AutoFit()
    '        Dim f As New SaveFileDialog
    '        Dim camino As String = ""
    '        Dim archivo As String
    '        archivo = ("Pedido" & "_" & cbRazonSocial.Text & "_" & Date.Now.ToString("dd-MM-yyyy-hh-ss") & ".xlsx")
    '        f.Filter = "Excel Files|*.xlsx;*.xls;"
    '        f.FileName = archivo
    '        If DialogResult.OK = f.ShowDialog() Then
    '            camino = f.FileName
    '            objLibroExcel.SaveAs(camino, XlFileFormat.xlWorkbookDefault, System.Reflection.Missing.Value, System.Reflection.Missing.Value, False, False, XlSaveAsAccessMode.xlNoChange, False, False, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value)
    '            dgvPedido.DataSource = Nothing
    '            btnImprimir.Enabled = False
    '            Process.Start("explorer.exe", "/select," & camino)
    '        End If
    '        objLibroExcel.Close()
    '        objExcel.Quit()
    '        System.Runtime.InteropServices.Marshal.ReleaseComObject(objLibroExcel)
    '        System.Runtime.InteropServices.Marshal.ReleaseComObject(objHojaExcel)
    '        System.Runtime.InteropServices.Marshal.ReleaseComObject(objExcel)
    '        objLibroExcel = Nothing
    '        objExcel = Nothing
    '    Catch ex As Exception
    '        Utilidades.ShowBalloon(btnImprimir, "Error", "No se pudo exportar clientes", ToolTipIcon.Error)
    '    End Try
    'End Sub
End Class