using System;
using System.Runtime.InteropServices;
using static PConsoleWindowConstants;

namespace Pluton.Utilities
{
    public static class PConsoleWindow
    {
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        
        /// <summary> 
        /// Hide console window. 
        /// </summary>
        public static void HideConsole()
        {
            IntPtr handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);
        }

        /// <summary>
        /// Show console window. 
        /// </summary>
        public static void ShowConsole()
        {
            IntPtr handle = GetConsoleWindow();
            ShowWindow(handle, PConsoleWindowConstants.SW_SHOW);
        }

        /// <summary>
        /// You can no longer resize the window
        /// </summary>
        public static void NoResizable()
        {
            IntPtr handle = GetConsoleWindow();
            IntPtr sysMenu = GetSystemMenu(handle, false);
            DeleteMenu(sysMenu, PConsoleWindowConstants.SC_SIZE, PConsoleWindowConstants.MF_BYCOMMAND);
        }

        /// <summary>
        /// You can no longer interact with window bar buttons(_ ☐ X).
        /// </summary>
        public static void DisableBarButtons()
        {
            IntPtr handle = GetConsoleWindow();
            IntPtr sysMenu = GetSystemMenu(handle, false);
            DeleteMenu(sysMenu, PConsoleWindowConstants.SC_CLOSE, PConsoleWindowConstants.MF_BYCOMMAND);
            DeleteMenu(sysMenu, PConsoleWindowConstants.SC_MINIMIZE, PConsoleWindowConstants.MF_BYCOMMAND);
            DeleteMenu(sysMenu, PConsoleWindowConstants.SC_MAXIMIZE, PConsoleWindowConstants.MF_BYCOMMAND);
        }
    }
}
