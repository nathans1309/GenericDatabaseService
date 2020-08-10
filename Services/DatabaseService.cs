using Microsoft.EntityFrameworkCore;
using System;

namespace WebApplication3.Services {
  public interface IDatabaseService<TContext> where TContext : DbContext {
    int Command(Func<TContext, int> command);
    T Query<T>(Func<TContext, T> query);
  }

  public class DatabaseService<TContext>: IDatabaseService<TContext> where TContext : DbContext {
    private readonly DbContextFactory<TContext> _dbContextFactory;

    public DatabaseService(DbContextFactory<TContext> dbContextFactory) {
      _dbContextFactory = dbContextFactory;
    }

    public int Command(Func<TContext, int> command) {
      using(var db = _dbContextFactory.Create()) {
        command(db);
        return db.SaveChanges();
      }
    }

    public T Query<T>(Func<TContext, T> query) {
      using(var db = _dbContextFactory.Create()) {
        return query(db);
      }
    }
  }
}
