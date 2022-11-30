Imports GestionPedidos.ServiceReferenceGP
Public Class CargaPedidos
    Dim oProductosPedidos As New ProductosPedidosE
    Dim oCliente As New ClienteE
    Dim oProducto As New ProductoE
    Dim query As String
    Dim result As String = -99
    Dim msj As DialogResult
    Dim posicionEnGrilla As Integer = 0
    Dim idProductoSeleccionado = 0
    Dim idClienteSeleccionado = 0
    Dim buttonClickedConsulta As String = ""
    Dim ws As New ServiceReferenceGP.WSGestionPedidosSoapClient
    Private Sub CargaPedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InicializarComponentes()
        CargarCombos()
        dgvPedido.Columns.Add("id", "ID")
        dgvPedido.Columns.Add("descripcion", "Descripción")
        dgvPedido.Columns.Add("cantidad", "Cantidad")
        dgvPedido.Columns.Add("um", "U.M.")
        dgvPedido.Columns.Add("subtotal", "Subtotal")
        dgvPedido.ReadOnly = True
        dgvPedido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvPedido.RowHeadersVisible = False
        dgvPedido.Columns(0).Visible = False
    End Sub

    Private Sub InicializarComponentes()
        dgvPedido.Rows.Clear()
        cbRazonSocial.Text = ""
        cbDescripcionProducto.Text = ""
        tbCantidad.Text = ""
        tbUnidadMedida.Text = ""
        tbPrecioUnitario.Text = ""
        tbPrecioTotal.Text = ""
    End Sub

    Private Sub btnVaciar_Click(sender As Object, e As EventArgs) Handles btnVaciar.Click
        dgvPedido.Rows.Clear()
        btnQuitar.Enabled = False
    End Sub

    Private Sub CargarCombos()
        Dim ds As New DataSet
        Try
            ds = ws.Producto_ObtenerTodo()
            If ds IsNot Nothing Then
                cbDescripcionProducto.DataSource = ds.Tables(0)
                cbDescripcionProducto.DisplayMember = "prDescripcion"
                cbDescripcionProducto.ValueMember = "prId"
                cbDescripcionProducto.SelectedValue = "1"
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
            End If
        Catch ex As Exception
            Utilidades.ShowBalloon(cbDescripcionProducto, "Atención", "No se pudieron cargar los clientes", ToolTipIcon.Error)
        End Try
    End Sub

    Private Sub cbDescripcionProducto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDescripcionProducto.SelectedIndexChanged
        Dim ds As New DataSet
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
            Try
                dgvPedido.Rows.Add("", cbDescripcionProducto.Text, tbCantidad.Text, tbUnidadMedida.Text, tbSubtotal.Text)
                tbCantidad.Text = ""
                tbUnidadMedida.Text = ""
                tbPrecioUnitario.Text = ""
                tbPrecioTotal.Text = ""
                If dgvPedido IsNot Nothing Then
                    btnQuitar.Enabled = True
                End If
            Catch ex As Exception
                msj = MessageBox.Show("No se han podido cargar los productos ingresados.", "Error!", MessageBoxButtons.OK)
            End Try
        Else
            Utilidades.ShowBalloon(tbCantidad, "Atención", "Ingrese la cantidad!", ToolTipIcon.Error)
        End If
    End Sub

    Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
        Dim FilaSeleccionada As Integer = dgvPedido.CurrentRow.Index
        Try
            dgvPedido.Rows.Remove(dgvPedido.Rows(FilaSeleccionada))
            If dgvPedido.Rows.Count = 0 Then
                btnQuitar.Enabled = False
            End If
        Catch ex As Exception
            msj = MessageBox.Show("No se han podido borrar las filas indicadas.", "Error!", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        InicializarComponentes()
    End Sub

    Private Sub sumarTotal() Handles dgvPedido.AllowUserToAddRowsChanged
        Try
            If dgvPedido.Rows.Count > 0 Then
                For Each Fila As DataGridViewRow In dgvPedido.Rows
                    If Not Fila Is Nothing Then

                    End If
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class