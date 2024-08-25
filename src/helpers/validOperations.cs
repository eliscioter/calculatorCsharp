namespace ConsoleApp1.src.helpers
{

    public static class ValidOperations
    {
        private static HashSet<string> valid_operations;
        public static HashSet<string> Operations() {
            return valid_operations = ["Addition", "Subtraction", "Multiplication", "Division"];
        }
        public static string ToCapitalize(this string s)
        {
            return string.Concat(s[0].ToString().ToUpper(), s.AsSpan(1));
        }
        public static bool IsValidOperation(this string operation)
        {
            return Operations().Contains(operation.ToCapitalize());
        }
    }
}