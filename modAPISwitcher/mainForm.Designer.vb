<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class mainForm
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mainForm))
        Me.vanillaButton = New System.Windows.Forms.Button()
        Me.moddedButton = New System.Windows.Forms.Button()
        Me.PathButton = New System.Windows.Forms.Button()
        Me.PathSelectDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.ModdedLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'vanillaButton
        '
        Me.vanillaButton.Location = New System.Drawing.Point(12, 6)
        Me.vanillaButton.Name = "vanillaButton"
        Me.vanillaButton.Size = New System.Drawing.Size(138, 52)
        Me.vanillaButton.TabIndex = 0
        Me.vanillaButton.Text = "Vanilla"
        Me.vanillaButton.UseVisualStyleBackColor = True
        '
        'moddedButton
        '
        Me.moddedButton.Location = New System.Drawing.Point(158, 6)
        Me.moddedButton.Name = "moddedButton"
        Me.moddedButton.Size = New System.Drawing.Size(138, 52)
        Me.moddedButton.TabIndex = 1
        Me.moddedButton.Text = "Modded"
        Me.moddedButton.UseVisualStyleBackColor = True
        '
        'PathButton
        '
        Me.PathButton.Location = New System.Drawing.Point(151, 81)
        Me.PathButton.Name = "PathButton"
        Me.PathButton.Size = New System.Drawing.Size(145, 33)
        Me.PathButton.TabIndex = 3
        Me.PathButton.Text = "Change File Path"
        Me.PathButton.UseVisualStyleBackColor = True
        '
        'PathSelectDialog
        '
        Me.PathSelectDialog.Description = "Select the Hollow Knight folder."
        '
        'ModdedLabel
        '
        Me.ModdedLabel.AutoSize = True
        Me.ModdedLabel.Location = New System.Drawing.Point(12, 81)
        Me.ModdedLabel.Name = "ModdedLabel"
        Me.ModdedLabel.Size = New System.Drawing.Size(59, 17)
        Me.ModdedLabel.TabIndex = 4
        Me.ModdedLabel.Text = "Modded"
        '
        'mainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(308, 123)
        Me.Controls.Add(Me.ModdedLabel)
        Me.Controls.Add(Me.PathButton)
        Me.Controls.Add(Me.moddedButton)
        Me.Controls.Add(Me.vanillaButton)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "mainForm"
        Me.Text = "modding API toggler"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents vanillaButton As Button
    Friend WithEvents moddedButton As Button
    Friend WithEvents PathButton As Button
    Friend WithEvents PathSelectDialog As FolderBrowserDialog
    Friend WithEvents ModdedLabel As Label
End Class
