Public Class GameLoop

    Public gameScene As New gameScene
    Public menuScene As New menuScene
    Public deathScene As New deathScene


    Public Sub New()


    End Sub

    Public Sub update()

        Select Case Globals.gameState.ToLower
            Case "game"
                gameScene.update()
            Case "menu"
                menuScene.update()
            Case "lost"
                deathScene.update()
        End Select

    End Sub

    Public Sub draw(sb As SpriteBatch)

        Select Case Globals.gameState.ToLower
            Case "game"
                gameScene.draw(sb)
            Case "menu"
                menuScene.draw(sb)
            Case "lost"
                deathScene.draw(sb)
        End Select

    End Sub

End Class
