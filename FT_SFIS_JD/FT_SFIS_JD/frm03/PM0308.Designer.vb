<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PM0308
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
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.Txtdutyen = New System.Windows.Forms.TextBox()
    Me.Txtdutych = New System.Windows.Forms.TextBox()
    Me.Txtdutycode = New System.Windows.Forms.TextBox()
    Me.Laben = New System.Windows.Forms.Label()
    Me.Labch = New System.Windows.Forms.Label()
    Me.Labbadzeren = New System.Windows.Forms.Label()
    Me.dgblzr = New System.Windows.Forms.DataGridView()
    Me.GroupBox1.SuspendLayout()
    CType(Me.dgblzr, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.Txtdutyen)
    Me.GroupBox1.Controls.Add(Me.Txtdutych)
    Me.GroupBox1.Controls.Add(Me.Txtdutycode)
    Me.GroupBox1.Controls.Add(Me.Laben)
    Me.GroupBox1.Controls.Add(Me.Labch)
    Me.GroupBox1.Controls.Add(Me.Labbadzeren)
    Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
    Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(901, 112)
    Me.GroupBox1.TabIndex = 5
    Me.GroupBox1.TabStop = False
    '
    'Txtdutyen
    '
    Me.Txtdutyen.Font = New System.Drawing.Font("SimHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Txtdutyen.Location = New System.Drawing.Point(129, 78)
    Me.Txtdutyen.Name = "Txtdutyen"
    Me.Txtdutyen.Size = New System.Drawing.Size(516, 26)
    Me.Txtdutyen.TabIndex = 2
    '
    'Txtdutych
    '
    Me.Txtdutych.BackColor = System.Drawing.Color.AntiqueWhite
    Me.Txtdutych.Font = New System.Drawing.Font("SimHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Txtdutych.Location = New System.Drawing.Point(129, 46)
    Me.Txtdutych.Name = "Txtdutych"
    Me.Txtdutych.Size = New System.Drawing.Size(516, 26)
    Me.Txtdutych.TabIndex = 1
    '
    'Txtdutycode
    '
    Me.Txtdutycode.BackColor = System.Drawing.Color.AntiqueWhite
    Me.Txtdutycode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.Txtdutycode.Font = New System.Drawing.Font("SimHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Txtdutycode.Location = New System.Drawing.Point(129, 14)
    Me.Txtdutycode.Name = "Txtdutycode"
    Me.Txtdutycode.Size = New System.Drawing.Size(136, 26)
    Me.Txtdutycode.TabIndex = 0
    '
    'Laben
    '
    Me.Laben.Location = New System.Drawing.Point(6, 81)
    Me.Laben.Name = "Laben"
    Me.Laben.Size = New System.Drawing.Size(121, 21)
    Me.Laben.TabIndex = 0
    Me.Laben.Text = "英文名稱"
    Me.Laben.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Labch
    '
    Me.Labch.Location = New System.Drawing.Point(6, 49)
    Me.Labch.Name = "Labch"
    Me.Labch.Size = New System.Drawing.Size(121, 21)
    Me.Labch.TabIndex = 0
    Me.Labch.Text = "中文名稱"
    Me.Labch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Labbadzeren
    '
    Me.Labbadzeren.Location = New System.Drawing.Point(6, 17)
    Me.Labbadzeren.Name = "Labbadzeren"
    Me.Labbadzeren.Size = New System.Drawing.Size(121, 21)
    Me.Labbadzeren.TabIndex = 0
    Me.Labbadzeren.Text = "不良責任代碼"
    Me.Labbadzeren.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'dgblzr
    '
    Me.dgblzr.AllowUserToAddRows = False
    Me.dgblzr.AllowUserToDeleteRows = False
    Me.dgblzr.AllowUserToResizeRows = False
    DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.dgblzr.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
    Me.dgblzr.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
    Me.dgblzr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dgblzr.Dock = System.Windows.Forms.DockStyle.Fill
    Me.dgblzr.Location = New System.Drawing.Point(0, 112)
    Me.dgblzr.MultiSelect = False
    Me.dgblzr.Name = "dgblzr"
    Me.dgblzr.RowTemplate.Height = 24
    Me.dgblzr.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.dgblzr.Size = New System.Drawing.Size(901, 344)
    Me.dgblzr.TabIndex = 6
    '
    'PM0308
    '
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Me.ClientSize = New System.Drawing.Size(901, 456)
    Me.Controls.Add(Me.dgblzr)
    Me.Controls.Add(Me.GroupBox1)
    Me.Font = New System.Drawing.Font("SimHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Name = "PM0308"
    Me.Text = "不良責任0308"
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    CType(Me.dgblzr, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Txtdutych As System.Windows.Forms.TextBox
    Friend WithEvents Txtdutycode As System.Windows.Forms.TextBox
    Friend WithEvents Laben As System.Windows.Forms.Label
    Friend WithEvents Labch As System.Windows.Forms.Label
    Friend WithEvents Labbadzeren As System.Windows.Forms.Label
    Friend WithEvents dgblzr As System.Windows.Forms.DataGridView
    Friend WithEvents Txtdutyen As System.Windows.Forms.TextBox
End Class
