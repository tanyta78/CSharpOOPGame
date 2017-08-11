using System;
using System.Drawing;

namespace BackToBg.Core.Models.Utilities
{
    public static class Constants
    {
        public const int TradeDialogItemRows = 5;
        public const int TradeDialogSpacingColumns = 4;
        public const int TradeDialogItemMaxLength = 20;
        public const char RoadChar = ' ';
        public const char DefaultPlayerFigure = '☻';
        public const char BanditFigure = 'B';
	    public const char BasicBuildingBorder = '*';
	    public const char BasicBuildingInner = 'O';
        public const int ConsoleHeight = 41;
        public const int ConsoleWidth = 61;
        public const int DefaultBanditHealth = 10;
	    public const int DefaultSizeFactor = 1;
	    public const int DefaultMapSize = 100;

        public static Color InventoryActiveColor = Color.Beige;
        public static Color InventoryActiveRowColor = Color.Green;
        public static Color InventoryInactiveColor = Color.Gray;
        public static ConsoleColor UserPromptColor = ConsoleColor.Yellow;

        public static string AreYouSureBuy = "Y/N Are you sure you want to buy this item: {0}?";
        public static string AreYouSureSell = "Y/N Are you sure you want to sell this item: {0}?";

		public const int DefaultPlayerAttack = 10;
	    public const int PlayerStartingHitPoints = 100;
	    public const int PlayerStartingAgility = 49;
	    public const int PlayerStartingStrength = 62;
	    public const int PlayerStartingIntelligence = 39;
	    public const int PlayerStartingStamina = 200;
	    public const int PlayerStartingExpirience = 0;
	    public const double PlayerStartingMoney = 500;

	    public const int FallinBranchDamage = 15;
	    public const int BrokenLegDamage = 30;
	    public const int FoundMoneyAmmount = 50;

	    public static readonly string FallingBranchMsg = $"You got hit by falling branch - you lost {Constants.FallinBranchDamage} hitpoints";
	    public static readonly string BrokenLegMsg = $"You fell into open shaft - you lost  {Constants.BrokenLegDamage} hitpoints";

	    public static readonly string FoundMoneyMsg = $"Congratilations you found {Constants.FoundMoneyAmmount}$";
	    
	}
}