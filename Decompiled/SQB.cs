// Decompiled with JetBrains decompiler
// Type: SQB
// Assembly: SteamElite, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC0AF3C1-BDDB-427F-AF9C-215450AD8173
// Assembly location: C:\Users\Пользователь\Desktop\Decompiled.exe

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;

public class SQB
{
  private static IntPtr NullPtr135515 = (IntPtr) 0;
  private static SQB.KeyType3151531 defaultKeyType = SQB.KeyType3151531.UserKey;
  private const int CRYPTPROTECT_UI_FORBIDDEN31521512531 = 1;
  private const int CRYPTPROTECT_LOCAL_MACHINE13515 = 4;

  [DllImport("crypt32.dll", CharSet = CharSet.Auto, SetLastError = true)]
  private static extern bool CryptUnprotectData(ref SQB.DATA_BLOB pCipherText, ref string pszDescription, ref SQB.DATA_BLOB pEntropy, IntPtr pReserved, ref SQB.CRYPTPROTECT_PROMPTSTRUCT pPrompt, int dwFlags, ref SQB.DATA_BLOB pPlainText);

  [DllImport("crypt32.dll", CharSet = CharSet.Auto, SetLastError = true)]
  private static extern bool CryptProtectData(ref SQB.DATA_BLOB pPlainText, string szDescription, ref SQB.DATA_BLOB pEntropy, IntPtr pReserved, ref SQB.CRYPTPROTECT_PROMPTSTRUCT pPrompt, int dwFlags, ref SQB.DATA_BLOB pCipherText);

  private static void InitPrompt135151531(ref SQB.CRYPTPROTECT_PROMPTSTRUCT ps)
  {
    ps.cbSize24241245153 = Marshal.SizeOf(typeof (SQB.CRYPTPROTECT_PROMPTSTRUCT));
    ps.dwPromptFlags134515115 = 0;
    ps.hwndApp135431514 = SQB.NullPtr135515;
    ps.szPrompt24363576468 = (string) null;
  }

  private static void InitBLOB135151(byte[] data, ref SQB.DATA_BLOB blob)
  {
    if (data == null)
      data = new byte[0];
    blob.pbData = Marshal.AllocHGlobal(data.Length);
    if (blob.pbData == IntPtr.Zero)
      throw new Exception("Unable to allocate data buffer for BLOB structure.");
    blob.cbData2184741874 = data.Length;
    Marshal.Copy(data, 0, blob.pbData, data.Length);
  }

  public static string Encrypt(string plainText)
  {
    return SQB.Encrypt(SQB.defaultKeyType, plainText, string.Empty, string.Empty);
  }

  public static string Encrypt(SQB.KeyType3151531 keyType, string plainText)
  {
    return SQB.Encrypt(keyType, plainText, string.Empty, string.Empty);
  }

  public static string Encrypt(SQB.KeyType3151531 keyType, string plainText, string entropy)
  {
    return SQB.Encrypt(keyType, plainText, entropy, string.Empty);
  }

  public static string Encrypt(SQB.KeyType3151531 keyType, string plainText, string entropy, string description)
  {
    if (plainText == null)
      plainText = string.Empty;
    if (entropy == null)
      entropy = string.Empty;
    return Convert.ToBase64String(SQB.Encrypt(keyType, Encoding.UTF8.GetBytes(plainText), Encoding.UTF8.GetBytes(entropy), description));
  }

  public static byte[] Encrypt(SQB.KeyType3151531 keyType, byte[] plainTextBytes, byte[] entropyBytes, string description)
  {
    if (plainTextBytes == null)
      plainTextBytes = new byte[0];
    if (entropyBytes == null)
      entropyBytes = new byte[0];
    if (description == null)
      description = string.Empty;
    SQB.DATA_BLOB dataBlob1 = new SQB.DATA_BLOB();
    SQB.DATA_BLOB pCipherText = new SQB.DATA_BLOB();
    SQB.DATA_BLOB dataBlob2 = new SQB.DATA_BLOB();
    SQB.CRYPTPROTECT_PROMPTSTRUCT cryptprotectPromptstruct = new SQB.CRYPTPROTECT_PROMPTSTRUCT();
    SQB.InitPrompt135151531(ref cryptprotectPromptstruct);
    try
    {
      try
      {
        SQB.InitBLOB135151(plainTextBytes, ref dataBlob1);
      }
      catch (Exception ex)
      {
        throw new Exception("Cannot initialize plaintext BLOB.", ex);
      }
      try
      {
        SQB.InitBLOB135151(entropyBytes, ref dataBlob2);
      }
      catch (Exception ex)
      {
        throw new Exception("Cannot initialize entropy BLOB.", ex);
      }
      int dwFlags = 1;
      if (keyType == SQB.KeyType3151531.MachineKey)
        dwFlags |= 4;
      if (!SQB.CryptProtectData(ref dataBlob1, description, ref dataBlob2, IntPtr.Zero, ref cryptprotectPromptstruct, dwFlags, ref pCipherText))
        throw new Exception("CryptProtectData failed.", (Exception) new Win32Exception(Marshal.GetLastWin32Error()));
      byte[] destination = new byte[pCipherText.cbData2184741874];
      Marshal.Copy(pCipherText.pbData, destination, 0, pCipherText.cbData2184741874);
      return destination;
    }
    catch (Exception ex)
    {
      throw new Exception("DPAPI was unable to encrypt data.", ex);
    }
    finally
    {
      if (dataBlob1.pbData != IntPtr.Zero)
        Marshal.FreeHGlobal(dataBlob1.pbData);
      if (pCipherText.pbData != IntPtr.Zero)
        Marshal.FreeHGlobal(pCipherText.pbData);
      if (dataBlob2.pbData != IntPtr.Zero)
        Marshal.FreeHGlobal(dataBlob2.pbData);
    }
  }

  public static string Decrypt(string cipherText)
  {
    string description;
    return SQB.Decrypt(cipherText, string.Empty, out description);
  }

  public static string Decrypt(string cipherText, out string description)
  {
    return SQB.Decrypt(cipherText, string.Empty, out description);
  }

  public static string Decrypt(string cipherText, string entropy, out string description)
  {
    if (entropy == null)
      entropy = string.Empty;
    return Encoding.UTF8.GetString(SQB.Decrypt(Convert.FromBase64String(cipherText), Encoding.UTF8.GetBytes(entropy), out description));
  }

  public static byte[] Decrypt(byte[] cipherTextBytes, byte[] entropyBytes, out string description)
  {
    SQB.DATA_BLOB pPlainText = new SQB.DATA_BLOB();
    SQB.DATA_BLOB dataBlob1 = new SQB.DATA_BLOB();
    SQB.DATA_BLOB dataBlob2 = new SQB.DATA_BLOB();
    SQB.CRYPTPROTECT_PROMPTSTRUCT cryptprotectPromptstruct = new SQB.CRYPTPROTECT_PROMPTSTRUCT();
    SQB.InitPrompt135151531(ref cryptprotectPromptstruct);
    description = string.Empty;
    try
    {
      try
      {
        SQB.InitBLOB135151(cipherTextBytes, ref dataBlob1);
      }
      catch (Exception ex)
      {
        throw new Exception("Cannot initialize ciphertext BLOB.", ex);
      }
      try
      {
        SQB.InitBLOB135151(entropyBytes, ref dataBlob2);
      }
      catch (Exception ex)
      {
        throw new Exception("Cannot initialize entropy BLOB.", ex);
      }
      int dwFlags = 1;
      if (!SQB.CryptUnprotectData(ref dataBlob1, ref description, ref dataBlob2, IntPtr.Zero, ref cryptprotectPromptstruct, dwFlags, ref pPlainText))
        throw new Exception("CryptUnprotectData failed.", (Exception) new Win32Exception(Marshal.GetLastWin32Error()));
      byte[] destination = new byte[pPlainText.cbData2184741874];
      Marshal.Copy(pPlainText.pbData, destination, 0, pPlainText.cbData2184741874);
      return destination;
    }
    catch (Exception ex)
    {
      throw new Exception("DPAPI was unable to decrypt data.", ex);
    }
    finally
    {
      if (pPlainText.pbData != IntPtr.Zero)
        Marshal.FreeHGlobal(pPlainText.pbData);
      if (dataBlob1.pbData != IntPtr.Zero)
        Marshal.FreeHGlobal(dataBlob1.pbData);
      if (dataBlob2.pbData != IntPtr.Zero)
        Marshal.FreeHGlobal(dataBlob2.pbData);
    }
  }

  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
  internal struct DATA_BLOB
  {
    public int cbData2184741874;
    public IntPtr pbData;
  }

  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
  internal struct CRYPTPROTECT_PROMPTSTRUCT
  {
    public int cbSize24241245153;
    public int dwPromptFlags134515115;
    public IntPtr hwndApp135431514;
    public string szPrompt24363576468;
  }

  public enum KeyType3151531
  {
    UserKey = 1,
    MachineKey = 2,
  }
}
