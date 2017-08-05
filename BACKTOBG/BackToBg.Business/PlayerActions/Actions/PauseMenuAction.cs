using System;
using System.Collections.Generic;
using BackToBg.Business.Attributes;
using BackToBg.Business.Common;
using BackToBg.Business.Menu;
using BackToBg.Business.Reader;
using BackToBg.Business.UtilityInterfaces;
using BackToBg.Business.Writer;

namespace BackToBg.Business.PlayerActions.Actions
{
    [PlayerAction("Escape")]
    public class PauseMenuAction : PlayerAction
    {
        public override void Execute()
        {
            var pauseMenu = new PauseMenu(new ConsoleReader(), new ConsoleWriter(Constants.ConsoleHeight, Constants.ConsoleWidth));
            pauseMenu.StartMenu();
        }
    }
}