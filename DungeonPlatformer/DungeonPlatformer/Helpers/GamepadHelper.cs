using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DungeonPlatformer.Helpers
{
    public static class GamepadHelper
    {
        public delegate void KeyPressedEventHandler();

        static private GamePadState _currentState;
        private static GamePadState _previousState;

        private static float VibrationLength;
        static private float VibrationElapsed;

        public static void Update(float dt)
        {
            _previousState = _currentState;
            _currentState = GamePad.GetState(0);

            if (VibrationLength > 0)
                VibrationLength -= dt;
            else
            {
                Vibration(0,0);
            }

        }

        static public void Vibration(float power1, float power2, float length = 0)
        {
            VibrationLength = length;

            GamePad.SetVibration(PlayerIndex.One, power1, power2);
        }

        static public bool Press(Buttons button)
        {
            return _currentState.IsButtonDown(button);
        }

        static public bool WasPressed(Buttons button)
        {
            return _currentState.IsButtonDown(button) && _previousState.IsButtonUp(button);
        }

        static public bool WasReleased(Buttons button)
        {
            return _currentState.IsButtonUp(button) && _previousState.IsButtonDown(button);
        }
    }
}
