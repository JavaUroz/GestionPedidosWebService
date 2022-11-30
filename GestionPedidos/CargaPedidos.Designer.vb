<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CargaPedidos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cbRazonSocial = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbDescripcionProducto = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbCantidad = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbUnidadMedida = New System.Windows.Forms.TextBox()
        Me.tbPrecioTotal = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dgvPedido = New System.Windows.Forms.DataGridView()
        Me.tbPrecioUnitario = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.gbTipoDestinatario = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.tbSubtotal = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnVaciar = New System.Windows.Forms.Button()
        Me.btnQuitar = New System.Windows.Forms.Button()
        CType(Me.dgvPedido, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTipoDestinatario.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbRazonSocial
        '
        Me.cbRazonSocial.FormattingEnabled = True
        Me.cbRazonSocial.Location = New System.Drawing.Point(90, 17)
        Me.cbRazonSocial.Name = "cbRazonSocial"
        Me.cbRazonSocial.Size = New System.Drawing.Size(162, 21)
        Me.cbRazonSocial.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Razón Social:"
        '
        'cbDescripcionProducto
        '
        Me.cbDescripcionProducto.FormattingEnabled = True
        Me.cbDescripcionProducto.Location = New System.Drawing.Point(84, 21)
        Me.cbDescripcionProducto.Name = "cbDescripcionProducto"
        Me.cbDescripcionProducto.Size = New System.Drawing.Size(209, 21)
        Me.cbDescripcionProducto.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Descripción:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(315, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Cantidad:"
        '
        'tbCantidad
        '
        Me.tbCantidad.Location = New System.Drawing.Point(370, 21)
        Me.tbCantidad.Name = "tbCantidad"
        Me.tbCantidad.Size = New System.Drawing.Size(61, 20)
        Me.tbCantidad.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(441, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "UM:"
        '
        'tbUnidadMedida
        '
        Me.tbUnidadMedida.Enabled = False
        Me.tbUnidadMedida.Location = New System.Drawing.Point(471, 21)
        Me.tbUnidadMedida.Name = "tbUnidadMedida"
        Me.tbUnidadMedida.Size = New System.Drawing.Size(72, 20)
        Me.tbUnidadMedida.TabIndex = 5
        '
        'tbPrecioTotal
        '
        Me.tbPrecioTotal.Enabled = False
        Me.tbPrecioTotal.Location = New System.Drawing.Point(412, 255)
        Me.tbPrecioTotal.Name = "tbPrecioTotal"
        Me.tbPrecioTotal.Size = New System.Drawing.Size(131, 20)
        Me.tbPrecioTotal.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(372, 258)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Total:"
        '
        'dgvPedido
        '
        Me.dgvPedido.AllowUserToAddRows = False
        Me.dgvPedido.AllowUserToDeleteRows = False
        Me.dgvPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPedido.Location = New System.Drawing.Point(15, 24)
        Me.dgvPedido.Name = "dgvPedido"
        Me.dgvPedido.Size = New System.Drawing.Size(528, 216)
        Me.dgvPedido.TabIndex = 8
        '
        'tbPrecioUnitario
        '
        Me.tbPrecioUnitario.Location = New System.Drawing.Point(343, 50)
        Me.tbPrecioUnitario.Name = "tbPrecioUnitario"
        Me.tbPrecioUnitario.Size = New System.Drawing.Size(61, 20)
        Me.tbPrecioUnitario.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(278, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Precio unit.:"
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(424, 447)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 11
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(505, 447)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 12
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'gbTipoDestinatario
        '
        Me.gbTipoDestinatario.Controls.Add(Me.Label1)
        Me.gbTipoDestinatario.Controls.Add(Me.cbRazonSocial)
        Me.gbTipoDestinatario.Location = New System.Drawing.Point(13, 7)
        Me.gbTipoDestinatario.Name = "gbTipoDestinatario"
        Me.gbTipoDestinatario.Size = New System.Drawing.Size(567, 51)
        Me.gbTipoDestinatario.TabIndex = 13
        Me.gbTipoDestinatario.TabStop = False
        Me.gbTipoDestinatario.Text = "Cliente"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.tbSubtotal)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.btnAgregar)
        Me.GroupBox2.Controls.Add(Me.tbPrecioUnitario)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.tbUnidadMedida)
        Me.GroupBox2.Controls.Add(Me.tbCantidad)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.cbDescripcionProducto)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 64)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(567, 84)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Producto"
        '
        'tbSubtotal
        '
        Me.tbSubtotal.Enabled = False
        Me.tbSubtotal.Location = New System.Drawing.Point(463, 50)
        Me.tbSubtotal.Name = "tbSubtotal"
        Me.tbSubtotal.Size = New System.Drawing.Size(80, 20)
        Me.tbSubtotal.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(413, 53)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Subtotal:"
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(14, 55)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregar.TabIndex = 11
        Me.btnAgregar.Text = "Cargar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnVaciar)
        Me.GroupBox3.Controls.Add(Me.btnQuitar)
        Me.GroupBox3.Controls.Add(Me.dgvPedido)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.tbPrecioTotal)
        Me.GroupBox3.Location = New System.Drawing.Point(13, 154)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(567, 285)
        Me.GroupBox3.TabIndex = 15
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Pedido"
        '
        'btnVaciar
        '
        Me.btnVaciar.Location = New System.Drawing.Point(212, 247)
        Me.btnVaciar.Name = "btnVaciar"
        Me.btnVaciar.Size = New System.Drawing.Size(75, 23)
        Me.btnVaciar.TabIndex = 10
        Me.btnVaciar.Text = "Vaciar"
        Me.btnVaciar.UseVisualStyleBackColor = True
        '
        'btnQuitar
        '
        Me.btnQuitar.Enabled = False
        Me.btnQuitar.Location = New System.Drawing.Point(15, 247)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(75, 23)
        Me.btnQuitar.TabIndex = 9
        Me.btnQuitar.Text = "Quitar"
        Me.btnQuitar.UseVisualStyleBackColor = True
        '
        'CargaPedidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(595, 478)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.gbTipoDestinatario)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Name = "CargaPedidos"
        Me.Text = "Ventas"
        CType(Me.dgvPedido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbTipoDestinatario.ResumeLayout(False)
        Me.gbTipoDestinatario.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cbRazonSocial As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cbDescripcionProducto As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents tbCantidad As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents tbUnidadMedida As TextBox
    Friend WithEvents tbPrecioTotal As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents dgvPedido As DataGridView
    Friend WithEvents tbPrecioUnitario As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnAceptar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents gbTipoDestinatario As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btnAgregar As Button
    Friend WithEvents btnQuitar As Button
    Friend WithEvents btnVaciar As Button
    Friend WithEvents tbSubtotal As TextBox
    Friend WithEvents Label7 As Label
End Class
