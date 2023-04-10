Public Class FrmQTN
  Const strNTab As String = "SFIS_QTN"
  Private QT As New APSQL.SQLCNV
  Private WithEvents clsN As clsEDIT2012.clsEDIT2012 = Nothing
  Dim NDialog1 As FileDialog
  Private bolAppend As Boolean = False
  Private QTN As QTNLIST
  Private aryImg As New Dictionary(Of String, Byte())
  Private aryImg1 As New Dictionary(Of String, String)
  Private strBegin As String = ""
  Sub New()

    ' 此為設計工具所需的呼叫。
    InitializeComponent()

    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
    languagechange(Me)
  End Sub
  Private Sub Qlist()
    QT.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, strNTab)
    QT.SqlFields("QTN02", "序號", , , True)
    QT.SqlFields("QTN03", "中文說明")
    QT.SqlFields("QTN04", "英文說明")
    QT.Where("QTN01", "=", TextBox1.Text)   '由於選取項目的不同，只擷取所選取的組件
    Dim rs As DataTable = DB.RsSQL(BIG2GB(QT.Text), "DV1")

    QT.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, strNTab)
    QT.SqlFields("QTN01", , , , True)
    QT.SqlFields("QTN02", , , , True)
    QT.SqlFields("QTN03")
    QT.SqlFields("QTN05")
    QT.Where("QTN01", "Like", "#" & TextBox1.Text & "||%")
    Dim rs1 As DataTable = db.RsSQL(QT.Text, "DR")
    bolAppend = False
    If rs1.Rows.Count > 0 Then
      bolAppend = True
      Dim aryS As New Dictionary(Of String, DataRow)
      Dim aryC As New Dictionary(Of String, DataColumn)
      For Each r As DataRow In rs.Rows
        aryS.Add(r.Item(0).ToString.Trim, r)
      Next
      Dim c As DataColumn = Nothing
      aryImg.Clear()
      aryImg1.Clear()
      For Each r As DataRow In rs1.Rows
        If r!QTN05.GetType IsNot GetType(DBNull) Then
          Dim bytV() As Byte = r!QTN05
          If bytV IsNot Nothing AndAlso bytV.Length > 0 Then
            aryImg.Add(r!QTN01.ToString & "_" & r!QTN02.ToString, bytV)
          End If
        End If
        Dim strC As String = BIG2GB(r!QTN01.ToString.Trim)
        If aryC.ContainsKey(strC) = False Then
          Dim strV() As String = Split(strC, "||")
          If strV.Length = 2 Then
            If IsNumeric(strV(1).Substring(0, 2)) Then
              c = rs.Columns.Add(strV(1).Substring(2), GetType(String))
            Else
              c = rs.Columns.Add(strV(1), GetType(String))
            End If
          Else
            c = rs.Columns.Add(BIG2GB("備用") & rs.Columns.Count - 2, GetType(String))
          End If
          aryC.Add(strC, c)
        Else
          c = aryC(strC)
        End If
        If aryS.ContainsKey(r!QTN02.ToString.Trim) = True Then
          aryS(r!QTN02.ToString.Trim).Item(c) = r!QTN03.ToString.Trim
        Else
          Dim r1 As DataRow = rs.Rows.Add(r!QTN02.ToString.Trim)
          r1.Item(c) = r!QTN03.ToString.Trim
          aryS.Add(r!QTN02.ToString.Trim, r1)
        End If
      Next
    End If
    DV1.DataSource = rs
    For Each c As DataGridViewColumn In DV1.Columns
      c.SortMode = DataGridViewColumnSortMode.NotSortable
    Next
    DV1.CalLast()
    DV1.AppendBegin()
  End Sub

  Private Sub FrmQTN_Activated(sender As Object, e As EventArgs) Handles Me.Activated
    Me.WindowState = FormWindowState.Maximized
  End Sub

  Private Sub FrmQTN_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
    TuiCK(Me)
  End Sub

  Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles Me.Load
    Me.WindowState = FormWindowState.Maximized
    clsN = New clsEDIT2012.clsEDIT2012(TabControl1, DB, language, False, strNTab)
    clsN.GetToolsItem("DELETE").Enabled = clsRTS.GetRight(Me.Tag & "/003")
    If clsRTS.GetRight(Me.Tag & "/001") Then
      clsN.GetToolsItem("SAVE").Enabled = True
      Button2.Visible = True
      Button3.Visible = True
      Button4.Visible = True
      Button1.Visible = True
      Label3.Visible = True
      TextBox3.Visible = True
      clsN.AddToolsItem(BIG2GB("轉檔"), My.Resources.XDOWN, AddressOf txtN)
      clsN.GetToolsItem(0).GetCurrentParent.Font = Me.Font
    Else
      clsN.GetToolsItem("SAVE").Enabled = False
      Button2.Visible = False
      Button3.Visible = False
      Button4.Visible = False
      Button1.Visible = False
      Label3.Visible = False
      TextBox3.Visible = False
    End If
  End Sub
  Private Sub txtN(sender As Object, e As System.EventArgs)
    sfd1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
    sfd1.Filter = "SQL|*.SQL"  '|  shift + \  
    sfd1.Title = BIG2GB("請選取存檔檔名")
    If sfd1.ShowDialog() = Windows.Forms.DialogResult.OK Then

      Dim dt As DataTable, fs As String = sfd1.FileName, fw As System.IO.StreamWriter, s As String
      If fs = "" Then Exit Sub
      If IO.File.Exists(fs) = True Then IO.File.Delete(fs)
      With QT
        .sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, strNTab)
        .Where("QTN01", "<>", "#LBFx")
        .SqlFields("*")
        .sqlOrder("QTN01", APSQL.SQLCNV.intOrder.Order_Asc)
        .sqlOrder("QTN02", APSQL.SQLCNV.intOrder.Order_Asc)
        dt = DB.RsSQL(.Text, "S01")
        If dt.Rows.Count = 0 Then          'row count 沒有資料 離開程序
          MsgBox(BIG2GB("沒有資料"), , BIG2GB("轉檔"))
          Exit Sub
        End If
        fw = New System.IO.StreamWriter(fs, False, System.Text.Encoding.Unicode)   'ture 延續新增 false 覆蓋
        For i As Integer = 0 To dt.Rows.Count - 1
          .sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, strNTab)
          .SqlFields("QTN01", dt.Rows(i).Item("QTN01").ToString)
          .SqlFields("QTN02", dt.Rows(i).Item("QTN02").ToString)
          .SqlFields("QTN03", dt.Rows(i).Item("QTN03").ToString)
          .SqlFields("QTN04", dt.Rows(i).Item("QTN04").ToString)
          s = .Text
          fw.WriteLine(s)
          fw.WriteLine("GO")     'GO為sql 指令 筆記本中會顯示 於SQL執行會輸入字串
        Next
        fw.Close()               '關閉 StreamWriter
      End With
      MsgBox(BIG2GB("轉檔完成！"), , BIG2GB("轉檔"))
    End If
  End Sub
  Private Sub clsN_DVSelect(s As clsEDIT2012.clsEDIT2012, r As System.Windows.Forms.DataGridViewRow) Handles clsN.DVSelect
    TextBox1.Text = r.Cells(BIG2GB("組件")).Value.ToString
    TextBox2.Text = ""
    TextBox1.Enabled = False
    Dim sqlcv As New APSQL.SQLCNV
    sqlcv.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, strNTab)
    sqlcv.Where("QTN01", "=", "@SESSIONS")
    sqlcv.Where("QTN02", "=", TextBox1.Text.Trim)
    sqlcv.SqlFields("QTN03", "DATAS")
    Dim dt As DataTable = db.RsSQL(sqlcv.Text, "DESC")
    If dt.Rows.Count > 0 Then TextBox2.Text = dt.Rows(0)!DATAS.ToString
    Qlist()
  End Sub

  Private Sub clsN_DVTable(s As clsEDIT2012.clsEDIT2012, ByRef strSQL As String) Handles clsN.DVTable
    QT.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, strNTab)
#If SDF = 1 Then
    QT.Where("QTN01", "Not Like", "#%")
    QT.Where("QTN01", "Not Like", "@%")
#Else
    QT.Where("QTN01", "Not Like", "[#@]%")
#End If
    QT.Where("QTN01", "<>", "SN-SE")
    QT.SqlFields("QTN01", BIG2GB("組件"), , True, True)
    QT.SqlFields("Count(*)", BIG2GB("筆數"))    'table顯示conut筆數
    strSQL = QT.Text
    'TabControl1.Refresh()
  End Sub

  Private Sub clsN_Frm_CheckDup(s As clsEDIT2012.clsEDIT2012, ByRef strSQL As String) Handles clsN.Frm_CheckDup
    QT.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, strNTab)
    QT.SqlFields("*")
    QT.Where("QTN01", "=", TextBox1.Text)
    strSQL = QT.Text
  End Sub

  Private Sub clsN_Frm_Clear(s As clsEDIT2012.clsEDIT2012) Handles clsN.Frm_Clear
    TextBox1.Text = ""
    TextBox2.Text = ""
    TextBox1.Enabled = True
    Qlist()
    TabControl1.SelectedIndex = 0
  End Sub

  Private Sub clsN_Frm_Delete(s As clsEDIT2012.clsEDIT2012, ByRef strSQL As String, ByRef bolOK As Boolean) Handles clsN.Frm_Delete
    If TextBox1.Text = "" Then Exit Sub
    If MsgBox(BIG2GB("此組件資料將刪除=") & TextBox1.Text & "?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Me.Text) <> MsgBoxResult.Yes Then
      bolOK = False
      Exit Sub                '=return
    Else
      bolOK = True
    End If
    QT.sqlMAKE(APSQL.SQLCNV.intMode.mssql_delete, strNTab)
    QT.Where("QTN01", "=", TextBox1.Text)
    QT.Where("QTN01", "Like", "#" & TextBox1.Text.Trim & "%", , , "OR")
    strSQL = QT.Text
    clsN.Updated = True
  End Sub

  Private Sub clsN_Frm_InsertM(s As clsEDIT2012.clsEDIT2012, ByRef strSQL As String, ByRef intR As Integer) Handles clsN.Frm_InsertM
    ReBuildDescribe()
#If EWMS Then
    If My.Settings.bolQTN = False Then
      My.Settings.bolQTN = True
      My.Settings.Save()
    End If
#End If
    For Each x As DataGridViewRow In DV1.Rows
      If GCell(x.Cells(0)) = "" Or GCell(x.Cells(1)) = "" Then Continue For
      QT.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, strNTab)
      QT.SqlFields("QTN01", TextBox1.Text)
      QT.SqlFields("QTN02", x.Cells(0).Value.ToString)         'T發生問題中斷 存入檔案會跳到此程序 null
      QT.SqlFields("QTN03", x.Cells(1).Value.ToString)
      If x.Cells(2).Value.ToString <> "" Then
        QT.SqlFields("QTN04", x.Cells(2).Value.ToString)
      End If
      DB.RsSQL(QT.Text)
      If bolAppend = True Then
        For intI As Integer = 3 To DV1.ColumnCount - 1
          If GCell(x.Cells(intI)) <> "" Then
            Dim strK As String = "#" & TextBox1.Text & "||" & intI.ToString("00") & DV1.Columns(intI).Name & "_" & GCell(x.Cells(0))
            QT.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, strNTab)
            QT.SqlFields("QTN01", "#" & TextBox1.Text & "||" & intI.ToString("00") & DV1.Columns(intI).Name)
            QT.SqlFields("QTN02", GCell(x.Cells(0)))
            QT.SqlFields("QTN03", GCell(x.Cells(intI)))
            If aryImg1.ContainsKey(strK) = True Then
              QT.SqlFields("QTN05", aryImg1(strK), APSQL.intFMode.msfld_Image)
              DB.RsSQL(QT.Text, QT.GetImgs)
            ElseIf aryImg.ContainsKey(strK) = True Then
              QT.SqlFields("QTN05", aryImg(strK))
              DB.RsSQL(QT.Text, QT.GetImgs)
            Else
              DB.RsSQL(QT.Text)
            End If
          End If
        Next
      End If
    Next
    MsgBox(BIG2GB("新增完成"))
    strSQL = ""
    intR = 0
    clsN.Updated = True
  End Sub

  Private Sub clsN_Frm_UpdateM(s As clsEDIT2012.clsEDIT2012, ByRef strSQL As String, ByRef intR As Integer) Handles clsN.Frm_UpdateM
    ReBuildDescribe()
#If EWMS Then
    If My.Settings.bolQTN = False Then
      My.Settings.bolQTN = True
      My.Settings.Save()
    End If
#End If
    QT.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, strNTab)
    QT.Where("QTN01", "=", TextBox1.Text)
    QT.SqlFields("*")
    Dim rsP As DataTable = DB.RsSQL(QT.Text, "RT")
    Dim aryG As New Dictionary(Of String, Byte()), bolTU As Boolean = False
    For Each r As DataRow In rsP.Rows
      If r!QTN05.GetType Is GetType(DBNull) Then
        Continue For
      End If
      Dim bytB() As Byte = r!QTN05
      aryG.Add(r!QTN02.ToString.Trim, bytB)
    Next
    QT.sqlMAKE(APSQL.SQLCNV.intMode.mssql_delete, strNTab)
    QT.Where("QTN01", "=", TextBox1.Text)
    QT.Where("QTN01", "Like", "#" & TextBox1.Text & "%", , , "OR")
    DB.RsSQL(QT.Text)
    For Each x As DataGridViewRow In DV1.Rows
      If GCell(x.Cells(0)) = "" Or GCell(x.Cells(1)) = "" Then Continue For
      QT.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, strNTab)
      QT.SqlFields("QTN01", TextBox1.Text)
      QT.SqlFields("QTN02", x.Cells(0).Value.ToString)
      QT.SqlFields("QTN03", x.Cells(1).Value.ToString)
      If x.Cells(2).Value.ToString <> "" Then
        QT.SqlFields("QTN04", x.Cells(2).Value.ToString)
      End If
      If aryG.ContainsKey(x.Cells(0).Value.ToString) = True Then
        QT.SqlFields("QTN05", aryG(x.Cells(0).Value.ToString))
        bolTU = True
      End If
      'QT.Where("DEF01", "=", TextBox1.Text)
      If bolTU Then
        DB.RsSQL(QT.Text, QT.GetImgs)
      Else
        DB.RsSQL(QT.Text)       '暫時拿掉不會因重複產生訊息，儲存同組件名產生重複索引鍵訊息()
      End If
      If bolAppend = True Then
        For intI As Integer = 3 To DV1.ColumnCount - 1
          If GCell(x.Cells(intI)) <> "" Then
            Dim strK As String = "#" & TextBox1.Text & "||" & intI.ToString("00") & DV1.Columns(intI).Name & "_" & GCell(x.Cells(0))
            QT.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, strNTab)
            QT.SqlFields("QTN01", "#" & TextBox1.Text & "||" & intI.ToString("00") & DV1.Columns(intI).Name)
            QT.SqlFields("QTN02", GCell(x.Cells(0)))
            QT.SqlFields("QTN03", GCell(x.Cells(intI)))
            If aryImg1.ContainsKey(strK) = True Then
              QT.SqlFields("QTN05", aryImg1(strK), APSQL.intFMode.msfld_Image)
              DB.RsSQL(QT.Text, QT.GetImgs)
            ElseIf aryImg.ContainsKey(strK) = True Then
              QT.SqlFields("QTN05", aryImg(strK))
              DB.RsSQL(QT.Text, QT.GetImgs)
            Else
              DB.RsSQL(QT.Text)
            End If
          End If
        Next
      End If
    Next
    MsgBox(BIG2GB("更新完成"))
    strSQL = ""
    intR = 0
    clsN.Updated = True
  End Sub

  Private Sub clsN_isDataValid(s As clsEDIT2012.clsEDIT2012, ByRef bolOK As Boolean) Handles clsN.isDataValid
    If TextBox1.Text.Trim = "" Then
      MsgBox(BIG2GB("組件欄位不可空白。"), , Me.Text)
      TextBox1.Focus()
      bolOK = False   '檢查 允許與否
      Exit Sub        '到此段結束，不會繼續下Run
    End If
    Dim bolT As Boolean = False
    For Each x As DataGridViewRow In DV1.Rows
      If GCell(x.Cells(0)) = "" Or GCell(x.Cells(1)) = "" Then Continue For
      bolT = True
      For i As Integer = 0 To x.Index - 1
        If GCell(DV1.Rows(i).Cells(0)) = GCell(x.Cells(0)) Then
          MsgBox(BIG2GB("序號重複。"))   '重複比對
          Return
        End If
      Next
    Next
    If bolT = False Then
      MsgBox(BIG2GB("序號欄或中文說明不可空白"))
      Return
    End If
    bolOK = True
  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    DV1.Rows.Remove(DV1.CurrentRow)
    If DV1.RowCount = 0 Then DV1.AppendBegin()
  End Sub

  Private Sub DV1_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DV1.CellBeginEdit
    strBegin = GCell(DV1.Rows(e.RowIndex).Cells(e.ColumnIndex))
  End Sub

  Private Sub ReBuildDescribe()
    Dim sqlcv As New APSQL.SQLCNV, strSQL As String = ""
    If TextBox1.Text.Trim.StartsWith("#") Or TextBox1.Text.Trim.StartsWith("@") Then
      Return
    End If
    If TextBox1.Text.Trim = "SN-SE" Then
      Return
    End If
    sqlcv.sqlMAKE(APSQL.SQLCNV.intMode.mssql_delete, strNTab)
    sqlcv.Where("QTN01", "=", "@SESSIONS")
    sqlcv.Where("QTN02", "=", TextBox1.Text.Trim)
    strSQL &= BIG2GB(sqlcv.Text) & ";"
    DB.RsSQL(sqlcv.Text)
    sqlcv.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, strNTab)
    sqlcv.SqlFields("QTN01", "@SESSIONS")
    sqlcv.SqlFields("QTN02", TextBox1.Text.Trim)
    sqlcv.SqlFields("QTN03", TextBox2.Text.Trim)
    strSQL &= BIG2GB(sqlcv.Text)
    DB.RsSQL(sqlcv.Text)
  End Sub

  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    Dim rs As DataTable = DV1.DataSource
    If TextBox3.Text.Trim = "" Then
      MsgBox(BIG2GB("請先填寫欄位名稱"))
      TextBox3.Focus()
      Return
    End If
    If rs.Columns.Contains(TextBox3.Text.Trim) = True Then
      MsgBox(BIG2GB("欄位名不得重複"))
      TextBox3.Focus()
      Return
    End If
    rs.Columns.Add(TextBox3.Text.Trim, GetType(String))
    DV1.DataSource = rs
    bolAppend = True
    TextBox3.Text = ""
  End Sub

  Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    If DV1.CurrentRow Is Nothing OrElse DV1.CurrentCell Is Nothing Then Return
    Dim ofl As New OpenFileDialog
    Dim strK As String = "#" & TextBox1.Text & "||" & DV1.CurrentCell.ColumnIndex.ToString("00") & DV1.Columns(DV1.CurrentCell.ColumnIndex).Name & "_" & GCell(DV1.CurrentRow.Cells(0))
    ofl.Title = DV1.Columns(DV1.CurrentCell.ColumnIndex).HeaderText
    Dim strF As String = GCell(DV1.CurrentCell)
    ofl.Filter = BIG2GB("所有檔案|*.*")
    If strF <> "" Then
      ofl.InitialDirectory = IO.Path.GetDirectoryName(strF)
      ofl.FileName = IO.Path.GetFileName(strF)
    End If
    If ofl.ShowDialog = Windows.Forms.DialogResult.OK Then
      strF = ofl.FileName
      If IO.File.Exists(strF) = False Then Return
      DV1.CurrentCell.Value = strF
      If aryImg1.ContainsKey(strK) = False Then
        aryImg1.Add(strK, strF)
      Else
        aryImg1(strK) = strF
      End If
    End If
  End Sub

  Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
    If e.KeyChar = vbCr Or e.KeyChar = vbLf Then
      e.Handled = True
      My.Computer.Keyboard.SendKeys(vbTab)
    End If
  End Sub

  Private Sub TextBox1_Validated(sender As Object, e As EventArgs) Handles TextBox1.Validated
    If TextBox1.Text.Trim = "" Then Return
    If TextBox1.Text.Trim.StartsWith("#") And TextBox1.Text.Trim.Contains("||") Then
      MsgBox(BIG2GB("字典無法叫用次級欄位"))
      TextBox1.Focus()
      Return
    End If
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, strNTab)
    sqlCV.Where("QTN01", "=", TextBox1.Text.Trim)
    sqlCV.SqlFields("QTN02")
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    If TextBox1.Text.Trim.StartsWith("#") Or TextBox1.Text.Trim.StartsWith("@") Then
      If rs.Rows.Count = 0 Then
        MsgBox(BIG2GB("保留字的字典不得新增"))
        TextBox1.Focus()
        Return
      End If
    End If
    TextBox1.Enabled = False
    TextBox2.Text = ""
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, strNTab)
    sqlCV.Where("QTN01", "=", "@SESSIONS")
    sqlCV.Where("QTN02", "=", TextBox1.Text.Trim)
    sqlCV.SqlFields("QTN03", "DATAS")
    rs = DB.RsSQL(sqlCV.Text, "RT")
    If rs.Rows.Count > 0 Then TextBox2.Text = rs.Rows(0)!DATAS.ToString
    Qlist()
  End Sub
  Private Sub ToLoadFile(strK As String, strK1 As String, strF As String)
    If IO.File.Exists(strF) = False Then Return
    strK = strK.Trim.ToUpper
    strK1 = strK1.Trim.ToUpper
    Dim strV() As String = strK.Split("#|".ToCharArray)
    Dim rs As DataTable = Nothing
    If strV.Length >= 2 Then
      Dim sqlCV As New APSQL.SQLCNV
      sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, strNTab)
      sqlCV.Where("QTN01", "=", strV(1))
      sqlCV.Where("QTN02", "=", strK1)
      sqlCV.SqlFields("QTN03")
      rs = DB.RsSQL(sqlCV.Text, "RT")
      If rs.Rows.Count = 0 Then
        sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, strNTab)
        sqlCV.SqlFields("QTN01", strV(1))
        sqlCV.SqlFields("QTN02", strK1)
        sqlCV.SqlFields("QTN03", IO.Path.GetFileNameWithoutExtension(strF))
        sqlCV.SqlFields("QTN04", "")
        DB.RsSQL(sqlCV.Text)
      End If
    End If
    sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_select, strNTab)
    sqlCV.Where("QTN01", "=", strK)
    sqlCV.Where("QTN02", "=", strK1)
    sqlCV.SqlFields("QTN03")
    rs = DB.RsSQL(sqlCV.Text, "RT")
    If rs.Rows.Count = 0 Then
      sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_insert, strNTab)
      sqlCV.SqlFields("QTN01", strK)
      sqlCV.SqlFields("QTN02", strK1)
      sqlCV.SqlFields("QTN03", strF)
      sqlCV.SqlFields("QTN04", "")
      sqlCV.SqlFields("QTN05", strF, APSQL.intFMode.msfld_Image)
      DB.RsSQL(sqlCV.Text, sqlCV.GetImgs)
    Else
      sqlCV.sqlMAKE(APSQL.SQLCNV.intMode.mssql_update, strNTab)
      sqlCV.Where("QTN01", "=", strK)
      sqlCV.Where("QTN02", "=", strK1)
      sqlCV.SqlFields("QTN03", strF)
      sqlCV.SqlFields("QTN04", "")
      sqlCV.SqlFields("QTN05", strF, APSQL.intFMode.msfld_Image)
      DB.RsSQL(sqlCV.Text, sqlCV.GetImgs)
    End If
  End Sub

  Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
    Dim ofl As New OpenFileDialog
    ofl.Title = BIG2GB("系統更新支援批次導入作業")
    ofl.Filter = BIG2GB("所有檔案|*.UPL")
    ofl.DefaultExt = "UPL"
    ofl.InitialDirectory = ""
    ofl.FileName = ""
    If ofl.ShowDialog = Windows.Forms.DialogResult.OK Then
      Dim strDIR As String = IO.Path.GetDirectoryName(ofl.FileName)
      Dim strV() As String = IO.File.ReadAllLines(ofl.FileName)
      For Each strK As String In strV
        If strK.Trim = "" Then Continue For
        If strK.Trim.StartsWith("#") = False Then
          Try
            DB.RsSQL(strK.Trim)
          Catch ex As Exception

          End Try
          Continue For
        End If
        Dim strM() As String = strK.Split("^,".ToCharArray)
        If strM.Length = 3 Then
          Dim strF As String = strDIR & "\" & strM(2).Trim
          ToLoadFile(strM(0), strM(1), strF)
        ElseIf strM.Length = 2 Then
          Dim strF As String = strDIR & "\" & strM(1).Trim
          ToLoadFile(strM(0), strM(1), strF)
        End If
      Next
      MsgBox(BIG2GB("系統更新支援批次導入完成"))
    End If
  End Sub
End Class
