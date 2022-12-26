<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DGVProductos
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
        Me.dtpFechaActPrecioVenta = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFechaActPrecioCompra = New System.Windows.Forms.DateTimePicker()
        Me.dgv_Productos = New System.Windows.Forms.DataGridView()
        Me.txt_Descripcion = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_PrecioCompra = New System.Windows.Forms.TextBox()
        Me.txt_PrecioVenta = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_Exportar = New System.Windows.Forms.Button()
        Me.btn_Eliminar = New System.Windows.Forms.Button()
        Me.btn_Modificar = New System.Windows.Forms.Button()
        Me.btn_Agregar = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cb_UnidadMedida = New System.Windows.Forms.ComboBox()
        Me.btn_Aceptar = New System.Windows.Forms.Button()
        Me.btn_Cancelar = New System.Windows.Forms.Button()
        CType(Me.dgv_Productos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtpFechaActPrecioVenta
        '
        Me.dtpFechaActPrecioVenta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaActPrecioVenta.Location = New System.Drawing.Point(407, 86)
        Me.dtpFechaActPrecioVenta.Name = "dtpFechaActPrecioVenta"
        Me.dtpFechaActPrecioVenta.Size = New System.Drawing.Size(112, 20)
        Me.dtpFechaActPrecioVenta.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(292, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Fecha última compra:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(292, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Fecha última venta:"
        '
        'dtpFechaActPrecioCompra
        '
        Me.dtpFechaActPrecioCompra.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaActPrecioCompra.Location = New System.Drawing.Point(406, 56)
        Me.dtpFechaActPrecioCompra.Name = "dtpFechaActPrecioCompra"
        Me.dtpFechaActPrecioCompra.Size = New System.Drawing.Size(112, 20)
        Me.dtpFechaActPrecioCompra.TabIndex = 0
        '
        'dgv_Productos
        '
        Me.dgv_Productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Productos.Location = New System.Drawing.Point(6, 19)
        Me.dgv_Productos.Name = "dgv_Productos"
        Me.dgv_Productos.Size = New System.Drawing.Size(546, 279)
        Me.dgv_Productos.TabIndex = 2
        '
        'txt_Descripcion
        '
        Me.txt_Descripcion.Location = New System.Drawing.Point(108, 25)
        Me.txt_Descripcion.Name = "txt_Descripcion"
        Me.txt_Descripcion.Size = New System.Drawing.Size(212, 20)
        Me.txt_Descripcion.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(36, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Descripción:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(333, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "U. Medida:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(37, 59)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Precio de Compra:"
        '
        'txt_PrecioCompra
        '
        Me.txt_PrecioCompra.Location = New System.Drawing.Point(137, 56)
        Me.txt_PrecioCompra.Name = "txt_PrecioCompra"
        Me.txt_PrecioCompra.Size = New System.Drawing.Size(128, 20)
        Me.txt_PrecioCompra.TabIndex = 11
        '
        'txt_PrecioVenta
        '
        Me.txt_PrecioVenta.Location = New System.Drawing.Point(136, 86)
        Me.txt_PrecioVenta.Name = "txt_PrecioVenta"
        Me.txt_PrecioVenta.Size = New System.Drawing.Size(128, 20)
        Me.txt_PrecioVenta.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(36, 89)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Precio de Venta:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_Exportar)
        Me.GroupBox1.Controls.Add(Me.btn_Eliminar)
        Me.GroupBox1.Controls.Add(Me.btn_Modificar)
        Me.GroupBox1.Controls.Add(Me.btn_Agregar)
        Me.GroupBox1.Controls.Add(Me.dgv_Productos)
        Me.GroupBox1.Location = New System.Drawing.Point(23, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(562, 353)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Consulta"
        '
        'btn_Exportar
        '
        Me.btn_Exportar.Location = New System.Drawing.Point(477, 316)
        Me.btn_Exportar.Name = "btn_Exportar"
        Me.btn_Exportar.Size = New System.Drawing.Size(75, 23)
        Me.btn_Exportar.TabIndex = 6
        Me.btn_Exportar.Text = "Exportar"
        Me.btn_Exportar.UseVisualStyleBackColor = True
        '
        'btn_Eliminar
        '
        Me.btn_Eliminar.Location = New System.Drawing.Point(178, 316)
        Me.btn_Eliminar.Name = "btn_Eliminar"
        Me.btn_Eliminar.Size = New System.Drawing.Size(75, 23)
        Me.btn_Eliminar.TabIndex = 5
        Me.btn_Eliminar.Text = "Eliminar"
        Me.btn_Eliminar.UseVisualStyleBackColor = True
        '
        'btn_Modificar
        '
        Me.btn_Modificar.Location = New System.Drawing.Point(96, 316)
        Me.btn_Modificar.Name = "btn_Modificar"
        Me.btn_Modificar.Size = New System.Drawing.Size(75, 23)
        Me.btn_Modificar.TabIndex = 4
        Me.btn_Modificar.Text = "Modificar"
        Me.btn_Modificar.UseVisualStyleBackColor = True
        '
        'btn_Agregar
        '
        Me.btn_Agregar.Location = New System.Drawing.Point(14, 316)
        Me.btn_Agregar.Name = "btn_Agregar"
        Me.btn_Agregar.Size = New System.Drawing.Size(75, 23)
        Me.btn_Agregar.TabIndex = 3
        Me.btn_Agregar.Text = "Agregar"
        Me.btn_Agregar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cb_UnidadMedida)
        Me.GroupBox2.Controls.Add(Me.txt_PrecioVenta)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txt_PrecioCompra)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txt_Descripcion)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.dtpFechaActPrecioCompra)
        Me.GroupBox2.Controls.Add(Me.dtpFechaActPrecioVenta)
        Me.GroupBox2.Location = New System.Drawing.Point(26, 384)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(559, 128)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Producto"
        '
        'cb_UnidadMedida
        '
        Me.cb_UnidadMedida.FormattingEnabled = True
        Me.cb_UnidadMedida.Location = New System.Drawing.Point(398, 25)
        Me.cb_UnidadMedida.Name = "cb_UnidadMedida"
        Me.cb_UnidadMedida.Size = New System.Drawing.Size(121, 21)
        Me.cb_UnidadMedida.TabIndex = 14
        '
        'btn_Aceptar
        '
        Me.btn_Aceptar.Location = New System.Drawing.Point(429, 524)
        Me.btn_Aceptar.Name = "btn_Aceptar"
        Me.btn_Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.btn_Aceptar.TabIndex = 16
        Me.btn_Aceptar.Text = "Aceptar"
        Me.btn_Aceptar.UseVisualStyleBackColor = True
        '
        'btn_Cancelar
        '
        Me.btn_Cancelar.Location = New System.Drawing.Point(510, 524)
        Me.btn_Cancelar.Name = "btn_Cancelar"
        Me.btn_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.btn_Cancelar.TabIndex = 17
        Me.btn_Cancelar.Text = "Cancelar"
        Me.btn_Cancelar.UseVisualStyleBackColor = True
        '
        'DGVProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(609, 561)
        Me.Controls.Add(Me.btn_Cancelar)
        Me.Controls.Add(Me.btn_Aceptar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "DGVProductos"
        Me.Text = "DGVProductos"
        CType(Me.dgv_Productos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dtpFechaActPrecioVenta As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpFechaActPrecioCompra As DateTimePicker
    Friend WithEvents dgv_Productos As DataGridView
    Friend WithEvents txt_Descripcion As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txt_PrecioCompra As TextBox
    Friend WithEvents txt_PrecioVenta As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btn_Eliminar As Button
    Friend WithEvents btn_Modificar As Button
    Friend WithEvents btn_Agregar As Button
    Friend WithEvents btn_Exportar As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btn_Aceptar As Button
    Friend WithEvents btn_Cancelar As Button
    Friend WithEvents cb_UnidadMedida As ComboBox
End Class
