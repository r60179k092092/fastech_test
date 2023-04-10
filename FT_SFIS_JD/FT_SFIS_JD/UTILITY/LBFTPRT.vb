Imports LABTRANx64.Labtran
Imports LABTRANx64
Public Class LBFTPRT
  Private strLBF As String = ""
  Private strLBFX As String = ""
  Private bmps As Bitmap = Nothing
  Sub New()

    ' 此為設計工具所需的呼叫。
    InitializeComponent()

    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
    languagechange(Me)
  End Sub
  Public Property LBFName As String
    Get
      Return strLBFX
    End Get
    Set(value As String)
      bmps = Nothing
      If value = "" Then
        strLBFX = ""
        strLBF = ""
        Return
      End If
      Dim sqlCV As New APSQL.SQLCNV
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_QTN")
      sqlCV.Where("QTN01", "=", "#LBFX")
      sqlCV.Where("QTN02", "=", value)
      sqlCV.SqlFields("*")
      Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
      If rs.Rows.Count = 0 Then
        strLBFX = ""
        strLBF = ""
        Return
      Else
        Dim bytV() As Byte = rs.Rows(0)!QTN05
        If bytV Is Nothing OrElse bytV.Length = 0 Then
          strLBFX = ""
          strLBF = ""
          Return
        Else
          strLBFX = value
          strLBF = System.Text.Encoding.UTF8.GetString(bytV)
          sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_QTN")
          sqlCV.Where("QTN01", "=", "#LABELS")
          sqlCV.Where("QTN02", "=", strLBFX)
          sqlCV.SqlFields("*")
          rs = DB.RsSQL(sqlCV.Text, "RT")
          If rs.Rows.Count > 0 Then
            bytV = rs.Rows(0)!QTN05
            If bytV Is Nothing OrElse bytV.Length = 0 Then
              Return
            Else
              Dim fs As New IO.MemoryStream
              fs.Write(bytV, 0, bytV.Length)
              bmps = New Bitmap(fs)
              fs.Close()
              fs.Dispose()
            End If
          End If
        End If
      End If
    End Set
  End Property
  Private Sub LBFTPRT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim rs As DataTable
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_QTN")
    sqlCV.Where("QTN01", "=", "PRINTERS")
    sqlCV.SqlFields("QTN02")
    sqlCV.SqlFields("QTN03")
    sqlCV.SqlFields("QTN02 + ' ' + QTN03", "DATAS")
    rs = DB.RsSQL(sqlCV.Text, "RQP")
    CB1.DisplayMember = "DATAS"
    CB1.ValueMember = "QTN02"
    CB1.DataSource = rs
    CB1.SelectedValue = My.Settings.LABPTYPE
    If CB1.SelectedValue Is Nothing AndAlso rs.Rows.Count > 0 Then
      CB1.SelectedValue = rs.Rows(0)!QTN02.ToString.Trim
    End If
    CB2.Items.Clear()
    For Each strK As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
      CB2.Items.Add(strK)
    Next
    CB2.Items.Add("none")
    CB2.SelectedIndex = CB2.Items.IndexOf(My.Settings.LABPRT)
    If CB2.SelectedIndex < 0 Then CB2.SelectedIndex = 0
  End Sub

  Private Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
    If bmps IsNot Nothing Then
      My.Computer.Clipboard.SetImage(bmps)
      MsgBox(BIG2GB("圖片已經放入剪貼簿請自行黏貼到文檔"))
    End If
  End Sub
  Private Sub GetPictures(s As LABTRANx64.Labtran.PictCell, strF As String, ByRef bmpX As Bitmap)
    If strF.StartsWith("@") Then
      strF = strF.Substring(1)
      bmpX = My.Resources.ResourceManager.GetObject(strF)
      If bmpX IsNot Nothing Then Return
    Else
      If IO.File.Exists(strF) = True Then Return
      strF = IO.Path.GetFileNameWithoutExtension(strF)
    End If
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_QTN")
    sqlCV.Where("QTN01", "=", "@LBFIMAGES")
    sqlCV.Where("QTN02", "=", strF)
    sqlCV.SqlFields("QTN05")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    If rs.Rows.Count = 0 Then
      bmpX = My.Resources.ResourceManager.GetObject(strF)
      Return
    End If
    If rs.Rows(0)!QTN05.GetType Is GetType(DBNull) Then Return
    Dim bytV() As Byte = rs.Rows(0)!QTN05
    Dim stm As New IO.MemoryStream
    stm.Write(bytV, 0, bytV.Length)
    bmpX = New Bitmap(stm)
    stm.Close()
    stm.Dispose()
    Return
  End Sub

  Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
    If CB1.SelectedItem Is Nothing Then Return
    If strLBF = "" Then Return
    Me.Enabled = False
    Dim r As DataRowView = CB1.SelectedItem
    Dim strPrt As String = CB2.Text.Trim
    If strPrt = "none" Then
      strPrt = "D:\Dumped.txt"
    End If
    My.Settings.LABPRT = CB2.Text.Trim
    My.Settings.LABPTYPE = r!QTN03.ToString.Trim
    My.Settings.Save()
    strPrt &= "," & r!QTN03.ToString.Trim
    Dim labP As New LabRunX64(strPrt, strLBF)
    labP.Darkness = Val(TextBox1.Text)
    labP.OffsetX = Val(TextBox2.Text)
    labP.OffsetY = Val(TextBox3.Text)
    labP.GetLabPrint.SetReDirect(AddressOf GetPictures)
    labP.OpenPrinter()
    Dim intT As Integer = 0
    Do While intT < 100 And labP.Ready = False
      My.Application.DoEvents()
      Threading.Thread.Sleep(20)
      intT += 1
    Loop
    If labP.Ready = False Then
      labP.Cancel = True
      labP.ClosePrinter()
      labP.Dispose()
      Me.Enabled = True
      Return
    End If
    labP.PrintLabel(True)
    labP.ClosePrinter()
    labP.Dispose()
    Me.Enabled = True
  End Sub

  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    Me.Close()
  End Sub
End Class