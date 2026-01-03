
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Play.Common.Entities;
using System.Data;
using System.Linq.Expressions;

namespace Play.Common.Repositories
{
    public class MongoRepository<T> : IRepository<T> where T:IEntity
    {
        private readonly IConfiguration _config;
        //collection is similar to table in sql server
        private readonly IMongoCollection<T> dbcollections;
        private readonly FilterDefinitionBuilder<T> filterBuilder = Builders<T>.Filter;

        public MongoRepository(IMongoDatabase database,string collectionName)
        {
            dbcollections = database.GetCollection<T>(collectionName);
        }
        public async Task<IReadOnlyCollection<T>> GetAllAsync()
        {
            return await dbcollections.Find(filterBuilder.Empty).ToListAsync();
        }
        public async Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            return await dbcollections.Find(filter).ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            FilterDefinition<T> filter = filterBuilder.Eq(x => x.Id, id);
            return await dbcollections.Find(filter).FirstOrDefaultAsync();
        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await dbcollections.Find(filter).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            await dbcollections.InsertOneAsync(entity);

        }
        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            FilterDefinition<T> filter = filterBuilder.Eq(x => x.Id, entity.Id);
            await dbcollections.ReplaceOneAsync(filter, entity);
        }
        public async Task RemoveAsync(Guid id)
        {
            FilterDefinition<T> filter = filterBuilder.Eq(x => x.Id, id);
            await dbcollections.DeleteOneAsync(filter);
        }

        

        
    }
}
