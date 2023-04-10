Public Class clsLBPRT
  Private strName As String = "LBPRT"
  Private strPrtName As String
  Private strSyncFile As String
  Private strLBName As String
  Private nextLBPRT As clsLBPRT = Nothing
  Private arySymbols As New Dictionary(Of String, ArrayList)
  Private aryCells As New ArrayList
  Private aryPV As New Dictionary(Of String, String)
  Private bolSelectPrt As Boolean = False
  Private bolSelectFirst As Boolean = False
  Private aryBuff As New ArrayList
  Private intPage As Integer = 0
  Private sngWidth As Single = 0
  Private sngHeight As Single = 0
  Private sngEdgeLeft As Single = 0
  Private sngEdgeTop As Single = 0
  Private sngEdgeBottom As Single = 0
  Private sngEdgeRight As Single = 0
  Private sngFootHeight As Single = 0
  Private bolAutoPage As Boolean = 0
  Private bolPORG As Boolean = False
  Private rtLast As New RectangleF(0, 0, 0, 0)
    Private intPQ As System.Drawing.Printing.PrinterResolutionKind = System.Drawing.Printing.PrinterResolutionKind.Custom
    Private intPK As System.Drawing.Printing.PaperKind = System.Drawing.Printing.PaperKind.A4
  Private intCCnt As Integer = 0
  Private sngLX As Single = 0
  Private sngLY As Single = 0
  Private sgx As Graphics
  Private szPageSize As SizeF = New SizeF(0, 0)
  Private arySeg As New ArrayList
  Public Class LBPCell
    Public strID As String = ""
    Public intMode As Integer = 0
    Public rgt As RectangleF
    Public strSPar As String = ""
    Public Overridable Function ReCall(strV As String) As String()
      Dim strM() As String = strV.Split(vbTab)
      intMode = Val(strM(0))
      strID = strM(1)
      rgt = New RectangleF(Val(strM(2)), Val(strM(3)), Val(strM(4)), Val(strM(5)))
      strSPar = strM(6)
      Return strM
    End Function
    Public Overrides Function ToString() As String
      Return intMode & vbTab & strID & vbTab & rgt.X & vbTab & rgt.Y & vbTab & rgt.Width & vbTab & rgt.Height & vbTab & strSPar
    End Function
  End Class
  Public Class PCell
    Inherits LBPCell
    Public fmt As StringFormat
    Public CF As Font
    Public Br As Brush
    Public strV As String
    Public Sub Show(ByVal gx As Graphics)
      'Debug.Print(gx.DpiX & "," & gx.DpiY & "," & strV)
      gx.DrawString(strV, CF, Br, New RectangleF(rgt.X, rgt.Y + 3, rgt.Width, rgt.Height - 3), fmt)
    End Sub
    Public Overrides Function ReCall(strP As String) As String()
      Dim strM() As String = MyBase.ReCall(strP)
      Dim f As FontStyle = Val(strM(9))
      CF = New Font(strM(7), CType(Val(strM(8)), Single), f)
      fmt = New StringFormat
      fmt.Alignment = Val(strM(10))
      fmt.LineAlignment = Val(strM(11))
      fmt.Trimming = Val(strM(12))
      fmt.FormatFlags = Val(strM(13))
      Br = New SolidBrush(Color.FromArgb(Val(strM(14))))
      strV = strM(15).Replace("$*CR$", vbCr)
      strV = strV.Replace("$*LF$", vbLf)
      strV = strV.Replace("$*TB$", vbTab)
      Return strM
    End Function
    Public Overrides Function ToString() As String
      Dim strK As String = MyBase.ToString() & vbTab
      Dim strP As String = strV.Replace(vbTab, "$*TB$")
      strP = strP.Replace(vbCr, "$*CR$")
      strP = strP.Replace(vbLf, "$*LF$")
      strK &= CF.FontFamily.Name & vbTab & CF.Size.ToString("0.00") & vbTab & CF.Style.ToString("D") & vbTab
      strK &= fmt.Alignment.ToString("D") & vbTab & fmt.LineAlignment.ToString("D") & vbTab & fmt.Trimming.ToString("D") & vbTab & fmt.FormatFlags.ToString("D") & vbTab
      strK &= CType(Br, SolidBrush).Color.ToArgb.ToString("0") & vbTab & strP & vbCrLf
      Return strK
    End Function
  End Class
  Public Class LCell
    Inherits LBPCell
    Public Pn As Pen
    Public Sub Show(ByVal gx As Graphics)
      gx.DrawLine(Pn, rgt.X, rgt.Y, rgt.X + rgt.Width, rgt.Y + rgt.Height)
    End Sub
    Public Overrides Function ReCall(strV As String) As String()
      Dim strM() As String = MyBase.ReCall(strV)
      Pn = New Pen(Color.FromArgb(Val(strM(7))), Val(strM(8)))
      Pn.DashStyle = Val(strM(9))
      Pn.SetLineCap(Drawing2D.LineCap.Round, Drawing2D.LineCap.Round, Drawing2D.DashCap.Round)
      Return strM
    End Function
    Public Overrides Function ToString() As String
      Dim strP As String = MyBase.ToString() & vbTab
      strP &= Pn.Color.ToArgb.ToString("0") & vbTab & Pn.Width.ToString("0.00") & vbTab
      strP &= Pn.DashStyle.ToString("D") & vbCrLf
      Return strP
    End Function
  End Class
  Public Class DrwCell
    Inherits LBPCell
    Private bmpx As Bitmap = Nothing
    Public bolOrg As Boolean = False
    Public strB As String = ""
    Public Sub SetBmps(s As Bitmap)
      bmpx = s
    End Sub
    Public Sub Show(gx As Graphics)
      If bmpx Is Nothing Then
        If strB.StartsWith("@") Then
          bmpx = My.Resources.ResourceManager.GetObject(strB.Substring(1).Trim)
        Else
          If IO.File.Exists(strB) Then
            bmpx = New Bitmap(strB)
          Else
            gx.DrawRectangle(Pens.Black, rgt.X, rgt.Y, rgt.Width, rgt.Height)
            Return
          End If
        End If
      End If
      '不放大縮小
      If bolOrg Then
        gx.DrawImage(bmpx, rgt.Location)
        Return
      End If
      Dim sngX As Single = bmpx.Width
      Dim sngY As Single = bmpx.Height
      Dim sngJ As Single = sngX / sngY
      Dim sngI As Single = (rgt.Width / rgt.Height) / sngJ
      Dim rgtF As RectangleF = Nothing
      If sngI > 1 Then
        Dim sngL As Single = (rgt.Width - (rgt.Width / sngI)) / 2
        rgtF = New RectangleF(sngL + rgt.X, rgt.Y, rgt.Width / sngI, rgt.Height)
      Else
        Dim sngL As Single = (rgt.Height - (rgt.Height * sngI)) / 2
        rgtF = New RectangleF(rgt.X, sngL + rgt.Y, rgt.Width, rgt.Height * sngI)
      End If
      gx.DrawImage(bmpx, rgtF)
    End Sub
    Public Overrides Function ReCall(strV As String) As String()
      Dim strM() As String = MyBase.ReCall(strV)
      strB = strM(7)
      If strM(8) = "1" Then
        bolOrg = True
      Else
        bolOrg = False
      End If
      If strM(9) = "" Then
        bmpx = Nothing
      Else
        Dim bytV() As Byte = Convert.FromBase64String(strM(9))
        Dim fm As New IO.MemoryStream
        fm.Write(bytV, 0, bytV.Length)
        bmpx = New Bitmap(fm)
        fm.Close()
        fm.Dispose()
      End If
      Return strM
    End Function
    Public Overrides Function ToString() As String
      Dim strP As String = MyBase.ToString() & vbTab
      Dim strBP As String = ""
      If bmpx Is Nothing Then
        If bmpx Is Nothing Then
          If strB.StartsWith("@") Then
            bmpx = My.Resources.ResourceManager.GetObject(strB.Substring(1).Trim)
          Else
            If IO.File.Exists(strB) Then
              bmpx = New Bitmap(strB)
            End If
          End If
        End If
      End If
      If bmpx IsNot Nothing Then
        Dim fm As New IO.MemoryStream
        bmpx.Save(fm, System.Drawing.Imaging.ImageFormat.Png)
        Dim bytV() As Byte = fm.ToArray
        strBP = Convert.ToBase64String(bytV)
        fm.Close()
        fm.Dispose()
      End If
      strP &= strB & vbTab & IIf(bolOrg, 1, 0) & vbTab & strBP & vbCrLf
      Return strP
    End Function
  End Class
  Public Class BCell
    Inherits LBPCell
    Public pn As Pen
    Public Sub Show(ByVal gx As Graphics)
      gx.DrawRectangle(pn, rgt.X, rgt.Y, rgt.Width, rgt.Height)
    End Sub
    Public Overrides Function ReCall(strV As String) As String()
      Dim strM() As String = MyBase.ReCall(strV)
      Pn = New Pen(Color.FromArgb(Val(strM(7))), Val(strM(8)))
      Pn.DashStyle = Val(strM(9))
      Pn.SetLineCap(Drawing2D.LineCap.Round, Drawing2D.LineCap.Round, Drawing2D.DashCap.Round)
      Return strM
    End Function
    Public Overrides Function ToString() As String
      Dim strP As String = MyBase.ToString() & vbTab
      strP &= Pn.Color.ToArgb.ToString("0") & vbTab & Pn.Width.ToString("0.00") & vbTab
      strP &= Pn.DashStyle.ToString("D") & vbCrLf
      Return strP
    End Function
  End Class
  Public Class PageS
    Inherits LBPCell
    Public PageNo As Integer
    Public Overrides Function ReCall(strV As String) As String()
      Dim strM() As String = MyBase.ReCall(strV)
      PageNo = Val(strM(7))
      Return strM
    End Function
    Public Overrides Function ToString() As String
      Dim strP As String = MyBase.ToString() & vbTab
      strP &= PageNo & vbCrLf
      Return strP
    End Function
  End Class
  Public Class LBCell
    Public CellID As String
    Public CellX As Single
    Public CellY As Single
    Public cellWidth As Single
    Public CellHeight As Single
    Public CellColr As Color = Color.Black
    Public CFont As Font = New Font("細明體", 10)
    Public CAlign As StringAlignment = StringAlignment.Near
    Public CellValue As String
    Private CellOutput As Object
    Private strTID As String = ""
    Private bolDoPrt As Boolean = False
    Private sgx As Graphics = Nothing
    Public intMode As Integer = 0
    Sub New(ByVal strV As String, ByRef rgt As RectangleF)
      Dim bm As Bitmap = New Bitmap(1, 1)
      bm.SetResolution(100, 100)
      sgx = Graphics.FromImage(bm)
      CellID = "**"
      strV = strV.Replace(vbTab, " ").TrimStart
      'Debug.Print(strV)
      '參數一 X軸
      Dim intI As Integer = strV.IndexOf(" ")
      If intI <= 0 Then Return
      Dim strM As String = strV.Substring(0, intI).Trim
      If strM = "*" Then
        CellX = rgt.X
      ElseIf strM.ToUpper = "+W" Then
        CellX = rgt.X + rgt.Width
      ElseIf strM.StartsWith("+") Then
        CellX = rgt.X + Val(strM.Substring(1))
      Else
        CellX = Val(strM)
      End If
      strV = strV.Substring(intI).TrimStart
      intI = strV.IndexOf(" ")
      If intI <= 0 Then Return
      '參數二 Y軸
      strM = strV.Substring(0, intI).Trim
      If strM = "*" Then
        CellY = rgt.Y
      ElseIf strM.ToUpper = "+H" Then
        CellY = rgt.Y + rgt.Height
      ElseIf strM.StartsWith("+") Then
        CellY = rgt.Y + Val(strM.Substring(1))
      Else
        CellY = Val(strM)
      End If
      strV = strV.Substring(intI).TrimStart
      intI = strV.IndexOf(" ")
      If intI <= 0 Then Return
      '參數三 區塊命令
      strM = strV.Substring(0, intI).Trim
      strV = strV.Substring(intI).TrimStart
      'Debug.Print(strM)
      Dim fms As System.Drawing.FontStyle = FontStyle.Regular
      Select Case strM.Substring(0, 1).ToUpper
        Case "F"
          intMode = 3
          For intI = 1 To 3
            Select Case strM.Substring(intI, 1)
              Case "B"
                fms = fms Or FontStyle.Bold
              Case "I"
                fms = fms Or FontStyle.Italic
              Case "U"
                fms = fms Or FontStyle.Underline
            End Select
          Next
          CFont = New Font(strV, CType(Val(strM.Substring(4)), Single), fms)
          CellValue = CType(fms, Integer) & "," & Val(strM.Substring(4)).ToString("000.0") & "," & strV
        Case "X"
          intMode = 2
          strM = strM.Substring(1).Trim
          If strM = "*" Then
            cellWidth = rgt.Width
          Else
            cellWidth = Val(strM)
          End If
          intI = strV.IndexOf(" ")
          If intI <= 0 Then Return
          strM = strV.Substring(0, intI).Trim
          If strM = "*" Then
            CellHeight = rgt.Height
          Else
            CellHeight = Val(strM)
          End If
          rgt.X = CellX
          rgt.Y = CellY
          rgt.Height = CellHeight
          rgt.Width = cellWidth
          CellValue = strV.Substring(intI).TrimStart
        Case "C"
          intMode = 1
          CAlign = StringAlignment.Center
          strM = strM.Substring(1).Trim
          If strM = "*" Then
            cellWidth = rgt.Width
          Else
            cellWidth = Val(strM)
          End If
          intI = strV.IndexOf(" ")
          If intI <= 0 Then Return
          strM = strV.Substring(0, intI).Trim
          If strM = "*" Then
            CellHeight = rgt.Height
          Else
            CellHeight = Val(strM)
          End If
          rgt.X = CellX
          rgt.Y = CellY
          rgt.Height = CellHeight
          rgt.Width = cellWidth
          CellValue = strV.Substring(intI).TrimStart
        Case "L"
          intMode = 1
          CAlign = StringAlignment.Near
          strM = strM.Substring(1).Trim
          If strM = "*" Then
            cellWidth = rgt.Width
          Else
            cellWidth = Val(strM)
          End If
          intI = strV.IndexOf(" ")
          If intI <= 0 Then Return
          strM = strV.Substring(0, intI).Trim
          If strM = "*" Then
            CellHeight = rgt.Height
          Else
            CellHeight = Val(strM)
          End If
          rgt.X = CellX
          rgt.Y = CellY
          rgt.Height = CellHeight
          rgt.Width = cellWidth
          CellValue = strV.Substring(intI).TrimStart
        Case "R"
          intMode = 1
          CAlign = StringAlignment.Far
          strM = strM.Substring(1).Trim
          If strM = "*" Then
            cellWidth = rgt.Width
          Else
            cellWidth = Val(strM)
          End If
          intI = strV.IndexOf(" ")
          If intI <= 0 Then Return
          strM = strV.Substring(0, intI).Trim
          If strM = "*" Then
            CellHeight = rgt.Height
          Else
            CellHeight = Val(strM)
          End If
          rgt.X = CellX
          rgt.Y = CellY
          rgt.Height = CellHeight
          rgt.Width = cellWidth
          CellValue = strV.Substring(intI).TrimStart
        Case "A" '自動擴充處理
          intMode = 21
          CAlign = StringAlignment.Near
          strM = strM.Substring(1).Trim
          If strM = "*" Then
            cellWidth = rgt.Width
          Else
            cellWidth = Val(strM)
          End If
          intI = strV.IndexOf(" ")
          If intI <= 0 Then Return
          strM = strV.Substring(0, intI).Trim
          If strM = "*" Then
            CellHeight = rgt.Height
          Else
            CellHeight = Val(strM)
          End If
          rgt.X = CellX
          rgt.Y = CellY
          rgt.Height = CellHeight
          rgt.Width = cellWidth
          CellValue = strV.Substring(intI).TrimStart
        Case "T" '字串超過自動Trim
          intMode = 11
          CAlign = StringAlignment.Near
          strM = strM.Substring(1).Trim
          If strM = "*" Then
            cellWidth = rgt.Width
          Else
            cellWidth = Val(strM)
          End If
          intI = strV.IndexOf(" ")
          If intI <= 0 Then Return
          strM = strV.Substring(0, intI).Trim
          If strM = "*" Then
            CellHeight = rgt.Height
          Else
            CellHeight = Val(strM)
          End If
          rgt.X = CellX
          rgt.Y = CellY
          rgt.Height = CellHeight
          rgt.Width = cellWidth
          CellValue = strV.Substring(intI).TrimStart
        Case "B"
          intMode = 4
          strM = strM.Substring(1).Trim
          If strM = "*" Then
            cellWidth = rgt.Width
          Else
            cellWidth = Val(strM)
          End If
          intI = strV.IndexOf(" ")
          If intI <= 0 Then Return
          strM = strV.Substring(0, intI).Trim
          If strM = "*" Then
            CellHeight = rgt.Height
          Else
            CellHeight = Val(strM)
          End If
          rgt.X = CellX
          rgt.Y = CellY
          rgt.Height = CellHeight
          rgt.Width = cellWidth
          CellValue = strV.Substring(intI).TrimStart
        Case "M"
          intMode = 5
          strM = strM.Substring(1).Trim
          If strM = "*" Then
            cellWidth = rgt.Width
          Else
            cellWidth = Val(strM)
          End If
          intI = strV.IndexOf(" ")
          If intI <= 0 Then Return
          strM = strV.Substring(0, intI).Trim
          If strM = "*" Then
            CellHeight = rgt.Height
          Else
            CellHeight = Val(strM)
          End If
          rgt.X = CellX
          rgt.Y = CellY
          rgt.Height = CellHeight
          rgt.Width = cellWidth
          CellValue = strV.Substring(intI).TrimStart
          'Case Else
          '  Debug.Print("ERR " & strM)
      End Select
    End Sub
    Public Function GetSymbols() As String()
      Dim aryL As New ArrayList, intI As Integer = InStr(CellValue, "$$")
      While intI > 0
        Dim intJ = InStr(intI + 2, CellValue, "*$")
        If intJ > 0 Then
          aryL.Add(CellValue.Substring(intI + 1, intJ - intI))
          intI = intJ + 2
        ElseIf CellValue.Length >= intI + 3 Then
          aryL.Add(CellValue.Substring(intI + 1, 2))
          intI += 4
        Else
          intI += 2
        End If
        intI = InStr(intI, CellValue, "$$")
      End While
      If aryL.Count = 0 Then aryL.Add("**")
      Return aryL.ToArray(GetType(String))
    End Function
    Public Function Draw(rgt As RectangleF, Optional ByVal ofx As Single = 0, Optional ByVal ofy As Single = 0, Optional coLr As Object = Nothing) As Object
      If bolDoPrt = False Then Return Nothing
      Dim ccolr As Color = CellColr
      If coLr IsNot Nothing Then ccolr = coLr
      If intMode = 1 Or intMode = 11 Or intMode = 21 Then
        Dim s As New PCell
        s.strID = strTID.Trim(",")
        s.Br = New SolidBrush(ccolr)
        s.fmt = New StringFormat
        s.intMode = intMode
        Select Case intMode
          Case 1
            s.fmt.Trimming = StringTrimming.None
            s.fmt.LineAlignment = StringAlignment.Center
          Case 11
            s.fmt.Trimming = StringTrimming.EllipsisCharacter
            s.fmt.FormatFlags = StringFormatFlags.NoWrap
            s.fmt.LineAlignment = StringAlignment.Center
          Case 21
            s.fmt.Trimming = StringTrimming.None
            s.fmt.FormatFlags = StringFormatFlags.FitBlackBox + StringFormatFlags.NoClip
            s.fmt.LineAlignment = StringAlignment.Center
        End Select
        s.fmt.Alignment = CAlign
        s.CF = CFont
        s.strV = CellOutput
        s.rgt = New RectangleF((CellX + ofx) * 39.37, (CellY + ofy) * 39.37, cellWidth * 39.37, CellHeight * 39.37)
        If intMode = 21 Then
          Dim sz As SizeF = sgx.MeasureString(s.strV, s.CF, New SizeF(s.rgt.Width, s.rgt.Height), s.fmt)
          'Debug.Print(sgx.DpiX & "," & sgx.DpiY & "," & s.CF.ToString & "," & sz.ToString & "," & s.strV.Contains(vbCr) & s.strV.Contains(vbLf) & s.strV & "," & s.rgt.Size.ToString)
          If s.rgt.Height < sz.Height Then
            s.rgt.Height = sz.Height + 4
          End If
        End If

        Return s
      ElseIf intMode = 2 And (CellHeight = 0 Or cellWidth = 0) Then
        Dim s As New LCell
        s.intMode = 2
        s.strID = strTID.Trim(",")
        s.rgt = New RectangleF((CellX + ofx) * 39.37, (CellY + ofy) * 39.37, cellWidth * 39.37, CellHeight * 39.37)
        'If s.rgt.Height > 0 And s.rgt.Height < rgt.Height Then
        '  s.rgt.Height = rgt.Height
        'End If
        Dim sngL As Single = Val(CellOutput)
        s.Pn = New Pen(ccolr, sngL)
        If CellOutput.EndsWith("D1") Then
          s.Pn.DashStyle = Drawing2D.DashStyle.Dash
        ElseIf CellOutput.EndsWith("D2") Then
          s.Pn.DashStyle = Drawing2D.DashStyle.DashDot
        ElseIf CellOutput.EndsWith("D3") Then
          s.Pn.DashStyle = Drawing2D.DashStyle.DashDotDot
        ElseIf CellOutput.EndsWith("D4") Then
          s.Pn.DashStyle = Drawing2D.DashStyle.Dot
        Else
          s.Pn.DashStyle = Drawing2D.DashStyle.Solid
        End If
        s.Pn.SetLineCap(Drawing2D.LineCap.Round, Drawing2D.LineCap.Round, Drawing2D.DashCap.Round)
        Return s
      ElseIf intMode = 2 Then
        Dim s As New BCell
        s.intMode = 12
        s.strID = strTID.Trim(",")
        s.rgt = New RectangleF((CellX + ofx) * 39.37, (CellY + ofy) * 39.37, cellWidth * 39.37, CellHeight * 39.37)
        'If s.rgt.Height > 0 And s.rgt.Height < rgt.Height Then
        '  s.rgt.Height = rgt.Height
        'End If
        Dim sngL As Single = Val(CellOutput)
        s.pn = New Pen(ccolr, sngL)
        If CellOutput.EndsWith("D1") Then
          s.pn.DashStyle = Drawing2D.DashStyle.Dash
        ElseIf CellOutput.EndsWith("D2") Then
          s.pn.DashStyle = Drawing2D.DashStyle.DashDot
        ElseIf CellOutput.EndsWith("D3") Then
          s.pn.DashStyle = Drawing2D.DashStyle.DashDotDot
        ElseIf CellOutput.EndsWith("D4") Then
          s.pn.DashStyle = Drawing2D.DashStyle.Dot
        Else
          s.pn.DashStyle = Drawing2D.DashStyle.Solid
        End If
        s.pn.SetLineCap(Drawing2D.LineCap.Round, Drawing2D.LineCap.Round, Drawing2D.DashCap.Round)
        Return s
      ElseIf intMode = 4 Or intMode = 5 Then
        Dim s As New DrwCell
        s.intMode = intMode
        s.strID = strTID.Trim(",")
        s.rgt = New RectangleF((CellX + ofx) * 39.37, (CellY + ofy) * 39.37, cellWidth * 39.37, CellHeight * 39.37)
        If CellOutput.GetType Is GetType(String) Then
          s.strB = CellOutput
        ElseIf CellOutput.GetType Is GetType(Bitmap) Then
          s.SetBmps(CellOutput)
        Else
          Return Nothing
        End If
        If intMode = 5 Then s.bolOrg = True
        Return s
      Else
        Return Nothing
      End If
    End Function
    Public Sub Disp(ByVal gx As Graphics)
      If bolDoPrt = False Then Return
      Dim fmt As New StringFormat
      fmt.Alignment = StringAlignment.Center
      fmt.LineAlignment = CAlign
      fmt.Trimming = StringTrimming.None
      gx.DrawString(CellOutput, CFont, New SolidBrush(CellColr), New RectangleF(CellX, CellY, cellWidth, CellHeight), fmt)
    End Sub
    Public Sub Flash()
      CellOutput = CellValue
      bolDoPrt = False
      strTID = ""
    End Sub
    Public Overloads Sub SetString(ByVal strID As String, ByVal strV As String)
      If CellOutput.Contains("$$" & strID & "^") Then
        Dim strP() As String = Split(CellOutput, "$$" & strID & "^")
        Dim strK As String = strP(0)
        For intM As Integer = 1 To strP.GetUpperBound(0)
          If strV.StartsWith("*") Then
            If strV.Contains(strP(intM).Substring(0, 1)) Then
              strK &= "☑" & strP(intM).Substring(1)
            Else
              strK &= "☐" & strP(intM).Substring(1)
            End If
          Else
            If strV = strP(intM).Substring(0, strV.Length) Then
              strK &= "☑" & strP(intM).Substring(strV.Length)
            Else
              strK &= "☐" & strP(intM).Substring(strV.Length)
            End If
          End If
        Next
        CellOutput = strK
      Else
        CellOutput = CellOutput.Replace("$$" & strID, strV)
      End If
      strTID &= strID & ","
      bolDoPrt = True
    End Sub
    Public Overloads Sub SetString(ByVal strID As String, ByVal bmpx As Bitmap)
      If CellOutput = "$$" & strID Then
        CellOutput = bmpx
      End If
      strTID &= strID & ","
      bolDoPrt = True
    End Sub

    Public Function GetOutput() As String
      If bolDoPrt = False Then Return ""
      Dim strV As String = CellX.ToString("00.00") & " " & CellY.ToString("00.00") & " "
      If CAlign = StringAlignment.Center Then
        strV &= "C"
      ElseIf CAlign = StringAlignment.Far Then
        strV &= "R"
      Else
        strV &= "L"
      End If
      strV &= cellWidth.ToString("00.00") & " " & CellHeight.ToString("00.00") & " " & CellOutput
      Return strV
    End Function
  End Class
  ''' <summary>
  ''' 設定或取得LBPRT物件名稱
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property Name() As String
    Get
      Return strName
    End Get
    Set(ByVal value As String)
      strName = value
    End Set
  End Property
  ''' <summary>
  ''' 取得LBPRT版本
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public ReadOnly Property Version() As String
    Get
      Return "LB_Prt V2.0 2013/02"
    End Get
  End Property
  ''' <summary>
  ''' 設定或取得解析度條件
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
    Public Property PrintQuility As System.Drawing.Printing.PrinterResolutionKind
        Get
            Return intPQ
        End Get
        Set(value As System.Drawing.Printing.PrinterResolutionKind)
            intPQ = value
        End Set
    End Property
  ''' <summary>
  ''' 設定或取得紙張類型
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
    Public Property PaperKind As System.Drawing.Printing.PaperKind
        Get
            Return intPK
        End Get
        Set(value As System.Drawing.Printing.PaperKind)
            intPK = value
        End Set
    End Property
  ''' <summary>
  ''' 設定或取得左邊界保留寬度
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property EdgeLeft As Single
    Get
      Return sngEdgeLeft
    End Get
    Set(value As Single)
      sngEdgeLeft = value
    End Set
  End Property
  ''' <summary>
  ''' 設定或取得右邊界保留寬度
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property EdgeRight As Single
    Get
      Return sngEdgeRight
    End Get
    Set(value As Single)
      sngEdgeRight = value
    End Set
  End Property
  ''' <summary>
  ''' 設定或取得上邊界保留高度
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property EdgeTop As Single
    Get
      Return sngEdgeTop
    End Get
    Set(value As Single)
      sngEdgeTop = value
    End Set
  End Property
  ''' <summary>
  ''' 設定或取得下邊界保留高度
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property EdgeBottom As Single
    Get
      Return sngEdgeBottom
    End Get
    Set(value As Single)
      sngEdgeBottom = value
    End Set
  End Property
  ''' <summary>
  ''' 設定或取得表尾高度
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property FootHeight As Single
    Get
      Return sngFootHeight
    End Get
    Set(value As Single)
      sngFootHeight = value
    End Set
  End Property
  ''' <summary>
  ''' 設定或取得印表機名
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property PrinterName() As String
    Get
      Return strPrtName
    End Get
    Set(ByVal value As String)
      strPrtName = value
    End Set
  End Property
  ''' <summary>
  '''  設定或取得同步檔案名(暫無作用)
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property SyncFile() As String
    Get
      Return strSyncFile
    End Get
    Set(ByVal value As String)
      strSyncFile = value
    End Set
  End Property
  ''' <summary>
  ''' 設定或取得格式檔名
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property LabelFile() As String
    Get
      Return strLBName
    End Get
    Set(ByVal value As String)
      strLBName = value
      InitLBL()
    End Set
  End Property
  Public Property AutoPage As Boolean
    Get
      Return bolAutoPage
    End Get
    Set(value As Boolean)
      bolAutoPage = value
    End Set
  End Property
  ''' <summary>
  '''  設定或取得紙張寬度
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property PageWidth() As Single
    Get
      If sngWidth = 0 Then
        Return szPageSize.Width
      Else
        Return sngWidth
      End If
    End Get
    Set(ByVal value As Single)
      sngWidth = value
    End Set
  End Property
  ''' <summary>
  ''' 設定或取得紙張高度
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property PageHeight() As Single
    Get
      If sngHeight = 0 Then
        Return szPageSize.Height
      Else
        Return sngHeight
      End If
    End Get
    Set(ByVal value As Single)
      sngHeight = value
    End Set
  End Property
  ''' <summary>
  ''' 設定或取得列印方向 True:橫向 False:直向
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property PageOrint() As Boolean
    Get
      Return bolPORG
    End Get
    Set(ByVal value As Boolean)
      bolPORG = value
      If sngHeight > 0 And sngWidth > 0 Then
        szPageSize = New SizeF(sngWidth, sngHeight)
        bolPORG = False
      Else
                Dim p1 As New System.Drawing.Printing.PrinterSettings
                For Each p As System.Drawing.Printing.PaperSize In p1.PaperSizes
                    If p.Kind = intPK Then
                        If bolPORG = True Then
                            szPageSize = New SizeF(p.Height / 39.37, p.Width / 39.37)
                        Else
                            szPageSize = New SizeF(p.Width / 39.37, p.Height / 39.37)
                        End If
                    End If
                Next
      End If
    End Set
  End Property
  ''' <summary>
  ''' 設定或取得是否可以選擇印表機
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property SelectPrt As Boolean
    Get
      Return bolSelectPrt
    End Get
    Set(value As Boolean)
      bolSelectPrt = value
    End Set
  End Property
  Public Function IsFullPage() As Boolean
    If (szPageSize.Height - sngEdgeBottom - sngFootHeight) > GetBound.Height Then
      Return False
    Else
      Return True
    End If
  End Function
  Public Function GetLastX() As Single
    Return GetBound.Left
  End Function
  Public Function GetLastY() As Single
    Return GetBound.Bottom
  End Function
  ''' <summary>
  ''' 取得設定的參數值
  ''' </summary>
  ''' <param name="strK">參數代碼</param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function GetParam(strK As String) As String
    If aryPV.ContainsKey(strK) Then
      Return aryPV(strK)
    Else
      Return ""
    End If
  End Function
  ''' <summary>
  ''' 設定參數代碼數值
  ''' </summary>
  ''' <param name="strK">參數代碼</param>
  ''' <param name="value">值</param>
  ''' <remarks></remarks>
  Public Sub SetParam(strK As String, value As String)
    If aryPV.ContainsKey(strK) Then
      aryPV(strK) = value
    Else
      aryPV.Add(strK, value)
    End If
  End Sub
  Private Function GetUpdate(ByVal strK As String) As String
    '更新預設參數使程式好寫 $%xx=
    For Each strM As String In aryPV.Keys
      If strM.StartsWith("$%") Then
        strK = strK.Replace(strM, aryPV(strM))
      Else
        strK = strK.Replace("[" & strM & "]", aryPV(strM))
      End If
    Next
    '修正一些直接ASCII 設定
    Dim IntI As Integer = InStr(strK, "$*")
    While IntI > 0
      If IntI > 1 And strK.Length > IntI + 4 Then
        strK = strK.Substring(0, IntI - 1) & Chr(Val(strK.Substring(IntI + 1, 3))) & strK.Substring(IntI + 4)
      ElseIf IntI > 1 Then
        strK = strK.Substring(0, IntI - 1) & Chr(Val(strK.Substring(IntI + 1, 3)))
      ElseIf strK.Length > IntI + 4 Then
        strK = Chr(Val(strK.Substring(IntI + 1, 3))) & strK.Substring(IntI + 4)
      Else
        strK = Chr(Val(strK.Substring(IntI + 1, 3)))
      End If
      IntI = InStr(IntI, strK, "$*")
    End While
    Return strK
  End Function
  Public Function GetNextLBPRT() As clsLBPRT
    Return nextLBPRT
  End Function
  Public Function GetAryBuff() As ArrayList
    Return aryBuff
  End Function
  Public Sub MegreNext()
    If nextLBPRT Is Nothing Then Return
    nextLBPRT.MegreNext()
    For Each s As Object In nextLBPRT.GetAryBuff
      aryBuff.Add(s)
    Next
  End Sub
  Public Sub MergeBuff(clsLB As clsLBPRT)
    For Each s As Object In clsLB.GetAryBuff
      aryBuff.Add(s)
    Next
  End Sub
  ''' <summary>
  ''' 初始化一個格式檔案
  ''' </summary>
  ''' <remarks></remarks>
  Public Sub InitLBL()
    If IO.File.Exists(strLBName) = False Then Return
    Dim strS As String = IO.File.ReadAllText(strLBName, System.Text.Encoding.Default)
    InitLBL(strS)
  End Sub
  ''' <summary>
  ''' 初始化一個格式檔
  ''' </summary>
  ''' <param name="strFS">檔名或格式字串</param>
  ''' <remarks></remarks>
  Public Sub InitLBL(ByVal strFS As String)
    Dim intSP As Integer = strFS.IndexOf("###==###" & vbCrLf)
    If intSP > 0 Then
      Dim strFS1 As String = strFS.Substring(intSP + 10)
      strFS = strFS.Substring(0, intSP)
      nextLBPRT = New clsLBPRT
      nextLBPRT.InitLBL(strFS1)
    End If
    Dim strFMT As String = "", CFont As New Font("細明體", 10)
    Dim bmp As New Bitmap(10, 10)
    sgx = Graphics.FromImage(bmp)
    Dim rgt As New RectangleF(0, 0, 0, 0)
    arySymbols.Clear()
    aryCells.Clear()
    aryPV.Clear()
    Dim strV() As String = strFS.Split(vbCrLf.ToCharArray)
    For Each strK As String In strV
      If strK.Contains("//") = True Then
        If strK.StartsWith("//") Then Continue For
        strK = strK.Substring(0, strK.IndexOf("//")).Trim()
      End If
      If strK.Contains(":=") = True Then
        Dim intI As Integer = strK.IndexOf(":=")
        If intI > 0 Then
          aryPV.Add(strK.Substring(0, intI).Trim.ToUpper, strK.Substring(intI + 2).Trim)
        End If
        Continue For
      End If
      If strK.Trim((vbTab & " ").ToCharArray).Length = 0 Then Continue For
      strK = strK.TrimStart
      If strK.StartsWith(";") = True Then Continue For
      If strK.StartsWith("$%") = True And strK.Contains("=") = True Then
        Dim intI As Integer = strK.IndexOf("=")
        If intI > 0 Then
          aryPV.Add(strK.Substring(0, intI).Trim, strK.Substring(intI + 1).Trim)
        End If
        Continue For
      End If
      strK = GetUpdate(strK)
      Dim strP() As String = Split(strK, "||"), bolT As Boolean = False
      Dim strU() As String = strK.Trim.Split((" " & vbTab).ToCharArray)
      Dim intU As Integer = 0
      For Each strQ As String In strU
        If strQ <> "" Then
          intU += 1
          If intU = 3 Then
            strU(0) = strQ.Substring(0, 1)
            Exit For
          End If
        End If
      Next
      For Each strQ As String In strP
        If bolT = True Then
          strK = rgt.X.ToString("0.00") & " " & rgt.Y.ToString("0.00") & " " & strU(0) & rgt.Width.ToString("0.00") & " " & rgt.Height.ToString("0.00") & " " & strQ
        Else
          strK = strQ
          bolT = True
        End If
        Dim s1 As New LBCell(strK, rgt)
        If s1.intMode = 3 Then
          If s1.CellValue <> strFMT Then
            CFont = s1.CFont
            strFMT = s1.CellValue
          End If
        ElseIf s1.intMode = 1 Or s1.intMode = 11 Or s1.intMode = 21 Then
          s1.CFont = CFont
          aryCells.Add(s1)
          Dim strL() As String = s1.GetSymbols()
          For Each strL1 As String In strL
            If arySymbols.ContainsKey(strL1) = False Then
              arySymbols.Add(strL1, New ArrayList)
            End If
            arySymbols(strL1).Add(s1)
          Next
        ElseIf s1.intMode = 2 Then
          aryCells.Add(s1)
          Dim strL() As String = s1.GetSymbols()
          For Each strL1 As String In strL
            If arySymbols.ContainsKey(strL1) = False Then
              arySymbols.Add(strL1, New ArrayList)
            End If
            arySymbols(strL1).Add(s1)
          Next
        ElseIf s1.intMode = 4 Or s1.intMode = 5 Then
          aryCells.Add(s1)
          Dim strL() As String = s1.GetSymbols()
          For Each strL1 As String In strL
            If arySymbols.ContainsKey(strL1) = False Then
              arySymbols.Add(strL1, New ArrayList)
            End If
            arySymbols(strL1).Add(s1)
          Next
        End If
      Next
    Next
    If aryPV.ContainsKey("PAPERKIND") = True Then
            If [Enum].IsDefined(GetType(System.Drawing.Printing.PaperKind), aryPV("PAPERKIND")) = True Then
                intPK = [Enum].Parse(GetType(System.Drawing.Printing.PaperKind), aryPV("PAPERKIND"))
            End If
    End If
    If aryPV.ContainsKey("ORINT") = True Then
      bolPORG = IIf(aryPV("ORINT").ToUpper = "H" Or aryPV("ORINT") = "1" Or aryPV("ORINT").ToUpper = "TRUE", True, False)
    End If
    If aryPV.ContainsKey("AUTOPAGE") = True Then
      bolAutoPage = IIf(aryPV("AUTOPAGE") = "1" Or aryPV("AUTOPAGE").ToUpper = "TRUE", True, False)
    End If
    If aryPV.ContainsKey("EDGELEFT") = True Then
      sngEdgeLeft = Val(aryPV("EDGELEFT"))
    End If
    If aryPV.ContainsKey("EDGETOP") = True Then
      sngEdgeTop = Val(aryPV("EDGETOP"))
    End If
    If aryPV.ContainsKey("EDGERIGHT") = True Then
      sngEdgeRight = Val(aryPV("EDGERIGHT"))
    End If
    If aryPV.ContainsKey("EDGEBOTTOM") = True Then
      sngEdgeBottom = Val(aryPV("EDGEBOTTOM"))
    End If
    If aryPV.ContainsKey("PAGEWIDTH") = True Then
      sngWidth = Val(aryPV("PAGEWIDTH"))
            intPK = System.Drawing.Printing.PaperKind.Custom
    End If
    If aryPV.ContainsKey("PAGEHEIGHT") = True Then
      sngHeight = Val(aryPV("PAGEHEIGHT"))
    End If
    If aryPV.ContainsKey("FOOTHEIGHT") = True Then
      sngFootHeight = Val(aryPV("FOOTHEIGHT"))
    End If
    FlashNew()
  End Sub
  ''' <summary>
  ''' 從新開始報表輸出
  ''' </summary>
  ''' <remarks></remarks>
  Public Sub FlashNew()
    For Each s As LBCell In aryCells
      s.Flash()
    Next
    aryBuff.Clear()
    arySeg.Clear()
    rtLast = New RectangleF(0, 0, 0, 0)
    intPage = 0
    If sngHeight > 0 And sngWidth > 0 Then
      szPageSize = New SizeF(sngWidth, sngHeight)
      bolPORG = False
    Else
            Dim p1 As New System.Drawing.Printing.PrinterSettings
            For Each p As System.Drawing.Printing.PaperSize In p1.PaperSizes
                If p.Kind = intPK Then
                    If bolPORG = True Then
                        szPageSize = New SizeF(p.Height / 39.37, p.Width / 39.37)
                    Else
                        szPageSize = New SizeF(p.Width / 39.37, p.Height / 39.37)
                    End If
                End If
            Next
    End If
  End Sub
  ''' <summary>
  ''' 設定報表要列印字段
  ''' </summary>
  ''' <param name="strID">字段序號00-99</param>
  ''' <param name="strV">字段內容</param>
  ''' <remarks></remarks>
  Public Sub ADD_PG(ByVal strID As String, ByVal strV As String)
    If arySymbols.ContainsKey(strID) = False Then Return
    For Each s As LBCell In arySymbols(strID)
      s.SetString(strID, strV)
    Next
  End Sub
  Public Sub ADD_PG(ByVal strID As String, ByVal bmpX As Bitmap)
    If arySymbols.ContainsKey(strID) = False Then Return
    For Each s As LBCell In arySymbols(strID)
      s.SetString(strID, bmpX)
    Next
  End Sub
  ''' <summary>
  ''' 設定區段起頭
  ''' </summary>
  ''' <remarks></remarks>
  Public Sub NewSession()
    rtLast = GetBound()
    If bolAutoPage Then
      sngLX = rtLast.Left
      sngLY = rtLast.Bottom
    Else
      sngLX = 0
      sngLY = 0
    End If
    arySeg.Clear()
  End Sub
  ''' <summary>
  ''' 取得區段內容每一區塊
  ''' </summary>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function GetSession(strID As String) As LBPCell()
    Dim aryL As New ArrayList
    For Each s As LBPCell In arySeg
      If s.strID.Contains(strID) Then
        aryL.Add(s)
      End If
    Next
    If aryL.Count = 0 Then Return Nothing
    Return aryL.ToArray(GetType(LBPCell))
  End Function
  ''' <summary>
  ''' 取得運作區的大小
  ''' </summary>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function GetBound() As RectangleF
    Dim rt As RectangleF = Nothing
    If arySeg.Count = 0 Then
      Return New RectangleF(sngEdgeLeft, sngEdgeTop, 0, 0)
    End If
    Dim bolBG As Boolean = False
    For Each s As LBPCell In arySeg
      If bolBG = False Then
        rt = s.rgt
        bolBG = True
      Else
        rt = RectangleF.Union(rt, s.rgt)
      End If
    Next
    Return New RectangleF(rt.X * 0.0254, rt.Y * 0.0254, rt.Width * 0.0254, rt.Height * 0.0254)
  End Function
  Public Function ReLoad(strB As String) As Boolean
    Dim strV() As String = strB.Split(vbCrLf.ToCharArray)
    If strV.Length = 1 Then
      If IO.File.Exists(strB) = False Then Return False
      strV = IO.File.ReadAllLines(strB)
    End If
    aryBuff.Clear()
    For Each strM As String In strV
      If strM.Length = 0 Then Continue For
      Dim intJ As Integer = Val(strM.Substring(0, 2))
      Select Case intJ
        Case 1, 11, 21
          Dim s As New PCell
          s.ReCall(strM)
          aryBuff.Add(s)
        Case 2
          Dim s As New LCell
          s.ReCall(strM)
          aryBuff.Add(s)
        Case 12
          Dim s As New BCell
          s.ReCall(strM)
          aryBuff.Add(s)
        Case 4, 5
          Dim s As New DrwCell
          s.ReCall(strM)
          aryBuff.Add(s)
        Case 99
          Dim s As New PageS
          s.ReCall(strM)
          aryBuff.Add(s)
      End Select
    Next
    Return True
  End Function
  Public Function GetRep() As String
    Dim strM As String = ""
    For Each s As LBPCell In aryBuff
      strM &= s.ToString
    Next
    Return strM
  End Function
  Public Sub SaveRep(strF As String)
    If IO.File.Exists(strF) = True Then IO.File.Delete(strF)
    IO.File.AppendAllText(strF, GetRep, System.Text.Encoding.UTF8)
  End Sub
  ''' <summary>
  ''' 報表段落輸出
  ''' </summary>
  ''' <param name="bolM">True 向右接續</param>
  ''' <param name="colR">前景顏色</param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function PrtLBL_Merge(bolM As Boolean, colR As Object, FixHeight As Boolean) As Boolean
    Dim x As Double = 0, y As Double = 0
    If bolM = True Then
      x = GetBound.Right
      y = GetBound.Top
      If x + 0.2 > rtLast.Right Then
        x = GetBound.Left
        x = GetBound.Bottom
        NewSession()
      End If
    Else
      x = GetBound.Left
      y = GetBound.Bottom
    End If
    Return PrtLBL(x, y, colR, FixHeight)
  End Function
  ''' <summary>
  ''' 報表段落輸出
  ''' </summary>
  ''' <param name="x">X軸位移</param>
  ''' <param name="y">Y軸位移</param>
  ''' <param name="colR">前景顏色</param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function PrtLBL(Optional ByVal x As Double = -0.1, Optional ByVal y As Double = -0.1, Optional colR As Object = Nothing, Optional bolFixH As Boolean = False) As Boolean
    Dim bolA As Boolean = False
    If x = -0.1 And y = -0.1 And bolAutoPage Then
      x = GetLastX()
      y = GetLastY()
      bolA = True
    End If
    Dim rgt As New RectangleF(0, 0, 0, 0)
    Dim aryThis As New ArrayList
    For Each s As LBCell In aryCells
      Dim s1 = s.Draw(rgt, x, y, colR)
      If s1 IsNot Nothing Then
        If bolA = True Then
          If rgt.X = 0 And rgt.Y = 0 And rgt.Width = 0 And rgt.Height = 0 Then
            rgt.X = CType(s1, LBPCell).rgt.X
            rgt.Y = CType(s1, LBPCell).rgt.Y
            rgt.Width = CType(s1, LBPCell).rgt.Width
            rgt.Height = CType(s1, LBPCell).rgt.Height
          Else
            rgt = RectangleF.Union(rgt, CType(s1, LBPCell).rgt)
          End If
        End If
        aryBuff.Add(s1)
        arySeg.Add(s1)
        aryThis.Add(s1)
      End If
      s.Flash()
    Next
    If bolA = True And bolFixH Then
      For Each s As LBPCell In aryThis
        If s.rgt.Height > 0.01 Then s.rgt.Height = rgt.Height
      Next
    End If
    Return True
  End Function
  ''' <summary>
  ''' 報表煥頁輸出
  ''' </summary>
  ''' <remarks></remarks>
  Public Sub NewPage()
    Dim s As New PageS
    NewSession()
    sngLX = 0
    sngLY = 0
    intPage += 1
    s.PageNo = intPage
    s.intMode = 99
    aryBuff.Add(s)
  End Sub
  ''' <summary>
  ''' 使用預覽列印報表
  ''' </summary>
  ''' <remarks></remarks>
  Public Sub PrtDialog()
    If strPrtName = "" Then Return
    arySeg.Clear()
    Dim PDLG As New PrintPreviewDialog()
        Dim PDoc As New System.Drawing.Printing.PrintDocument
    PDoc.DocumentName = strName
    PDoc.PrinterSettings.PrinterName = strPrtName
    If sngWidth <> 0 And sngHeight <> 0 Then
            Dim PSZ As New System.Drawing.Printing.PaperSize("CUST" & (sngWidth * 10).ToString("000") & "X" & (sngHeight * 10).ToString("000"), sngWidth * 39.37, sngHeight * 39.37)
      PDoc.DefaultPageSettings.PaperSize = PSZ
    End If
    PDoc.DefaultPageSettings.Landscape = bolPORG
        If intPQ <> System.Drawing.Printing.PrinterResolutionKind.Custom Then
            PDoc.DefaultPageSettings.PrinterResolution.Kind = intPQ
        End If
    intCCnt = 0
    AddHandler PDoc.PrintPage, AddressOf PrintPages
    AddHandler PDoc.BeginPrint, AddressOf BGPrts
    AddHandler PDLG.Load, AddressOf docVLoad
    AddHandler PDLG.FormClosed, AddressOf EndJobD
    bolSelectFirst = True
    PDLG.SetDesktopLocation(0, 0)
    PDLG.Document = PDoc
    PDLG.ShowDialog()
  End Sub
  Private Sub BGPrts(ByVal s As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)
    If bolSelectPrt = True And bolSelectFirst = False Then
      Dim Sel As New PrintDialog
      Sel.Document = s
      Sel.ShowNetwork = True
      Sel.UseEXDialog = True
      If Sel.ShowDialog <> DialogResult.OK Then
        e.Cancel = True
        Return
      End If
    End If
    bolSelectFirst = False
    intCCnt = 0
  End Sub
  Private Sub docVLoad(ByVal s As Object, ByVal e As System.EventArgs)
    Dim docv As PrintPreviewDialog = s
    RemoveHandler docv.Load, AddressOf docVLoad
    docv.Bounds = My.Computer.Screen.WorkingArea
  End Sub
  ''' <summary>
  ''' 使用直接報表輸出
  ''' </summary>
  ''' <remarks></remarks>
  Public Sub PrtReport()
        Dim PDoc As New System.Drawing.Printing.PrintDocument
    arySeg.Clear()
    PDoc.DocumentName = strName
    If strPrtName <> "" Then
      PDoc.PrinterSettings.PrinterName = strPrtName
    End If
    If bolSelectPrt Then
      Dim Sel As New PrintDialog
      Sel.Document = PDoc
      Sel.ShowNetwork = True
      Sel.UseEXDialog = True
      If Sel.ShowDialog <> DialogResult.OK Then
        Return
      End If
    End If
    If sngWidth <> 0 And sngHeight <> 0 Then
            Dim PSZ As New System.Drawing.Printing.PaperSize("CUST" & (sngWidth * 10).ToString("000") & "X" & (sngHeight * 10).ToString("000"), sngWidth * 39.37, sngHeight * 39.37)
      PDoc.DefaultPageSettings.PaperSize = PSZ
    End If
    PDoc.DefaultPageSettings.Landscape = bolPORG
        If intPQ <> System.Drawing.Printing.PrinterResolutionKind.Custom Then
            PDoc.DefaultPageSettings.PrinterResolution.Kind = intPQ
        End If
    intCCnt = 0
    AddHandler PDoc.PrintPage, AddressOf PrintPages
    AddHandler PDoc.EndPrint, AddressOf EndJob
    PDoc.Print()
  End Sub

    Private Sub PrintPages(ByVal s As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        While intCCnt < aryBuff.Count
            Dim s1 As Object = aryBuff(intCCnt)
            If s1.GetType Is GetType(PCell) Then
                CType(s1, PCell).Show(e.Graphics)
            ElseIf s1.GetType Is GetType(LCell) Then
                CType(s1, LCell).Show(e.Graphics)
            ElseIf s1.GetType Is GetType(BCell) Then
                CType(s1, BCell).Show(e.Graphics)
            ElseIf s1.GetType Is GetType(DrwCell) Then
                CType(s1, DrwCell).Show(e.Graphics)
            ElseIf s1.GetType Is GetType(PageS) And intCCnt < aryBuff.Count - 1 Then
                e.HasMorePages = True
                intCCnt += 1
                Return
            End If
            intCCnt += 1
        End While
        e.HasMorePages = False
    End Sub
    Private Sub EndJob(ByVal s As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)
        Dim s1 As System.Drawing.Printing.PrintDocument = s
        RemoveHandler s1.PrintPage, AddressOf PrintPages
        RemoveHandler s1.EndPrint, AddressOf EndJob
    End Sub
  Private Sub EndJobD(ByVal s As Object, ByVal e As FormClosedEventArgs)
    Dim docV As PrintPreviewDialog = s
        Dim docP As System.Drawing.Printing.PrintDocument = docV.Document
    RemoveHandler docV.FormClosed, AddressOf EndJobD
    RemoveHandler docP.PrintPage, AddressOf PrintPages
    RemoveHandler docP.BeginPrint, AddressOf BGPrts
    docV.Dispose()
    docP.Dispose()
  End Sub
End Class
