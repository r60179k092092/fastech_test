<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DRAGN
  Inherits System.Windows.Forms.UserControl

  'UserControl 覆寫 Dispose 以清除元件清單。
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
    Me.components = New System.ComponentModel.Container()
    Me.TL = New System.Windows.Forms.Label()
    Me.MR = New System.Windows.Forms.Label()
    Me.BM = New System.Windows.Forms.Label()
    Me.BR = New System.Windows.Forms.Label()
    Me.CMS = New System.Windows.Forms.ContextMenuStrip(Me.components)
    Me.DELETE = New System.Windows.Forms.ToolStripMenuItem()
    Me.COPY = New System.Windows.Forms.ToolStripMenuItem()
    Me.COPYX = New System.Windows.Forms.ToolStripMenuItem()
    Me.CMS.SuspendLayout()
    Me.SuspendLayout()
    '
    'TL
    '
    Me.TL.BackColor = System.Drawing.Color.White
    Me.TL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.TL.Cursor = System.Windows.Forms.Cursors.SizeAll
    Me.TL.Location = New System.Drawing.Point(8, 20)
    Me.TL.Margin = New System.Windows.Forms.Padding(0)
    Me.TL.Name = "TL"
    Me.TL.Size = New System.Drawing.Size(7, 7)
    Me.TL.TabIndex = 0
    Me.TL.Visible = False
    '
    'MR
    '
    Me.MR.BackColor = System.Drawing.Color.White
    Me.MR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.MR.Cursor = System.Windows.Forms.Cursors.SizeWE
    Me.MR.Location = New System.Drawing.Point(104, 40)
    Me.MR.Margin = New System.Windows.Forms.Padding(0)
    Me.MR.Name = "MR"
    Me.MR.Size = New System.Drawing.Size(7, 7)
    Me.MR.TabIndex = 1
    Me.MR.Visible = False
    '
    'BM
    '
    Me.BM.BackColor = System.Drawing.Color.White
    Me.BM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.BM.Cursor = System.Windows.Forms.Cursors.SizeNS
    Me.BM.Location = New System.Drawing.Point(49, 64)
    Me.BM.Margin = New System.Windows.Forms.Padding(0)
    Me.BM.Name = "BM"
    Me.BM.Size = New System.Drawing.Size(7, 7)
    Me.BM.TabIndex = 6
    Me.BM.Visible = False
    '
    'BR
    '
    Me.BR.BackColor = System.Drawing.Color.White
    Me.BR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.BR.Cursor = System.Windows.Forms.Cursors.SizeNWSE
    Me.BR.Location = New System.Drawing.Point(104, 64)
    Me.BR.Margin = New System.Windows.Forms.Padding(0)
    Me.BR.Name = "BR"
    Me.BR.Size = New System.Drawing.Size(7, 7)
    Me.BR.TabIndex = 7
    Me.BR.Visible = False
    '
    'CMS
    '
    Me.CMS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DELETE, Me.COPY, Me.COPYX})
    Me.CMS.Name = "ContextMenuStrip1"
    Me.CMS.Size = New System.Drawing.Size(125, 70)
    '
    'DELETE
    '
    Me.DELETE.Name = "DELETE"
    Me.DELETE.Size = New System.Drawing.Size(124, 22)
    Me.DELETE.Text = "刪除"
    '
    'COPY
    '
    Me.COPY.Name = "COPY"
    Me.COPY.Size = New System.Drawing.Size(124, 22)
    Me.COPY.Text = "複製"
    '
    'COPYX
    '
    Me.COPYX.Name = "COPYX"
    Me.COPYX.Size = New System.Drawing.Size(124, 22)
    Me.COPYX.Text = "多重複製"
    '
    'DRAGN
    '
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Me.AutoSize = True
    Me.BackColor = System.Drawing.Color.Transparent
    Me.Controls.Add(Me.BR)
    Me.Controls.Add(Me.BM)
    Me.Controls.Add(Me.MR)
    Me.Controls.Add(Me.TL)
    Me.Cursor = System.Windows.Forms.Cursors.Hand
    Me.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Margin = New System.Windows.Forms.Padding(0)
    Me.Name = "DRAGN"
    Me.Size = New System.Drawing.Size(172, 164)
    Me.CMS.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents TL As System.Windows.Forms.Label
  Friend WithEvents MR As System.Windows.Forms.Label
  Friend WithEvents BM As System.Windows.Forms.Label
  Friend WithEvents BR As System.Windows.Forms.Label
  Friend WithEvents CMS As System.Windows.Forms.ContextMenuStrip
  Friend WithEvents DELETE As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents COPY As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents COPYX As System.Windows.Forms.ToolStripMenuItem

End Class
