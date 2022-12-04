Public Class Form1
    Dim name = ""
    Dim temp = ""
    Dim result = ""
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim SD As New SaveFileDialog
        SD.FileName = "Qrcode"
        SD.Filter = "PNG Files only (*.png)|*.png"
        If SD.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Try
                PictureBox1.Image.Save(SD.FileName, System.Drawing.Imaging.ImageFormat.Png)
                MessageBox.Show("Successfully Saved")
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CheckBox1.Checked() Then
            Dim generate As New MessagingToolkit.Barcode.BarcodeEncoder
            generate.BackColor = Color.White
            generate.LabelFont = New Font("Arial", 7, FontStyle.Regular)
            generate.IncludeLabel = True
            generate.CustomLabel = "QRCode"
            result = "name: " + name + vbNewLine + "temp: " + temp
            Try
                PictureBox1.Image = New Bitmap(generate.Encode(MessagingToolkit.Barcode.BarcodeFormat.QRCode, result))
            Catch ex As Exception
                PictureBox1.Image = Nothing
            End Try

        Else
            MessageBox.Show("Please Agree to the terms and conditions")
        End If


    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        name = TextBox1.Text
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        temp = TextBox2.Text
    End Sub


End Class
