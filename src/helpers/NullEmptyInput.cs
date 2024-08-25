namespace ConsoleApp1.src.helpers
{
    public static class NullEmptyInput
    {
        public static bool IsEmptyOrNull(this string s)
        {
            return s == "" || s == null;
        }
    }
}