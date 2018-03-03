// Decompiled with JetBrains decompiler
// Type: IWshRuntimeLibrary.IWshCollection
// Assembly: SteamElite, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC0AF3C1-BDDB-427F-AF9C-215450AD8173
// Assembly location: C:\Users\Пользователь\Desktop\Decompiled.exe

using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace IWshRuntimeLibrary
{
  [CompilerGenerated]
  [Guid("F935DC27-1CF0-11D0-ADB9-00C04FD58A0B")]
  [TypeIdentifier]
  [ComImport]
  public interface IWshCollection : IEnumerable
  {
    [DispId(0)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    [return: MarshalAs(UnmanagedType.Struct)]
    object Item([MarshalAs(UnmanagedType.Struct), In] ref object Index);
  }
}
