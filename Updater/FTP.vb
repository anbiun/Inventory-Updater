Option Explicit On
Option Strict On
Imports System.ComponentModel
Imports System.IO
Imports System.Net

Public Class FTP
    Private BWorker As New BackgroundWorker
    Public Setting As New Sett
    Private ExtractAll As Boolean = False
    Private fileSize As Integer
    Private Filelist As New List(Of String)
    Sub New()
        AddHandler BWorker.DoWork, AddressOf BWorker_DoWork
        AddHandler BWorker.ProgressChanged, AddressOf BWorker_ProgressChanged
        AddHandler BWorker.RunWorkerCompleted, AddressOf BWorker_RunWorkerCompleted
        BWorker.WorkerReportsProgress = True
    End Sub
    Private Sub BWorker_DoWork(sender As Object, e As DoWorkEventArgs)
        Dim buffer(1023) As Byte
        Dim bytesIn As Integer
        Dim totalBytesIn As Integer
        Dim output As IO.Stream

        Try
            For Each Files As String In Filelist
                Dim FTPRequest As FtpWebRequest = DirectCast(WebRequest.Create(Setting.URL + "/" + Files), FtpWebRequest)
                FTPRequest.Credentials = Setting.Credentials
                FTPRequest.Method = WebRequestMethods.Ftp.DownloadFile
                Dim stream As Stream = FTPRequest.GetResponse.GetResponseStream
                Dim OutPutFilePath As String = IO.Path.GetFileName(Files)
                output = File.Create(OutPutFilePath)
                bytesIn = 1
                Do Until bytesIn < 1
                    bytesIn = stream.Read(buffer, 0, 1024)
                    If bytesIn > 0 Then
                        output.Write(buffer, 0, bytesIn)
                        totalBytesIn += bytesIn
                        'FileSize = totalBytesIn.ToString
                        If fileSize > 0 Then
                            Dim perc As Integer = CInt((totalBytesIn / fileSize) * 100)
                            BWorker.ReportProgress(perc)

                        End If
                    End If
                Loop
                output.Close()
                stream.Close()
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub BWorker_ProgressChanged(sender As Object, e As ProgressChangedEventArgs)
        Setting.UpdateProgress(e.ProgressPercentage)
    End Sub
    Private Sub BWorker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
        Dim Unpack As New Unpackfile With {
            .File = Setting.FileUpdate,
            .PgLabel = Setting.PgLabel,
            .PgBar = Setting.PgBar,
            .RunApp = Setting.RunApp,
            .FileVersion = Setting.Version
        }

        Setting.InfoVersion.Text = "กำลังติดตั้งไฟล์"
        Setting.PgLabel.Visible = False
        Setting.PgBar.Visible = True
        If ExtractAll Then
            Unpack.All()
        Else
            Unpack.Update()
        End If
    End Sub
    Public Function Newversion() As Boolean
        Dim newVer As String = "", CurrentVersion As String
        Dim line As String()
        Try
            If File.Exists(Setting.Version) Then
                CurrentVersion = ReadLocalFile(Setting.Version, "version=")
            Else
                CurrentVersion = "0"
            End If

            Dim request As FtpWebRequest = TryCast(WebRequest.Create(Setting.URL + Setting.Version), FtpWebRequest)
            request.KeepAlive = False
            request.Method = WebRequestMethods.Ftp.DownloadFile
            request.Credentials = Setting.Credentials
            Using response = DirectCast(request.GetResponse(), FtpWebResponse)
                Dim reader As StreamReader
                Dim ftpRespStream As Stream = response.GetResponseStream
                reader = New StreamReader(ftpRespStream, Text.Encoding.UTF8)
                line = reader.ReadToEnd.Split()
                For Each item As String In line
                    If Not String.IsNullOrEmpty(item) Then
                        Dim result As String = item.Substring(item.IndexOf("=") + 1)
                        If item.ToLower.Contains("version") Then
                            newVer = result
                        Else
                            ExtractAll = CBool(result)
                        End If
                    End If
                Next
            End Using

            If newVer <> CurrentVersion Then
                getFileList()
                Setting.PgBar.Visible = False
                Setting.PgLabel.Visible = True
                BWorker.RunWorkerAsync()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Private Sub GetFileList()
        ''listfile in ftp
        Dim Line As String()
        Try
            Dim request As FtpWebRequest = TryCast(WebRequest.Create(Setting.URL), FtpWebRequest)
            request.KeepAlive = False
            request.Method = WebRequestMethods.Ftp.ListDirectory
            request.Credentials = Setting.Credentials
            Using response = DirectCast(request.GetResponse(), FtpWebResponse)
                Dim reader As StreamReader
                Dim ftpRespStream As Stream = response.GetResponseStream
                reader = New StreamReader(ftpRespStream, Text.Encoding.UTF8)
                Line = reader.ReadToEnd.Split()
                For Each item As String In Line
                    If Not String.IsNullOrEmpty(item) AndAlso item.Contains(".") Then
                        Filelist.Add(item)
                    End If
                Next
            End Using
        Catch ex As Exception

        End Try
        For Each Files As String In Filelist
            Try
                Dim FTPRequest As FtpWebRequest = DirectCast(WebRequest.Create(Setting.URL + "/" + Files), FtpWebRequest)
                FTPRequest.Credentials = Setting.Credentials
                FTPRequest.Method = Net.WebRequestMethods.Ftp.GetFileSize
                fileSize += CInt(FTPRequest.GetResponse.ContentLength)
                'FileSize = flLength.ToString               
                'Setting.PgBar.Maximum = fileSize
            Catch ex As Exception

            End Try
        Next
        Setting.PgBar.Maximum = fileSize
    End Sub
    Public Function ReadLocalFile(Filename As String, Filter As String) As String
        Dim result As String = ""
        If Not File.Exists(Filename) Then
            Return ""
        End If
        For Each line In File.ReadAllLines(Filename)
            If line.ToLower.Contains(Filter) Then
                result = line.Substring(line.IndexOf("=") + 1)
                Exit For
            End If
        Next
        Return result
    End Function

End Class

Public Class Sett
    Private FtpConfig As String = "ftp.jlproducts"
    Private _URL As String
    Private _appname As String
    Private _FileVer As String
    Private _user As String
    Private _password As String
    Private _pgdownload As New ProgressBar
    Private _pglabel As Label
    Private _credentials As NetworkCredential
    Private _binFolder As String
    Private _fileUpdate As String
    Private _panelDownload As Panel
    Private _infoVer As Label
    Public Property InfoVersion As Label
        Set(value As Label)
            _infoVer = value
        End Set
        Get
            Return _infoVer
        End Get
    End Property
    Public ReadOnly Property FileUpdate As String
        Get
            Return _fileUpdate
        End Get
    End Property
    Public ReadOnly Property RunApp As String
        Get
            Return _binFolder + _appname
        End Get
    End Property
    Public ReadOnly Property Bin As String
        Get
            Return _binFolder
        End Get
    End Property
    Public Property PgBar As ProgressBar
        Set(value As ProgressBar)
            _pgdownload = value
        End Set
        Get
            Return _pgdownload
        End Get
    End Property
    Public Property PgLabel As Label
        Set(value As Label)
            _pglabel = value
        End Set
        Get
            Return _pglabel
        End Get
    End Property
    Public Property Version As String
        Set(value As String)
            _FileVer = value
        End Set
        Get
            Return _FileVer
        End Get
    End Property
    Public Property URL As String
        Set(value As String)
            _URL = value
        End Set
        Get
            Return _URL
        End Get
    End Property
    Public ReadOnly Property Credentials As NetworkCredential
        Get
            Return _credentials
        End Get
    End Property
    Public Function Readconfig() As Boolean

        If Not File.Exists(FtpConfig) Then
            MessageBox.Show("ติดต่อ FTPServer เพื่อตรวจสอบอัพเดทไม่ได้", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        Try
            For Each line As String In File.ReadAllLines(FtpConfig)
                If Not String.IsNullOrEmpty(line) Then
                    Dim result As String = line.Substring(line.IndexOf("=") + 1)
                    With line.ToLower
                        If .Contains("url=") Then
                            URL = result
                        ElseIf .Contains("user=") Then
                            _user = result
                        ElseIf .Contains("pass=") Then
                            _password = result
                        ElseIf .Contains("fileapp=") Then
                            _appname = result
                        ElseIf .Contains("fileversion=") Then
                            _FileVer = result
                        ElseIf .Contains("folderbin=") Then
                            _binFolder = result
                        ElseIf .Contains("fileupdate=") Then
                            _fileUpdate = result
                        End If
                    End With
                End If
            Next
            _credentials = New NetworkCredential(_user, _password)
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Public Sub UpdateProgress(Value As Integer)
        infoVersion.Text = "กำลังอัพเดท..."
        infoVersion.ForeColor = PgLabel.ForeColor
        PgBar.Value = Value
        PgLabel.Text = Value.ToString & " %"
    End Sub
End Class

