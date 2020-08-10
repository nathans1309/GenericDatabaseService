using Microsoft.EntityFrameworkCore;
using System;

namespace WebApplication3.Services {
  public class DbContextFactory<TContext> where TContext : DbContext {
    private readonly DbContextOptions<TContext> _options;

    public DbContextFactory(DbContextOptions<TContext> options) {
      _options = options;
    }

    public TContext Create() => (TContext)typeof(TContext)
      .GetConstructor(new Type[] { typeof(DbContextOptions<TContext>) })
      .Invoke(new object[] { _options });
  }
}
