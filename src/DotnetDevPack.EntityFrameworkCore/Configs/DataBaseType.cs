namespace DotnetDevPack.EntityFrameworkCore.Configs
{
  using System.ComponentModel;

  /// <summary>
  /// 数据库类型
  /// </summary>
  public enum DataBaseType
  {
    /// <summary>
    /// MySQL数据库
    /// </summary>
    [Description("MySQL数据库")]
    MySQL = 0,

    /// <summary>
    /// SqlServer数据库
    /// </summary>
    [Description("SqlServer数据库")]
    SqlServer = 1,

    /// <summary>
    /// Sqlite数据库
    /// </summary>
    [Description("Sqlite数据库")]
    Sqlite = 2,

    /// <summary>
    /// Oracle数据库
    /// </summary>
    [Description("Oracle数据库")]
    Oracle = 3,

    /// <summary>
    /// PostgreSQL数据库
    /// </summary>
    [Description("PostgreSQL数据库")]
    PostgreSQL = 4
  }
}
