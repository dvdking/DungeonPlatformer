using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace DungeonPlatformer
{
    static public class Settings
    {
        public const int CellSize = 16;
        static public readonly Vector2 Gravity = new Vector2(0,1);
        public const float GameSpeed = 0.1f;
    }
}
