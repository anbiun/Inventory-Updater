Imports System.ComponentModel
Imports IWshRuntimeLibrary

Public NotInheritable Class SplashScreen
    Private Copyright As String = " 2017 - " & Today.Year
    Private ftp As New FTP
    Private bwLoad As New BackgroundWorker
    Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        AddHandler bwLoad.DoWork, AddressOf bwDowork
        AddHandler bwLoad.RunWorkerCompleted, AddressOf bwComplete
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Private Sub SplashScreen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim bgarr As Bitmap() = {My.Resources.bg1, My.Resources.content_main_bg}
        Dim r As New Random()
        Dim bgrnd As Integer = r.Next(2)
        MainLayoutPanel.BackgroundImage = bgarr(bgrnd)
        infoCop.Text += Copyright

        ftp.Setting.PgBar = ProBar
        ftp.Setting.PgLabel = ProLabel
        ftp.Setting.infoVersion = infoVer

        If ftp.Setting.Readconfig = False Then End

        Dim version As String = ftp.ReadLocalFile(ftp.Setting.version, "version=")
        infoVer.Text = "Version " + version.Substring(version.IndexOf("=") + 1)

        bwLoad.RunWorkerAsync()
    End Sub
    Private Sub CheckUpdate()
        If ftp.Newversion = False Then
            'if update zip found delete it
            If IO.File.Exists(ftp.Setting.FileUpdate) Then IO.File.Delete(ftp.Setting.FileUpdate)
            'if bin/app notfound can't start
            Dim appPath As String = IO.Path.Combine(IO.Directory.GetParent(Application.StartupPath).ToString, ftp.Setting.RunApp)
            If Not IO.File.Exists(appPath) Then
                IO.File.Delete(ftp.Setting.Version)
                Application.Restart()
            Else
                Shell(appPath, AppWinStyle.NormalFocus)
                End
            End If

        End If
    End Sub
    Private Sub BwDowork(sender As Object, e As DoWorkEventArgs)
        System.Threading.Thread.Sleep(1000)
    End Sub
    Private Sub BwComplete(sender As Object, e As RunWorkerCompletedEventArgs)
        CheckUpdate()
    End Sub

End Class
