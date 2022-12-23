Imports GestionPedidos.ServiceReferenceGP
Imports Microsoft.Office.Interop.Excel
Public Class DGVPedidos
    Dim oProductosPedidos As ProductosPedidosE
    Dim query As String
    Dim result As String = -99
    Dim msj As DialogResult
    Dim posicionEnGrilla As Integer = 0
    Dim idProductoPedidoSeleccionado = 0
    Dim buttonClickedConsulta As String = ""
    Dim ws As New ServiceReferenceGP.WSGestionPedidosSoapClient

    Private Sub DGVPedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InicializarComponentes()
        dgvPedido.ReadOnly = True
        dgvPedido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvPedido.RowHeadersVisible = False
        dgvPedido.Columns(0).Visible = False
        dgvPedido.Columns(1).HeaderText = "Cliente"
        dgvPedido.Columns(2).HeaderText = "Producto"
        dgvPedido.Columns(3).HeaderText = "Cantidad"
        dgvPedido.Columns(4).HeaderText = "U.M."
        dgvPedido.Columns(5).HeaderText = "Total"
    End Sub
    Private Sub InicializarComponentes()
        Try
            Dim ds As New DataSet
            ds = ws.Ppconsulta_ObtenerTodo
            dgvPedido.DataSource = ds.Tables(0).DefaultView
        Catch ex As Exception
            msj = MessageBox.Show(ex, MessageBoxButtons.OK)
        End Try
    End Sub
    Public Function ProductosPedidos_Borrar(ByVal id As Integer) As Integer
        Try
            oProductosPedidos = ws.ProductosPedidos_ObtenerPorCampo("ppId", id)
            result = ws.ProductosPedidos_Borrar(oProductosPedidos)
        Catch ex As Exception
            msj = MessageBox.Show(ex, MessageBoxButtons.OK)
        End Try
        Return result
    End Function

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        InicializarComponentes()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If dgvPedido.CurrentRow IsNot Nothing Then
            If (MessageBox.Show("¿Desea eliminar el cliente " & dgvPedido.Rows(dgvPedido.CurrentRow.Index).Cells("ppId").Value.ToString & " - " & dgvPedido.Rows(dgvPedido.CurrentRow.Index).Cells("clRazonSocial").Value.ToString & "?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes) Then
                ''No es necesario quitar la fila ya que se quita sola al presionar Delete
                ''DataGridView1.Rows.RemoveAt(DataGridView1.CurrentRow.Index)
                ProductosPedidos_Borrar(idProductoPedidoSeleccionado)
            End If
        End If
    End Sub

    Private Sub dgvPedido_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPedido.CellContentClick
        posicionEnGrilla = e.RowIndex
        idProductoPedidoSeleccionado = CInt(dgvPedido.Rows(posicionEnGrilla).Cells(0).Value)
    End Sub
End Class