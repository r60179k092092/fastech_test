Imports FDGV

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm0506A
  Inherits System.Windows.Forms.Form

  'Form 覆寫 Dispose 以清除元件清單。
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

  '為 Windows Form 設計工具的必要項
  Private components As System.ComponentModel.IContainer

  '注意: 以下為 Windows Form 設計工具所需的程序
  '可以使用 Windows Form 設計工具進行修改。
  '請不要使用程式碼編輯器進行修改。
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.DG = New FDGV.FDataGridView()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.TDC02 = New System.Windows.Forms.TextBox()
    Me.isTDC02 = New System.Windows.Forms.CheckBox()
    Me.TBB04 = New System.Windows.Forms.TextBox()
    Me.isTBB04 = New System.Windows.Forms.CheckBox()
    Me.CheckBox3 = New System.Windows.Forms.CheckBox()
    Me.TBB03 = New System.Windows.Forms.ComboBox()
    Me.isTBB03 = New System.Windows.Forms.CheckBox()
    Me.TD01 = New System.Windows.Forms.ComboBox()
    Me.isTD01 = New System.Windows.Forms.CheckBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.DTP2 = New System.Windows.Forms.DateTimePicker()
    Me.Button3 = New System.Windows.Forms.Button()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Button2 = New System.Windows.Forms.Button()
    Me.DTP1 = New System.Windows.Forms.DateTimePicker()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Button4 = New System.Windows.Forms.Button()
    CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'DG
    '
    Me.DG.AllowUserToAddRows = False
    Me.DG.AllowUserToDeleteRows = False
    Me.DG.AllowUserToResizeRows = False
    DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.DG.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
    Me.DG.Append = False
    Me.DG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
    Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DG.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DG.Location = New System.Drawing.Point(0, 134)
    Me.DG.MultiSelect = False
    Me.DG.Name = "DG"
    Me.DG.RowTemplate.Height = 23
    Me.DG.RowWise = False
    Me.DG.SaveSetting = ""
    Me.DG.Size = New System.Drawing.Size(1184, 279)
    Me.DG.TabIndex = 43
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.Button4)
    Me.GroupBox1.Controls.Add(Me.Button1)
    Me.GroupBox1.Controls.Add(Me.TDC02)
    Me.GroupBox1.Controls.Add(Me.isTDC02)
    Me.GroupBox1.Controls.Add(Me.TBB04)
    Me.GroupBox1.Controls.Add(Me.isTBB04)
    Me.GroupBox1.Controls.Add(Me.CheckBox3)
    Me.GroupBox1.Controls.Add(Me.TBB03)
    Me.GroupBox1.Controls.Add(Me.isTBB03)
    Me.GroupBox1.Controls.Add(Me.TD01)
    Me.GroupBox1.Controls.Add(Me.isTD01)
    Me.GroupBox1.Controls.Add(Me.Label3)
    Me.GroupBox1.Controls.Add(Me.DTP2)
    Me.GroupBox1.Controls.Add(Me.Button3)
    Me.GroupBox1.Controls.Add(Me.TextBox1)
    Me.GroupBox1.Controls.Add(Me.Label2)
    Me.GroupBox1.Controls.Add(Me.Button2)
    Me.GroupBox1.Controls.Add(Me.DTP1)
    Me.GroupBox1.Controls.Add(Me.Label1)
    Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
    Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(1184, 134)
    Me.GroupBox1.TabIndex = 44
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "查詢條件"
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(771, 96)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(113, 33)
    Me.Button1.TabIndex = 62
    Me.Button1.Text = "查詢"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'TDC02
    '
    Me.TDC02.Enabled = False
    Me.TDC02.Location = New System.Drawing.Point(545, 61)
    Me.TDC02.Name = "TDC02"
    Me.TDC02.Size = New System.Drawing.Size(73, 30)
    Me.TDC02.TabIndex = 61
    '
    'isTDC02
    '
    Me.isTDC02.AutoSize = True
    Me.isTDC02.Location = New System.Drawing.Point(459, 65)
    Me.isTDC02.Name = "isTDC02"
    Me.isTDC02.Size = New System.Drawing.Size(91, 23)
    Me.isTDC02.TabIndex = 60
    Me.isTDC02.Text = "線別："
    Me.isTDC02.UseVisualStyleBackColor = True
    '
    'TBB04
    '
    Me.TBB04.Enabled = False
    Me.TBB04.Location = New System.Drawing.Point(942, 24)
    Me.TBB04.Name = "TBB04"
    Me.TBB04.Size = New System.Drawing.Size(234, 30)
    Me.TBB04.TabIndex = 59
    '
    'isTBB04
    '
    Me.isTBB04.AutoSize = True
    Me.isTBB04.Location = New System.Drawing.Point(845, 28)
    Me.isTBB04.Name = "isTBB04"
    Me.isTBB04.Size = New System.Drawing.Size(91, 23)
    Me.isTBB04.TabIndex = 58
    Me.isTBB04.Text = "型號："
    Me.isTBB04.UseVisualStyleBackColor = True
    '
    'CheckBox3
    '
    Me.CheckBox3.AutoSize = True
    Me.CheckBox3.Checked = True
    Me.CheckBox3.CheckState = System.Windows.Forms.CheckState.Checked
    Me.CheckBox3.Location = New System.Drawing.Point(630, 65)
    Me.CheckBox3.Name = "CheckBox3"
    Me.CheckBox3.Size = New System.Drawing.Size(175, 23)
    Me.CheckBox3.TabIndex = 57
    Me.CheckBox3.Text = "僅計算首尾工序"
    Me.CheckBox3.UseVisualStyleBackColor = True
    '
    'TBB03
    '
    Me.TBB03.Enabled = False
    Me.TBB03.FormattingEnabled = True
    Me.TBB03.Location = New System.Drawing.Point(114, 63)
    Me.TBB03.Name = "TBB03"
    Me.TBB03.Size = New System.Drawing.Size(298, 27)
    Me.TBB03.TabIndex = 56
    '
    'isTBB03
    '
    Me.isTBB03.AutoSize = True
    Me.isTBB03.Location = New System.Drawing.Point(18, 65)
    Me.isTBB03.Name = "isTBB03"
    Me.isTBB03.Size = New System.Drawing.Size(91, 23)
    Me.isTBB03.TabIndex = 55
    Me.isTBB03.Text = "料號："
    Me.isTBB03.UseVisualStyleBackColor = True
    '
    'TD01
    '
    Me.TD01.Enabled = False
    Me.TD01.FormattingEnabled = True
    Me.TD01.Location = New System.Drawing.Point(545, 26)
    Me.TD01.Name = "TD01"
    Me.TD01.Size = New System.Drawing.Size(263, 27)
    Me.TD01.TabIndex = 54
    '
    'isTD01
    '
    Me.isTD01.AutoSize = True
    Me.isTD01.Location = New System.Drawing.Point(438, 28)
    Me.isTD01.Name = "isTD01"
    Me.isTD01.Size = New System.Drawing.Size(112, 23)
    Me.isTD01.TabIndex = 53
    Me.isTD01.Text = "工單號："
    Me.isTD01.UseVisualStyleBackColor = True
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(253, 30)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(20, 19)
    Me.Label3.TabIndex = 52
    Me.Label3.Text = "-"
    '
    'DTP2
    '
    Me.DTP2.CustomFormat = "yyyy/MM/dd"
    Me.DTP2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
    Me.DTP2.Location = New System.Drawing.Point(273, 24)
    Me.DTP2.Name = "DTP2"
    Me.DTP2.Size = New System.Drawing.Size(139, 30)
    Me.DTP2.TabIndex = 51
    '
    'Button3
    '
    Me.Button3.Location = New System.Drawing.Point(1105, 96)
    Me.Button3.Name = "Button3"
    Me.Button3.Size = New System.Drawing.Size(64, 33)
    Me.Button3.TabIndex = 49
    Me.Button3.Text = "離開"
    Me.Button3.UseVisualStyleBackColor = True
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(114, 97)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(651, 30)
    Me.TextBox1.TabIndex = 48
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(37, 102)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(72, 19)
    Me.Label2.TabIndex = 47
    Me.Label2.Text = "檔名："
    '
    'Button2
    '
    Me.Button2.Location = New System.Drawing.Point(904, 96)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(181, 33)
    Me.Button2.TabIndex = 46
    Me.Button2.Text = "產生Excel報表"
    Me.Button2.UseVisualStyleBackColor = True
    '
    'DTP1
    '
    Me.DTP1.CustomFormat = "yyyy/MM/dd"
    Me.DTP1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
    Me.DTP1.Location = New System.Drawing.Point(114, 24)
    Me.DTP1.Name = "DTP1"
    Me.DTP1.Size = New System.Drawing.Size(139, 30)
    Me.DTP1.TabIndex = 40
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(37, 30)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(72, 19)
    Me.Label1.TabIndex = 44
    Me.Label1.Text = "日期："
    '
    'Button4
    '
    Me.Button4.Location = New System.Drawing.Point(845, 60)
    Me.Button4.Name = "Button4"
    Me.Button4.Size = New System.Drawing.Size(240, 33)
    Me.Button4.TabIndex = 63
    Me.Button4.Text = "存入損失工時及備註"
    Me.Button4.UseVisualStyleBackColor = True
    '
    'Frm0506A
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 19.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1184, 413)
    Me.Controls.Add(Me.DG)
    Me.Controls.Add(Me.GroupBox1)
    Me.Font = New System.Drawing.Font("細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
    Me.Name = "Frm0506A"
    Me.Text = "生產統計報表"
    CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents DG As FDataGridView
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents DTP2 As System.Windows.Forms.DateTimePicker
  Friend WithEvents Button3 As System.Windows.Forms.Button
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents DTP1 As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TDC02 As System.Windows.Forms.TextBox
  Friend WithEvents isTDC02 As System.Windows.Forms.CheckBox
  Friend WithEvents TBB04 As System.Windows.Forms.TextBox
  Friend WithEvents isTBB04 As System.Windows.Forms.CheckBox
  Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
  Friend WithEvents TBB03 As System.Windows.Forms.ComboBox
  Friend WithEvents isTBB03 As System.Windows.Forms.CheckBox
  Friend WithEvents TD01 As System.Windows.Forms.ComboBox
  Friend WithEvents isTD01 As System.Windows.Forms.CheckBox
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents Button4 As System.Windows.Forms.Button
End Class
