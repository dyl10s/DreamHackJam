Public Class menuScene

    Public Sub New()

    End Sub

    Public Sub update()

    End Sub

    Public Sub draw(sb As SpriteBatch)

        sb.Begin()

        sb.Draw(Game1.contentMnger.loadTexture("Main Menu"), New Rectangle(0, 0, 1280, 720), Color.White)

        Dim ms As MouseState = Microsoft.Xna.Framework.Input.Mouse.GetState
        sb.Draw(Game1.contentMnger.loadTexture("UI cursor"), New Rectangle(ms.X, ms.Y, 40, 40), Color.White)

        'Console.WriteLine(ms.X.ToString + " " + ms.Y.ToString)
        If ms.LeftButton = ButtonState.Pressed Then
            If New Rectangle(551, 350, 189, 65).Contains(ms.X, ms.Y) Then
                'play
                Globals.points = 0
                Globals.totalMoney = 0
                Globals.gameState = "game"
            End If

            If New Rectangle(461, 430, 360, 81).Contains(ms.X, ms.Y) Then
                'instructions
            End If

            If New Rectangle(551, 538, 138, 80).Contains(ms.X, ms.Y) Then
                'exit
                Game1.needsClose = True
            End If
        End If

        sb.End()

    End Sub

End Class
