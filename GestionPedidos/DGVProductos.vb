Imports GestionPedidos.ServiceReferenceGestionPedidos
Imports Microsoft.Office.Interop.Excel
Public Class DGVProductos
    Dim oCliente As New ClienteE
    Dim query As String
    Dim result As String = -99
    Dim msj As DialogResult
    Dim posicionEnGrilla As Integer = 0
    Dim idClienteSeleccionado = 0
    Dim buttonClickedConsulta As String = ""
    Dim ws As ServiceReferenceGestionPedidos.WSGestionPedidosSoapClient

    Private Sub DGVProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv_Productos.ReadOnly = True
        dgv_Productos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgv_Productos.RowHeadersVisible = False
        dgv_Productos.Columns(0).Visible = False
        dgv_Productos.Columns(1).HeaderText = "Código"
        dgv_Productos.Columns(2).HeaderText = "Descripción"
        dgv_Productos.Columns(3).HeaderText = "U.M."
        dgv_Productos.Columns(4).HeaderText = "Precio de compra"
        dgv_Productos.Columns(5).HeaderText = "Precio de venta"
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
End Class