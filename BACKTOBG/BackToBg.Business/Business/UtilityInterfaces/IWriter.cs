using System;

namespace BackToBg.Core.Business.UtilityInterfaces
{
    public interface IWriter
    {
        int ConsoleHeight { get; }
        int ConsoleWidth { get; }
        void Clear();
        void DisplayException(string message);
        void WriteLine(string message);
        void SetCursorPosition(int left, int top);
        void DisplayMessageInColor(string message, ConsoleColor color);
        void DisplayQuestCompletionMessage(string message);
        void DisplayMessageInColorCentered(string message, ConsoleColor color);
        void DisplayStatsBar(string message, ConsoleColor color);
    }
}