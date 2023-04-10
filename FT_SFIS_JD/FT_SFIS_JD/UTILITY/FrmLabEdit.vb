Imports LABTRANx64.Labtran
Imports LABTRANx64
Imports APSQL
Public Class FrmLabEdit
  Const strQTN As String = "SFIS_QTN"
  Sub New()

    ' 此為 Windows Form 設計工具所需的呼叫。
    InitializeComponent()
    languagechange(Me)
    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
    attb.SetColorKey(Color.FromArgb(245, 245, 245), Color.White, Imaging.ColorAdjustType.Default)

  End Sub
  Private sqlcv As New SQLCNV
  Private dr As DRAGN
  'Private gp As GTRGBMP
  Private WithEvents Fldcmd As New LabCmds("TEMP")
  Private s1 As New PictureBox
  Private s2 As New PictureBox
  Friend WithEvents s3 As New PictureBox
  Private sngRelView As Single = 600
  Private sngRel As Single = 600
  Private fldV As Flds = Nothing
  Private fldVH As Flds = Nothing
  Private CurrDragn As DRAGN = Nothing
  Private ConDRAGN As Integer = 1
  Private bolAS As Boolean = True
  Private strFDC As String = ""
  Private rsFDC As New DataTable
  Private attb As New Imaging.ImageAttributes
  Private bolRL As Boolean = False
  Private strTBN As String = ""
  'Private intUSEQ As Integer = 0
  Private bolHaltReDraw As Boolean
  Private bolTLab As Boolean = False
  Private bolCheck As Boolean = False
  'Private bolLock As Boolean = False
  'Private intUQ As Integer = 0
  'Private intDIRSQ As Integer = 0
  'Private strNames As String = ""
  'Private strVers As String = ""
  'Private intSEQID As Integer = 0
  'Private arySeqID As New ArrayList
  Private KPrgt As Rectangle
  Private bolChgZoom As Boolean = False
  Private FigPath As Drawing.Drawing2D.GraphicsPath
  Public Property FDCMap As String
    Get
      Return strFDC
    End Get
    Set(value As String)
      strFDC = value
      If rsFDC.Columns.Count = 0 Then
        rsFDC.Columns.Add("ID", GetType(String))
        rsFDC.Columns.Add("Value", GetType(String))
      End If
      rsFDC.Rows.Clear()
      If strFDC.Trim = "" Then Return
      Dim strV() As String = strFDC.Split("|^".ToCharArray)
      rsFDC.Rows.Add("", BIG2GB("(無)"))
      For Each strK As String In strV
        Dim strM() As String = (strK & ",").Split(",")
        If strM(1).Trim = "" Then
          rsFDC.Rows.Add(strM(0), BIG2GB(strM(0)))
        Else
          rsFDC.Rows.Add(strM(0), BIG2GB(strM(1)))
        End If
      Next
    End Set
  End Property

  Private Sub FrmLabEdit_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
    TuiCK(Me)
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

  Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    TSCB1.Enabled = False
    TSCB1.SelectedIndex = 2
    '元件選項
    Dim rs As New DataTable
    rs.Columns.Add("KEY")
    rs.Columns.Add("DATA")
    Dim Keys As String() = [Enum].GetNames(GetType(BarType))
    Dim Datas As Integer() = [Enum].GetValues(GetType(BarType))
    For intI As Integer = Keys.GetLowerBound(0) To Keys.GetUpperBound(0)
      If Datas(intI) = 2002 Or Datas(intI) = 5001 Then Continue For
      If Datas(intI) <> 0 Then rs.Rows.Add(BIG2GB(Keys(intI)), Datas(intI))
    Next
    CB1.DataSource = rs
    CB1.DisplayMember = "KEY"
    CB1.ValueMember = "DATA"
    DGV.RowHeadersVisible = False
    DGV.ColumnHeadersVisible = True
    DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    DGV.AllowUserToAddRows = False
    DGV.AllowUserToDeleteRows = False
    DGV.AllowUserToOrderColumns = False
    DGV.Columns.Add("ID", "ID")
    DGV.Columns.Add("DESC", BIG2GB("項目"))
    DGV.Columns.Add("VALUE", BIG2GB("存值"))
    fldVH = New Flds
    fldVH.Cell = New PageCell
    fldVH.Hpos = New HandPosi
    fldVH.Hpos.FDH = 100
    fldVH.Hpos.FDW = 100
    fldVH.Hpos.Resolution = 300
    fldVH.Name = "PAGE"
    sngRel = fldVH.Hpos.Resolution
    fldVH.Cell.Resolution = fldVH.Hpos.Resolution
    With CType(fldVH.Cell, PageCell)
      .PageArrayX = 1
      .PageArrayY = 1
      .PagePitch = 103
      .PagePitchX = 100
      .PagePitchY = 100
      ' TB.Text = fldVH.Name & ": " & fldVH.Hpos.FDW - (.PageArrayX - 1) * .PagePitchX & " * " & fldVH.Hpos.FDH - (.PageArrayY - 1) * .PagePitchY
      'Debug.Print(.PagePitch)
    End With
    Clean()
    PB1.Controls.Add(s1)
    PB2.Controls.Add(s2)
    PL.Controls.Add(s3)
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, strQTN)
    sqlCV.Where("QTN01", "=", "#LBFX")
    sqlCV.SqlFields("QTN02")
    sqlCV.SqlFields("QTN03")
    sqlCV.SqlFields("QTN04")
    Dim rs1 As DataTable = DB.RsSQL(sqlCV.Text, "RT")
    ComboBox1.Items.Clear()
    ComboBox2.Items.Clear()
    For Each r As DataRow In rs1.Rows
      ComboBox1.Items.Add(r!QTN02.ToString.Trim.ToUpper)
      If r!QTN04.ToString.Trim <> "" Then
        If ComboBox2.Items.IndexOf(r!QTN04.ToString.Trim.ToUpper) = -1 Then
          ComboBox2.Items.Add(r!QTN04.ToString.Trim.ToUpper)
        End If
      End If
    Next
    ComboBox1.Text = ""
    ComboBox2.Text = ""
    TSCB1.Enabled = True
    ToolStripButton2.Enabled = clsRTS.GetRight(Me.Tag & "/003")
    ToolStripButton7.Enabled = clsRTS.GetRight(Me.Tag & "/001")
    ToolStripButton9.Enabled = clsRTS.GetRight(Me.Tag & "/001")
    'LoadFromFile("D:\YSTAG2_1.LBFx")
  End Sub
  '清除畫面
  Public Sub Clean(Optional bolALL As Boolean = True)
    Application.UseWaitCursor = True
    Me.SuspendLayout()
    If bolALL Then
      ComboBox1.Text = ""
      ComboBox2.Text = ""
      LDesc.Text = ""
      LName.Text = ""
    End If
    PL.Visible = False
    bolHaltReDraw = True
    CB1.SelectedIndex = 0
    DGV.Rows.Clear()
    While s3.Controls.Count > 0
      Dim d As DRAGN = s3.Controls(0)
      d.Dispose()
    End While
    's3.Controls.Clear()
    'Debug.Print(s3.Controls.Count)
    Fldcmd.Clear()
    ConDRAGN = 1
    TSCB1.SelectedIndex = 2
    DrawRuler()
    Button1.Enabled = False
    PL.Visible = True
    Me.ResumeLayout(True)
    bolHaltReDraw = False
    Application.UseWaitCursor = False
  End Sub

  '開啟舊檔
  'Private Sub GetPicture(ByVal s As Object, ByVal strN As String, ByRef bmpX As Bitmap)
  '  Dim rs As DataTable
  '  sqlcv.sqlMAKE(SQLCNV.intMode.mssql_select, strQTN)
  '  sqlcv.Where("QTN02", "=", strN)
  '  sqlcv.Where("QTN01", "=", "#LBT_BM")
  '  sqlcv.SqlFields("QTN05")
  '  rs = DB.RsSQL(sqlcv.Text, "PEDIR")
  '  If rs.Rows.Count = 0 Then
  '    Return
  '  End If
  '  Dim fs As New IO.MemoryStream
  '  Dim bytV As Byte() = rs.Rows(0).Item("QTN05")
  '  If bytV.Length Then
  '    fs.Write(bytV, 0, bytV.Length)
  '    fs.Flush()
  '    bmpX = Image.FromStream(fs, True)
  '  End If
  'End Sub
  '尺標
  Public Sub DrawRuler()
    Dim sngRP As Single, intI As Integer, Xsize As Single, Ysize As Single
    Dim f As Font = New Drawing.Font("Arial", 9, FontStyle.Regular)
    Dim sngRound As Single
    With CType(fldVH.Cell, PageCell)
      'TB.Text = fldVH.Name & ": " & fldVH.Hpos.FDW.ToString("0.0") & "*" & _
      '          fldVH.Hpos.FDH.ToString("0.0") & " 單元:" & _
      '          (fldVH.Hpos.FDW - (.PageArrayX - 1) * .PagePitchX).ToString("0.0") & " * " & _
      '          (fldVH.Hpos.FDH - (.PageArrayY - 1) * .PagePitchY).ToString("0.0")
      sngRel = fldVH.Hpos.Resolution
      Xsize = fldVH.Hpos.FDW - (.PageArrayX - 1) * .PagePitchX
      Ysize = fldVH.Hpos.FDH - (.PageArrayY - 1) * .PagePitchY
      sngRound = .Round
    End With
    Dim sngXF As Single = PL.ClientSize.Width / (Int((Xsize + 9.4999) \ 10) * 10) * 25.4
    Dim sngYF As Single = PL.ClientSize.Height / (Int((Ysize + 9.4999) \ 10) * 10) * 25.4
    If bolChgZoom = False Then
      If sngXF > sngYF Then
        sngXF = Int(sngYF / sngRel * 100)
      Else
        sngXF = Int(sngXF / sngRel * 100)
      End If
      If sngXF > 100 Then sngXF = 100
      If sngXF < 33 Then sngXF = 33
      TSCB1.Text = Format(sngXF, "0") & " %"
    Else
      sngXF = Val(TSCB1.Text)
    End If
    sngRelView = sngRel * (sngXF / 100)
    sngRP = sngRelView / 25.4
    Dim intX As Integer = Int((Int(Xsize + 9.4999) \ 10) * 10 * sngRP + 0.5)
    Dim intY As Integer = Int((Int(Ysize + 9.4999) \ 10) * 10 * sngRP + 0.5)
    'X軸尺標
    Dim bm1 As New Bitmap(intX, 31)
    Dim gx As Graphics
    gx = Graphics.FromImage(bm1)
    gx.Clear(Color.WhiteSmoke)
    intI = 0
    For sngI As Single = sngRP To intX Step sngRP
      intI += 1
      If intI Mod 10 = 0 Then
        gx.DrawString((intI / 10).ToString, f, Brushes.Black, sngI - gx.MeasureString((intI / 10).ToString, f).Width - 3, 1)
        gx.DrawLine(Pens.Black, sngI, 5, sngI, 30)
      ElseIf intI Mod 5 = 0 Then
        gx.DrawLine(Pens.Red, sngI, 10, sngI, 30)
      Else
        gx.DrawLine(Pens.Gray, sngI, 20, sngI, 30)
      End If
    Next
    'gx.DrawLine(Pens.Black, 0, 30, intI * (sngRP / 10), 30)
    gx.ResetTransform()
    s1.ClientSize = New Size(bm1.Width, bm1.Height)
    s1.Location = New Point(0, 0)
    s1.Visible = True
    s1.BorderStyle = BorderStyle.None
    s1.BackgroundImage = bm1
    'Y軸尺標
    Dim bm2 As New Bitmap(31, intY)
    gx = Graphics.FromImage(bm2)
    gx.Clear(Color.WhiteSmoke)
    intI = 0
    For sngI As Single = sngRP To intY Step sngRP
      intI += 1
      If intI Mod 10 = 0 Then
        gx.DrawString((intI / 10).ToString, f, Brushes.Black, 1, sngI - gx.MeasureString((intI / 10).ToString, f).Height - 3)
        gx.DrawLine(Pens.Black, 5, sngI, 30, sngI)
      ElseIf intI Mod 5 = 0 Then
        gx.DrawLine(Pens.Red, 10, sngI, 30, sngI)
      Else
        gx.DrawLine(Pens.Black, 20, sngI, 30, sngI)
      End If
    Next
    'gx.DrawLine(Pens.Black, 30, 0, 30, intI * (sngRP / 10))
    gx.ResetTransform()
    s2.ClientSize = New Size(bm2.Width, bm2.Height)
    s2.Location = New Point(0, 0)
    s2.Visible = True
    s2.BorderStyle = BorderStyle.None
    s2.BackgroundImage = bm2
    s3.Name = "s3"
    s3.Location = New Point(0, 0)
    Dim bm3 As New Bitmap(CType(Int(Xsize * sngRP + 0.5), Integer), CType(Int(Ysize * sngRP + 0.5), Integer))
    s3.BorderStyle = BorderStyle.FixedSingle
    s3.ClientSize = bm3.Size
    If sngRound = 0 Then
      FigPath = Nothing
    Else
      FigPath = New Drawing.Drawing2D.GraphicsPath
      FigPath.StartFigure()
      FigPath.AddArc(0, 0, sngRound * sngRP, sngRound * sngRP, 180, 90)
      FigPath.AddLine(sngRound * sngRP, 0, bm3.Width - sngRound * sngRP - 1, 0)
      FigPath.AddArc(bm3.Width - sngRound * sngRP - 1, 0, sngRound * sngRP, sngRound * sngRP, 270, 90)
      FigPath.AddLine(bm3.Width - 1, sngRound * sngRP, bm3.Width - 1, bm3.Height - sngRound * sngRP - 1)
      FigPath.AddArc(bm3.Width - sngRound * sngRP - 1, bm3.Height - sngRound * sngRP - 1, sngRound * sngRP, sngRound * sngRP, 0, 90)
      FigPath.AddLine(bm3.Width - sngRound * sngRP - 1, bm3.Height - 1, sngRound * sngRP, bm3.Height - 1)
      FigPath.AddArc(0, bm3.Height - sngRound * sngRP - 1, sngRound * sngRP, sngRound * sngRP, 90, 90)
      'FigPath.AddLine(0, sngRound * sngRP, 0, bm3.Height - sngRound * sngRP)
      FigPath.CloseFigure()
      gx = Graphics.FromImage(bm3)
      gx.Clear(Color.White)
      gx.DrawPath(Pens.Blue, FigPath)
    End If
    s3.Image = bm3
    gx.Dispose()
    PL.Refresh()
  End Sub
  Private Sub s3_ControlAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles s3.ControlAdded
    If e.Control.Name Is Nothing Then Exit Sub
    '加入元件列表中item
    TSSB1.DropDownItems.Add(e.Control.Name)
    TSSB1.DropDownItems(TSSB1.DropDownItems.Count - 1).Name = e.Control.Name
  End Sub
  Private Sub s3_ControlRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles s3.ControlRemoved
    If TSSB1.DropDownItems.ContainsKey(e.Control.Name) = False Then Exit Sub
    '刪除元件列表中Item
    TSSB1.DropDownItems.RemoveAt(TSSB1.DropDownItems.IndexOfKey(e.Control.Name))
  End Sub
  Private Sub s3_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles s3.LocationChanged
    '尺標跟著Scroll移動
    s1.Left = s3.Location.X
    s2.Top = s3.Location.Y
  End Sub
  '確定產生新元件
  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    If fldV.Name <> "DUMMY" Then Return
    Select Case fldV.Cell.CellType \ 1000
      Case 1
        If CType(fldV.Cell, IBarcode).Text.Trim = "" Or fldV.Cell.MHeight = 0 Then Return
      Case 2
        If CType(fldV.Cell, IText).Text.Trim = "" Then Return
      Case 3
        If CType(fldV.Cell, LineCell).MHeight = 0 And CType(fldV.Cell, LineCell).MWidth = 0 Then Return
      Case 4
        If CType(fldV.Cell, PictCell).FileName.Trim = "" Or fldV.Cell.MHeight = 0 Or fldV.Cell.MWidth = 0 Then Return
        Dim strFS As String = CType(fldV.Cell, PictCell).FileName.Trim
        If IO.File.Exists(strFS) Then
          Dim sqlCV As New APSQL.SQLCNV
          sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "SFIS_QTN")
          sqlCV.Where("QTN01", "=", "@LBFIMAGES")
          sqlCV.Where("QTN02", "=", IO.Path.GetFileNameWithoutExtension(strFS))
          sqlCV.SqlFields("QTN03", strFS)
          sqlCV.SqlFields("QTN05", strFS, intFMode.msfld_Image)
          Dim intL As Integer = DB.RsSQL(sqlCV.Text, sqlCV.GetImgs)
          If intL = 0 Then
            sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_QTN")
            sqlCV.SqlFields("QTN01", "@LBFIMAGES")
            sqlCV.SqlFields("QTN02", IO.Path.GetFileNameWithoutExtension(strFS))
            sqlCV.SqlFields("QTN03", strFS)
            sqlCV.SqlFields("QTN05", strFS, intFMode.msfld_Image)
            DB.RsSQL(sqlCV.Text, sqlCV.GetImgs)
          End If
        End If
      Case 5
        If CType(fldV.Cell, InterCmd).Text.Trim = "" Then Return
    End Select
    fldV.Hpos.Resolution = sngRel
    fldV.Cell.Resolution = sngRel
    Fldcmd.Add(fldV.Cell.CellType.ToString & "-" & ConDRAGN)
    ConDRAGN += 1
    Dim d As New DRAGN
    d.Name = fldV.Name
    If fldV.Cell.GetType Is GetType(PictCell) Then
      CType(fldV.Cell, PictCell).SetGetPict(AddressOf GetPictures)
      CType(fldV.Cell, PictCell).FileName = CType(fldV.Cell, PictCell).FileName
    End If
    d.SetObject(fldV)
    d.Resolution = sngRel
    d.ReMap()
    s3.Controls.Add(d)
    d.ResolutionView = sngRelView
    AddHandler d.Click, AddressOf Dragn_Click
    AddHandler d.Disposed, AddressOf Dragn_Dispose
    AddHandler d.PropertyChange, AddressOf PropertyChange
    AddHandler d.MoveRedraw, AddressOf ReDraws
    AddHandler d.DoCopy, AddressOf DoCopys
    AddHandler d.DoCopyMul, AddressOf DoCopymuls
    CurrDragn = d
    Button1.Enabled = False
    ReDraws(d, New Rectangle(0, 0, 0, 0), 2)
    s3.Refresh()
  End Sub
  Private Function ChageFDC(strV As String, strJ As String) As String
    Dim strK() As String = strJ.Split("-")
    Dim strP As String = strV.Replace("\[", Chr(1)).Replace("\]", Chr(2))
    Dim strM() As String = strP.Split("[")
    strV = ""
    For Each strI As String In strM
      Dim intI As Integer = strI.IndexOf("]")
      If intI < 0 Then
        strV &= strI
      Else
        strV &= "["
        Dim strPar As String = strI.Substring(0, intI)
        Dim bolT As Boolean = False
        Dim intL As Integer = strK.GetUpperBound(0)
        Dim strNP As String = ""
        For intM As Integer = strPar.Length - 1 To 0 Step -1
          If Char.IsNumber(strPar.Substring(intM, 1)) = False Then
            If bolT Then
              bolT = False
              strNP = strK(intL) & strNP
              intL -= 1
            End If
            strNP = strPar.Substring(intM, 1) & strNP
          Else
            If intL < 0 Then
              strNP = strPar.Substring(intM, 1) & strNP
            Else
              bolT = True
            End If
          End If
        Next
        strV &= strNP & strI.Substring(intI)
      End If
    Next
    Return strV
  End Function
  Private Sub DoCopymuls(ByVal s As DRAGN, ByVal fld As Flds, ByVal Xs As Single, Ys As Single, strJ As String)
    Dim strN As String = fld.Cell.CellType.ToString & "-" & ConDRAGN
    Fldcmd.Add(strN, fld.Cell.CellType, fld.Hpos.ToString & fld.Cell.ToString)
    ConDRAGN += 1
    fldV = Fldcmd.GetFields(strN)
    Select Case fld.Cell.CellType \ 1000
      Case 1
        CType(fldV.Cell, IBarcode).Text = CType(fld.Cell, IBarcode).Text
      Case 2
        CType(fldV.Cell, IText).Text = CType(fld.Cell, IText).Text
    End Select
    fldV.Reflash(True)
    fldV.Hpos.FDY += Ys
    fldV.Hpos.FDX += Xs
    fldV.Hpos.Resolution = sngRel
    fldV.Cell.Resolution = sngRel
    If strJ <> "" Then
      Fldcmd.UpdateProperty(fldV, "FDC", ChageFDC(Fldcmd.GetProperty(fldV, "FDC"), strJ))
    End If
    Dim d As New DRAGN
    d.Name = fldV.Name
    d.SetObject(fldV)
    d.Resolution = sngRel
    d.ReMap()
    s3.Controls.Add(d)
    d.ResolutionView = sngRelView
    AddHandler d.Click, AddressOf Dragn_Click
    AddHandler d.Disposed, AddressOf Dragn_Dispose
    AddHandler d.PropertyChange, AddressOf PropertyChange
    AddHandler d.MoveRedraw, AddressOf ReDraws
    AddHandler d.DoCopy, AddressOf DoCopys
    CurrDragn = d
    Button1.Enabled = False
    ReDraws(d, New Rectangle(0, 0, 0, 0), 2)
    s3.Refresh()
  End Sub

  Private Sub DoCopys(ByVal s As DRAGN, ByVal fld As Flds)
    Dim strN As String = fld.Cell.CellType.ToString & "-" & ConDRAGN
    Fldcmd.Add(strN, fld.Cell.CellType, fld.Hpos.ToString & fld.Cell.ToString)
    ConDRAGN += 1
    fldV = Fldcmd.GetFields(strN)
    Select Case fld.Cell.CellType \ 1000
      Case 1
        CType(fldV.Cell, IBarcode).Text = CType(fld.Cell, IBarcode).Text
      Case 2
        CType(fldV.Cell, IText).Text = CType(fld.Cell, IText).Text
    End Select
    fldV.Reflash(True)
    fldV.Hpos.FDY = fldV.Hpos.FDY + fld.Hpos.FDH
    fldV.Hpos.Resolution = sngRel
    fldV.Cell.Resolution = sngRel
    Dim d As New DRAGN
    d.Name = fldV.Name
    d.SetObject(fldV)
    d.Resolution = sngRel
    d.ReMap()
    s3.Controls.Add(d)
    d.ResolutionView = sngRelView
    AddHandler d.Click, AddressOf Dragn_Click
    AddHandler d.Disposed, AddressOf Dragn_Dispose
    AddHandler d.PropertyChange, AddressOf PropertyChange
    AddHandler d.MoveRedraw, AddressOf ReDraws
    AddHandler d.DoCopy, AddressOf DoCopys
    AddHandler d.DoCopyMul, AddressOf DoCopymuls
    CurrDragn = d
    Button1.Enabled = False
    ReDraws(d, New Rectangle(0, 0, 0, 0), 2)
    s3.Refresh()
  End Sub
  '當元件刪除清除資料
  Private Sub Dragn_Dispose(ByVal sender As Object, ByVal e As System.EventArgs)
    Dim s As DRAGN = sender
    Fldcmd.Remove(s.Name)
    RemoveHandler s.Disposed, AddressOf Dragn_Dispose
    RemoveHandler s.Click, AddressOf Dragn_Click
    RemoveHandler s.PropertyChange, AddressOf PropertyChange
    RemoveHandler s.MoveRedraw, AddressOf ReDraws
    RemoveHandler s.DoCopy, AddressOf DoCopys
    RemoveHandler s.DoCopyMul, AddressOf DoCopymuls
    If fldV IsNot Nothing Then fldV.Name = ""
    CurrDragn = Nothing
    DGV.Rows.Clear()
    ReDraws(Nothing, Nothing, 2)
  End Sub

  Public Sub ReDraws(ByVal sender As DRAGN, ByVal rgtV As Rectangle, ByVal intM As Integer)
    If s3.Image Is Nothing Or bolHaltReDraw Then Return
    Dim g As Graphics
    If intM = 1 Then
      If rgtV.X < 0 Or rgtV.Y < 0 Then
        Dim sp As New Point(IIf(rgtV.X < 0, -rgtV.X, 0), IIf(rgtV.Y < 0, -rgtV.Y, 0))
        rgtV.Location += sp
        sender.PointOff = sp
      End If
      If rgtV.Right > s3.ClientSize.Width Or rgtV.Bottom > s3.ClientSize.Height Then
        Dim sp As New Point(IIf(rgtV.Right > s3.ClientSize.Width, s3.ClientSize.Width - rgtV.Right, 0), _
                        IIf(rgtV.Bottom > s3.ClientSize.Height, s3.ClientSize.Height - rgtV.Bottom, 0))
        rgtV.Location += sp
        sender.PointOff = sp
      End If
      'Debug.Print(KPrgt.ToString)
      ControlPaint.DrawReversibleFrame(KPrgt, Color.Yellow, FrameStyle.Dashed)
      KPrgt = s3.RectangleToScreen(rgtV)
      ControlPaint.DrawReversibleFrame(KPrgt, Color.Yellow, FrameStyle.Dashed)
    ElseIf intM = 3 Then
      If rgtV.Right > s3.ClientSize.Width Or rgtV.Bottom > s3.ClientSize.Height Then
        Dim sp As New Point(IIf(rgtV.Right > s3.ClientSize.Width, s3.ClientSize.Width - rgtV.Right, 0), _
                        IIf(rgtV.Bottom > s3.ClientSize.Height, s3.ClientSize.Height - rgtV.Bottom, 0))
        rgtV.Width += sp.X
        rgtV.Height += sp.Y
        sender.PointOff = sp
      End If
      ControlPaint.DrawReversibleFrame(KPrgt, Color.Yellow, FrameStyle.Dashed)
      KPrgt = s3.RectangleToScreen(rgtV)
      ControlPaint.DrawReversibleFrame(KPrgt, Color.Yellow, FrameStyle.Dashed)
    ElseIf intM = 2 Then
      ControlPaint.DrawReversibleFrame(KPrgt, Color.Yellow, FrameStyle.Dashed)
      KPrgt = New Rectangle(0, 0, 0, 0)
      g = Graphics.FromImage(s3.Image)
      g.Clear(Color.White)
      For Each d As DRAGN In s3.Controls
        d.Resolution = fldVH.Hpos.Resolution
        If d.Visible = True Then
          Dim s As Bitmap = d.Getbmp
          If s IsNot Nothing Then
            g.DrawImage(s, d.GetLabCmds.GetClip(d.GetBmpSize), 0, 0, s.Width, s.Height, GraphicsUnit.Pixel, attb)
          End If
        End If
      Next
      If FigPath IsNot Nothing Then g.DrawPath(Pens.Blue, FigPath)
      s3.Refresh()
      g.Dispose()
    ElseIf intM = 0 Then
      KPrgt = sender.RectangleToScreen(sender.ClientRectangle)
    End If
  End Sub
  '元件資料變更顯示
  Private Sub PropertyChange(ByVal sender As DRAGN, ByVal strN As String)
    If fldV Is Nothing OrElse fldV.Name = "DUMMY" OrElse fldV.Name = "" OrElse bolHaltReDraw Then Return
    For Each drs As DataGridViewRow In DGV.Rows
      If drs.Cells(2).GetType IsNot GetType(DataGridViewButtonCell) Then
        If strN.Contains(drs.Cells(0).Value.ToString) Then
          drs.Cells(2).Value = Fldcmd.GetProperty(fldV, drs.Cells(0).Value.ToString).ToString
        End If
      End If
    Next
  End Sub
  '當元件Click抓取元件資料
  Private Sub Dragn_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    Dim s As DRAGN = sender, bolT As Boolean = False
    If fldV IsNot Nothing AndAlso s.Name = fldV.Name Then
      s.onDragn()
      Return
    End If
    fldV = Fldcmd.GetFields(s.Name)
    DGV.Rows.Clear()
    BuildDGV(fldV.Cell)
    If (fldV.Cell.CellType \ 1000) = 2 Then
      If CType(fldV.Cell, IText).FONTDOWNLOAD <> "" Then bolT = True
    End If
    For Each drs As DataGridViewRow In DGV.Rows
      drs.Cells(1).Value = BIG2GB(GCell(drs.Cells(1)))
      If drs.Cells(2).GetType IsNot GetType(DataGridViewButtonCell) Then
        If drs.Cells(2).ReadOnly Then
          drs.Cells(2).Value = BIG2GB(Fldcmd.GetProperty(fldV, drs.Cells(0).Value).ToString)
        Else
          drs.Cells(2).Value = Fldcmd.GetProperty(fldV, drs.Cells(0).Value).ToString
        End If
      End If
      If bolT AndAlso "FJX,FJY,MUX,FDH,MUY,FTN,FSZ,BSG,FTS,FSD,FSS,AutoSize,RZLock".Contains(drs.Cells(0).Value.ToString) Then
        drs.Cells(2).ReadOnly = True
        drs.Cells(2).Style.BackColor = Color.LightGray
      End If
    Next
    s.onDragn()
    CurrDragn = s
  End Sub
  Private Sub PageUpdate(ByVal f As FormSet, ByVal fld As Flds)
    Me.SuspendLayout()
    PL.Visible = False
    bolHaltReDraw = True
    fldVH = fld
    RemoveHandler f.DataChange, AddressOf PageUpdate
    DrawRuler()
    Dim dr As DRAGN
    For Each c As Control In s3.Controls
      dr = c
      dr.Resolution = sngRel
      dr.ResolutionView = sngRelView
      dr.ReMap()
    Next
    PL.Visible = True
    Me.ResumeLayout(True)
    bolHaltReDraw = False
    ReDraws(Nothing, Nothing, 2)
  End Sub
  '新增紙張設定
  Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
    Dim s1 As New FormSet(fldVH)
    AddHandler s1.DataChange, AddressOf PageUpdate
    s1.ShowDialog(Me)
  End Sub
  '變更螢幕顯示解析度
  Private Sub ControlResolutionViewChang()
    bolChgZoom = True
    Me.SuspendLayout()
    s3.SuspendLayout()
    PL.Visible = False
    bolHaltReDraw = True
    DrawRuler()
    Dim dr As DRAGN
    For Each c As Control In s3.Controls
      dr = c
      dr.ResolutionView = sngRelView
    Next
    PL.Visible = True
    Me.ResumeLayout(True)
    s3.ResumeLayout(True)
    bolHaltReDraw = False
    ReDraws(Nothing, Nothing, 2)
  End Sub
  Private Sub BuildDGV(ByVal c As Cells)
    If bolHaltReDraw Then Return
    Dim rs As New DataTable
    Dim LBFS As LabFlds() = Nothing
    Dim LF As LabFlds
    LBFS = fldV.Cell.Fields
    If LBFS Is Nothing Then Exit Sub
    For Each LF In LBFS
      Select Case LF.TypeofFld
        Case LabFlds.TypeFld.CommandB
          If LF.Name = "FDF" Then Continue For
          Dim r As Integer = DGV.Rows.Add(LF.Name, LF.Desc, "")
          Dim butncell As New DataGridViewButtonCell
          butncell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
          butncell.Value = BIG2GB("變  更")
          DGV.Rows(r).Cells(2) = butncell
        Case LabFlds.TypeFld.FixValue
          DGV.Rows.Add(LF.Name, LF.Desc, BIG2GB(Fldcmd.GetProperty(fldV, LF.Name).ToString))
          DGV.Rows(DGV.RowCount - 1).ReadOnly = True
          DGV.Rows(DGV.RowCount - 1).Cells(2).Style.BackColor = Color.LightGray
        Case LabFlds.TypeFld.StrValue, LabFlds.TypeFld.Numeric 'TEXT
          If LF.Name = "FDC" And strFDC.Trim <> "" Then
            Dim r As Integer = DGV.Rows.Add(LF.Name, LF.Desc, "")
            Dim cmcell As New DataGridViewComboBoxCell
            cmcell.DataSource = rsFDC
            cmcell.DisplayMember = "Value"
            cmcell.ValueMember = "ID"
            DGV.Rows(r).Cells(2) = cmcell
            DGV.Rows(r).Cells(2).Value = Fldcmd.GetProperty(fldV, LF.Name).ToString
          Else
            DGV.Rows.Add(LF.Name, LF.Desc, Fldcmd.GetProperty(fldV, LF.Name))
          End If
          If LF.ReqField Then DGV.Rows(DGV.RowCount - 1).Cells(2).Style.BackColor = Color.LightGreen
        Case LabFlds.TypeFld.SelValue
          rs = LF.CataLogs
          If rs Is Nothing Then Exit Select
          Dim r As Integer = DGV.Rows.Add(LF.Name, LF.Desc, "")
          For Each r1 As DataRow In rs.Rows
            r1!KEY = BIG2GB(r1!KEY.ToString)
          Next
          Dim cmcell As New DataGridViewComboBoxCell
          cmcell.DataSource = rs
          cmcell.DisplayMember = "KEY"
          cmcell.ValueMember = "DATA"
          DGV.Rows(r).Cells(2) = cmcell
          DGV.Rows(r).Cells(2).Value = Fldcmd.GetProperty(fldV, LF.Name).ToString
        Case LabFlds.TypeFld.Checked, LabFlds.TypeFld.BoolValue
          Dim ckcell As New DataGridViewCheckBoxCell
          ckcell.TrueValue = "True"
          ckcell.FalseValue = "False"
          Dim r As Integer = DGV.Rows.Add(LF.Name, LF.Desc, "")
          DGV.Rows(r).Cells(2) = ckcell
          DGV.Rows(r).Cells(2).Value = Fldcmd.GetProperty(fldV, LF.Name).ToString
      End Select
    Next
    DGV.Columns(0).ReadOnly = True
    DGV.Columns(1).ReadOnly = True
    DGV.Columns(0).Visible = False
  End Sub
  Private Sub TSCB1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TSCB1.KeyDown
    '放大縮小比率變更
    Dim intV As Integer
    If e.KeyData = Keys.Enter Then
      intV = Val(TSCB1.Text)
      TSCB1.Text = intV & "%"
      ControlResolutionViewChang()
    End If
  End Sub
  '放大
  Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
    If TSCB1.SelectedIndex > 0 Then
      TSCB1.SelectedIndex = TSCB1.SelectedIndex - 1
    ElseIf TSCB1.SelectedIndex < 0 Then
      TSCB1.SelectedIndex = 4
    End If
  End Sub
  '縮小
  Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
    If TSCB1.SelectedIndex <> 4 Then
      TSCB1.SelectedIndex = TSCB1.SelectedIndex + 1
    End If
  End Sub

  Private Overloads Function ReadAFont(ByVal c1 As IText) As Boolean
    FD.Font = c1.TextFont
    If FD.ShowDialog = Windows.Forms.DialogResult.OK Then
      c1.TextFont = FD.Font
      c1.CX = 1
      c1.CY = 1
      c1.AutoSize = True
      c1.RzLock = False
      c1.FONTDOWNLOAD = ""
      For Each drs As DataGridViewRow In DGV.Rows
        If "MUX,MUY,FTN,FSZ,FTS".Contains(drs.Cells(0).Value.ToString) Then
          drs.Cells(2).Value = BIG2GB(Fldcmd.GetProperty(fldV, drs.Cells(0).Value.ToString).ToString)
          drs.Cells(2).ReadOnly = True
          drs.Cells(2).Style.BackColor = Color.LightGray
        End If
        If "FJX,FJY,FDH,BSG,BVS,AutoSize,RZLock,FSD,FSS".Contains(drs.Cells(0).Value.ToString) Then
          drs.Cells(2).Value = Fldcmd.GetProperty(fldV, drs.Cells(0).Value.ToString).ToString
          drs.Cells(2).ReadOnly = False
          drs.Cells(2).Style.BackColor = Color.White
        End If
      Next
      Return True
      'For intI As Integer = 0 To DGV.RowCount - 1
      '  Select Case DGV.Rows(intI).Cells(0).Value.ToString.Trim
      '    Case "FTN"
      '      DGV.Rows(intI).Cells(2).Value = FD.Font.Name
      '    Case "FTS"
      '      DGV.Rows(intI).Cells(2).Value = FD.Font.Style.ToString
      '    Case "FSZ"
      '      DGV.Rows(intI).Cells(2).Value = FD.Font.Size
      '    Case "MUX", "MUY"
      '      DGV.Rows(intI).Cells(2).Value = 1
      '    Case "AutoSize"
      '      DGV.Rows(intI).Cells(2).Value = "True"
      '  End Select
      'Next
    End If
    Return False
  End Function
  Private Sub CB1_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CB1.SelectedValueChanged
    If DGV.ColumnCount = 0 Then Return
    DGV.Rows.Clear()
    Fldcmd.Add("DUMMY", Val(CB1.SelectedValue.ToString), "")
    fldV = Fldcmd.GetFields("DUMMY")
    CurrDragn = Nothing
    BuildDGV(fldV.Cell)
    Select Case (fldV.Cell.CellType \ 1000)
      Case 2
        ReadAFont(CType(fldV.Cell, IText))
      Case 4
        If Val(CB1.SelectedValue.ToString) \ 1000 = 4 Then
          ReadAFile(CType(fldV.Cell, PictCell))
          CType(fldV.Cell, PictCell).SetGetPict(AddressOf GetPictures)
        End If
    End Select
    Button1.Enabled = True
  End Sub
  Private Overloads Function ReadAFile(ByVal c1 As PictCell) As Boolean
    'FrmBMP.FileName = c1.FileName
    'If FrmBMP.ShowDialog = Windows.Forms.DialogResult.Yes Then
    '  c1.FileName = FrmBMP.FileName
    '  TBN.Text = FrmBMP.FileName
    '  Return True
    'End If
    'Return False
    OFD.FileName = c1.FileName
    If OFD.ShowDialog = Windows.Forms.DialogResult.OK Then
      c1.FileName = OFD.FileName
      Dim strFS As String = OFD.FileName
      If My.Resources.ResourceManager.GetObject(IO.Path.GetFileNameWithoutExtension(strFS)) IsNot Nothing Then
        c1.FileName = "@" & IO.Path.GetFileNameWithoutExtension(strFS)
      End If
      If IO.File.Exists(strFS) Then
        Dim sqlCV As New APSQL.SQLCNV
        sqlCV.sqlMAKE(SQLCNV.intMode.mssql_update, "SFIS_QTN")
        sqlCV.Where("QTN01", "=", "@LBFIMAGES")
        sqlCV.Where("QTN02", "=", IO.Path.GetFileNameWithoutExtension(strFS))
        sqlCV.SqlFields("QTN03", strFS)
        sqlCV.SqlFields("QTN05", strFS, intFMode.msfld_Image)
        Dim intL As Integer = DB.RsSQL(sqlCV.Text, sqlCV.GetImgs)
        If intL = 0 Then
          sqlCV.sqlMAKE(SQLCNV.intMode.mssql_insert, "SFIS_QTN")
          sqlCV.SqlFields("QTN01", "@LBFIMAGES")
          sqlCV.SqlFields("QTN02", IO.Path.GetFileNameWithoutExtension(strFS))
          sqlCV.SqlFields("QTN03", strFS)
          sqlCV.SqlFields("QTN05", strFS, intFMode.msfld_Image)
          DB.RsSQL(sqlCV.Text, sqlCV.GetImgs)
        End If
      End If
      Dim intI As Integer
      For intI = 0 To DGV.RowCount - 1
        If DGV.Rows(intI).Cells(0).Value.ToString.Trim = "FDS" Then
          DGV.Rows(intI).Cells(2).Value = OFD.FileName
        End If
      Next
      Return True
    End If
    Return False
  End Function

  Private Sub DGV_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellClick
    'Button元件
    If e.RowIndex < 0 Or e.RowIndex > DGV.Rows.Count Then Return
    If DGV.Rows(e.RowIndex).Cells(e.ColumnIndex).GetType Is GetType(DataGridViewButtonCell) Then
      Select Case DGV.Rows(e.RowIndex).Cells(0).Value
        Case "FONT" '字型變更
          If ReadAFont(fldV.Cell) Then
            If CurrDragn IsNot Nothing Then
              CurrDragn.AutoSize = True
              CurrDragn.ReMap()
              ReDraws(Nothing, Nothing, 2)
            End If
          End If
        Case "FDS"
          If ReadAFile(fldV.Cell) Then
            If CurrDragn IsNot Nothing Then
              CurrDragn.ReMap()
              ReDraws(Nothing, Nothing, 2)
            End If
          End If
          'Case "FDF"
          '  If ReadAPCL(fldV.Cell) Then
          '    fldV.Hpos.FDH = fldV.Cell.MHeight
          '    If CurrDragn IsNot Nothing Then
          '      CurrDragn.ReMap()
          '      ReDraws(Nothing, Nothing, 2)
          '    End If
          '  End If
      End Select
    End If
  End Sub
  Private Function isCellNull(c As DataGridViewCell) As Boolean
    If c Is Nothing OrElse c.Value Is Nothing OrElse c.Value Is DBNull.Value Then
      Return True
    Else
      Return False
    End If
  End Function

  Private Function GCell(c As DataGridViewCell, Optional bolFmtVal As Boolean = False) As String
    If isCellNull(c) = True Then Return ""
    If bolFmtVal Then
      Return c.FormattedValue.ToString.Trim
    Else
      Return c.Value.ToString.Trim
    End If
  End Function
  Private Sub DGV_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellEndEdit
    '當DGVCell資料變更時更新元件資料
    If e.ColumnIndex = 2 Then
      If GCell(DGV.Rows(e.RowIndex).Cells(0)) = "FDC" Then
        If strFDC.Trim = "" And GCell(DGV.Rows(e.RowIndex).Cells(2)) = "" Then Return
        For Each r As DataGridViewRow In DGV.Rows
          If GCell(r.Cells(0)) = "FDS" AndAlso (GCell(r.Cells(2)) = "" Or (GCell(r.Cells(2)).StartsWith("<") And GCell(r.Cells(2)).EndsWith(">"))) Then
            r.Cells(2).Value = "<" & GCell(DGV.Rows(e.RowIndex).Cells(2)) & ">"
            Fldcmd.UpdateProperty(fldV, GCell(r.Cells(0)), GCell(r.Cells(2)))
          End If
        Next
      End If
      Fldcmd.UpdateProperty(fldV, DGV.Rows(e.RowIndex).Cells(0).Value, DGV.Rows(e.RowIndex).Cells(2).Value)
      If CurrDragn IsNot Nothing Then
        CurrDragn.ReMap()
        ReDraws(Nothing, New Rectangle(0, 0, 0, 0), 2)
      End If
    End If
  End Sub

  Private Sub TSSB1_DropDownItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles TSSB1.DropDownItemClicked
    '選擇元件列表中元件帶到最前面及顯示該元件資料
    s3.Controls(e.ClickedItem.Name).BringToFront()
    s3.Controls(e.ClickedItem.Name).Select()
    Dragn_Click(s3.Controls(e.ClickedItem.Name), EventArgs.Empty)
  End Sub

  Private Function DrawBitmap() As Bitmap
    Dim Xsize As Integer, Ysize As Integer
    Dim p As PageCell = fldVH.Cell
    Xsize = Int((fldVH.Hpos.FDW - (p.PageArrayX - 1) * p.PagePitchX) * sngRel * 0.03937 + 0.5)
    Ysize = Int((fldVH.Hpos.FDH - (p.PageArrayY - 1) * p.PagePitchY) * sngRel * 0.03937 + 0.5)
    If (Xsize Mod 8) = 0 Then Xsize += 1
    Dim sngR As Single = p.Round * sngRel * 0.03937
    Dim FP As New Drawing.Drawing2D.GraphicsPath
    Dim bitX As New Bitmap(Xsize, Ysize)
    Dim g As Graphics = Graphics.FromImage(bitX)
    g.Clear(Color.White)
    For Each d As DRAGN In s3.Controls
      'If d.GetBar.FieldData.StartsWith("*") And (d.GetBar.CellType \ 1000) = 1 Then
      '  CType(d.GetBar, IBarcode).DrawColor = Color.Red
      '  d.LabFldV.Reflash()
      'End If
      Dim s As Bitmap = d.Getbmp
      If s IsNot Nothing Then
        g.DrawImage(s, d.GetLabCmds.GetView(d.GetBmpSize), 0, 0, s.Width, s.Height, GraphicsUnit.Pixel, attb)
      End If
      'If d.GetBar.FieldData.StartsWith("*") And (d.GetBar.CellType \ 1000) = 1 Then
      '  CType(d.GetBar, IBarcode).DrawColor = Color.Black
      '  d.LabFldV.Reflash()
      'End If
    Next
    If sngR = 0 Then
      g.DrawRectangle(New Pen(Color.Black, 0), New Rectangle(0, 0, Xsize - 1, Ysize - 1))
    Else
      FP.StartFigure()
      FP.AddArc(0, 0, sngR, sngR, 180, 90)
      FP.AddLine(sngR, 0, Xsize - sngR - 1, 0)
      FP.AddArc(Xsize - sngR - 1, 0, sngR, sngR, 270, 90)
      FP.AddLine(Xsize - 1, sngR, Xsize - 1, Ysize - sngR - 1)
      FP.AddArc(Xsize - sngR - 1, Ysize - sngR - 1, sngR, sngR, 0, 90)
      FP.AddLine(Xsize - sngR - 1, Ysize - 1, sngR, Ysize - 1)
      FP.AddArc(0, Ysize - sngR - 1, sngR, sngR, 90, 90)
      FP.CloseFigure()
      g.DrawPath(New Pen(Color.Black, 0), FP)
    End If
    Dim sm As New GETMONO
    sm.GetBMP(bitX, New Rectangle(0, 0, Xsize, Ysize))
    Dim bitY As Bitmap = sm.GetCLIPMono
    bitX.Dispose()
    g.Dispose()
    Return bitY
  End Function

  'Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
  '  CB1.SelectedIndex = 0
  '  'SC.Panel1Collapsed = True
  'End Sub
  '儲存檔案
  Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
    If ComboBox1.Text.Trim = "" Then
      MsgBox(BIG2GB("格式名不得空白"), MsgBoxStyle.OkOnly)
      Return
    End If
    Dim strCMD As String = ToLbfx()
    Dim bytV() As Byte = System.Text.Encoding.UTF8.GetBytes(strCMD)
    sqlcv.sqlMAKE(SQLCNV.intMode.mssql_update, strQTN)
    sqlcv.Where("QTN01", "=", "#LBFX")
    sqlcv.Where("QTN02", "=", ComboBox1.Text.Trim.ToUpper)
    sqlcv.SqlFields("QTN03", LName.Text & vbTab & LDesc.Text.Trim)
    sqlcv.SqlFields("QTN04", ComboBox2.Text.Trim.ToUpper)
    sqlcv.SqlFields("QTN05", bytV)
    Dim intL As Integer = DB.RsSQL(sqlcv.Text, sqlcv.GetImgs)
    If intL = 0 Then
      sqlcv.sqlMAKE(SQLCNV.intMode.mssql_insert, strQTN)
      sqlcv.SqlFields("QTN01", "#LBFX")
      sqlcv.SqlFields("QTN02", ComboBox1.Text.Trim.ToUpper)
      sqlcv.SqlFields("QTN03", LName.Text & vbTab & LDesc.Text.Trim)
      sqlcv.SqlFields("QTN04", ComboBox2.Text.Trim.ToUpper)
      sqlcv.SqlFields("QTN05", bytV)
      DB.RsSQL(sqlcv.Text, sqlcv.GetImgs)
      ComboBox1.Items.Add(ComboBox1.Text.Trim)
      If ComboBox2.Text.Trim <> "" AndAlso ComboBox2.Items.IndexOf(ComboBox2.Text.Trim.ToUpper) = -1 Then
        ComboBox2.Items.Add(ComboBox2.Text.Trim.ToUpper)
      End If
    End If
    sqlcv.sqlMAKE(SQLCNV.intMode.mssql_select, strQTN)
    sqlcv.Where("QTN01", "=", "#LABELS")
    sqlcv.Where("QTN02", "=", ComboBox1.Text.Trim.ToUpper)
    sqlcv.SqlFields("QTN02")
    Dim rs As DataTable = DB.RsSQL(sqlcv.Text, "RT")
    If rs.Rows.Count > 0 Then
      sqlcv.sqlMAKE(SQLCNV.intMode.mssql_update, strQTN)
      sqlcv.Where("QTN01", "=", "#LABELS")
      sqlcv.Where("QTN02", "=", ComboBox1.Text.Trim.ToUpper)
    Else
      sqlcv.sqlMAKE(SQLCNV.intMode.mssql_insert, strQTN)
      sqlcv.SqlFields("QTN01", "#LABELS")
      sqlcv.SqlFields("QTN02", ComboBox1.Text.Trim.ToUpper)
    End If
    sqlcv.SqlFields("QTN03", LName.Text & vbTab & LDesc.Text.Trim)
    sqlcv.SqlFields("QTN04", ComboBox2.Text.Trim.ToUpper)
    Dim bmp1 As Bitmap = DrawBitmap()
    Dim fs As New IO.MemoryStream
    bmp1.Save(fs, Imaging.ImageFormat.Png)
    sqlcv.SqlFields("QTN05", fs.ToArray)
    DB.RsSQL(sqlcv.Text, sqlcv.GetImgs)
    fs.Close()
    bmp1.Dispose()
    fs.Dispose()
    MsgBox(BIG2GB("儲存完畢"))
  End Sub

  Private Sub DGV_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV.CellMouseDown
    If e.Button = Windows.Forms.MouseButtons.Right Then
      If e.RowIndex < 0 Or e.RowIndex >= DGV.Rows.Count Or e.ColumnIndex <> 2 Then Return
      If DGV.Rows(e.RowIndex).Cells(e.ColumnIndex).GetType Is GetType(DataGridViewTextBoxCell) Then
        DGV.CurrentCell = DGV.Rows(e.RowIndex).Cells(e.ColumnIndex)
        Dim pt As Rectangle = DGV.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False)
        Me.Controls.Add(TEV)
        TEV.Visible = True
        TEV.BringToFront()
        TEV.Location = Me.PointToClient(DGV.PointToScreen(pt.Location))
        If TEV.Bottom > Me.ClientRectangle.Height Then
          TEV.Top = TEV.Top - TEV.Height + pt.Height
        End If
        TEV.Text = GCell(DGV.CurrentCell)
        TEV.Focus()
      End If
    End If
  End Sub

  Private Sub DGV_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGV.CurrentCellDirtyStateChanged
    Static bolT As Boolean = False
    If bolT Then Return
    bolT = True
    If DGV.CurrentCell.GetType Is GetType(DataGridViewComboBoxCell) Or DGV.CurrentCell.GetType Is GetType(DataGridViewCheckBoxCell) Then
      'Debug.Print(DGV.CurrentCell.RowIndex & "," & DGV.CurrentCell.ColumnIndex)
      DGV.CommitEdit(DataGridViewDataErrorContexts.CurrentCellChange)
      Fldcmd.UpdateProperty(fldV, DGV.CurrentRow.Cells(0).Value, DGV.CurrentCell.Value)
      If CurrDragn IsNot Nothing Then
        CurrDragn.ReMap(True)
        ReDraws(Nothing, Nothing, 2)
      End If
    End If
    bolT = False
  End Sub

  'Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
  '  msg.Items.Clear()
  '  'Button3.Enabled = False
  'End Sub

  Private Sub Fldcmd_Errors(ByVal o As Object, ByVal strV As String) Handles Fldcmd.Errors
    If o.GetType.GetMember("CellType").Length > 0 Then
      With CType(o, Cells)
        msg.Items.Add(.CellType.ToString & ":" & strV)
        'Button3.Enabled = True
      End With
    End If
  End Sub

  Private Sub LoadFromFile(strN As String)
    Dim strV() As String
    If strN.Length > 100 OrElse IO.File.Exists(strN) = False Then
      strV = strN.Split(vbCrLf.ToCharArray)
    ElseIf IO.File.Exists(strN) = False Then
      Return
    Else
      strV = IO.File.ReadAllLines(strN, System.Text.Encoding.UTF8)
    End If
    Dim strCMD As String = "", intC As Integer = 0, intT As Integer = 0, strName As String = ""
    Dim rs As New DataTable
    rs.Columns.Add("PC01", GetType(Integer))
    rs.Columns.Add("PC02", GetType(String))
    rs.Columns.Add("PC03", GetType(Integer))
    rs.Columns.Add("PC04", GetType(String))
    rs.TableName = "BTPC"
    For Each strP As String In strV
      If strP.Trim = "" Then Continue For
      If strP.StartsWith("# ") Then
        If strP.StartsWith("# FileName = ") Then ComboBox1.Text = strP.Substring(13).Trim
        If strP.StartsWith("# Group = ") Then ComboBox2.Text = strP.Substring(10).Trim
        If strP.StartsWith("# Desc = ") Then LDesc.Text = strP.Substring(9).Trim
        If strP.StartsWith("# Name = ") Then LName.Text = strP.Substring(9).Trim
        Continue For
      End If
      If strP.StartsWith("[") And strP.EndsWith("]") Then
        If strName <> "" Then
          rs.Rows.Add(intC, strName, intT, strCMD)
        End If
        strName = strP.Trim("[ ]".ToCharArray)
        intC += 1
        intT = 0
        strCMD = ""
        Continue For
      End If
      If strP.StartsWith("Name = ") Then
        strName = strP.Substring(7).Trim
        Continue For
      End If
      If strP.StartsWith("Type = ") Then
        intT = Val(strP.Substring(7))
        Continue For
      End If
      strCMD &= strP & vbCrLf
    Next
    If strName <> "" Then
      rs.Rows.Add(intC, strName, intT, strCMD)
    End If
    Clean(False)
    bolChgZoom = False
    Application.UseWaitCursor = True
    Me.SuspendLayout()
    PL.Visible = False
    bolHaltReDraw = True
    Fldcmd.Clear()
    ConDRAGN = 0
    Fldcmd.Resolution = sngRel
    Fldcmd.Add(rs)
    For Each strNX As String In Fldcmd.GetFields.Keys
      Dim fldSV As Flds = Fldcmd.GetFields(strNX)
      If fldSV.Cell.CellType = BarType.無 Then
        fldVH = fldSV
        sngRel = fldSV.Cell.Resolution
        Fldcmd.AxisResolution = sngRel
        fldSV.Hpos.Resolution = sngRel
        Fldcmd.Resolution = sngRel
        DrawRuler()
        Continue For
      End If
      If fldSV.Cell.GetType Is GetType(PictCell) Then
        CType(fldSV.Cell, PictCell).SetGetPict(AddressOf GetPictures)
        CType(fldSV.Cell, PictCell).FileName = CType(fldSV.Cell, PictCell).FileName
      End If
      Dim d As New DRAGN
      fldSV.Cell.Resolution = sngRel
      d.SetObject(fldSV)
      d.ResolutionView = sngRelView
      d.Name = strNX
      s3.Controls.Add(d)
      Dim intI As Integer = Val(strNX.Substring(strNX.IndexOf("-") + 1))
      If intI > ConDRAGN Then ConDRAGN = intI
      AddHandler d.Click, AddressOf Dragn_Click
      AddHandler d.Disposed, AddressOf Dragn_Dispose
      AddHandler d.PropertyChange, AddressOf PropertyChange
      AddHandler d.MoveRedraw, AddressOf ReDraws
      AddHandler d.DoCopy, AddressOf DoCopys
      AddHandler d.DoCopyMul, AddressOf DoCopymuls
    Next
    Button1.Enabled = False
    ConDRAGN += 1
    PL.Visible = True
    bolHaltReDraw = False
    Me.ResumeLayout(True)
    ReDraws(Nothing, Nothing, 2)
    Application.UseWaitCursor = False
  End Sub
  Private Function ToLbfx() As String
    Dim strLB As String = ""
    strLB &= "# FileName = " & ComboBox1.Text.Trim & vbCrLf
    strLB &= "# Group = " & ComboBox2.Text.Trim & vbCrLf
    strLB &= "# Name = " & LName.Text.Trim & vbCrLf
    strLB &= "# Desc = " & LDesc.Text.Trim & vbCrLf
    strLB &= "# Version = " & "001" & vbCrLf
    strLB &= "# Update Time = " & Now.ToString & vbCrLf
    strLB &= "[Paper]" & vbCrLf
    strLB &= "Name = " & fldVH.Name & vbCrLf
    strLB &= "Type = " & CType(fldVH.Cell.CellType, Integer) & vbCrLf
    strLB &= fldVH.Hpos.ToString.Trim(vbCrLf.ToCharArray) & vbCrLf
    strLB &= fldVH.Cell.ToString.Trim(vbCrLf.ToCharArray) & vbCrLf
    For Each fld As Flds In Fldcmd.GetFields.Values
      If fld.Cell.CellType = BarType.無 Then Continue For
      strLB &= "[" & fld.Name.Trim & "]" & vbCrLf
      strLB &= "Type = " & CType(fld.Cell.CellType, Integer) & vbCrLf
      strLB &= fld.Hpos.ToString.Trim(vbCrLf.ToCharArray) & vbCrLf
      strLB &= fld.Cell.ToString.Trim(vbCrLf.ToCharArray) & vbCrLf
    Next
    Return strLB.TrimEnd(vbCrLf.ToCharArray)
  End Function
  Private Sub SaveToFile(ByVal strN As String)
    IO.File.WriteAllText(strN, ToLbfx, System.Text.Encoding.UTF8)
    MsgBox(BIG2GB("儲存完畢"))
  End Sub

  Private Sub ToolStripButton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton9.Click
    If ComboBox1.Text.Trim = "" Then
      MsgBox(BIG2GB("格式名不得空白"), MsgBoxStyle.OkOnly)
      Return
    End If
    Dim FDL As New SaveFileDialog
    FDL.Title = BIG2GB("另存新文字檔")
    If IO.Directory.Exists("C:\LABTRAN") = False Then IO.Directory.CreateDirectory("C:\LABTRAN")
    FDL.InitialDirectory = "C:\LABTRAN"
    FDL.DefaultExt = ".LBFx"
    FDL.Filter = BIG2GB("LABTRAN文字檔|*.LBFx")
    FDL.FileName = ComboBox1.Text.Trim & ".LBFx"
    If FDL.ShowDialog = Windows.Forms.DialogResult.OK Then
      SaveToFile(FDL.FileName)
    End If
    FDL.Dispose()
  End Sub

  Private Sub TSCB1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TSCB1.SelectedIndexChanged
    If TSCB1.Enabled = False Then Return
    ControlResolutionViewChang()
  End Sub

  Private Sub ComboBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox1.KeyPress
    If e.KeyChar = vbCr Then
      e.Handled = True
      ComboBox1_SelectedIndexChanged(Nothing, Nothing)
    End If
  End Sub

  Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
    If ComboBox1.Enabled = False Then Return
    If bolCheck = True Then
      bolCheck = False
      ComboBox1.Enabled = False
      Return
    End If
    If ComboBox1.Text.Trim = "" Then
      Clean()
      Return
    End If
    ComboBox1.Enabled = False
    Dim strKP As String = ComboBox1.Text.Trim.ToUpper
    sqlcv.sqlMAKE(SQLCNV.intMode.mssql_select, strQTN)
    sqlcv.Where("QTN01", "=", "#LBFX")
    sqlcv.Where("QTN02", "=", strKP)
    sqlcv.SqlFields("QTN03")
    sqlcv.SqlFields("QTN04")
    sqlcv.SqlFields("QTN05")
    Dim rs As DataTable = DB.RsSQL(sqlcv.Text, "RT")
    If rs.Rows.Count = 0 Then
      Clean()
      ToolStripButton3_Click(Nothing, Nothing)
    Else
      Dim bytV() As Byte = rs.Rows(0)!QTN05
      Dim strF As String = System.Text.Encoding.UTF8.GetString(bytV)
      LoadFromFile(strF)
      ComboBox2.Text = rs.Rows(0)!QTN04.ToString.Trim
      Dim str03() As String = rs.Rows(0)!QTN03.ToString.Trim.Split(vbTab)
      If str03.Length > 1 Then
        LDesc.Text = str03(1)
        LName.Text = str03(0)
      Else
        LDesc.Text = rs.Rows(0)!QTN03.ToString.Trim
        LName.Text = ""
      End If
    End If
    ComboBox1.Text = strKP
  End Sub

  Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
    Clean()
    ComboBox1.Enabled = True
  End Sub

  Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
    Dim intI As Integer = -1, strP As String = ""
    strP = ComboBox1.Text.Trim
    For intK As Integer = 0 To ComboBox1.Items.Count - 1
      If ComboBox1.Items(intK).Trim.ToUpper = ComboBox1.Text.Trim.ToUpper Then
        intI = intK
        strP = ComboBox1.Items(intK).Trim
        Exit For
      End If
    Next
    If MsgBox(BIG2GB("是否要清除格式" & strP), MsgBoxStyle.YesNo, Me.Text) = MsgBoxResult.Yes Then
      If intI >= 0 Then
        ComboBox1.Items.RemoveAt(intI)
      End If
      Dim sqlCV As New APSQL.SQLCNV
      sqlCV.sqlMAKE(SQLCNV.intMode.mssql_delete, strQTN)
      sqlCV.Where("QTN01", "IN", "'#LBFX','#LABELS'", intFMode.msfld_field)
      sqlCV.Where("QTN02", "=", strP.ToUpper.Trim)
      DB.RsSQL(sqlCV.Text)
      Clean()
    End If
  End Sub

  Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
    If ComboBox1.Enabled = True Then
      Dim FDL1 As New OpenFileDialog
      FDL1.Title = BIG2GB("開啟LBFx文字檔")
      If IO.Directory.Exists("C:\LABTRAN") = False Then IO.Directory.CreateDirectory("C:\LABTRAN")
      FDL1.InitialDirectory = "C:\LABTRAN"
      FDL1.DefaultExt = ".LBFx"
      FDL1.Filter = BIG2GB("LABTRAN文字檔|*.LBFx")
      FDL1.FileName = ComboBox1.Text.Trim & ".LBFx"
      If FDL1.ShowDialog = Windows.Forms.DialogResult.OK Then
        If IO.File.Exists(FDL1.FileName) = False Then Return
        Dim strK() As String = IO.File.ReadAllLines(FDL1.FileName)
        Dim strL As String = ""
        For Each strM As String In strK
          If strM.Trim.StartsWith("# FileName =") Then
            strL = strM.Trim.Substring(12).Trim
            Exit For
          End If
        Next
        LoadFromFile(FDL1.FileName)
        ComboBox1.Enabled = False
        ComboBox1.Text = strL.ToUpper
      End If
      FDL1.Dispose()
      Return
    Else
      MsgBox(BIG2GB("請先按新格式再導入文件檔"))
    End If
  End Sub

  Private Sub DGV_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DGV.DataError

  End Sub

  Private Sub EXITS_Click(sender As Object, e As EventArgs) Handles EXITS.Click
    Me.Close()
    TuiCK(Me)
  End Sub

  Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
    ComboBox1.Enabled = True
    bolCheck = True
  End Sub

  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    Panel1.Visible = True
    Me.Controls.Add(Panel1)
    Panel1.BringToFront()
    Dim sqlCV As New APSQL.SQLCNV
    sqlCV.sqlMAKE(SQLCNV.intMode.mssql_select, "SFIS_QTN")
    sqlCV.Where("QTN01", "=", "#LBFX")
    If ComboBox2.Text.Trim <> "" Then
      sqlCV.Where("QTN04", "=", ComboBox2.Text.Trim)
    End If
    sqlCV.SqlFields("QTN04", BIG2GB("類別"), , , True)
    sqlCV.SqlFields("QTN02", BIG2GB("格式名"), , , True)
    sqlCV.SqlFields("('')", BIG2GB("名稱"))
    sqlCV.SqlFields("QTN03", BIG2GB("說明"))
    Dim rs As DataTable = DB.RsSQL(sqlCV.Text, "QLAB1")
    For Each r As DataRow In rs.Rows
      Dim str03() As String = r.Item(3).ToString.Trim.Split(vbTab)
      If str03.Length > 1 Then
        r.Item(2) = str03(0)
        r.Item(3) = str03(1)
      End If
    Next
    FNDATA.DataSource = rs
  End Sub

  Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    If FNDATA.CurrentRow Is Nothing Then
      Panel1.Visible = False
    End If
    Clean()
    ComboBox1.Enabled = True
    ComboBox1.Text = GCell(FNDATA.CurrentRow.Cells(1))
    ComboBox2.Text = GCell(FNDATA.CurrentRow.Cells(0))
    Panel1.Visible = False
    ComboBox1_SelectedIndexChanged(Nothing, Nothing)
  End Sub

  Private Sub msg_SelectedIndexChanged(sender As Object, e As EventArgs) Handles msg.SelectedIndexChanged
    msg.Items.Clear()
  End Sub

  Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
    Panel1.Visible = False
  End Sub

  Private Sub FNDATA_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles FNDATA.CellContentClick
    Button3_Click(Nothing, Nothing)
  End Sub

  Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
    Dim f As New LBFTPRT
    f.LBFName = ComboBox1.Text.Trim
    f.ShowDialog()
  End Sub

  Private Sub DGV_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV.CellContentClick

  End Sub

  Private Sub TEV_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TEV.KeyPress
    If e.KeyChar = vbCr Or e.KeyChar = vbLf Then
      e.Handled = True
      My.Computer.Keyboard.SendKeys(vbTab)
    End If
  End Sub

  Private Sub TEV_LostFocus(sender As Object, e As EventArgs) Handles TEV.LostFocus
    DGV.CurrentCell.Value = TEV.Text.Trim
    DGV_CellEndEdit(DGV, New DataGridViewCellEventArgs(DGV.CurrentCell.ColumnIndex, DGV.CurrentCell.RowIndex))
    TEV.Visible = False
  End Sub
End Class
