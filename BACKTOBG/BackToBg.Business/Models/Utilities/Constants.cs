﻿using System;
using System.Drawing;

namespace BackToBg.Core.Models.Utilities
{
    public static class Constants
    {
        public const int TradeDialogItemRows = 5;
        public const int TradeDialogSpacingColumns = 4;
        public const int TradeDialogItemMaxLength = 20;

        public const char DefaultPlayerFigure = '☻';
        public const char BanditFigure = 'B';
        public const int ConsoleHeight = 41;
        public const int ConsoleWidth = 61;
        public const int DefaultBanditHealth = 10;
        public const int DefaultPlayerAttack = 1;

        public static Color InventoryActiveColor = Color.Beige;
        public static Color InventoryActiveRowColor = Color.Green;
        public static Color InventoryInactiveColor = Color.Gray;
        public static ConsoleColor UserPromptColor = ConsoleColor.Yellow;

        public static string AreYouSureBuy = "Y/N Are you sure you want to buy this item: {0}?";
        public static string AreYouSureSell = "Y/N Are you sure you want to sell this item: {0}?";
    }
}