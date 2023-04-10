Imports LABTRANx64
Imports LABTRANx64.Labtran
Public Class DRAGN
#Const TransparentMode = 1
  Protected bolDrag As Boolean = True
  Protected bolLock As Boolean = False
  Protected bolAutoSZ As Boolean = True
  Protected bolSuspend As Boolean = False
  Protected FldV As Flds = Nothing
  Private bLDrag As DragEventArgs
  Private ptV As Point
  Private ptO As Point
  Private pt1 As Point
  Private pt2 As Point
  Private ptOff As New Point(0, 0)
  Private sizV As Size
  Private sizO As Size
  Private sizT As Size
  Private attb As New Imaging.ImageAttributes
  Private sngResolution As Single = 300
  Public Event PropertyChange(ByVal snder As DRAGN, ByVal strN As String)
  Public Event DoCopy(ByVal sender As DRAGN, ByVal fldV As Flds)
  Public Event DoCopyMul(ByVal sender As DRAGN, ByVal fldV As Flds, ByVal X As Single, ByVal Y As Single, ByVal strJ As String)
  Public Event MoveRedraw(ByVal sender As DRAGN, ByVal rgtV As Rectangle, ByVal intM As Integer)
  Sub New()
    '此為 Windows Form 設計工具所需的呼叫。
    InitializeComponent()
    ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
#If TransparentMode = 1 Then
    Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
    Me.UpdateStyles()
#End If
    attb.SetColorKey(Color.FromArgb(245, 245, 245), Color.White, Imaging.ColorAdjustType.Default)
    Me.BackColor = Color.Transparent
  End Sub
  
  Public Sub SetObject(ByVal fld As Flds)
    If FldV IsNot Nothing Then
      FldV = Nothing
    End If
    If fld Is Nothing OrElse _
       fld.Cell Is Nothing OrElse _
       fld.Hpos Is Nothing OrElse _
       fld.Cell.CellType = 0 Then
      Return
    End If
    FldV = fld
    RZLock = FldV.Cell.RzLock
    sngResolution = FldV.Cell.Resolution
    AutoSize = FldV.Cell.AutoSize
    Dim strN As String = FldV.Reflash
    RaiseEvent PropertyChange(Me, strN)
  End Sub
  Private Sub ReSizView(ByVal rgtV As Rectangle)
    If FldV.Dirty Then
      RaiseEvent PropertyChange(Me, FldV.Reflash())
      rgtV = FldV.Hpos.GetDrag()
    End If
    Me.Location = rgtV.Location
    Me.Size = rgtV.Size
    TL.Visible = False
    MR.Visible = False
    BM.Visible = False
    BR.Visible = False
    If (FldV.Cell.CellType \ 1000) = 3 Then
      Dim rtg As Rectangle = Me.ClientRectangle
      If rtg.Width < 6 Then rtg.Width = 6
      If rtg.Height < 6 Then rtg.Height = 6
      Dim rg As New Region(rtg)
      If rtg.Width > 12 And rtg.Height > 12 Then
        rtg.Inflate(-6, -6)
        rg.Xor(rtg)
      End If
      Me.Region = rg
    End If
    FldV.Clear()
  End Sub
  Public Property RZLock() As Boolean
    Get
      Return FldV.Cell.RzLock
    End Get
    Set(ByVal value As Boolean)
      bolLock = value
      FldV.Cell.RzLock = value
    End Set
  End Property
  Public Sub ReMap(Optional ByVal NoChange As Boolean = False)
    If NoChange = False Then RaiseEvent PropertyChange(Me, FldV.Reflash(True))
    Dim rgtv As Rectangle = FldV.Hpos.GetDrag
    Me.Visible = False
    'Debug.Print(Now.ToString & "," & Now.Ticks.ToString)
    Me.Location = rgtv.Location
    Me.ClientSize = rgtv.Size
    If (FldV.Cell.CellType \ 1000) = 3 Then
      Dim rtg As Rectangle = Me.ClientRectangle
      If rtg.Width < 6 Then rtg.Width = 6
      If rtg.Height < 6 Then rtg.Height = 6
      Dim rg As New Region(rtg)
      If rtg.Width > 12 And rtg.Height > 12 Then
        rtg.Inflate(-6, -6)
        rg.Xor(rtg)
      End If
      Me.Region = rg
    End If
    'Debug.Print(Now.ToString & "," & Now.Ticks.ToString)
    Me.Visible = True
    FldV.Clear()
  End Sub
  Public WriteOnly Property PointOff() As Point
    Set(ByVal value As Point)
      ptOff = value
      Windows.Forms.Cursor.Position += value
    End Set
  End Property
  Public ReadOnly Property GetBar() As Cells
    Get
      Return FldV.Cell
    End Get
  End Property
  Public Function LabFldV() As Flds
    Return FldV
  End Function
  Public ReadOnly Property RotateFlip() As Integer
    Get
      Return FldV.Hpos.FRT
    End Get
  End Property
  Public ReadOnly Property GetBmpSize() As Size
    Get
      Dim bit1 As Bitmap = FldV.GetBMP
      If bit1 Is Nothing Then
        Return New Size(0, 0)
      Else
        Return FldV.GetBMP.Size
      End If
    End Get
  End Property
  Public ReadOnly Property Getbmp() As Bitmap
    Get
      Return FldV.GetBMPView
    End Get
  End Property
  Public Property Resolution() As Single
    Get
      Return FldV.Cell.Resolution
    End Get
    Set(ByVal value As Single)
      sngResolution = value
      Dim sngV As Double = FldV.Hpos.ResolutionView / FldV.Cell.Resolution
      FldV.Cell.Resolution = value
      FldV.Hpos.Resolution = value
      If FldV.Hpos.ResolutionView = 1 Then
        FldV.Hpos.ResolutionView = value
      Else
        FldV.Hpos.ResolutionView = value * sngV
      End If
      FldV.Clear()
    End Set
  End Property
  Public Property ResolutionView() As Single
    Get
      Return FldV.Hpos.ResolutionView
    End Get
    Set(ByVal value As Single)
      FldV.Hpos.ResolutionView = value
      ReMap(True)
    End Set
  End Property
  Public ReadOnly Property GetLabCmds() As HandPosi
    Get
      Return FldV.Hpos
    End Get
  End Property
  Private Sub DRAGN_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
    bolDrag = False
    TL.Visible = False
    MR.Visible = False
    BM.Visible = False
    BR.Visible = False
  End Sub
  Public Sub onDragn()
    Me.SuspendLayout()
    Dim sz As Size = Me.ClientSize
    'Debug.Print(sz.ToString & Me.Size.ToString)
    bolDrag = True
    TL.Visible = False
    MR.Visible = False
    BM.Visible = False
    BR.Visible = False
    TL.Left = 0
    TL.Top = 0
    MR.Left = 0
    MR.Top = 0
    BM.Left = 0
    BM.Top = 0
    BR.Left = 0
    BR.Top = 0
    TL.Visible = True
    If FldV.Cell.AutoSize = True Then
      MR.Visible = False
      BM.Visible = False
      BR.Visible = False
    Else
      MR.Visible = True
      BM.Visible = True
      BR.Visible = True
      If (FldV.Cell.CellType \ 1000) = 3 Then
        If FldV.Cell.MWidth = 0 Then
          MR.Visible = False
          BR.Visible = False
        End If
        If FldV.Cell.MHeight = 0 Then
          BM.Visible = False
          BR.Visible = False
        End If
        Dim rtg As Rectangle = Me.ClientRectangle
        If rtg.Width < 6 Then rtg.Width = 6
        If rtg.Height < 6 Then rtg.Height = 6
        Dim rg As New Region(rtg)
        If rtg.Width > 12 And rtg.Height > 12 Then
          rtg.Inflate(-6, -6)
          rg.Xor(rtg)
        End If
        Me.Region = rg
      End If
      If MR.Visible Then
        MR.Left = sz.Width - MR.Width
        MR.Top = Int((sz.Height - MR.Height) / 2 + 0.5)
        'MR.BringToFront()
      End If
      If BM.Visible Then
        BM.Top = sz.Height - BM.Height
        BM.Left = Int((sz.Width - BM.Width) / 2 + 0.5)
      End If
      If BR.Visible Then
        BR.Top = sz.Height - BR.Height
        BR.Left = sz.Width - BR.Width
      End If
    End If
    Me.Visible = True
    Me.BringToFront()
    Me.ResumeLayout()
    Me.PerformLayout()
    'Debug.Print(sz.ToString & Me.Size.ToString)
    'Me.Refresh()
  End Sub
  Private Sub DRAGN_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
    If e.Button = Windows.Forms.MouseButtons.Right Then
      CMS.Show(System.Windows.Forms.Control.MousePosition)
    End If
  End Sub
  Private Sub TL_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TL.MouseDown
    If e.Button = Windows.Forms.MouseButtons.Left Then
      ptV = Cursor.Position - Me.Location
      ptOff = New Point(0, 0)
      Me.Visible = False
      AddHandler TL.MouseMove, AddressOf TL_MouseMove
      RaiseEvent MoveRedraw(Me, New Rectangle(ptO, Me.ClientSize), 0)
    End If
  End Sub
  Private Sub TL_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    If ptV.IsEmpty Or e.Button <> Windows.Forms.MouseButtons.Left Then Return
    ptO = Cursor.Position - ptV
    RaiseEvent MoveRedraw(Me, New Rectangle(ptO, Me.ClientSize), 1)
    ptO = Point.Empty
  End Sub
  Private Sub TL_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TL.MouseUp
    If ptV.IsEmpty Then
      Me.Visible = True
      RaiseEvent MoveRedraw(Me, New Rectangle(ptO, Me.ClientSize), 2)
      Return
    End If
    TL_MouseMove(sender, e)
    FldV.Hpos.ReLocation(Cursor.Position - ptV, 0.01)
    ptV = Point.Empty
    ptO = Point.Empty
    RemoveHandler TL.MouseMove, AddressOf TL_MouseMove
    ReSizView(FldV.Hpos.GetDrag)
    FldV.Clear()
    Me.Visible = True
    RaiseEvent MoveRedraw(Me, New Rectangle(ptO, Me.ClientSize), 2)
  End Sub
  Private Sub MR_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MR.MouseDown, BM.MouseDown, BR.MouseDown
    If e.Button = Windows.Forms.MouseButtons.Left Then
      pt1 = Cursor.Position
      ptOff = New Point(0, 0)
      sizV = Me.ClientSize
      Me.Visible = False
      AddHandler CType(sender, Label).MouseMove, AddressOf MR_MouseMove
      RaiseEvent MoveRedraw(Me, New Rectangle(Me.Location, sizO), 0)
    End If
  End Sub
  Private Sub MR_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    If pt1.IsEmpty Or e.Button <> Windows.Forms.MouseButtons.Left Then Return
    pt2 = Cursor.Position
    sizO = sizV
    If sender.Equals(MR) = True Then
      sizO.Width = sizV.Width - (pt1.X - pt2.X)
    ElseIf sender.Equals(BM) = True Then
      sizO.Height = sizV.Height - (pt1.Y - pt2.Y)
    ElseIf sender.Equals(BR) = True Then
      sizO.Height = sizV.Height - (pt1.Y - pt2.Y)
      sizO.Width = sizV.Width - (pt1.X - pt2.X)
    End If
    RaiseEvent MoveRedraw(Me, New Rectangle(Me.Location, sizO), 3)
  End Sub
  Private Sub MR_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MR.MouseUp, BM.MouseUp, BR.MouseUp
    If pt1.IsEmpty Then
      Me.Visible = True
      RaiseEvent MoveRedraw(Me, New Rectangle(Me.Location, sizO), 2)
      Return
    End If
    MR_MouseMove(sender, e)
    pt2 = Cursor.Position
    If sender.Equals(MR) = True Then
      sizO.Width = sizV.Width - (pt1.X - pt2.X)
    ElseIf sender.Equals(BM) = True Then
      sizO.Height = sizV.Height - (pt1.Y - pt2.Y)
    ElseIf sender.Equals(BR) = True Then
      sizO.Width = sizV.Width - (pt1.X - pt2.X)
      sizO.Height = sizV.Height - (pt1.Y - pt2.Y)
    End If
    RemoveHandler CType(sender, Label).MouseMove, AddressOf MR_MouseMove
    If FldV.Hpos.FRT = 90 Or FldV.Hpos.FRT = 270 Then
      Dim intI As Integer = sizO.Width
      sizO.Width = sizO.Height
      sizO.Height = intI
    End If
    Dim sz As Size = FldV.Hpos.ReSizeClip(sizO, 0.01)
    If FldV.Cell.GetType Is GetType(TextFix) Then
      With CType(FldV.Cell, TextFix)
        If .AutoSize = False And .FJX = Justs.Fill And .FJY = Justs.Fill Then
          FldV.Cell.MHeight = FldV.Hpos.FDH
          FldV.Cell.MWidth = FldV.Hpos.FDW
        End If
      End With

    End If
    pt1 = Point.Empty
    pt2 = Point.Empty
    ReSizView(FldV.Hpos.GetDrag)
    FldV.Clear()
    Me.Visible = True
    RaiseEvent MoveRedraw(Me, New Rectangle(Me.Location, sizO), 2)
  End Sub
#If TransparentMode = 1 Then
  'Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
  '  Get
  '    Dim cp As CreateParams = MyBase.CreateParams
  '    cp.ExStyle = cp.ExStyle Or &H20
  '    Return cp
  '  End Get
  'End Property
  Private Sub DRAGN_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
    Return
  End Sub

#End If

  Private Sub DELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETE.Click
    Me.Dispose()
  End Sub

  Private Sub COPY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COPY.Click
    RaiseEvent DoCopy(Me, FldV)
  End Sub

  Private Sub COPYX_Click(sender As Object, e As EventArgs) Handles COPYX.Click
    Dim frm As New frmMulCopy
    If frm.ShowDialog = DialogResult.OK Then
      Dim xs As Single = Val(frm.XStep.Text)
      Dim ys As Single = Val(frm.Ystep.Text)
      If xs = 0 Then xs = FldV.Hpos.FDW
      If ys = 0 Then ys = FldV.Hpos.FDH
      For intX As Integer = 1 To Val(frm.Cols.Text)
        For intY As Integer = 1 To Val(frm.Rows.Text)
          If intX = 1 And intY = 1 Then Continue For
          If frm.AutoCode.Checked = True Then
            RaiseEvent DoCopyMul(Me, FldV, xs * (intX - 1), ys * (intY - 1), intX & "-" & intY)
          Else
            RaiseEvent DoCopyMul(Me, FldV, xs * (intX - 1), ys * (intY - 1), "")
          End If
        Next
      Next
    End If
  End Sub

  Private Sub BM_Click(sender As Object, e As EventArgs) Handles BM.Click

  End Sub
End Class
