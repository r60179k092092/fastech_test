<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PM0307
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
    Me.Labbadcode = New System.Windows.Forms.Label()
    Me.Labbadch = New System.Windows.Forms.Label()
    Me.txtreasoncode = New System.Windows.Forms.TextBox()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.Txtreasonen = New System.Windows.Forms.TextBox()
    Me.Txtreasonch = New System.Windows.Forms.TextBox()
    Me.Labbaden = New System.Windows.Forms.Label()
    Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
    Me.DGXM = New System.Windows.Forms.DataGridView()
    Me.ComboBox1 = New System.Windows.Forms.ComboBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TextBox2 = New System.Windows.Forms.TextBox()
    Me.GroupBox1.SuspendLayout()
    CType(Me.DGXM, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Labbadcode
    '
    Me.Labbadcode.Location = New System.Drawing.Point(6, 21)
    Me.Labbadcode.Name = "Labbadcode"
    Me.Labbadcode.Size = New System.Drawing.Size(127, 21)
    Me.Labbadcode.TabIndex = 0
    Me.Labbadcode.Text = "不良現象代碼"
    Me.Labbadcode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Labbadch
    '
    Me.Labbadch.Location = New System.Drawing.Point(6, 49)
    Me.Labbadch.Name = "Labbadch"
    Me.Labbadch.Size = New System.Drawing.Size(127, 21)
    Me.Labbadch.TabIndex = 0
    Me.Labbadch.Text = "不良現象中文"
    Me.Labbadch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'txtreasoncode
    '
    Me.txtreasoncode.BackColor = System.Drawing.Color.AntiqueWhite
    Me.txtreasoncode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtreasoncode.Font = New System.Drawing.Font("SimHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtreasoncode.Location = New System.Drawing.Point(136, 18)
    Me.txtreasoncode.Name = "txtreasoncode"
    Me.txtreasoncode.Size = New System.Drawing.Size(118, 26)
    Me.txtreasoncode.TabIndex = 0
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.TextBox2)
    Me.GroupBox1.Controls.Add(Me.Label3)
    Me.GroupBox1.Controls.Add(Me.TextBox1)
    Me.GroupBox1.Controls.Add(Me.Label2)
    Me.GroupBox1.Controls.Add(Me.Label1)
    Me.GroupBox1.Controls.Add(Me.ComboBox1)
    Me.GroupBox1.Controls.Add(Me.Txtreasonen)
    Me.GroupBox1.Controls.Add(Me.Txtreasonch)
    Me.GroupBox1.Controls.Add(Me.Labbaden)
    Me.GroupBox1.Controls.Add(Me.txtreasoncode)
    Me.GroupBox1.Controls.Add(Me.Labbadch)
    Me.GroupBox1.Controls.Add(Me.Labbadcode)
    Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
    Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(802, 165)
    Me.GroupBox1.TabIndex = 6
    Me.GroupBox1.TabStop = False
    '
    'Txtreasonen
    '
    Me.Txtreasonen.Font = New System.Drawing.Font("SimHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Txtreasonen.Location = New System.Drawing.Point(136, 74)
    Me.Txtreasonen.Name = "Txtreasonen"
    Me.Txtreasonen.Size = New System.Drawing.Size(278, 26)
    Me.Txtreasonen.TabIndex = 2
    '
    'Txtreasonch
    '
    Me.Txtreasonch.BackColor = System.Drawing.Color.AntiqueWhite
    Me.Txtreasonch.Font = New System.Drawing.Font("SimHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Txtreasonch.Location = New System.Drawing.Point(136, 46)
    Me.Txtreasonch.Name = "Txtreasonch"
    Me.Txtreasonch.Size = New System.Drawing.Size(278, 26)
    Me.Txtreasonch.TabIndex = 1
    '
    'Labbaden
    '
    Me.Labbaden.Location = New System.Drawing.Point(6, 77)
    Me.Labbaden.Name = "Labbaden"
    Me.Labbaden.Size = New System.Drawing.Size(127, 21)
    Me.Labbaden.TabIndex = 7
    Me.Labbaden.Text = "不良現象英文"
    Me.Labbaden.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'OpenFileDialog1
    '
    Me.OpenFileDialog1.FileName = "OpenFileDialog1"
    '
    'DGXM
    '
    Me.DGXM.AllowUserToAddRows = False
    Me.DGXM.AllowUserToDeleteRows = False
    Me.DGXM.AllowUserToResizeRows = False
    DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.DGXM.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
    Me.DGXM.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
    Me.DGXM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DGXM.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DGXM.Location = New System.Drawing.Point(0, 165)
    Me.DGXM.MultiSelect = False
    Me.DGXM.Name = "DGXM"
    Me.DGXM.RowTemplate.Height = 24
    Me.DGXM.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DGXM.Size = New System.Drawing.Size(802, 298)
    Me.DGXM.TabIndex = 7
    '
    'ComboBox1
    '
    Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.ComboBox1.FormattingEnabled = True
    Me.ComboBox1.Items.AddRange(New Object() {"MA 主要缺陷", "MI 次要缺陷", "CR 致命缺陷"})
    Me.ComboBox1.Location = New System.Drawing.Point(136, 103)
    Me.ComboBox1.Name = "ComboBox1"
    Me.ComboBox1.Size = New System.Drawing.Size(180, 24)
    Me.ComboBox1.TabIndex = 8
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(6, 105)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(127, 21)
    Me.Label1.TabIndex = 9
    Me.Label1.Text = "缺陷程度"
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TextBox1
    '
    Me.TextBox1.Font = New System.Drawing.Font("SimHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox1.Location = New System.Drawing.Point(136, 130)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(278, 26)
    Me.TextBox1.TabIndex = 10
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(6, 133)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(127, 21)
    Me.Label2.TabIndex = 11
    Me.Label2.Text = "備註"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(428, 18)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(127, 21)
    Me.Label3.TabIndex = 12
    Me.Label3.Text = "詳細不良說明"
    Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TextBox2
    '
    Me.TextBox2.Font = New System.Drawing.Font("SimHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox2.Location = New System.Drawing.Point(451, 42)
    Me.TextBox2.Multiline = True
    Me.TextBox2.Name = "TextBox2"
    Me.TextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both
    Me.TextBox2.Size = New System.Drawing.Size(339, 114)
    Me.TextBox2.TabIndex = 13
    '
    'PM0307
    '
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Me.ClientSize = New System.Drawing.Size(802, 463)
    Me.Controls.Add(Me.DGXM)
    Me.Controls.Add(Me.GroupBox1)
    Me.Font = New System.Drawing.Font("SimHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Name = "PM0307"
    Me.Text = "不良現象0307"
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    CType(Me.DGXM, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
    Friend WithEvents Labbadcode As System.Windows.Forms.Label
    Friend WithEvents Labbadch As System.Windows.Forms.Label
    Friend WithEvents txtreasoncode As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Txtreasonch As System.Windows.Forms.TextBox
    Friend WithEvents Labbaden As System.Windows.Forms.Label
    Friend WithEvents Txtreasonen As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
  Friend WithEvents DGXM As System.Windows.Forms.DataGridView
  Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
  Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
