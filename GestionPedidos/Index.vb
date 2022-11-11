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
        childForm.Text = "Clientes"
        childForm.MdiParent = Me
        childForm.Dock = DockStyle.Fill
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
        Dim childForm As New DGVClientes
        childForm.Text = "Productos"
        childForm.MdiParent = Me
        childForm.Dock = DockStyle.Fill
        childForm.Show()
    End Sub
End Class