using System.Collections;
using System.Collections.Generic;

namespace R
{
    public static class S
    {
        public static string MainMenuActivity = "MainMenu";
        public static string GameActivity = "Game";

        public static string LoadingScreenScene = "LoadingScreen";
        public static string MainScene = "Main";

        #region Stats

        public const int DAMAGE = 0;
        public const int ROF = 1;
        public const int HP = 2;
        public const int SPEED = 3;
        public const int RANGE = 5;
        public const int PROJECTILE_SPEED = 6;
        public const int MONEY = 7;

        #endregion

        public static string UpgradeMenuTag = "UpgradeMenu";

        #region Upgrade button
        public static string ButtonCurrentValueFormat = "Current : {0}";
        public static string ButtonNextValueFormat = "+ 1 ({0} $)";
        #endregion

        public static string MainTag = "Main";
        public static string GameManagerTag = "GameManager";
    }
}