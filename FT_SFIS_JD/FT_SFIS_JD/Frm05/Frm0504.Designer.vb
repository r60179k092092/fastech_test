<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm0504
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
    Me.btnQuit = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'btnQuit
    '
    Me.btnQuit.Location = New System.Drawing.Point(12, 12)
    Me.btnQuit.Name = "btnQuit"
    Me.btnQuit.Size = New System.Drawing.Size(126, 46)
    Me.btnQuit.TabIndex = 26
    Me.btnQuit.Text = "離開"
    Me.btnQuit.UseVisualStyleBackColor = True
    '
    'Frm0504
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(968, 589)
    Me.Controls.Add(Me.btnQuit)
    Me.Name = "Frm0504"
    Me.Text = "老化數據紀錄表"
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents btnQuit As System.Windows.Forms.Button
End Class
