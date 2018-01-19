Imports Microsoft.Xna.Framework
Imports Microsoft.Xna.Framework.Graphics
Imports Microsoft.Xna.Framework.Input

Namespace safeprojectname

    Public Class Game1

        Inherits Game
        Private graphics As GraphicsDeviceManager
        Private spriteBatch As SpriteBatch
        Public Shared publicGraphics As GraphicsDeviceManager
        Public Shared gameLoop As GameLoop
        Public Shared contentMnger As contentMnger

        Public backgroudSong As SoundEffect
        Public seInstance As SoundEffectInstance

        Public Shared needsClose As Boolean = False

        Public Sub New()
            graphics = New GraphicsDeviceManager(Me)

            graphics.GraphicsProfile = GraphicsProfile.HiDef

            graphics.PreferredBackBufferWidth() = 1280
            graphics.PreferredBackBufferHeight() = 720

            graphics.ApplyChanges()
            IsMouseVisible = False

            graphics.IsFullScreen = False

            Content.RootDirectory = "Content"

            publicGraphics = graphics

        End Sub

        Protected Overrides Sub Initialize()
            ' TODO: Add your initialization logic here
            gameLoop = New GameLoop

            MyBase.Initialize()
        End Sub


        Protected Overrides Sub LoadContent()
            ' Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = New SpriteBatch(GraphicsDevice)
            backgroudSong = Content.Load(Of SoundEffect)("Pim Poy Pocket")
            seInstance = backgroudSong.CreateInstance
            contentMnger = New contentMnger(Content)

            ' TODO: use this.Content to load your game content here
        End Sub

        Protected Overrides Sub UnloadContent()
            ' TODO: Unload any non ContentManager content here
        End Sub


        Protected Overrides Sub Update(gameTime As GameTime)
            If GamePad.GetState(PlayerIndex.One).Buttons.Back = ButtonState.Pressed OrElse Keyboard.GetState().IsKeyDown(Keys.Escape) Then
                [Exit]()
            End If


            seInstance.IsLooped = True
            If seInstance.State = SoundState.Playing Then
            Else
                seInstance.Play()
            End If



            If needsClose = True Then
                Me.Exit()
            End If

            ' TODO: Add your update logic here
            gameLoop.update()

            MyBase.Update(gameTime)
        End Sub

        Protected Overrides Sub Draw(gameTime As GameTime)
            GraphicsDevice.Clear(Color.CornflowerBlue)

            ' TODO: Add your drawing code here
            gameLoop.draw(spriteBatch)

            MyBase.Draw(gameTime)
        End Sub



    End Class
End Namespace