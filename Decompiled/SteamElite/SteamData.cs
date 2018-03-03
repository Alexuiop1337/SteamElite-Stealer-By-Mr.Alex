// Decompiled with JetBrains decompiler
// Type: SteamElite.SteamData
// Assembly: SteamElite, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC0AF3C1-BDDB-427F-AF9C-215450AD8173
// Assembly location: C:\Users\Пользователь\Desktop\Decompiled.exe

using Microsoft.Win32;
using System.IO;
using System.Text.RegularExpressions;

namespace SteamElite
{
  internal class SteamData
  {
    public static string[] pars(string page, string regul, int GN = 1)
    {
      MatchCollection matchCollection = new Regex(regul).Matches(page);
      string[] strArray = new string[matchCollection.Count];
      for (int index = 0; index < matchCollection.Count; ++index)
        strArray[index] = matchCollection[index].Groups[GN].ToString();
      return strArray;
    }

    public static string Login
    {
      get
      {
        return SteamData.pars(File.ReadAllText(Registry.CurrentUser.OpenSubKey("Software\\Valve\\Steam").GetValue("SteamPath").ToString() + "\\config\\SteamAppData.vdf"), "(\\w{3,})", 1)[3];
      }
    }
  }
}
