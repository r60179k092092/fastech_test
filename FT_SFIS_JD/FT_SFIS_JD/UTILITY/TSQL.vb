
Imports System
Imports System.Data.SqlClient
Public Class lgjTSQL
    Inherits APSQL.SQLDB

    Sub New(ByVal CONNECTION As String)
        Try
            bolActive = False
            Conn = New SqlClient.SqlConnection(CONNECTION)
            Conn.Open()
            bolActive = True
        Catch e As InvalidOperationException
            MsgBox("Connection String Bad !!")
        Catch e As SqlClient.SqlException
            MsgBox("Connection Error : " & e.Message.ToString)
        End Try
    End Sub
  Public Overloads Sub Open(ByVal CONNECTION As String)
    Try
      bolActive = False
      Conn = New SqlClient.SqlConnection(CONNECTION)
      Conn.Open()
      bolActive = True
    Catch e As InvalidOperationException
      MsgBox("Connection String Bad !!")
    Catch e As SqlClient.SqlException
      MsgBox("Connection Error : " & e.Message.ToString)
    End Try
  End Sub

    Public Function ExecuteNonQuery(ByVal cmdText As String, ByVal ParamArray commandParameters As SqlParameter()) As Integer
        Dim cmd As SqlCommand = New SqlCommand()
        PrepareCommand(cmd, Nothing, Nothing, cmdText, commandParameters)
        Dim val As Integer = cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()
        Return val
    End Function
    Public Function ExecuteNonQuery(ByVal connection As SqlConnection, ByVal cmdText As String, ByVal ParamArray commandParameters As SqlParameter()) As Integer
        Dim cmd As SqlCommand = New SqlCommand()
        PrepareCommand(cmd, connection, Nothing, cmdText, commandParameters)
        Dim val As Integer = cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()
        Return val
    End Function
    Public Function ExecuteNonQuery(ByVal trans As SqlTransaction, ByVal cmdText As String, ByVal ParamArray commandParameters As SqlParameter()) As Integer
        Dim cmd As SqlCommand = New SqlCommand()
        PrepareCommand(cmd, CType(trans.Connection, SqlConnection), trans, cmdText, commandParameters)
        Dim val As Integer = cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()
        Return val
    End Function


    Public Sub ExecuteStoredProcedure(ByVal StoredProcedurename As String, ByVal ParamArray commandParameters As SqlParameter())
        Dim cmd As SqlCommand = New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        PrepareCommand(cmd, Nothing, Nothing, StoredProcedurename, commandParameters)
        cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()
    End Sub
    Public Sub ExecuteStoredProcedure(ByVal cmd As SqlCommand, ByVal StoredProcedure As String)
        cmd.CommandType = CommandType.StoredProcedure
        PrepareCommand(cmd, Nothing, Nothing, StoredProcedure, Nothing)
        cmd.ExecuteNonQuery()
    End Sub
    Public Function ExecuteStoredProcedureReturntb(ByVal cmd As SqlCommand, ByVal StoredProcedure As String) As DataTable
        cmd.CommandType = CommandType.StoredProcedure
        PrepareCommand(cmd, Nothing, Nothing, StoredProcedure, Nothing)
        Dim adp As SqlDataAdapter = New SqlDataAdapter()
        adp.SelectCommand = cmd
        Dim tb As DataTable = New DataTable()
        adp.Fill(tb)
        Return tb
    End Function



    Public Function ExecuteReader(ByVal cmdText As String, ByVal ParamArray commandParameters As SqlParameter()) As SqlDataReader
        Dim cmd As SqlCommand = New SqlCommand()
        PrepareCommand(cmd, Nothing, Nothing, cmdText, commandParameters)
        Dim rdr As SqlDataReader = cmd.ExecuteReader()
        cmd.Parameters.Clear()
        Return rdr
    End Function

    Public Function ExecuteScalar(ByVal cmdText As String, ByVal ParamArray commandParameters As SqlParameter()) As Object
        Dim cmd As SqlCommand = New SqlCommand()
        PrepareCommand(cmd, Nothing, Nothing, cmdText, commandParameters)
        Dim o As Object = cmd.ExecuteScalar()
        cmd.Parameters.Clear()
        Return o
    End Function

    Public Function ExecuteDataTable(ByVal cmdText As String, ByVal ParamArray commandParameters As SqlParameter()) As DataTable
        Dim cmd As SqlCommand = New SqlCommand()
        PrepareCommand(cmd, Nothing, Nothing, cmdText, commandParameters)
        Dim adp As SqlDataAdapter = New SqlDataAdapter()
        adp.SelectCommand = cmd
        Dim tb As DataTable = New DataTable()
        adp.Fill(tb)
        cmd.Parameters.Clear()
        Return tb
    End Function

    Private Sub PrepareCommand(ByVal cmd As SqlCommand, ByVal con As SqlConnection, ByVal trans As SqlTransaction, ByVal cmdText As String, ByVal cmdParms As SqlParameter())
        If con Is Nothing Then
            If Conn.State <> ConnectionState.Open Then
                Conn.Open()
            End If
            cmd.Connection = Conn
        Else
            cmd.Connection = con
        End If

        cmd.CommandText = cmdText
        If Not trans Is Nothing Then
            cmd.Transaction = trans
        End If
        If Not cmdParms Is Nothing Then
            Dim param As SqlParameter
            For Each param In cmdParms
                cmd.Parameters.Add(param)
            Next
        End If
    End Sub
End Class

