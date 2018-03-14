<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SplashScreen
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub
    Friend WithEvents appInfo As System.Windows.Forms.Label
    Friend WithEvents MainLayoutPanel As System.Windows.Forms.TableLayoutPanel

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.MainLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.appInfo = New System.Windows.Forms.Label()
        Me.DetailsLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.infoApp = New System.Windows.Forms.Label()
        Me.infoCop = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.infoVer = New System.Windows.Forms.Label()
        Me.ProLabel = New System.Windows.Forms.Label()
        Me.ProBar = New System.Windows.Forms.ProgressBar()
        Me.MainLayoutPanel.SuspendLayout()
        Me.DetailsLayoutPanel.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainLayoutPanel
        '
        Me.MainLayoutPanel.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.MainLayoutPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MainLayoutPanel.ColumnCount = 2
        Me.MainLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 243.0!))
        Me.MainLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 345.0!))
        Me.MainLayoutPanel.Controls.Add(Me.appInfo, 1, 0)
        Me.MainLayoutPanel.Controls.Add(Me.DetailsLayoutPanel, 1, 1)
        Me.MainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.MainLayoutPanel.Name = "MainLayoutPanel"
        Me.MainLayoutPanel.RowCount = 2
        Me.MainLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 213.0!))
        Me.MainLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43.0!))
        Me.MainLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.MainLayoutPanel.Size = New System.Drawing.Size(584, 281)
        Me.MainLayoutPanel.TabIndex = 0
        '
        'appInfo
        '
        Me.appInfo.BackColor = System.Drawing.Color.Transparent
        Me.appInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.appInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.appInfo.ForeColor = System.Drawing.SystemColors.Window
        Me.appInfo.Location = New System.Drawing.Point(246, 0)
        Me.appInfo.Name = "appInfo"
        Me.appInfo.Size = New System.Drawing.Size(339, 213)
        Me.appInfo.TabIndex = 0
        Me.appInfo.Text = "JL PRODUCTS"
        Me.appInfo.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'DetailsLayoutPanel
        '
        Me.DetailsLayoutPanel.AutoSize = True
        Me.DetailsLayoutPanel.BackColor = System.Drawing.Color.Transparent
        Me.DetailsLayoutPanel.ColumnCount = 1
        Me.DetailsLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.DetailsLayoutPanel.Controls.Add(Me.infoApp, 0, 0)
        Me.DetailsLayoutPanel.Controls.Add(Me.infoCop, 0, 1)
        Me.DetailsLayoutPanel.Controls.Add(Me.Panel1, 0, 2)
        Me.DetailsLayoutPanel.Dock = System.Windows.Forms.DockStyle.Right
        Me.DetailsLayoutPanel.Location = New System.Drawing.Point(253, 216)
        Me.DetailsLayoutPanel.Name = "DetailsLayoutPanel"
        Me.DetailsLayoutPanel.RowCount = 3
        Me.DetailsLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.DetailsLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.23809!))
        Me.DetailsLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.76191!))
        Me.DetailsLayoutPanel.Size = New System.Drawing.Size(332, 62)
        Me.DetailsLayoutPanel.TabIndex = 1
        '
        'infoApp
        '
        Me.infoApp.BackColor = System.Drawing.Color.Transparent
        Me.infoApp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.infoApp.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.infoApp.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.infoApp.Location = New System.Drawing.Point(3, 0)
        Me.infoApp.Name = "infoApp"
        Me.infoApp.Size = New System.Drawing.Size(326, 22)
        Me.infoApp.TabIndex = 1
        Me.infoApp.Text = "Inventory Management Software"
        Me.infoApp.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'infoCop
        '
        Me.infoCop.BackColor = System.Drawing.Color.Transparent
        Me.infoCop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.infoCop.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.infoCop.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.infoCop.Location = New System.Drawing.Point(3, 22)
        Me.infoCop.Name = "infoCop"
        Me.infoCop.Size = New System.Drawing.Size(326, 18)
        Me.infoCop.TabIndex = 3
        Me.infoCop.Text = "Copyright"
        Me.infoCop.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.infoVer)
        Me.Panel1.Controls.Add(Me.ProLabel)
        Me.Panel1.Controls.Add(Me.ProBar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 43)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(326, 16)
        Me.Panel1.TabIndex = 4
        '
        'infoVer
        '
        Me.infoVer.AutoSize = True
        Me.infoVer.BackColor = System.Drawing.Color.Transparent
        Me.infoVer.Dock = System.Windows.Forms.DockStyle.Right
        Me.infoVer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.infoVer.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.infoVer.Location = New System.Drawing.Point(142, 0)
        Me.infoVer.Name = "infoVer"
        Me.infoVer.Size = New System.Drawing.Size(94, 18)
        Me.infoVer.TabIndex = 4
        Me.infoVer.Text = "Version 4.0.3"
        Me.infoVer.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'ProLabel
        '
        Me.ProLabel.AutoSize = True
        Me.ProLabel.BackColor = System.Drawing.Color.Transparent
        Me.ProLabel.Dock = System.Windows.Forms.DockStyle.Right
        Me.ProLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.ProLabel.ForeColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ProLabel.Location = New System.Drawing.Point(236, 0)
        Me.ProLabel.Name = "ProLabel"
        Me.ProLabel.Size = New System.Drawing.Size(49, 18)
        Me.ProLabel.TabIndex = 4
        Me.ProLabel.Text = "100 %"
        Me.ProLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ProLabel.Visible = False
        '
        'ProBar
        '
        Me.ProBar.Dock = System.Windows.Forms.DockStyle.Right
        Me.ProBar.Location = New System.Drawing.Point(285, 0)
        Me.ProBar.Name = "ProBar"
        Me.ProBar.Size = New System.Drawing.Size(41, 16)
        Me.ProBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProBar.TabIndex = 5
        Me.ProBar.Visible = False
        '
        'SplashScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 281)
        Me.ControlBox = False
        Me.Controls.Add(Me.MainLayoutPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "SplashScreen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.MainLayoutPanel.ResumeLayout(False)
        Me.MainLayoutPanel.PerformLayout()
        Me.DetailsLayoutPanel.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DetailsLayoutPanel As TableLayoutPanel
    Friend WithEvents infoCop As Label
    Friend WithEvents infoApp As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents infoVer As Label
    Friend WithEvents ProLabel As Label
    Friend WithEvents ProBar As ProgressBar
End Class
