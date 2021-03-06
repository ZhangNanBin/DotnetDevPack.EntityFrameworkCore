namespace DotnetDevPack.EntityFrameworkCore.Configs
{
  public class SlaveConnectionConfig
  {
    /// <summary>
    /// 连接字符串
    /// </summary>
    public string ConnectionString { get; set; }

    /// <summary>
    /// 初始权重
    /// </summary>
    public int Weight { get; set; } = 0;

    /// <summary>
    /// 当前权重
    /// </summary>
    public int Current { get; set; } = 0;
  }
}
