namespace DotnetDevPack.EntityFrameworkCore
{
  using System;
  using System.Reflection;
  using DotnetDevPack.EntityFrameworkCore.Configs;
  using Microsoft.EntityFrameworkCore;

  public static class DbContextOptionsExtensions
  {
    /// <summary>
    /// 通过DbOptions获取数据库提供程序
    /// </summary>
    /// <param name="dbConfigurationOptions">数据库配置</param>
    /// <param name="type">Startup的类型</param>
    /// <returns>返回DbOptions获取数据库提供程序（主从配置）</returns>
    public static Action<DbContextOptionsBuilder> GetDbContextOptions(this DbConfigurationOptions dbConfigurationOptions, Type type = null)
    {
      if (dbConfigurationOptions is null)
      {
        throw new ArgumentNullException(nameof(dbConfigurationOptions));
      }

      var migrationsAssembly = type.GetTypeInfo().Assembly.GetName().Name;

      // 使用不同的数据库提供程序,默认采用主库连接
      var masterConnectionConfig = dbConfigurationOptions.ConnectionString;
      if (dbConfigurationOptions.DataBaseType == DataBaseType.MySQL)
      {
        return (DbContextOptionsBuilder builder) =>
        {
          builder.UseMySql(
            masterConnectionConfig,
            ServerVersion.AutoDetect(masterConnectionConfig),
            options =>
            {
              options.MigrationsAssembly(migrationsAssembly);
              options.CommandTimeout(dbConfigurationOptions.Timeout);
              options.UseQuerySplittingBehavior(dbConfigurationOptions.QuerySplittingBehavior);
            });
        };
      }

      if (dbConfigurationOptions.DataBaseType == DataBaseType.Oracle)
      {
        return (DbContextOptionsBuilder builder) =>
        {
          builder.UseOracle(
            masterConnectionConfig,
            options =>
            {
              options.MigrationsAssembly(migrationsAssembly);
              options.CommandTimeout(dbConfigurationOptions.Timeout);
              options.UseQuerySplittingBehavior(dbConfigurationOptions.QuerySplittingBehavior);
            });
        };
      }

      if (dbConfigurationOptions.DataBaseType == DataBaseType.SqlServer)
      {
        return (DbContextOptionsBuilder builder) =>
        {
          builder.UseSqlServer(
            masterConnectionConfig,
            options =>
            {
              options.MigrationsAssembly(migrationsAssembly);
              options.CommandTimeout(dbConfigurationOptions.Timeout);
              options.UseQuerySplittingBehavior(dbConfigurationOptions.QuerySplittingBehavior);
            });
        };
      }

      if (dbConfigurationOptions.DataBaseType == DataBaseType.Sqlite)
      {
        return (DbContextOptionsBuilder builder) =>
        {
          builder.UseSqlite(
            masterConnectionConfig,
            options =>
            {
              options.MigrationsAssembly(migrationsAssembly);
              options.CommandTimeout(dbConfigurationOptions.Timeout);
              options.UseQuerySplittingBehavior(dbConfigurationOptions.QuerySplittingBehavior);
            });
        };
      }

      if (dbConfigurationOptions.DataBaseType == DataBaseType.PostgreSQL)
      {
        return (DbContextOptionsBuilder builder) =>
        {
          builder.UseNpgsql(
            masterConnectionConfig,
            options =>
            {
              options.MigrationsAssembly(migrationsAssembly);
              options.CommandTimeout(dbConfigurationOptions.Timeout);
              options.UseQuerySplittingBehavior(dbConfigurationOptions.QuerySplittingBehavior);
            });
        };
      }

      return (DbContextOptionsBuilder builder) => throw new Exception("无效数据库类型");
    }
  }
}
