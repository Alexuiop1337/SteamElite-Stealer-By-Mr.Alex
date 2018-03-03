// Decompiled with JetBrains decompiler
// Type: DropBox
// Assembly: SteamElite, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC0AF3C1-BDDB-427F-AF9C-215450AD8173
// Assembly location: C:\Users\Пользователь\Desktop\Decompiled.exe

using Microsoft.Win32;
using System.IO;

public static class DropBox
{
  private static string Get_DropBox_Inastal_Folder()
  {
    if (Registry.CurrentUser.OpenSubKey("Software\\Dropbox") == null)
      return "error_1";
    if (Registry.CurrentUser.OpenSubKey("Software\\Dropbox").GetValue("InstallPath") == null)
      return "error_2";
    return new DirectoryInfo(Registry.CurrentUser.OpenSubKey("Software\\Dropbox").GetValue("InstallPath").ToString()).Parent.FullName;
  }

  public static string Get_DropBox_Files_Folder()
  {
    string str = File.ReadAllText(DropBox.Get_DropBox_Inastal_Folder() + "\\info.json");
    if (str == "error_1" || str == "error_2")
      return "DropBox not install";
    return str.Split('"')[5];
  }
}
