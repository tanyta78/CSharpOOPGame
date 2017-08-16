namespace BackToBg.Core.Models.Utilities
{
    public static class Functions
    {
        public static string ShortenLine(string line, int maxChars)
        {
            if (line.Length > maxChars)
                line = line.Substring(0, maxChars - 3) + "...";
            return line;
        }

        /// <summary>
        ///     Alligns and fills the line (if it's short enough with given filling character) / shortens (with '.' if too long)
        /// </summary>
        public static string AlignLine(string line, int maxChars, char fillingChar = ' ',
            Alignment alignment = Alignment.Left)
        {
            if (line.Length > maxChars)
                return ShortenLine(line, maxChars);
            if (line.Length < maxChars)
            {
                switch (alignment)
                {
                    case Alignment.Left:
                        line = line + new string(fillingChar, maxChars - line.Length);
                        break;
                    case Alignment.Middle:
                        line = new string(fillingChar, (maxChars - line.Length) / 2) + line +
                               new string(fillingChar, (maxChars - line.Length) / 2);
                        break;
                    case Alignment.Right:
                        line = new string(fillingChar, maxChars - line.Length) + line;
                        break;
                }
                return line;
            }

            return line;
        }
    }
}