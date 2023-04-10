<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDialog
    Inherits System.Windows.Forms.Form

    'Form 重寫 Dispose，以清理組件列表。
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

    'Windows 窗體設計器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下過程是 Windows 窗體設計器所必需的
    '可以使用 Windows 窗體設計器修改它。
    '不要使用代碼編輯器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.dg = New System.Windows.Forms.DataGridView()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.GD = New System.Windows.Forms.TextBox()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.Button2 = New System.Windows.Forms.Button()
    Me.Button4 = New System.Windows.Forms.Button()
    Me.BG = New System.ComponentModel.BackgroundWorker()
    CType(Me.dg, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.FlowLayoutPanel1.SuspendLayout()
    Me.SuspendLayout()
    '
    'dg
    '
    Me.dg.AllowUserToAddRows = False
    Me.dg.AllowUserToDeleteRows = False
    Me.dg.AllowUserToResizeColumns = False
    Me.dg.AllowUserToResizeRows = False
    DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.dg.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
    Me.dg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
    Me.dg.BackgroundColor = System.Drawing.SystemColors.MenuBar
    Me.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dg.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dg.Location = New System.Drawing.Point(0, 63)
    Me.dg.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.dg.Name = "dg"
    Me.dg.ReadOnly = True
    Me.dg.RowTemplate.Height = 23
    Me.dg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.dg.Size = New System.Drawing.Size(676, 361)
    Me.dg.TabIndex = 0
    '
    'GroupBox1
    '
    Me.GroupBox1.BackColor = System.Drawing.SystemColors.ScrollBar
    Me.GroupBox1.Controls.Add(Me.FlowLayoutPanel1)
    Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
    Me.GroupBox1.Font = New System.Drawing.Font("SimHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
    Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.GroupBox1.Size = New System.Drawing.Size(676, 63)
    Me.GroupBox1.TabIndex = 2
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "選擇信息"
    '
    'FlowLayoutPanel1
    '
    Me.FlowLayoutPanel1.Controls.Add(Me.Label1)
    Me.FlowLayoutPanel1.Controls.Add(Me.GD)
    Me.FlowLayoutPanel1.Controls.Add(Me.Button1)
    Me.FlowLayoutPanel1.Controls.Add(Me.Button2)
    Me.FlowLayoutPanel1.Controls.Add(Me.Button4)
    Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.FlowLayoutPanel1.Font = New System.Drawing.Font("SimHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
    Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 23)
    Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
    Me.FlowLayoutPanel1.Size = New System.Drawing.Size(670, 36)
    Me.FlowLayoutPanel1.TabIndex = 3
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("SimHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
    Me.Label1.Location = New System.Drawing.Point(3, 10)
    Me.Label1.Margin = New System.Windows.Forms.Padding(3, 10, 0, 0)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(40, 16)
    Me.Label1.TabIndex = 1
    Me.Label1.Text = "查找"
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    '
    'GD
    '
    Me.GD.Font = New System.Drawing.Font("SimHei", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134,Byte))
    Me.GD.Location = New System.Drawing.Point(46, 5)
    Me.GD.Margin = New System.Windows.Forms.Padding(3, 5, 3, 3)
    Me.GD.Name = "GD"
    Me.GD.Size = New System.Drawing.Size(351, 26)
    Me.GD.TabIndex = 0
    '
    'Button1
    '
    Me.Button1.AutoSize = true
    Me.Button1.BackColor = System.Drawing.SystemColors.Control
    Me.Button1.Font = New System.Drawing.Font("SimHei", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134,Byte))
    Me.Button1.ForeColor = System.Drawing.Color.Red
    Me.Button1.Location = New System.Drawing.Point(403, 6)
    Me.Button1.Margin = New System.Windows.Forms.Padding(3, 6, 3, 4)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(65, 26)
    Me.Button1.TabIndex = 1
    Me.Button1.Text = "選擇"
    Me.Button1.UseVisualStyleBackColor = false
    '
    'Button2
    '
    Me.Button2.AutoSize = true
    Me.Button2.BackColor = System.Drawing.SystemColors.Control
    Me.Button2.Font = New System.Drawing.Font("SimHei", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134,Byte))
    Me.Button2.ForeColor = System.Drawing.Color.Red
    Me.Button2.Location = New System.Drawing.Point(474, 6)
    Me.Button2.Margin = New System.Windows.Forms.Padding(3, 6, 3, 4)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(65, 26)
    Me.Button2.TabIndex = 2
    Me.Button2.Text = "取消"
    Me.Button2.UseVisualStyleBackColor = false
    '
    'Button4
    '
    Me.Button4.AutoSize = true
    Me.Button4.BackColor = System.Drawing.SystemColors.Control
    Me.Button4.Font = New System.Drawing.Font("SimHei", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134,Byte))
    Me.Button4.ForeColor = System.Drawing.Color.Red
    Me.Button4.Location = New System.Drawing.Point(545, 6)
    Me.Button4.Margin = New System.Windows.Forms.Padding(3, 6, 3, 4)
    Me.Button4.Name = "Button4"
    Me.Button4.Size = New System.Drawing.Size(82, 26)
    Me.Button4.TabIndex = 4
    Me.Button4.Text = "多選確定"
    Me.Button4.UseVisualStyleBackColor = false
    '
    'FrmDialog
    '
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Me.ClientSize = New System.Drawing.Size(676, 424)
    Me.ControlBox = false
    Me.Controls.Add(Me.dg)
    Me.Controls.Add(Me.GroupBox1)
    Me.Font = New System.Drawing.Font("SimHei", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
    Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
    Me.Name = "FrmDialog"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "工單選擇"
    CType(Me.dg,System.ComponentModel.ISupportInitialize).EndInit
    Me.GroupBox1.ResumeLayout(false)
    Me.FlowLayoutPanel1.ResumeLayout(false)
    Me.FlowLayoutPanel1.PerformLayout
    Me.ResumeLayout(false)

End Sub
    Friend WithEvents dg As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GD As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
  Friend WithEvents Button4 As System.Windows.Forms.Button
  Friend WithEvents BG As System.ComponentModel.BackgroundWorker
End Class
