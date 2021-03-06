﻿using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;

namespace Pluton.WindowsSystemFeatures
{
    public static class PDesktop
    {
        [DllImport("user32.dll")]
        private static extern int FindWindow(string className, string windowText);
        [DllImport("user32.dll")]
        private static extern int ShowWindow(int hwnd, int command);
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindowEx(IntPtr hwndParent,
        IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 1;

        /// <summary>
        /// Hide task bar.
        /// </summary>
        public static void HideTaskBar()
        {
            int hwnd = FindWindow("Shell_TrayWnd", "");
            ShowWindow(hwnd, SW_HIDE);
        }

        /// <summary>
        /// Show task bar.
        /// </summary>
        public static void ShowTaskBar()
        {
            int hwnd = FindWindow("Shell_TrayWnd", "");
            ShowWindow(hwnd, SW_SHOW);
        }

        /// <summary>
        /// Switch between light and dark theme.
        /// </summary>
        /// <param name="light">true = light theme; false = dark theme</param>
        public static void SetTheme(bool light)
        {
            try
            {
                GetPersonalizeKey().SetValue("AppsUseLightTheme", light ? 1 : 0, RegistryValueKind.DWord);
                GetPersonalizeKey().SetValue("SystemUsesLightTheme", light ? 1 : 0, RegistryValueKind.DWord);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static RegistryKey GetPersonalizeKey() => Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", true);
    }
}
