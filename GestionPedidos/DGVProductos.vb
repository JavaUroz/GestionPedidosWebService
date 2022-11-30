Imports System.Globalization
Imports System.IO
Imports System.Runtime.Serialization
Imports GestionPedidos.ServiceReferenceGP
Imports Microsoft.Office.Interop.Excel
Imports OfficeOpenXml

Public Class DGVProductos
    Dim oProducto As New ProductoE
    Dim query As String
    Dim result As String = -99
    Dim msj As DialogResult
    Dim posicionEnGrilla As Integer = 0
    Dim idProductoSeleccionado = 0
    Dim buttonClickedConsulta As String = ""
    Dim ws As New ServiceReferenceGP.WSGestionPedidosSoapClient

    Private Sub DGVProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InicializarComponentes()
        dgv_Productos.ReadOnly = True
        dgv_Productos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgv_Productos.RowHeadersVisible = False
        dgv_Productos.Columns(0).Visible = False
        dgv_Productos.Columns(1).HeaderText = "Descripción"
        dgv_Productos.Columns(2).HeaderText = "U.M."
        dgv_Productos.Columns(3).HeaderText = "Precio Venta"
        dgv_Productos.Columns(4).HeaderText = "Precio Compra"
        dgv_Productos.Columns(5).Visible = False
        dgv_Productos.Columns(6).Visible = False

    End Sub
    Private Sub InicializarComponentes()
        txt_Descripcion.Text = ""
        cb_UnidadMedida.Text = ""
        txt_PrecioCompra.Text = ""
        txt_PrecioVenta.Text = ""
        dtpFechaActPrecioCompra.Text = ""
        dtpFechaActPrecioVenta.Text = ""
        Try
            Dim ds As New DataSet
            ds = ws.Producto_ObtenerTodo
            dgv_Productos.DataSource = ds.Tables(0).DefaultView
        Catch ex As Exception
            msj = MessageBox.Show(ex, MessageBoxButtons.OK)
        End Try
    End Sub
    Private Sub DesactivarControlesProducto()
        txt_Descripcion.Enabled = False
        cb_UnidadMedida.Enabled = False
        txt_PrecioCompra.Enabled = False
        txt_PrecioVenta.Enabled = False
        dtpFechaActPrecioCompra.Enabled = False
        dtpFechaActPrecioVenta.Enabled = False
        btn_Aceptar.Enabled = False
        btn_Cancelar.Enabled = False
    End Sub
    Private Sub ActivarControlesProducto()
        txt_Descripcion.Enabled = True
        cb_UnidadMedida.Enabled = True
        txt_PrecioCompra.Enabled = True
        txt_PrecioVenta.Enabled = True
        dtpFechaActPrecioCompra.Enabled = True
        dtpFechaActPrecioVenta.Enabled = True
        btn_Aceptar.Enabled = True
        btn_Cancelar.Enabled = True
        CargarCombos()
    End Sub
    Private Sub DesactivarControlesDGV()
        btn_Agregar.Enabled = False
        btn_Modificar.Enabled = False
        btn_Eliminar.Enabled = False
    End Sub
    Private Sub ActivarControlesDGV()
        btn_Agregar.Enabled = True
        btn_Modificar.Enabled = True
        btn_Eliminar.Enabled = True
        CargarCombos()
    End Sub
    Private Sub CargarCombos()
        Dim ds As New DataSet
        Try
            ds = ws.UnidadMedida_ObtenerTodo()
            If ds IsNot Nothing Then
                cb_UnidadMedida.DataSource = ds.Tables(0)
                cb_UnidadMedida.DisplayMember = "Descripción"
                cb_UnidadMedida.ValueMember = "Codigo"
                cb_UnidadMedida.SelectedValue = "07"
            End If
        Catch ex As Exception
            Utilidades.ShowBalloon(cb_UnidadMedida, "Atención", "No se pudieron cargar las unidades de medidas", ToolTipIcon.Error)
        End Try
    End Sub
    Public Sub Modificar(ByVal idProducto As Integer, ByVal posicion As Integer)
        Try
            oProducto = ws.Producto_ObtenerPorCampo("prId", idProducto)
            If oProducto IsNot Nothing Then

                posicionEnGrilla = posicion

                'Datos de producto
                idProductoSeleccionado = idProducto ' Lo guardo en esta variable para despues recuperarlo al momento del update
                txt_Descripcion.Text = oProducto.PrDescripcion1
                cb_UnidadMedida.Text = oProducto.PrUnidadMedida1
                txt_PrecioCompra.Text = oProducto.PrPrecioCompra1
                txt_PrecioVenta.Text = oProducto.PrPrecioVenta1
                dtpFechaActPrecioCompra.Text = oProducto.PrFechaActPrecioCompra1
                dtpFechaActPrecioVenta.Text = oProducto.PrFechaActPrecioVenta1

            Else
                msj = MessageBox.Show("Ningún producto seleccionado!", "Por favor haga clic sobre un producto existente en la tabla.", MessageBoxButtons.OK)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btn_Exportar_Click(sender As Object, e As EventArgs) Handles btn_Exportar.Click
        Try
            copiarAlPortapapeles()
            Dim objLibroExcel As Workbook
            Dim objLibrosExcel As Workbooks
            Dim objHojaExcel As Worksheet
            Dim objHojasExcel As Sheets
            Dim objExcel As Application
            objExcel = New Application
            objExcel.Visible = False
            objExcel.DisplayAlerts = False
            objLibroExcel = CType(objExcel.Workbooks.Add(), Workbook)
            objLibrosExcel = objExcel.Workbooks
            objHojasExcel = objLibroExcel.Worksheets
            objLibroExcel = objLibrosExcel.Item(1)
            objHojaExcel = CType(objHojasExcel.Item(1), Worksheet)
            objHojaExcel.Name = "Productos"
            Dim CR As Range = objHojaExcel.Cells(1, 1)
            CR.Select()
            objHojaExcel.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, True)
            objHojaExcel.Range("A1", Chr(dgv_Productos.ColumnCount - 1 + 65) & dgv_Productos.RowCount + 1).Borders.Color = 0
            objHojaExcel.Range("A1", Chr(dgv_Productos.ColumnCount - 1 + 65) & dgv_Productos.RowCount + 1).Borders.LineStyle = XlLineStyle.xlContinuous
            objHojaExcel.Range("A1", Chr(dgv_Productos.ColumnCount - 1 + 65) & dgv_Productos.RowCount + 1).Borders.Weight = 2
            objHojaExcel.Columns.AutoFit()
            Dim f As New SaveFileDialog
            Dim camino As String = ""
            Dim archivo As String
            archivo = ("Productos " & Date.Now.ToString("dd-MM-yyyy-hh-ss") & ".xlsx")
            f.Filter = "Excel Files|*.xlsx;*.xls;"
            f.FileName = archivo
            If DialogResult.OK = f.ShowDialog() Then
                camino = f.FileName
                objLibroExcel.SaveAs(camino, XlFileFormat.xlWorkbookDefault, System.Reflection.Missing.Value, System.Reflection.Missing.Value, False, False, XlSaveAsAccessMode.xlNoChange, False, False, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value)
                dgv_Productos.DataSource = Nothing
                btn_Exportar.Enabled = False
                Process.Start("explorer.exe", "/select," & camino)
            End If
            objLibroExcel.Close()
            objExcel.Quit()
            System.Runtime.InteropServices.Marshal.ReleaseComObject(objLibroExcel)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(objHojaExcel)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(objExcel)
            objLibroExcel = Nothing
            objExcel = Nothing
        Catch ex As Exception
            Utilidades.ShowBalloon(btn_Exportar, "Error", "No se pudo exportar productos", ToolTipIcon.Error)
        End Try
        InicializarComponentes()
    End Sub
    Private Sub copiarAlPortapapeles()
        Try
            dgv_Productos.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
            dgv_Productos.MultiSelect = True
            dgv_Productos.SelectAll()
            Dim dataObj As DataObject = dgv_Productos.GetClipboardContent()
            If dataObj IsNot DBNull.Value Then
                Clipboard.SetDataObject(dataObj)
            End If
        Catch ex As Exception
            msj = MessageBox.Show("Error", ex.Message, MessageBoxButtons.OKCancel)
        End Try
    End Sub
    Private Sub btn_Agregar_Click(sender As Object, e As EventArgs) Handles btn_Agregar.Click
        ActivarControlesProducto()
        DesactivarControlesDGV()
        buttonClickedConsulta = "Agregar"
    End Sub
    Private Sub btn_Modificar_Click(sender As Object, e As EventArgs) Handles btn_Modificar.Click
        ActivarControlesProducto()
        DesactivarControlesDGV()
        buttonClickedConsulta = "Modificar"
        Modificar(dgv_Productos.Rows(posicionEnGrilla).Cells("prId").Value.ToString, posicionEnGrilla)
    End Sub

    Private Sub btn_Eliminar_Click(sender As Object, e As EventArgs) Handles btn_Eliminar.Click
        If dgv_Productos.CurrentRow IsNot Nothing Then
            If (MessageBox.Show("¿Desea eliminar el producto " & dgv_Productos.Rows(dgv_Productos.CurrentRow.Index).Cells("prCodigo").Value.ToString & " - " & dgv_Productos.Rows(dgv_Productos.CurrentRow.Index).Cells("prDescripcion").Value.ToString & "?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes) Then
                ''No es necesario quitar la fila ya que se quita sola al presionar Delete
                ''DataGridView1.Rows.RemoveAt(DataGridView1.CurrentRow.Index)
                Producto_Borrar(idProductoSeleccionado)
            End If
        End If
        InicializarComponentes()
    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click
        DesactivarControlesProducto()
        ActivarControlesDGV()
        Select Case buttonClickedConsulta
            Case "Agregar"
                If String.IsNullOrEmpty(txt_Descripcion.Text) Then
                    txt_Descripcion.Focus()
                    Utilidades.ShowBalloon(txt_Descripcion, "Error", "El campo Descripcion no puede estar vacío", ToolTipIcon.Error, 5000)
                    InicializarComponentes()
                    Return
                End If

                oProducto.PrDescripcion1 = txt_Descripcion.Text.Trim
                oProducto.PrUnidadMedida1 = cb_UnidadMedida.Text.Trim
                oProducto.PrPrecioCompra1 = txt_PrecioCompra.Text.Trim
                oProducto.PrPrecioVenta1 = txt_PrecioVenta.Text.Trim
                'oProducto.PrFechaActPrecioCompra1 = Convert.ToDateTime(dtpFechaActPrecioCompra.Value.Date().ToString)
                'oProducto.PrFechaActPrecioVenta1 = dtpFechaActPrecioVenta.Value.ToString("d", CultureInfo.CreateSpecificCulture("en-EN"))
                result = ws.Producto_Agregar(oProducto)
                Select Case result
                    Case -99 ' Error al guardar en la base de datos
                        Utilidades.ShowBalloon(btn_Agregar, "Lo siento", "No se pudo guardar el producto", ToolTipIcon.Error)
                        InicializarComponentes()
                    Case Else
                        msj = MessageBox.Show("Producto creado exitosamente!", "Felicitaciones", MessageBoxButtons.OK)
                        InicializarComponentes()
                End Select
            Case "Modificar"
                oProducto.PrId1 = idProductoSeleccionado
                oProducto.PrDescripcion1 = txt_Descripcion.Text.Trim
                oProducto.PrUnidadMedida1 = cb_UnidadMedida.Text.Trim
                oProducto.PrPrecioCompra1 = txt_PrecioCompra.Text.Trim
                oProducto.PrPrecioVenta1 = txt_PrecioVenta.Text.Trim
                oProducto.PrFechaActPrecioCompra1 = dtpFechaActPrecioCompra.Value.ToString("yyyy-MM-dd")
                oProducto.PrFechaActPrecioVenta1 = dtpFechaActPrecioVenta.Value.ToString("yyyy-MM-dd")

                result = ws.Producto_Actualizar(oProducto)
                Select Case result
                    Case -99 ' Error al guardar en la base de datos
                        msj = MessageBox.Show("Lo siento", "No se pudo modificar el producto", MessageBoxButtons.OK)
                        InicializarComponentes()
                    Case Else
                        msj = MessageBox.Show("Producto modificado exitosamente!", "Felicitaciones", MessageBoxButtons.OK)
                        InicializarComponentes()
                End Select
        End Select
    End Sub
    Public Function Producto_Borrar(ByVal codigo As Integer) As Integer
        Try
            oProducto = ws.Producto_ObtenerPorCampo("prCodigo", codigo)
            result = ws.Producto_Borrar(oProducto)
        Catch ex As Exception

        End Try
        Return result
    End Function
    Private Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        DesactivarControlesProducto()
        ActivarControlesDGV()
        InicializarComponentes()
    End Sub
    Private Sub dgv_Productos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_Productos.CellClick
        posicionEnGrilla = e.RowIndex
        idProductoSeleccionado = CInt(dgv_Productos.Rows(posicionEnGrilla).Cells(0).Value)
    End Sub
    Private Sub dgv_Productos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_Productos.CellDoubleClick
        ActivarControlesProducto()
        DesactivarControlesDGV()
        If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
            Modificar(dgv_Productos.Rows(e.RowIndex).Cells("prId").Value.ToString, e.RowIndex)
        End If
    End Sub
End Class