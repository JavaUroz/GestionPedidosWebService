Public Class DGVPedidos
    Private Sub DGVPedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InicializarComponentes()
        CargarCombos()
        dgvPedido.Columns.Add("id", "ID")
        dgvPedido.Columns.Add("cliente", "Cliente")
        dgvPedido.Columns.Add("producto", "Producto")
        dgvPedido.Columns.Add("cantidad", "Cantidad")
        dgvPedido.Columns.Add("um", "U.M.")
        dgvPedido.Columns.Add("total", "Total")
        dgvPedido.ReadOnly = True
        dgvPedido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvPedido.RowHeadersVisible = False
        dgvPedido.Columns(0).Visible = False
    End Sub
    Private Sub InicializarComponentes()

    End Sub
    Private Sub CargarCombos()

    End Sub
End Class