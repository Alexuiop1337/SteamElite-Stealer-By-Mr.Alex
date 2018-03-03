// Decompiled with JetBrains decompiler
// Type: IWshRuntimeLibrary.IWshShell3
// Assembly: SteamElite, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC0AF3C1-BDDB-427F-AF9C-215450AD8173
// Assembly location: C:\Users\Пользователь\Desktop\Decompiled.exe

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace IWshRuntimeLibrary
{
  [CompilerGenerated]
  [Guid("41904400-BE18-11D3-A28B-00104BD35090")]
  [TypeIdentifier]
  [ComImport]
  public interface IWshShell3 : IWshShell2
  {
    [DispId(100)]
    IWshCollection SpecialFolders { [DispId(100), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] [return: MarshalAs(UnmanagedType.Interface)] get; }

    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    extern void _VtblGap1_3();

    [DispId(1002)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    [return: MarshalAs(UnmanagedType.IDispatch)]
    object CreateShortcut([MarshalAs(UnmanagedType.BStr), In] string PathLink);
  }
}
