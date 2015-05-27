namespace Task4_1
{
    /// <summary>
    /// Класс, обрабатывающий "символы"
    /// </summary>
    public static class Symbol
    {
        public static bool IsBracket(string line)
        {
            return line == ")" || line == "(";
        }

        public static bool IsOperation(string line)
        {
            return line == "+" || line == "-" || line == "*" || line == "/";
        }
    }
}
