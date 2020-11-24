Public Class mainForm
    ' Warning to all reading this: the majority of this code was made while disassociating at 2am. I am honestly amazed it works.
    ' do not copy any code from this application, not because of plagiarism or anything, but because it sucks.
    Private isVanilla As Boolean = True
    Private fileExists As Boolean
    Private registryKey As Microsoft.Win32.RegistryKey

    '//Controls
    Private Sub mainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadFromRegistry()
        GameValidation()
        SetButtons()
    End Sub

    Private Sub vanillaButton_Click(sender As Object, e As EventArgs) Handles vanillaButton.Click
        GameValidation()
        If Not fileExists Then
            MsgBox("There is no dll at the expected location. Please make sure you have selected the right folder location.")
        ElseIf isVanilla Then
            Finish()
        ElseIf SetDLL(My.Resources.VanillaDLL) Then
            Finish()
        Else
            ' do nothing. return to program
        End If
    End Sub

    Private Sub moddedButton_Click(sender As Object, e As EventArgs) Handles moddedButton.Click
        GameValidation()
        If Not fileExists Then
            MsgBox("There is no dll at the expected location. Please make sure you have selected the right folder location.")
        ElseIf Not isVanilla Then
            Finish()
        ElseIf SetDLL(My.Resources.ModdedDLL) Then
            Finish()
        Else
            ' do nothing. return to program
        End If
    End Sub

    Private Sub PathButton_Click(sender As Object, e As EventArgs) Handles PathButton.Click ' /TODO add more error checking
        PathSelectDialog.Description = "Select the Hollow Knight folder.
eg. C:\Program Files (x86)\Steam\steamapps\common\Hollow Knight"
        DisplayFileDialog()
    End Sub

    Private Function DisplayFileDialog() As Boolean
        PathSelectDialog.SelectedPath = registryKey.GetValue("path")
        Select Case PathSelectDialog.ShowDialog()
            Case DialogResult.OK
                registryKey.SetValue("path", PathSelectDialog.SelectedPath)
                Return True
            Case DialogResult.Cancel
                ' do nothing
                Return False
            Case Else
                Return False
        End Select
    End Function

    '//Routines
    Private Function CheckModded() As Integer
        Dim vanillaBytes() As Byte = My.Resources.VanillaDLL ' Import dlls
        Dim moddedBytes() As Byte = My.Resources.ModdedDLL
        Dim assemblyBytes() As Byte
        If System.IO.File.Exists(registryKey.GetValue("path") & "\hollow_knight_Data\Managed\Assembly-CSharp.dll") Then
            assemblyBytes = My.Computer.FileSystem.ReadAllBytes(registryKey.GetValue("path") & "\hollow_knight_data\Managed\Assembly-CSharp.dll")
        Else
            MsgBox("There is no dll at the expected location. Please make sure you have selected the right folder location.")
            Return -1
        End If
        ' See if existing dll = vanilla dll. if not, game *should* be modded
        If assemblyBytes.SequenceEqual(vanillaBytes) Then
            Return 1
        ElseIf assemblyBytes.SequenceEqual(moddedBytes) Then
            Return 0
        Else
            Return -1
        End If
    End Function

    Private Sub SetButtons()
        Select Case isVanilla
            Case True
                vanillaButton.FlatStyle = FlatStyle.Flat
                ModdedLabel.Text = "Vanilla"
            Case False
                moddedButton.FlatStyle = FlatStyle.Flat
                ModdedLabel.Text = "Modded"
        End Select
    End Sub

    Private Function SetDLL(newDLL As Byte()) As Boolean
        If System.IO.File.Exists(registryKey.GetValue("path") & "\hollow_knight_Data\Managed\Assembly-CSharp.dll") Then
            My.Computer.FileSystem.WriteAllBytes(registryKey.GetValue("path") & "\hollow_knight_Data\Managed\Assembly-CSharp.dll", newDLL, False)
            Return True
        Else
            MsgBox("There is no dll at the expected location. Please make sure you have selected the right folder location.")
            Return False
        End If
    End Function

    Private Sub LoadFromRegistry()
        Dim subkeys() As String = Microsoft.Win32.Registry.CurrentUser.GetSubKeyNames()
        For Each subkey In subkeys
            If subkey = "hkAPIswitcher" Then
                registryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("hkAPIswitcher", True)
                Exit Sub
            End If
        Next
        ' only reachable if subkey is not present, so create new subkey w/ default value
        registryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("hkAPIswitcher")
        registryKey.SetValue("path", "C:\Program Files (x86)\Steam\steamapps\common\Hollow Knight")
    End Sub

    Private Sub GameValidation()
        Dim checkingmodded As Integer = CheckModded()
        Select Case checkingmodded
            Case -1
                fileExists = False
            Case Else
                isVanilla = checkingmodded
                fileExists = True
        End Select
    End Sub

    '//Finalisation
    Private Sub Finish()
        Me.Dispose()
        Me.Close()
    End Sub

End Class
