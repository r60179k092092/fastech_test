

Module Module1
  Public UCode As String = ""
  Public clsQTN As QTNLIST = Nothing
  '' </summary>
  ''判斷是否已經存在該窗體
  '' </summary>
  '' <param name="MainTabControlKey">選項卡的鍵值</param>
  '' <param name="objTabControl">要添加到的TabControl對象</param>
  '' <returns></returns>
  Private Function ErgodicModiForm(ByVal MainTabControlKey As String, ByVal objTabControl As TabControl) As [Boolean]
    '遍歷選項卡判斷是否存在該子窗體.
    For Each tItem As TabPage In objTabControl.TabPages
      If tItem.Name.ToUpper = MainTabControlKey.ToUpper Then
        '存在
        Return False
      End If
    Next
    Return True
    '不存在
  End Function
  ''' <summary>
  ''' 新建窗口
  ''' </summary>
  ''' <param name="fm"></param>
  ''' <param name="formTitle"></param>
  ''' <param name="controlName"></param>
  ''' <param name="TControl"></param>
  ''' <remarks></remarks>
  Public Sub NewFM(ByVal fm As Form, ByVal formTitle As String, ByVal controlName As String, ByVal TControl As TabControl)
    fm.MdiParent = FrmMain
    If ErgodicModiForm(controlName, TControl) Then
      Dim NTabPage As New TabPage
      NTabPage.Text = formTitle
      NTabPage.Name = controlName
      NTabPage.ToolTipText = fm.Name & " " & fm.Tag
      fm.Name = controlName
      fm.FormBorderStyle = FormBorderStyle.None
      fm.Dock = DockStyle.Fill
      NTabPage.Controls.Add(DirectCast(fm, Control))
      TControl.TabPages.Add(NTabPage)
      TControl.SelectedTab = NTabPage
      My.Application.DoEvents()
      fm.SuspendLayout()
      fm.Show()
      fm.ResumeLayout()
      TControl.ShowToolTips = True
    Else
      TControl.SelectedTab = TControl.TabPages.Item(controlName)
    End If
  End Sub
  ''' <summary>
  ''' 顯示指定tab
  ''' </summary>
  ''' <param name="controlName"></param>
  ''' <param name="TControl"></param>
  ''' <remarks></remarks>
  Public Sub ShowTabpage(ByVal controlName As String, ByVal TControl As TabControl)
    TControl.SelectedTab = TControl.TabPages.Item(controlName)
  End Sub
  ''' <summary> 
  ''' 退去窗口時移除他的tabpage 
  ''' </summary> 
  ''' <param name="fm"></param> 
  ''' <remarks></remarks> 
  Public Sub TuiCK(ByVal fm As Form)
    For Each tItem As TabPage In FrmMain.TabControl1.TabPages
      If tItem.Name.ToUpper = fm.Name.ToUpper Then
        FrmMain.TabControl1.TabPages.Remove(tItem)
        Exit For
      End If
    Next
  End Sub

End Module
