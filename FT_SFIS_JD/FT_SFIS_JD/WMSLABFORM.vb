Public Class WMSLABFORM
  Dim aryL As New ArrayList
  Dim strID As String = ""
  Public Property ID As String
    Get
      Return strID
    End Get
    Set(value As String)
      strID = value
    End Set
  End Property
  Private Sub WMSLABFORM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_distinc, "SFIS_QTN")
    sqlCV.Where("QTN01", "=", "#LABELS")
    sqlCV.SqlFields("QTN04", , , , True)
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    ComboBox1.Items.Clear()
    ComboBox1.Items.Add("(ALL)")
    For Each r As DataRow In rs.Rows
      ComboBox1.Items.Add(r!QTN04.ToString.Trim)
    Next
    If strID = "" Then
      ComboBox1.SelectedIndex = 0
    Else
      sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_QTN")
      sqlCV.Where("QTN01", "=", "#LABELS")
      sqlCV.Where("QTN02", "=", strID)
      sqlCV.SqlFields("*")
      rs = DB.RsSQL(sqlCV.Text, "RT")
      If rs.Rows.Count = 0 Then
        strID = ""
      Else
        Label2.Text = rs.Rows(0)!QTN02.ToString.Trim & " " & rs.Rows(0)!QTN03.ToString.Trim
        strID = rs.Rows(0)!QTN02.ToString.Trim
        ComboBox1.SelectedIndex = ComboBox1.Items.IndexOf(rs.Rows(0)!QTN04.ToString.Trim)
        If ComboBox1.SelectedIndex < 0 Then ComboBox1.SelectedIndex = 0
      End If
    End If
    ReList()
  End Sub
  Private Sub ReList()
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, "SFIS_QTN")
    sqlCV.Where("QTN01", "=", "#LABELS")
    If ComboBox1.Text <> "(ALL)" Then
      sqlCV.Where("QTN04", "=", ComboBox1.Text.Trim)
    End If
    sqlCV.SqlFields("QTN02", , , , True)
    sqlCV.SqlFields("QTN03")
    sqlCV.SqlFields("QTN05")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    For intI As Integer = rs.Rows.Count To aryL.Count - 1
      RemoveHandler CType(aryL(intI), IMGLIST).Click, AddressOf ClickPIC
      RemoveHandler CType(aryL(intI), IMGLIST).DoubleClick, AddressOf DClickPic
      FP.Controls.Remove(aryL(intI))
    Next
    aryL.Clear()
    For intI As Integer = 0 To FP.Controls.Count - 1
      If FP.Controls(intI).GetType Is GetType(IMGLIST) Then
        aryL.Add(FP.Controls(intI))
      End If
    Next
    For intI As Integer = 0 To rs.Rows.Count - 1
      If intI < aryL.Count Then
        CType(aryL(intI), IMGLIST).ShowMap(rs.Rows(intI))
      Else
        Dim s As New IMGLIST
        s.Visible = True
        s.Name = "IMG" & intI
        s.ShowMap(rs.Rows(intI))
        AddHandler s.Click, AddressOf ClickPIC
        AddHandler s.DoubleClick, AddressOf DClickPic
        FP.Controls.Add(s)
        aryL.Add(s)
      End If
    Next
  End Sub
  Private Sub DClickPic(sender As Object, e As EventArgs)
    strID = CType(sender, IMGLIST).GetID
    Me.DialogResult = Windows.Forms.DialogResult.OK
    Me.Close()
  End Sub
  Private Sub ClickPIC(sender As Object, e As EventArgs)
    Label2.Text = CType(sender, IMGLIST).GetDesc
    strID = CType(sender, IMGLIST).GetID
  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    If strID = "" Then Return
    Me.DialogResult = Windows.Forms.DialogResult.OK
    Me.Close()
  End Sub

  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    Me.DialogResult = Windows.Forms.DialogResult.Cancel
    Me.Close()
  End Sub

  Private Sub ComboBox1_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboBox1.SelectionChangeCommitted
    ReList()
  End Sub
End Class