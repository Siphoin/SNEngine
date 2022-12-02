using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace SNEngineLib.InputSystem
{
    public class Input : Component
    {
        #region Standalone

        private KeyboardState _currentKeyboardState;

        private KeyboardState _previousKeyboardState;

        private MouseState _currentMouseState;

        private MouseState _previousMouseState;

        #endregion

        private static Input _instance;

        public static Vector2 MousePosition
        {
            get
            {
                Point mousePoint = _instance._currentMouseState.Position;

                float x =  mousePoint.X;

                float y = mousePoint.Y;

                return new Vector2(x, y);
            }
        }
        public Input (NovelGame game)
        {
            if (game == null)
            {
                throw new ArgumentNullException(nameof(game));
            }

            if (_instance != null)
            {
                throw new Exception("instance input as exits");
            }

            _instance = this;

            _currentKeyboardState = Keyboard.GetState();
            _previousKeyboardState = _currentKeyboardState;
            _currentMouseState = Mouse.GetState();
            _previousMouseState = _currentMouseState;

            IsDrawable = false;
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            _previousMouseState = _currentMouseState;

            _currentMouseState = Mouse.GetState();

            _previousKeyboardState = _currentKeyboardState;

            _currentKeyboardState = Keyboard.GetState();
        }

        public static bool GetKeyDown (Keys key)
        {
            return _instance._currentKeyboardState.IsKeyDown(key) && !_instance._previousKeyboardState.IsKeyDown(key);
        }

        public static bool GetKeyUp(Keys key)
        {
            return _instance._currentKeyboardState.IsKeyUp(key) && !_instance._previousKeyboardState.IsKeyUp(key);
        }

        public static bool GetKey(Keys key)
        {
            return _instance._currentKeyboardState.IsKeyDown(key);
        }

        public static bool GetMouseButtonStateLeft ()
        {
            return _instance._currentMouseState.LeftButton == ButtonState.Released && _instance._previousMouseState.LeftButton == ButtonState.Pressed;
        }

        public static bool GetMouseButtonStateRight()
        {
            return _instance._currentMouseState.RightButton == ButtonState.Released && _instance._previousMouseState.RightButton == ButtonState.Pressed;
        }
    }
}
