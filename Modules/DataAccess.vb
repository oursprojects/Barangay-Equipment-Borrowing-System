Imports System.Data
Imports System.Data.OleDb

''' <summary>
''' Data Access Layer for Barangay Equipment Borrowing System
''' Uses ADO.NET with OleDb for MS Access database
''' </summary>
Module DataAccess
    ' Connection string - MS Access ACE OLE DB
    ' Database file should be in Data folder relative to executable
    Private Const CONNECTION_STRING As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Data\BarangayEquipment.accdb;Persist Security Info=False;"

    ''' <summary>
    ''' Gets the connection string
    ''' </summary>
    Public Function GetConnectionString() As String
        ' Replace |DataDirectory| with actual path
        Dim appPath As String = Application.StartupPath
        Dim dataFolder As String = System.IO.Path.Combine(appPath, "Data")
        
        ' Create Data folder if it doesn't exist
        If Not System.IO.Directory.Exists(dataFolder) Then
            Try
                System.IO.Directory.CreateDirectory(dataFolder)
            Catch
                ' If we can't create it, continue anyway - user will see error message
            End Try
        End If
        
        Dim dbPath As String = System.IO.Path.Combine(dataFolder, "BarangayEquipment.accdb")
        Return CONNECTION_STRING.Replace("|DataDirectory|\Data\BarangayEquipment.accdb", dbPath)
    End Function

    ''' <summary>
    ''' Executes a SELECT query and returns a DataTable
    ''' </summary>
    Public Function GetTable(sql As String, Optional params As List(Of OleDbParameter) = Nothing) As DataTable
        Dim dt As New DataTable()
        Dim connString As String = GetConnectionString()

        Using cn As New OleDbConnection(connString)
            cn.Open()
            Using cmd As New OleDbCommand(sql, cn)
                ' Add parameters if provided - create clones to avoid reuse issues
                If params IsNot Nothing Then
                    For Each p In params
                        ' Create a new parameter with the same value to avoid reuse issues
                        Dim newParam As New OleDbParameter() With {
                            .Value = p.Value,
                            .ParameterName = p.ParameterName,
                            .OleDbType = p.OleDbType
                        }
                        cmd.Parameters.Add(newParam)
                    Next
                End If

                Using da As New OleDbDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using

        Return dt
    End Function

    ''' <summary>
    ''' Executes INSERT, UPDATE, or DELETE and returns rows affected
    ''' </summary>
    Public Function ExecNonQuery(sql As String, Optional params As List(Of OleDbParameter) = Nothing) As Integer
        Dim connString As String = GetConnectionString()
        Dim rowsAffected As Integer = 0

        Using cn As New OleDbConnection(connString)
            cn.Open()
            Using cmd As New OleDbCommand(sql, cn)
                ' Add parameters if provided - create clones to avoid reuse issues
                If params IsNot Nothing Then
                    For Each p In params
                        ' Create a new parameter with the same value to avoid reuse issues
                        Dim newParam As New OleDbParameter() With {
                            .Value = p.Value,
                            .ParameterName = p.ParameterName,
                            .OleDbType = p.OleDbType
                        }
                        cmd.Parameters.Add(newParam)
                    Next
                End If

                rowsAffected = cmd.ExecuteNonQuery()
            End Using
        End Using

        Return rowsAffected
    End Function

    ''' <summary>
    ''' Executes a scalar query and returns a single value
    ''' </summary>
    Public Function ExecScalar(sql As String, Optional params As List(Of OleDbParameter) = Nothing) As Object
        Dim connString As String = GetConnectionString()
        Dim result As Object = Nothing

        Using cn As New OleDbConnection(connString)
            cn.Open()
            Using cmd As New OleDbCommand(sql, cn)
                ' Add parameters if provided - create clones to avoid reuse issues
                If params IsNot Nothing Then
                    For Each p In params
                        ' Create a new parameter with the same value to avoid reuse issues
                        Dim newParam As New OleDbParameter() With {
                            .Value = p.Value,
                            .ParameterName = p.ParameterName,
                            .OleDbType = p.OleDbType
                        }
                        cmd.Parameters.Add(newParam)
                    Next
                End If

                result = cmd.ExecuteScalar()
            End Using
        End Using

        Return result
    End Function

    ''' <summary>
    ''' Executes multiple SQL commands within a transaction
    ''' Returns True if all commands succeed, False otherwise
    ''' </summary>
    Public Function ExecuteTransaction(commands As List(Of TransactionCommand)) As Boolean
        Dim connString As String = GetConnectionString()
        Dim success As Boolean = False

        Using cn As New OleDbConnection(connString)
            cn.Open()
            Using tx As OleDbTransaction = cn.BeginTransaction()
                Try
                    For Each cmdInfo In commands
                        Using cmd As New OleDbCommand(cmdInfo.Sql, cn, tx)
                            If cmdInfo.Parameters IsNot Nothing Then
                                For Each p In cmdInfo.Parameters
                                    ' Create a new parameter with the same value to avoid reuse issues
                                    Dim newParam As New OleDbParameter() With {
                                        .Value = p.Value,
                                        .ParameterName = p.ParameterName,
                                        .OleDbType = p.OleDbType
                                    }
                                    cmd.Parameters.Add(newParam)
                                Next
                            End If
                            cmd.ExecuteNonQuery()
                        End Using
                    Next

                    tx.Commit()
                    success = True
                Catch ex As Exception
                    tx.Rollback()
                    Throw ' Re-throw to let caller handle
                End Try
            End Using
        End Using

        Return success
    End Function

    ''' <summary>
    ''' Tests database connection
    ''' </summary>
    Public Function TestConnection() As String
        Try
            Dim connString As String = GetConnectionString()
            Dim dbPath As String = System.IO.Path.Combine(Application.StartupPath, "Data", "BarangayEquipment.accdb")
            
            ' Check if Data folder exists
            Dim dataFolder As String = System.IO.Path.Combine(Application.StartupPath, "Data")
            If Not System.IO.Directory.Exists(dataFolder) Then
                Return "Data folder does not exist. Please create folder: " & dataFolder
            End If
            
            ' Check if database file exists
            If Not System.IO.File.Exists(dbPath) Then
                Return "Database file does not exist. Please create: " & dbPath & vbCrLf & vbCrLf & 
                       "To create the database:" & vbCrLf &
                       "1. Open Microsoft Access" & vbCrLf &
                       "2. Create a new blank database" & vbCrLf &
                       "3. Save it as 'BarangayEquipment.accdb' in the Data folder" & vbCrLf &
                       "4. Run the SQL scripts from the Database folder to create tables"
            End If
            
            ' Try to connect
            Using cn As New OleDbConnection(connString)
                cn.Open()
                Return "OK"
            End Using
        Catch ex As Exception
            Return "Connection failed: " & ex.Message & vbCrLf & vbCrLf &
                   "Make sure Microsoft Access Database Engine is installed." & vbCrLf &
                   "Download from: https://www.microsoft.com/en-us/download/details.aspx?id=54920"
        End Try
    End Function

    ''' <summary>
    ''' Helper class for transaction commands
    ''' </summary>
    Public Class TransactionCommand
        Public Property Sql As String
        Public Property Parameters As List(Of OleDbParameter)

        Public Sub New(sqlCommand As String, Optional params As List(Of OleDbParameter) = Nothing)
            Sql = sqlCommand
            Parameters = params
        End Sub
    End Class
End Module

