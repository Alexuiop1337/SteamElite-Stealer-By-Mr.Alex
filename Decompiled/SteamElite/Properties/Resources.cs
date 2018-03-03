// Decompiled with JetBrains decompiler
// Type: SteamElite.Properties.Resources
// Assembly: SteamElite, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC0AF3C1-BDDB-427F-AF9C-215450AD8173
// Assembly location: C:\Users\Пользователь\Desktop\Decompiled.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace SteamElite.Properties
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (SteamElite.Properties.Resources.resourceMan == null)
          SteamElite.Properties.Resources.resourceMan = new ResourceManager("SteamElite.Properties.Resources", typeof (SteamElite.Properties.Resources).Assembly);
        return SteamElite.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return SteamElite.Properties.Resources.resourceCulture;
      }
      set
      {
        SteamElite.Properties.Resources.resourceCulture = value;
      }
    }
  }
}
