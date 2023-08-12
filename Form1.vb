Imports System.IO
Imports System.IO.Compression
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub ExtractAndReadManifest(jarFilePath As String)
        Dim extractDir As String = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "TempExtract")
        Directory.CreateDirectory(extractDir)
        Try
            ZipFile.ExtractToDirectory(jarFilePath, extractDir)
            Dim manifestFilePath As String = Path.Combine(extractDir, "META-INF", "MANIFEST.MF")
            If File.Exists(manifestFilePath) Then
                Dim manifestContent As String = File.ReadAllText(manifestFilePath)
                RichTextBox1.Text = manifestContent
                Label2.Show()
                RichTextBox1.Show()
                Button2.Show()
            Else
                MessageBox.Show("MANIFEST.MF not found.")
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        Finally
            Directory.Delete(extractDir, True)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.Filter = "Java Archive Files|*.jar"
        openFileDialog1.Title = "Select a JAR File"
        If openFileDialog1.ShowDialog() = DialogResult.OK Then
            ExtractAndReadManifest(openFileDialog1.FileName)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        RichTextBox1.Clear()
        Label2.Hide()
        RichTextBox1.Hide()
        Button2.Hide()
    End Sub
End Class
