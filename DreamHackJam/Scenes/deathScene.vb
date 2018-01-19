Public Class deathScene

    Public Sub New()

    End Sub

    Public Sub update()

    End Sub

    Public Sub draw(sb As SpriteBatch)

        sb.Begin()

        sb.Draw(Game1.contentMnger.loadTexture("Death Screen"), New Rectangle(0, 0, 1280, 720), Color.White)

        Dim messure1 As Vector2 = Game1.contentMnger.loadFont("deathFont").MeasureString(Globals.points.ToString)
        Dim messure2 As Vector2 = Game1.contentMnger.loadFont("deathFont").MeasureString(Game1.gameLoop.gameScene.levelMaker.waveNum.ToString)

        sb.DrawString(Game1.contentMnger.loadFont("deathFont"), Globals.points.ToString, New Vector2(640 - (messure1.X / 2), 470), Color.White)
        sb.DrawString(Game1.contentMnger.loadFont("deathFont"), Game1.gameLoop.gameScene.levelMaker.waveNum.ToString, New Vector2(640 - (messure2.X / 2), 291), Color.White)

        Dim ms As MouseState = Microsoft.Xna.Framework.Input.Mouse.GetState
        sb.Draw(Game1.contentMnger.loadTexture("UI cursor"), New Rectangle(ms.X, ms.Y, 40, 40), Color.White)

        'Console.WriteLine(ms.X.ToString + " " + ms.Y.ToString)
        If ms.LeftButton = ButtonState.Pressed Then

            If New Rectangle(519, 556, 240, 43).Contains(ms.X, ms.Y) Then
                'play
                Globals.points = 0
                Globals.totalMoney = 0
                Globals.gameState = "game"
            End If

            If New Rectangle(539, 629, 194, 43).Contains(ms.X, ms.Y) Then
                'exit
                Game1.needsClose = True
            End If

        End If

        sb.End()

    End Sub

End Class
