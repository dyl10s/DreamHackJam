Public Class healthBar

    Public pos As Rectangle
    Public totalHP As Integer
    Public curHP As Integer
    Public size As Vector2

    Public Sub New(barSize As Vector2, maxHP As Integer, realPosition As Rectangle)

        pos = realPosition
        totalHP = maxHP
        curHP = totalHP
        size = barSize

    End Sub

    Public Sub update(HP As Integer, realPosition As Rectangle)

        pos = realPosition
        curHP = HP

    End Sub

    Public Sub draw(sb As SpriteBatch)

        Dim spriteX As Integer = pos.X + pos.Width / 2
        Dim spriteY As Integer = pos.Y - 10

        Dim hpX As Integer = size.X / 2
        Dim hpY As Integer = size.Y / 2

        sb.Draw(Game1.contentMnger.loadTexture("white"), New Rectangle(spriteX - hpX + Globals.cameraLoc.X, spriteY + Globals.cameraLoc.Y, size.X, size.Y), Nothing, Color.Red, Nothing, Nothing, Nothing, 0.5)

        Dim hpPercent As Double = curHP / totalHP

        sb.Draw(Game1.contentMnger.loadTexture("white"), New Rectangle(spriteX - hpX + Globals.cameraLoc.X, spriteY + Globals.cameraLoc.Y, size.X * hpPercent, size.Y), Nothing, Color.Green, Nothing, Nothing, Nothing, 0.6)

    End Sub

End Class
