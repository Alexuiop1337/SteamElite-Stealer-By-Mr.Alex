// Decompiled with JetBrains decompiler
// Type: GWH
// Assembly: SteamElite, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC0AF3C1-BDDB-427F-AF9C-215450AD8173
// Assembly location: C:\Users\Пользователь\Desktop\Decompiled.exe

using System;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;

internal class GWH
{
  [DllImport("user32.dll")]
  public static extern IntPtr GetForegroundWindow();

  [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
  private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

  [DllImport("user32.dll")]
  private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

  public string GetActiveWindowTitle()
  {
    try
    {
      IntPtr foregroundWindow = GWH.GetForegroundWindow();
      uint lpdwProcessId = 0;
      int windowThreadProcessId = (int) GWH.GetWindowThreadProcessId(foregroundWindow, out lpdwProcessId);
      string processName = Process.GetProcessById((int) lpdwProcessId).ProcessName;
      if (processName == "explorer" || processName == "WWAHost")
        return this.GetTitle(foregroundWindow);
      string str = FileVersionInfo.GetVersionInfo((string) new ManagementObjectSearcher(string.Format("SELECT ProcessId, ExecutablePath FROM Win32_Process WHERE ProcessId LIKE '{0}'", (object) lpdwProcessId.ToString())).Get().Cast<ManagementObject>().FirstOrDefault<ManagementObject>()["ExecutablePath"]).FileDescription;
      if (str == "")
        str = this.GetTitle(foregroundWindow);
      return str;
    }
    catch
    {
      return "";
    }
  }

  private string GetTitle(IntPtr handle)
  {
    string str = "";
    StringBuilder lpString = new StringBuilder(256);
    if (GWH.GetWindowText(handle, lpString, 256) > 0)
      str = lpString.ToString();
    return str;
  }
}
