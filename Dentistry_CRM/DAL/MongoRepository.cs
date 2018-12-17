using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dentistry_CRM.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Dentistry_CRM.DAL
{
    public class MongoRepository<TEntity> : IRepository<TEntity> where TEntity : Base , new ()
    {
        private string _collectionName;
        private readonly IMongoDataContext _dataContext;
        public string CollectionName
        {
            get => _collectionName ?? typeof(TEntity).Name;
            set => _collectionName = value;
        }
        private IMongoCollection<TEntity> Collection =>
            _dataContext.MongoDatabase.GetCollection<TEntity>(CollectionName);
        public MongoRepository(IMongoDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<TEntity>> GetAllAsync()
        {
            try
            {
                var result = await Collection.FindAsync<TEntity>(new BsonDocument());
                return await result.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                var result = await Collection.FindAsync<TEntity>(filter);
                return await result.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<TEntity> GetAsync(Guid id)
        {
            try
            {
                var cursor = await Collection
                                .Find(x => x.Id == id)
                                .FirstOrDefaultAsync();
                return cursor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<TEntity> CreateAsync(TEntity item)
        {
            try
            {
                await Collection.InsertOneAsync(item);
                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task InsertManyAsync(List<TEntity> entities)
        {
            try
            {
                await Collection.InsertManyAsync(entities);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            try
            {
                var updateResult = await Collection
                    .ReplaceOneAsync<TEntity>(filter: g => g.Id == entity.Id, replacement: entity);
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<TEntity> DeleteAsync(Guid id)
        {
            try
            {
                DeleteResult actionResult = await Collection.DeleteOneAsync(Builders<TEntity>.Filter.Eq("Id", id));
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task DeleteAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            await Collection.DeleteManyAsync(predicate);
        }
        public async Task<long> CountDocumentsAsync()
        {
            var res = await Collection.CountDocumentsAsync(FilterDefinition<TEntity>.Empty);
            return res;
        }
    }
}
