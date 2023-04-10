Imports System.Runtime.Remoting.Messaging

Public Class FrmMain
  'Private UpOrDown1, UpOrDown2, UpOrDown3, sz As Boolean
  'Private yin As Boolean = True
  Private bolT As Boolean = False
  Private bolF As Boolean = False
  Private bolRT As Boolean = False
  ' Dim lastnode As TreeNode

  'Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
  '    Try
  '        If yin = True Then
  '            Panel3.Width = Panel3.Width - 20
  '            If Panel3.Width = 0 Then
  '                yin = False
  '                Timer2.Enabled = False
  '            End If
  '        Else
  '            Panel3.Width = Panel3.Width + 20
  '            If Panel3.Width >= 160 Then
  '                yin = True
  '                Timer2.Enabled = False
  '            End If
  '        End If
  '    Catch ex As Exception
  '        Timer2.Enabled = False
  '    End Try
  'End Sub

  Private Sub FrmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    If My.Application.OpenForms.Count > 1 Then
      If MsgBox(BIG2GB("部分作業尚未結束，是否先結束清空？"), vbYesNo, BIG2GB("結束作業")) = MsgBoxResult.No Then
        e.Cancel = True
      End If
      For Each tp As TabPage In TabControl1.TabPages
        Dim s As Control = tp.Controls(0)
        If s.GetType.BaseType Is GetType(Form) Then
          DirectCast(s, Form).Close()
        End If
      Next
    End If
    e.Cancel = False
  End Sub
  Sub New()
    ' 此調用是設計器所必需的。
    InitializeComponent()
    ' 在 InitializeComponent() 調用之后添加任何初始化。
    languagechange(Me)
  End Sub

  Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Me.Hide()
    Dim frm As New FrmLogin
    frm.ShowDialog()
    If DB Is Nothing OrElse DB.Active = False Then
      End
    End If
    If lgnaccess = "" Then
      End
    End If
    Dim svdt As DateTime = DB.ExecuteScalar("select getdate()")
    Try
      Today = svdt.Date
      TimeOfDay = FormatDateTime(svdt, DateFormat.LongTime)
    Catch ex As Exception
      'MsgBox("權限無法修改日期" & ex.Message)
    End Try
    Lablogininfor.Text = BIG2GB("用戶：" & lgnname & "    登錄時間：" & Now.ToString("HH:mm:ss"))
    strAPATH = System.Windows.Forms.Application.StartupPath
    If IO.Directory.Exists(strAPATH & "\bin\Debug") = True Then
      strAPATH &= "\bin\Debug"
    End If
    bolRT = True
    clsMenus.LoadMenu()
    clsMenus.BulidMenu(TreeView1)
    clsRTS = New clsRights()
    clsRTS.Name = "AURTS_SFC"
    clsRTS.LoadNew(TreeView1, False)
    clsRTS.InitRights(lgnaccess)
    clsRTS.SetRight(TreeView1, lgnaccess)
    FlowTW()
    If My.Application.IsNetworkDeployed Then
      TSSlgs1.Text = My.Application.Deployment.CurrentVersion.ToString()
    Else
      TSSlgs1.Text = My.Application.Info.Version.ToString()
    End If
    Dim strDBSP As String = My.Settings.db
    If DBERP IsNot Nothing AndAlso DBERP.Active = True Then
      strDBSP &= ",K3=" & My.Settings.ODBC_DB
    End If
    If DBFERP IsNot Nothing AndAlso DBFERP.Active = True Then
      strDBSP &= ",FERP=" & My.Settings.FTDB
    End If
    Labeljt.Text = BIG2GB("  數據庫名【") & strDBSP & "】"
    Panel2.BackgroundImage = GetImage("MAIN_SFC")
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_QTN")
    sqlCV.SqlFields("QTN01", , , , True)
    sqlCV.SqlFields("QTN02", , , , True)
    sqlCV.SqlFields("QTN03")
    sqlCV.SqlFields("QTN04")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    clsQTN = New QTNLIST(rs)
    clsQTN.Language = My.Settings.language
    bolF = True
    Me.Show()
    Me.WindowState = FormWindowState.Maximized
  End Sub

  Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    If bolF Then
      Dim s As Bitmap = GetImage("Top_SFC.jpg")
      Panel1.BackgroundImage = s
      Panel13.BackgroundImage = GetImage("TopLeft_SFC.jpg")
      bolF = False
    End If
    Label19.Text = Now.ToLongDateString & " " & Now.ToString("dddd") & " " & Now.ToLongTimeString
  End Sub

  Public Sub ShowTabFrm(strN As String)
    Dim x As clsSFIS_PGS = clsMenus.GetID(strN)
    If x Is Nothing OrElse x.FormName = "" OrElse x.HasRight = False Then Return
    Dim controlName As String = x.FormName
    If My.Application.OpenForms.Item(controlName) Is Nothing Then
      Dim f As Form = clsMenus.GetForm(x.FormName)
      If f Is Nothing Then Return
      f.Tag = x.PATH
      Select Case x.StartMode
        Case frmStartMode.Active, frmStartMode.ActiveAsNew
          NewFM(f, x.Head, controlName, Me.TabControl1)
        Case frmStartMode.ShowDialog, frmStartMode.ShowDiaLogAsNew
          f.ShowDialog()
        Case frmStartMode.ShowFrm, frmStartMode.ShowFrmAsNew
          f.Show()
      End Select
    Else
      ShowTabpage(controlName, Me.TabControl1)
    End If
  End Sub
  Private Sub FlowTW()
    bolRT = True
    For Each n As TreeNode In TreeView1.Nodes
      n.Text = BIG2GB(n.Text.Trim)
      Dim intL As Integer = GetLenB(n.Text)
      If intL < 22 Then
        n.Text = n.Text & Space(22 - intL)
      End If
      n.ToolTipText = ""
      If n.Nodes.Count > 0 Then
        FlowND(n)
      End If
    Next
    bolRT = False
  End Sub
  Private Sub FlowND(n As TreeNode)
    For Each n1 As TreeNode In n.Nodes
      n1.Text = BIG2GB(n1.Text.Trim)
      Dim intL As Integer = GetLenB(n1.Text)
      If intL < 21 - n1.Level Then
        n1.Text = n1.Text & Space(21 - n1.Level - intL)
      End If
      n1.ToolTipText = ""
      If n1.Nodes.Count > 0 Then
        FlowND(n1)
      End If
    Next
  End Sub

  Private Sub TreeView1_BeforeExpand(sender As Object, e As TreeViewCancelEventArgs) Handles TreeView1.BeforeExpand
    If e.Node.Tag = "L" Then
      e.Cancel = True
    End If
  End Sub
  Private Sub TreeView1_DrawNode(sender As Object, e As DrawTreeNodeEventArgs) Handles TreeView1.DrawNode
    If bolRT Or e.Node.IsVisible = False Then Return
    Dim rgt As New Rectangle(e.Node.Bounds.X, e.Node.Bounds.Y + 2, TreeView1.Size.Width - 30 - e.Node.Bounds.X, e.Node.Bounds.Height - 4)
    Dim bmpx As Bitmap = My.Resources._09
    e.Graphics.DrawImage(bmpx, rgt)
    Dim fmt As New System.Drawing.StringFormat
    fmt.LineAlignment = StringAlignment.Center
    fmt.Alignment = StringAlignment.Center
    fmt.FormatFlags = StringFormatFlags.FitBlackBox + StringFormatFlags.NoWrap
    If e.Node.Tag = "L" Then
      e.Graphics.DrawString(e.Node.Text.Trim, TreeView1.Font, New SolidBrush(Color.DarkBlue), New Rectangle(rgt.X, rgt.Y + 3, rgt.Width, rgt.Height), fmt)
      Dim x As clsSFIS_PGS = clsMenus.GetID(e.Node.Name)
      If x Is Nothing Then Return
      x.HasRight = False
    Else
      e.Graphics.DrawString(e.Node.Text.Trim, TreeView1.Font, New SolidBrush(Color.DarkBlue), New Rectangle(rgt.X + 1, rgt.Y + 4, rgt.Width, rgt.Height), fmt)
      e.Graphics.DrawString(e.Node.Text.Trim, TreeView1.Font, New SolidBrush(Color.DarkBlue), New Rectangle(rgt.X + 2, rgt.Y + 5, rgt.Width, rgt.Height), fmt)
      e.Graphics.DrawString(e.Node.Text.Trim, TreeView1.Font, New SolidBrush(Color.White), New Rectangle(rgt.X, rgt.Y + 3, rgt.Width, rgt.Height), fmt)
      Dim x As clsSFIS_PGS = clsMenus.GetID(e.Node.Name)
      If x Is Nothing Then Return
      x.HasRight = True
    End If
  End Sub

  Private Sub TreeView1_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
    If e.Node.Name = "WINEXIT" Then
      Me.Close()
      Return
    ElseIf e.Node.Name = "WINLOGIN" Then
      If My.Application.OpenForms.Count > 1 Then
        If MsgBox(BIG2GB("部分作業尚未結束，是否先結束清空？"), vbYesNo, BIG2GB("登出")) = MsgBoxResult.No Then Return
        For Each tp As TabPage In TabControl1.TabPages
          Dim s As Control = tp.Controls(0)
          If s.GetType.BaseType Is GetType(Form) Then
            DirectCast(s, Form).Close()
          End If
        Next
      End If
      Lablogininfor.Text = BIG2GB("登入中")
      Dim frm As New FrmLogin
      frm.ShowDialog()
      Lablogininfor.Text = BIG2GB("用戶：" & lgnname & "    登錄時間：" & Now.ToString("HH:mm:ss"))
      bolRT = True
      clsRTS.SetRight(TreeView1, lgnaccess)
      FlowTW()
      Return
    ElseIf e.Node.Name = "WINRESET" Then
      For Each tp As TabPage In TabControl1.TabPages
        Dim s As Control = tp.Controls(0)
        If s.GetType.BaseType Is GetType(Form) Then
          DirectCast(s, Form).Close()
        End If
      Next
      Return
    End If
    ShowTabFrm(e.Node.Name)
  End Sub
End Class
