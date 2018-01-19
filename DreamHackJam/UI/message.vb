Public Class message

    Public message As String = ""
    Public time As Integer = 0

    Public timer As New Stopwatch

    Public Sub New(displayedMessage As String, TimeDisplayed As Integer)

        message = displayedMessage
        time = TimeDisplayed

        timer.Start()

        Game1.gameLoop.gameScene.messages.Add(Me)

    End Sub

    Public Sub update()

        If timer.ElapsedMilliseconds > time Then
            Game1.gameLoop.gameScene.messages.Remove(Me)
        End If

    End Sub

    Public Sub draw(sb As SpriteBatch)

        Dim font As SpriteFont = Game1.contentMnger.loadFont("mainFont")
        Dim length As Integer = font.MeasureString(message).X
        sb.DrawString(font, message, New Vector2((1280 / 2) - (length / 2), 50), Color.Black, 0, Nothing, 1, Nothing, 0.999)

    End Sub

End Class
