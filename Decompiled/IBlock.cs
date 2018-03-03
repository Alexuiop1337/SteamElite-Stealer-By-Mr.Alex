// Decompiled with JetBrains decompiler
// Type: IBlock
// Assembly: SteamElite, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC0AF3C1-BDDB-427F-AF9C-215450AD8173
// Assembly location: C:\Users\Пользователь\Desktop\Decompiled.exe

using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;

internal class IBlock
{
  public const int INTERNET_OPTION_SETTINGS_CHANGED = 39;
  public const int INTERNET_OPTION_REFRESH = 37;

  [DllImport("wininet.dll")]
  public static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int dwBufferLength);

  public static void Enabled()
  {
    RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);
    registryKey.SetValue("ProxyEnable", (object) 1);
    registryKey.SetValue("ProxyServer", (object) "2.23.143.150:443");
    IBlock.InternetSetOption(IntPtr.Zero, 39, IntPtr.Zero, 0);
    IBlock.InternetSetOption(IntPtr.Zero, 37, IntPtr.Zero, 0);
  }
}
