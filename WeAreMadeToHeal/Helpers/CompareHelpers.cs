namespace WeAreMadeToHeal
{
    public static class CompareHelpers
    {
        public static bool InDateRange(this DateTime value, DateTime start, DateTime end)
        {
            return start <= value && value <= end;
        }
    }
}
