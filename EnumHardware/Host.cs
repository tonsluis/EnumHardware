// See https://msdn.microsoft.com/en-us/library/aa389273(v=vs.85).aspx for the hardware class names.


namespace EnumHardware
{
  #region Directives
  // Standard .NET Directives
  using System;
  using System.Management;
  #endregion

  /// <summary>
  /// Host object
  /// </summary>
  public class Host
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="Host"/> Class.
    /// </summary>
    public Host()
    {
    }

    /// <summary>
    /// Lists the componenents
    /// </summary>
    public void ListComponents()
    {
      GetComponent("Win32_BaseBoard", "SerialNumber");

      GetComponent("Win32_DiskDrive");

    }


    #region GetComponent
    private void GetComponent(string hwClass, string syntax = null )
    {
      ManagementObjectSearcher mob = new ManagementObjectSearcher("root\\CIMV2", $"SELECT * FROM {hwClass}");
      foreach(ManagementObject mj in mob.Get())
      {
        Console.WriteLine($"'{Convert.ToString(mj[syntax])}'");
      }
    }


    private void GetComponent(string hwClass)
    {
      ManagementObjectSearcher mob = new ManagementObjectSearcher("root\\CIMV2", $"SELECT * FROM {hwClass}");
      foreach (ManagementObject mj in mob.Get())
      {
        foreach (PropertyData prop in mj.Properties)
        {
          Console.WriteLine($"{prop.Name} - '{prop.Value}'");
        }
      }
    }
    #endregion

  }
}
