Imports GestionPedidos.ServiceReferenceGP
Imports Microsoft.Office.Interop.Excel

Public Class DGVClientes
    Dim oCliente As New ClienteE
    Dim query As String
    Dim result As String = -99
    Dim msj As DialogResult
    Dim posicionEnGrilla As Integer = 0
    Dim idClienteSeleccionado = 0
    Dim buttonClickedConsulta As String = ""
    Dim ws As New ServiceReferenceGP.WSGestionPedidosSoapClient

    Private Sub DGVClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InicializarComponentes()
        dgv_Clientes.ReadOnly = True
        dgv_Clientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgv_Clientes.RowHeadersVisible = False
        dgv_Clientes.Columns(0).Visible = False
        dgv_Clientes.Columns(1).HeaderText = "CUIT"
        dgv_Clientes.Columns(2).HeaderText = "Razón Social"
        dgv_Clientes.Columns(3).HeaderText = "Dirección"
        dgv_Clientes.Columns(4).HeaderText = "Teléfono"
        dgv_Clientes.Columns(5).HeaderText = "E-Mail"
    End Sub
    Private Sub InicializarComponentes()
        txt_Cuit.Text = ""
        txt_RazonSocial.Text = ""
        txt_Direccion.Text = ""
        txt_Telefono.Text = ""
        txt_Email.Text = ""
        Try
            Dim ds As New DataSet
            ds = ws.Cliente_ObtenerTodo
            dgv_Clientes.DataSource = ds.Tables(0).DefaultView
        Catch ex As Exception
            msj = MessageBox.Show(ex, MessageBoxButtons.OK)
        End Try
    End Sub
    Private Sub DesactivarControlesCliente()
        txt_Cuit.Enabled = False
        txt_RazonSocial.Enabled = False
        txt_Direccion.Enabled = False
        txt_Telefono.Enabled = False
        txt_Email.Enabled = False
        btn_Aceptar.Enabled = False
        btn_Cancelar.Enabled = False
    End Sub
    Private Sub ActivarControlesCliente()
        txt_Cuit.Enabled = True
        txt_RazonSocial.Enabled = True
        txt_Direccion.Enabled = True
        txt_Telefono.Enabled = True
        txt_Email.Enabled = True
        btn_Aceptar.Enabled = True
        btn_Cancelar.Enabled = True
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
    End Sub
    Public Sub Modificar(ByVal idCliente As Integer, ByVal posicion As Integer)
        Try
            oCliente = ws.Cliente_ObtenerPorCampo("clId", idCliente)
            If oCliente IsNot Nothing Then

                posicionEnGrilla = posicion

                'DATOS FISCALES
                idClienteSeleccionado = idCliente ' Lo guardo en esta variable para despues recuperarlo al momento del update
                txt_Cuit.Text = oCliente.ClCuit1
                txt_RazonSocial.Text = oCliente.ClRazonSocial1
                txt_Direccion.Text = oCliente.ClDireccion1
                txt_Telefono.Text = oCliente.ClTelefono1
                txt_Email.Text = oCliente.ClEmail1
            Else
                msj = MessageBox.Show("Ningún cliente seleccionado!", "Por favor haga clic sobre un cliente existente en la tabla.", MessageBoxButtons.OK)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btn_Agregar_Click(sender As Object, e As EventArgs) Handles btn_Agregar.Click
        ActivarControlesCliente()
        DesactivarControlesDGV()
        buttonClickedConsulta = "Agregar"
    End Sub
    Private Sub btn_Modificar_Click(sender As Object, e As EventArgs) Handles btn_Modificar.Click
        ActivarControlesCliente()
        DesactivarControlesDGV()
        buttonClickedConsulta = "Modificar"
        Modificar(dgv_Clientes.Rows(posicionEnGrilla).Cells("clId").Value.ToString, posicionEnGrilla)
    End Sub

    Private Sub btn_Eliminar_Click(sender As Object, e As EventArgs) Handles btn_Eliminar.Click
        If dgv_Clientes.CurrentRow IsNot Nothing Then
            If (MessageBox.Show("¿Desea eliminar el cliente " & dgv_Clientes.Rows(dgv_Clientes.CurrentRow.Index).Cells("clId").Value.ToString & " - " & dgv_Clientes.Rows(dgv_Clientes.CurrentRow.Index).Cells("clRazonSocial").Value.ToString & "?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes) Then
                ''No es necesario quitar la fila ya que se quita sola al presionar Delete
                ''DataGridView1.Rows.RemoveAt(DataGridView1.CurrentRow.Index)
                Cliente_Borrar(idClienteSeleccionado)
            End If
        End If
        InicializarComponentes()
    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click
        DesactivarControlesCliente()
        ActivarControlesDGV()
        Select Case buttonClickedConsulta
            Case "Agregar"
                If String.IsNullOrEmpty(txt_Cuit.Text) Then
                    txt_Cuit.Focus()
                    Utilidades.ShowBalloon(txt_Cuit, "Error", "El campo CUIT no puede estar vacío", ToolTipIcon.Error, 5000)
                    InicializarComponentes()
                    Return
                End If
                If String.IsNullOrEmpty(txt_RazonSocial.Text) Then
                    txt_RazonSocial.Focus()
                    Utilidades.ShowBalloon(txt_RazonSocial, "Error", "El campo Razón Social no puede estar vacío", ToolTipIcon.Error, 5000)
                    Return
                End If

                oCliente.ClCuit1 = txt_Cuit.Text.Trim
                oCliente.ClRazonSocial1 = txt_RazonSocial.Text.Trim
                oCliente.ClDireccion1 = txt_Direccion.Text.Trim
                oCliente.ClTelefono1 = txt_Telefono.Text.Trim
                oCliente.ClEmail1 = txt_Email.Text.Trim

                result = ws.Cliente_Agregar(oCliente)
                Select Case result
                    Case -99 ' Error al guardar en la base de datos
                        Utilidades.ShowBalloon(btn_Agregar, "Lo siento", "No se pudo guardar el cliente", ToolTipIcon.Error)
                        InicializarComponentes()
                    Case Else
                        msj = MessageBox.Show("Cliente creado exitosamente!", "Felicitaciones", MessageBoxButtons.OK)
                        InicializarComponentes()
                End Select
            Case "Modificar"
                oCliente.ClId1 = idClienteSeleccionado
                oCliente.ClCuit1 = txt_Cuit.Text.Trim
                oCliente.ClRazonSocial1 = txt_RazonSocial.Text.Trim
                oCliente.ClDireccion1 = txt_Direccion.Text.Trim
                oCliente.ClTelefono1 = txt_Telefono.Text.Trim
                oCliente.ClEmail1 = txt_Email.Text

                result = ws.Cliente_Actualizar(oCliente)
                Select Case result
                    Case -99 ' Error al guardar en la base de datos
                        msj = MessageBox.Show("Lo siento", "No se pudo modificar el cliente", MessageBoxButtons.OK)
                        InicializarComponentes()
                    Case Else
                        msj = MessageBox.Show("Cliente modificado exitosamente!", "Felicitaciones", MessageBoxButtons.OK)
                        InicializarComponentes()
                End Select
        End Select
    End Sub
    Public Function Cliente_Borrar(ByVal id As Integer) As Integer
        Try
            oCliente = ws.Cliente_ObtenerPorCampo("clId", id)
            result = ws.Cliente_Borrar(oCliente)
        Catch ex As Exception

        End Try
        Return result
    End Function
    Private Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        DesactivarControlesCliente()
        ActivarControlesDGV()
        InicializarComponentes()
    End Sub
    Private Sub dgv_Clientes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_Clientes.CellClick
        posicionEnGrilla = e.RowIndex
        idClienteSeleccionado = CInt(dgv_Clientes.Rows(posicionEnGrilla).Cells(0).Value)
    End Sub
    Private Sub dgv_Clientes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_Clientes.CellDoubleClick
        ActivarControlesCliente()
        DesactivarControlesDGV()
        If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
            Modificar(dgv_Clientes.Rows(e.RowIndex).Cells("clId").Value.ToString, e.RowIndex)
        End If
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
            objHojaExcel.Name = "Clientes"
            Dim CR As Range = objHojaExcel.Cells(1, 1)
            CR.Select()
            objHojaExcel.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, True)
            objHojaExcel.Range("A1", Chr(dgv_Clientes.ColumnCount - 1 + 65) & dgv_Clientes.RowCount + 1).Borders.Color = 0
            objHojaExcel.Range("A1", Chr(dgv_Clientes.ColumnCount - 1 + 65) & dgv_Clientes.RowCount + 1).Borders.LineStyle = XlLineStyle.xlContinuous
            objHojaExcel.Range("A1", Chr(dgv_Clientes.ColumnCount - 1 + 65) & dgv_Clientes.RowCount + 1).Borders.Weight = 2
            objHojaExcel.Columns.AutoFit()
            Dim f As New SaveFileDialog
            Dim camino As String = ""
            Dim archivo As String
            archivo = ("Clientes " & Date.Now.ToString("dd-MM-yyyy-hh-ss") & ".xls")
            f.Filter = "Excel Files|*.xlsx;*.xls;"
            f.FileName = archivo
            If DialogResult.OK = f.ShowDialog() Then
                camino = f.FileName
                objLibroExcel.SaveAs(camino, XlFileFormat.xlWorkbookDefault, System.Reflection.Missing.Value, System.Reflection.Missing.Value, False, False, XlSaveAsAccessMode.xlNoChange, False, False, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value)
                dgv_Clientes.DataSource = Nothing
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
            Utilidades.ShowBalloon(btn_Exportar, "Error", "No se pudo exportar clientes", ToolTipIcon.Error)
        End Try
        InicializarComponentes()
    End Sub
    Private Sub copiarAlPortapapeles()
        Try
            dgv_Clientes.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
            dgv_Clientes.MultiSelect = True
            dgv_Clientes.SelectAll()
            Dim dataObj As DataObject = dgv_Clientes.GetClipboardContent()
            If dataObj IsNot DBNull.Value Then
                Clipboard.SetDataObject(dataObj)
            End If
        Catch ex As Exception
            msj = MessageBox.Show("Error", ex.Message, MessageBoxButtons.OKCancel)
        End Try
    End Sub
End Class