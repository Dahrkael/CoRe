using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CoRe
{
    namespace Input
    {
        public class InputManager
        {
            private static InputManager instance;

            private KeyboardState oldKeyboardState;
            private KeyboardState newKeyboardState;

            public static InputManager I
            { get { return Instance; } }

            public static InputManager Instance
            { get { if (instance == null) { instance = new InputManager(); } return instance; } }

            private InputManager()
            {
                oldKeyboardState = Keyboard.GetState();
            }

            public void Update()
            {
                oldKeyboardState = newKeyboardState;
                newKeyboardState = Keyboard.GetState();
            }

            public bool isKeyTriggered(Keys key)
            {
                if (newKeyboardState.IsKeyDown(key))
                {
                    if (oldKeyboardState.IsKeyUp(key))
                    { return true; }
                }
                return false;
            }

            public bool isKeyPressed(Keys key)
            {
                if (newKeyboardState.IsKeyDown(key))
                { return true; }
                return false;
            }
        }
    }
}
