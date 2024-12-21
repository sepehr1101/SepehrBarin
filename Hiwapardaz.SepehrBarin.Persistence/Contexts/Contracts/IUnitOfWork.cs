﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Hiwapardaz.SepehrBarin.Persistence.Contexts.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
        DatabaseFacade GetDatabase();
        EntityEntry GetEntry<T>(T entity);
        EntityState GetEntityState(object entity);
        EntityState SetEntityState(object entity, EntityState entityState);
        Task<ICollection<T>> ExecuteQuery<T>(string rawSql, params object[] parameters) where T : class;
        Task<int> ExecuteNonResultQuery(string rawQuery, params string[] parameters);
     
        TEntity FindOrThrow<TEntity>(params object?[]? keyValues) where TEntity : class;
        Task<TEntity> FindOrThrowAsync<TEntity>(params object?[]? keyValues) where TEntity : class;

    }
}