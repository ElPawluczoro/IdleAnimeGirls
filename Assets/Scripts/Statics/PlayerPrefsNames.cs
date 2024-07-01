namespace Scripts.Statics
{
    public class PlayerPrefsNames
    {
        // General
        public static readonly string SWEETS = "Sweets";
        public static readonly string COINS = "Coins";
        public static readonly string SWEETS_PER_CLICK_BASIC = "SweetsPerClickBasic";
        public static readonly string SWEETS_PER_CLICK_MULTIPLIER = "SweetsPerClickMultiplier";
        
        // Girls
        
        public static readonly string REGULAR_GIRLS_COUNT = "RegularGirlsCount";
        public static readonly string REGULAR_GIRLS_MAX = "RegularGirlsMax";
        public static readonly string FREE_REGULAR_GIRLS = "FreeRegularGirls";
        
        public static readonly string MANAGER_GIRLS_COUNT = "ManagerGirlsCount";
        public static readonly string MANAGER_GIRLS_MAX = "ManagerGirlsMax";
        public static readonly string FREE_MANAGER_GIRLS = "FreeManagerGirls";
        
        public static readonly string SWEETS_PER_REGULAR_GIRL = "SweetsPerRegularGirl";
        public static readonly string SWEETS_PER_REGULAR_GIRL_MULTIPLIER = "SweetsPerRegularGirlMultiplier";
        public static readonly string COINS_PER_REGULAR_GIRL = "CoinsPerRegularGirl";
        public static readonly string COINS_PER_REGULAR_GIRL_MULTIPLIER = "CoinsPerRegularGirlMultiplier";

        //Works

        public static readonly string REGULAR_GIRLS_ASSIGNED_TO_SWEETS_FOREST = "SweetsForestCount";
        public static readonly string REGULAR_GIRLS_ASSIGNED_TO_SWEETS_FOREST_MAX = "SweetsForestMax";
        public static readonly string REGULAR_GIRLS_ASSIGNED_TO_COINS_FARM = "CoinsFarmCount";
        public static readonly string REGULAR_GIRLS_ASSIGNED_TO_COINS_FARM_MAX = "CoinsFarmMax";

        public static readonly string SWEETS_FOREST_MANAGER = "SweetsForestManager";
        public static readonly string COINS_FARM_MANAGER = "CoinsFarmManager";
        
        // Upgrades
        
        /// <summary>
        /// Always add unique identificator. <br />
        /// ex:<br />
        /// string uid = "1"; ... UPGRADE + uid ...;<br />
        /// </summary>
        public static readonly string UPGRADE = "Upgrade";


    }
}