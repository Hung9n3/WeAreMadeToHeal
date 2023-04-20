using Dawn;

namespace WeAreMadeToHeal
{
    public static class StringHelpers
    {
        public static bool IsOnlyDigit(this string s)
        {
            Guard.Argument(s, "IsOnlyDigit has received a null string");
            return s.All(c => c >= '0' && c <= '9');
        }

        public static bool IsEmail(this string s)
        {
            Guard.Argument(s, "IsEmailOrUsername has received a null string");
            return s.Contains("@") && s.Contains(".");
        }
    }
}
