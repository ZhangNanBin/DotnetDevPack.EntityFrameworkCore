namespace DotnetDevPack.EntityFrameworkCore.Configs
{
  using System.Collections.Generic;
  using Microsoft.EntityFrameworkCore;

  /// <summary>
  /// Db配置 主数据库连接字符串为ConnectionConfig
  /// </summary>
  public class DbConfigurationOptions
  {
    /// <summary>
    /// 连接字符串
    /// </summary>
    public string ConnectionString { get; set; }

    /// <summary>
    /// 数据库类型
    /// </summary>
    public DataBaseType DataBaseType { get; set; }

    /// <summary>
    /// 指示应如何从数据库加载查询中的相关集合。
    /// </summary>
    public QuerySplittingBehavior QuerySplittingBehavior { get; set; } = QuerySplittingBehavior.SplitQuery;

    /// <summary>
    /// 从库信息配置
    /// </summary>
    public List<SlaveConnectionConfig> SlaveConnectionConfigs { get; set; }

    /// <summary>
    /// 是否开启读写分离
    /// </summary>
    public bool CQRSEnabled { get; set; } = false;

    /// <summary>
    /// 轮询策略
    /// </summary>
    public RoundRobinPolicy RoundRobinPolicy { get; set; } = RoundRobinPolicy.RandomPolling;

    /// <summary>
    /// 超时时间
    /// </summary>
    public int Timeout { get; set; } = 120;
  }
}

