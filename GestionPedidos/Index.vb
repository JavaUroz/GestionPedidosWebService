Public Class Index

    Private Sub Index_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub ClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesToolStripMenuItem.Click
        Dim f As Form
        For Each f In Me.MdiChildren
            If (f.Text = "Clientes") Then
                f.BringToFront()
                Return
            End If
        Next
        Dim childForm As New DGVClientes
        childForm.MdiParent = Me
        childForm.Dock = DockStyle.None
        childForm.Show()
    End Sub

    Private Sub ProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductosToolStripMenuItem.Click
        Dim f As Form
        For Each f In Me.MdiChildren
            If (f.Text = "Productos") Then
                f.BringToFront()
                Return
            End If
        Next
        Dim childForm As New DGVProductos
        childForm.MdiParent = Me
        childForm.Dock = DockStyle.None
        childForm.Show()
    End Sub

    Private Sub VentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentasToolStripMenuItem.Click
        Dim f As Form
        For Each f In Me.MdiChildren
            If (f.Text = "Carga") Then
                f.BringToFront()
                Return
            End If
        Next
        Dim childForm As New CargaPedidos
        childForm.gbTipoDestinatario.Text = "Cliente"
        childForm.MdiParent = Me
        childForm.Dock = DockStyle.None
        childForm.Show()
    End Sub

    Private Sub ConsultaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaToolStripMenuItem.Click
        Dim f As Form
        For Each f In Me.MdiChildren
            If (f.Text = "Consulta de pedidos") Then
                f.BringToFront()
                Return
            End If
        Next
        Dim childForm As New DGVPedidos
        childForm.MdiParent = Me
        childForm.Dock = DockStyle.None
        childForm.Show()
    End Sub
End Class