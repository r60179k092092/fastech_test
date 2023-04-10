<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm0330
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
    Me.DG = New System.Windows.Forms.DataGridView()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.btnFileSele = New System.Windows.Forms.Button()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.txtVerdor = New System.Windows.Forms.TextBox()
    Me.txtBatchNO = New System.Windows.Forms.TextBox()
    Me.txtPartNO = New System.Windows.Forms.TextBox()
    Me.txtCode = New System.Windows.Forms.TextBox()
    Me.txtFilePath = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Panel3 = New System.Windows.Forms.Panel()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.btnPrev = New System.Windows.Forms.Button()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.ComboBox1 = New System.Windows.Forms.ComboBox()
    Me.Label3 = New System.Windows.Forms.Label()
    CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.Panel3.SuspendLayout()
    Me.SuspendLayout()
    '
    'DG
    '
    Me.DG.AllowUserToAddRows = False
    Me.DG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
    Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DG.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DG.Location = New System.Drawing.Point(0, 110)
    Me.DG.Margin = New System.Windows.Forms.Padding(4)
    Me.DG.Name = "DG"
    Me.DG.ReadOnly = True
    Me.DG.RowTemplate.Height = 24
    Me.DG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DG.Size = New System.Drawing.Size(984, 518)
    Me.DG.TabIndex = 0
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(793, 12)
    Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(93, 19)
    Me.Label1.TabIndex = 13
    Me.Label1.Text = "檢驗判定"
    '
    'btnFileSele
    '
    Me.btnFileSele.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnFileSele.Location = New System.Drawing.Point(795, 41)
    Me.btnFileSele.Name = "btnFileSele"
    Me.btnFileSele.Size = New System.Drawing.Size(35, 30)
    Me.btnFileSele.TabIndex = 11
    Me.btnFileSele.Text = "..."
    Me.btnFileSele.UseVisualStyleBackColor = True
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(448, 81)
    Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(93, 19)
    Me.Label6.TabIndex = 8
    Me.Label6.Text = "廠商編號"
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(230, 81)
    Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(51, 19)
    Me.Label5.TabIndex = 7
    Me.Label5.Text = "批號"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(51, 81)
    Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(51, 19)
    Me.Label4.TabIndex = 6
    Me.Label4.Text = "料號"
    '
    'txtVerdor
    '
    Me.txtVerdor.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.txtVerdor.Location = New System.Drawing.Point(542, 75)
    Me.txtVerdor.Margin = New System.Windows.Forms.Padding(4)
    Me.txtVerdor.Name = "txtVerdor"
    Me.txtVerdor.ReadOnly = True
    Me.txtVerdor.Size = New System.Drawing.Size(111, 30)
    Me.txtVerdor.TabIndex = 2
    Me.txtVerdor.TabStop = False
    '
    'txtBatchNO
    '
    Me.txtBatchNO.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.txtBatchNO.Location = New System.Drawing.Point(282, 75)
    Me.txtBatchNO.Margin = New System.Windows.Forms.Padding(4)
    Me.txtBatchNO.Name = "txtBatchNO"
    Me.txtBatchNO.ReadOnly = True
    Me.txtBatchNO.Size = New System.Drawing.Size(155, 30)
    Me.txtBatchNO.TabIndex = 1
    Me.txtBatchNO.TabStop = False
    '
    'txtPartNO
    '
    Me.txtPartNO.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.txtPartNO.Location = New System.Drawing.Point(108, 75)
    Me.txtPartNO.Margin = New System.Windows.Forms.Padding(4)
    Me.txtPartNO.Name = "txtPartNO"
    Me.txtPartNO.ReadOnly = True
    Me.txtPartNO.Size = New System.Drawing.Size(111, 30)
    Me.txtPartNO.TabIndex = 0
    Me.txtPartNO.TabStop = False
    '
    'txtCode
    '
    Me.txtCode.BackColor = System.Drawing.Color.AntiqueWhite
    Me.txtCode.Location = New System.Drawing.Point(109, 6)
    Me.txtCode.Margin = New System.Windows.Forms.Padding(4)
    Me.txtCode.Name = "txtCode"
    Me.txtCode.Size = New System.Drawing.Size(541, 30)
    Me.txtCode.TabIndex = 1
    '
    'txtFilePath
    '
    Me.txtFilePath.BackColor = System.Drawing.Color.AntiqueWhite
    Me.txtFilePath.Location = New System.Drawing.Point(109, 41)
    Me.txtFilePath.Margin = New System.Windows.Forms.Padding(4)
    Me.txtFilePath.Name = "txtFilePath"
    Me.txtFilePath.Size = New System.Drawing.Size(678, 30)
    Me.txtFilePath.TabIndex = 3
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(9, 47)
    Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(93, 19)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "檢驗檔案"
    '
    'Panel3
    '
    Me.Panel3.Controls.Add(Me.TextBox1)
    Me.Panel3.Controls.Add(Me.btnPrev)
    Me.Panel3.Controls.Add(Me.Label7)
    Me.Panel3.Controls.Add(Me.ComboBox1)
    Me.Panel3.Controls.Add(Me.Label1)
    Me.Panel3.Controls.Add(Me.Label3)
    Me.Panel3.Controls.Add(Me.txtVerdor)
    Me.Panel3.Controls.Add(Me.Label6)
    Me.Panel3.Controls.Add(Me.txtCode)
    Me.Panel3.Controls.Add(Me.Label5)
    Me.Panel3.Controls.Add(Me.txtBatchNO)
    Me.Panel3.Controls.Add(Me.btnFileSele)
    Me.Panel3.Controls.Add(Me.Label4)
    Me.Panel3.Controls.Add(Me.txtFilePath)
    Me.Panel3.Controls.Add(Me.txtPartNO)
    Me.Panel3.Controls.Add(Me.Label2)
    Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel3.Location = New System.Drawing.Point(0, 0)
    Me.Panel3.Name = "Panel3"
    Me.Panel3.Size = New System.Drawing.Size(984, 110)
    Me.Panel3.TabIndex = 1
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(714, 5)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(72, 30)
    Me.TextBox1.TabIndex = 15
    Me.TextBox1.TabStop = False
    '
    'btnPrev
    '
    Me.btnPrev.Location = New System.Drawing.Point(843, 41)
    Me.btnPrev.Name = "btnPrev"
    Me.btnPrev.Size = New System.Drawing.Size(116, 59)
    Me.btnPrev.TabIndex = 4
    Me.btnPrev.Text = "預覽檔案"
    Me.btnPrev.UseVisualStyleBackColor = True
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(657, 11)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(51, 19)
    Me.Label7.TabIndex = 14
    Me.Label7.Text = "版次"
    '
    'ComboBox1
    '
    Me.ComboBox1.FormattingEnabled = True
    Me.ComboBox1.Items.AddRange(New Object() {"OK", "NG", "N/A"})
    Me.ComboBox1.Location = New System.Drawing.Point(892, 8)
    Me.ComboBox1.Name = "ComboBox1"
    Me.ComboBox1.Size = New System.Drawing.Size(67, 27)
    Me.ComboBox1.TabIndex = 2
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(9, 12)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(93, 19)
    Me.Label3.TabIndex = 0
    Me.Label3.Text = "物料條碼"
    '
    'frm0330
    '
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Me.ClientSize = New System.Drawing.Size(984, 628)
    Me.Controls.Add(Me.DG)
    Me.Controls.Add(Me.Panel3)
    Me.Font = New System.Drawing.Font("細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
    Me.Margin = New System.Windows.Forms.Padding(4)
    Me.Name = "frm0330"
    Me.Text = "IQC來料檢驗建立0330"
    CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
    Me.Panel3.ResumeLayout(False)
    Me.Panel3.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents DG As System.Windows.Forms.DataGridView
  Friend WithEvents txtCode As System.Windows.Forms.TextBox
  Friend WithEvents txtFilePath As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents txtVerdor As System.Windows.Forms.TextBox
  Friend WithEvents txtBatchNO As System.Windows.Forms.TextBox
  Friend WithEvents txtPartNO As System.Windows.Forms.TextBox
  Friend WithEvents btnFileSele As System.Windows.Forms.Button
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Panel3 As System.Windows.Forms.Panel
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents btnPrev As System.Windows.Forms.Button
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
