namespace BackToBg.Business.UtilityInterfaces
{
    public interface IWriter
    {
        int ConsoleHeight { get; }
        int ConsoleWidth { get; }
        void Clear();
        void DisplayException(string message);
        void WriteLine(string message);
        void SetCursorPosition(int left, int top);
    }
}