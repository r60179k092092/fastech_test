<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMulCopy
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
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Cols = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Rows = New System.Windows.Forms.TextBox()
    Me.XStep = New System.Windows.Forms.TextBox()
    Me.Ystep = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.AutoCode = New System.Windows.Forms.CheckBox()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.Button2 = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(4, 8)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(145, 20)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "複製行(Columns)："
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(28, 41)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(123, 20)
    Me.Label2.TabIndex = 1
    Me.Label2.Text = "複製列(Rows)："
    '
    'Cols
    '
    Me.Cols.Location = New System.Drawing.Point(147, 3)
    Me.Cols.Name = "Cols"
    Me.Cols.Size = New System.Drawing.Size(41, 26)
    Me.Cols.TabIndex = 0
    Me.Cols.Text = "1"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(196, 8)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(73, 20)
    Me.Label3.TabIndex = 3
    Me.Label3.Text = "行間距："
    '
    'Rows
    '
    Me.Rows.Location = New System.Drawing.Point(147, 36)
    Me.Rows.Name = "Rows"
    Me.Rows.Size = New System.Drawing.Size(41, 26)
    Me.Rows.TabIndex = 2
    Me.Rows.Text = "1"
    '
    'XStep
    '
    Me.XStep.Location = New System.Drawing.Point(267, 3)
    Me.XStep.Name = "XStep"
    Me.XStep.Size = New System.Drawing.Size(57, 26)
    Me.XStep.TabIndex = 1
    Me.XStep.Text = "0"
    '
    'Ystep
    '
    Me.Ystep.Location = New System.Drawing.Point(267, 36)
    Me.Ystep.Name = "Ystep"
    Me.Ystep.Size = New System.Drawing.Size(57, 26)
    Me.Ystep.TabIndex = 3
    Me.Ystep.Text = "0"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(196, 41)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(73, 20)
    Me.Label4.TabIndex = 7
    Me.Label4.Text = "列間距："
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(212, 69)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(114, 20)
    Me.Label6.TabIndex = 9
    Me.Label6.Text = "0表示自動間距"
    '
    'AutoCode
    '
    Me.AutoCode.AutoSize = True
    Me.AutoCode.Checked = True
    Me.AutoCode.CheckState = System.Windows.Forms.CheckState.Checked
    Me.AutoCode.Location = New System.Drawing.Point(12, 68)
    Me.AutoCode.Name = "AutoCode"
    Me.AutoCode.Size = New System.Drawing.Size(156, 24)
    Me.AutoCode.TabIndex = 4
    Me.AutoCode.Text = "變量尾碼自動增量"
    Me.AutoCode.UseVisualStyleBackColor = True
    '
    'Button1
    '
    Me.Button1.DialogResult = System.Windows.Forms.DialogResult.OK
    Me.Button1.Location = New System.Drawing.Point(7, 94)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(80, 39)
    Me.Button1.TabIndex = 5
    Me.Button1.TabStop = False
    Me.Button1.Text = "確定"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'Button2
    '
    Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Button2.Location = New System.Drawing.Point(108, 94)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(80, 39)
    Me.Button2.TabIndex = 13
    Me.Button2.TabStop = False
    Me.Button2.Text = "取消"
    Me.Button2.UseVisualStyleBackColor = True
    '
    'frmMulCopy
    '
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Me.ClientSize = New System.Drawing.Size(375, 137)
    Me.ControlBox = False
    Me.Controls.Add(Me.Button2)
    Me.Controls.Add(Me.Button1)
    Me.Controls.Add(Me.AutoCode)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Ystep)
    Me.Controls.Add(Me.XStep)
    Me.Controls.Add(Me.Rows)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Cols)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Margin = New System.Windows.Forms.Padding(4)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frmMulCopy"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "多重複製"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Cols As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Rows As System.Windows.Forms.TextBox
  Friend WithEvents XStep As System.Windows.Forms.TextBox
  Friend WithEvents Ystep As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents AutoCode As System.Windows.Forms.CheckBox
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
