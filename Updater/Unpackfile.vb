Option Explicit On
Option Strict On
Imports System.ComponentModel
Imports System.IO
Imports SharpCompress.Archive
Imports SharpCompress.Common

Public Class Unpackfile
    Private FileName As String
    Private _PgBar As New ProgressBar
    Private _PgLabel As New Label
    Private BGwork As New BackgroundWorker
    Private _AppPath As String
    Private _Filever As String
    Dim archive As IArchive
    Sub New()
        AddHandler BGwork.DoWork, AddressOf BgWork_Dowork
        AddHandler BGwork.ProgressChanged, AddressOf BgWork_Update
        AddHandler BGwork.RunWorkerCompleted, AddressOf BgWork_Complete
        BGwork.WorkerReportsProgress = True
    End Sub
    Public WriteOnly Property PgLabel As Label
        Set(value As Label)
            _PgLabel = value
        End Set
    End Property
    Public WriteOnly Property PgBar As ProgressBar
        Set(value As ProgressBar)
            _PgBar = value
        End Set
    End Property
    Public WriteOnly Property File As String
        Set(value As String)
            FileName = Application.StartupPath + "\" + value
        End Set
    End Property
    Public WriteOnly Property FileVersion As String
        Set(value As String)
            _Filever = value
        End Set
    End Property
    Public Property RunApp As String
        Set(value As String)
            _AppPath = value
        End Set
        Get
            Return _AppPath
        End Get
    End Property
    Public Sub All()
        DelDir()
        archive = ArchiveFactory.Open(FileName)
        _PgBar.Maximum = archive.Entries.Count
        _PgBar.Value = 0
        BGwork.RunWorkerAsync()
    End Sub
    Public Sub Update()
        archive = ArchiveFactory.Open(FileName)
        _PgBar.Maximum = archive.Entries.Count
        _PgBar.Value = 0
        BGwork.RunWorkerAsync()
    End Sub
    Private Sub DelDir()
        For Each Dir As String In Directory.GetDirectories(Directory.GetParent(Application.StartupPath).ToString)
            If Dir = Application.StartupPath Then Continue For
            Directory.Delete(Dir, True)
        Next
    End Sub
    Private Sub BgWork_Dowork(sender As Object, e As DoWorkEventArgs)
        Dim entryNum As Integer = 0
        For Each entry In archive.Entries
            entryNum += 1
            If Not entry.IsDirectory Then
                'Console.WriteLine(entry.FilePath)
                Try
                    entry.WriteToDirectory(Directory.GetParent(Application.StartupPath).ToString, ExtractOptions.ExtractFullPath Or ExtractOptions.Overwrite)
                Catch ex As Exception
                    IO.File.Delete(_Filever)
                End Try

            End If

            BGwork.ReportProgress(entryNum)
        Next
    End Sub
    Private Sub BgWork_Update(sender As Object, e As ProgressChangedEventArgs)
        _PgBar.Value = e.ProgressPercentage
    End Sub
    Private Sub BgWork_Complete(sender As Object, e As RunWorkerCompletedEventArgs)
        Application.Restart()
    End Sub

End Class
