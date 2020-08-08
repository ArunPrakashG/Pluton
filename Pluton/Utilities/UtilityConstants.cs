namespace Pluton.Utilities
{
    internal static class UtilityConstants
    {
        internal static class PConsoleWindowConstants
        {
            internal const int SW_HIDE = 0;
            internal const int SW_SHOW = 5;
            internal const int MF_BYCOMMAND = 0x00000000;
            internal const int SC_CLOSE = 0xF060;
            internal const int SC_MINIMIZE = 0xF020;
            internal const int SC_MAXIMIZE = 0xF030;
            internal const int SC_SIZE = 0xF000;
        }

        internal static class PProcessConstants
        {
            internal const uint ErrorStatus = 0xc0000022;
        }
    }
}