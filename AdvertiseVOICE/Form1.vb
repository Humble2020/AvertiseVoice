Imports System.IO

Public Class Form1

    Friend WithEvents GTHY As New SpeechLib.SpVoice
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GTHY.Voice = GTHY.GetVoices().Item(0) 'female voice
        GTHY.Rate = 0.2
        GTHY.Volume = 100
        GTHY.Speak(Me.RichTextBox1.Text, SpeechLib.SpeechVoiceSpeakFlags.SVSFParseAutodetect)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        GTHY.GetVoices()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'save in file
        Try
            Dim ss = New SpeechLib.SpFileStream
            If File.Exists(Application.StartupPath & "/AdvertVOICE.wav") Then
                File.Delete(Application.StartupPath & "/AdvertVOICE.wav")
            End If
            ss.Open("AdvertVOICE.wav", SpeechLib.SpeechStreamFileMode.SSFMCreateForWrite, False)
            GTHY.AudioOutputStream = ss
            GTHY.Rate = 0.2
            GTHY.Volume = 100
            GTHY.Speak(Me.RichTextBox1.Text, SpeechLib.SpeechVoiceSpeakFlags.SVSFParseAutodetect)
            ss.Close()
            MessageBox.Show("Advert File created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        Me.RichTextBox1.Text = String.Empty
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim hj As Integer = Nothing
        Try
            hj = Me.RichTextBox1.TextLength
            Me.Label1.Text = hj
        Catch ex As Exception

        End Try
    End Sub
End Class
