Public Class house

    Public pos As New Vector2(1280 / 2, 720 / 2)
    Public size As New Vector2(32, 32)

    Public colbox As collisionBox

    Public textureString As String = ""

    Public hpbar As healthBar
    Public health As Integer = 300

    'Public firerate As Integer = 250
    'Public fireTimer As New Stopwatch

    Public realPos As Vector2 = pos - New Vector2(size.X / 2, size.Y / 2)

    Public rotation As Double = 0

    Public Sub New(location As Vector2, texture As String, fullSize As Vector2)

        pos = location
        textureString = texture
        size = fullSize

        colbox = New collisionBox(location, size, "house")
        realPos = pos - New Vector2(size.X / 2, size.Y / 2)

        hpbar = New healthBar(New Vector2(size.X * 1.01, 5), health, New Rectangle(realPos.ToPoint, size.ToPoint))

    End Sub

    Public Sub update()

        colbox.update(realPos)
        hpbar.update(health, New Rectangle(realPos.ToPoint, size.ToPoint))

        If health <= 0 Then
            colbox.destroy()
        End If

        If colbox.isAlive = False Then
            destroy()
        End If

        realPos = pos - New Vector2(size.X / 2, size.Y / 2)

    End Sub

    Public Sub destroy()

        Game1.gameLoop.gameScene.houses.Remove(Me)

    End Sub

    Public Sub draw(sb As SpriteBatch)

        Dim texture As Texture2D = Game1.contentMnger.loadTexture(textureString)
        sb.Draw(texture, New Rectangle(pos.X + Globals.cameraLoc.X, pos.Y + Globals.cameraLoc.Y, size.X, size.Y), Nothing, Color.White, rotation, New Vector2(texture.Width / 2.0F, texture.Height / 2.0F), Nothing, 0.2)

        hpbar.draw(sb)

    End Sub

End Class
