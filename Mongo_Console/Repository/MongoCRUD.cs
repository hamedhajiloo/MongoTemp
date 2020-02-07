using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mongo_Console.Repository
{
    public class MongoCRUD
    {
        private IMongoDatabase db;

        public MongoCRUD(string database)
        {
            var client = new MongoClient();
            db = client.GetDatabase(database);
        }

        public async Task AddAsync<T>(string table,T record)
        {
            var collection = db.GetCollection<T>(table);
            await collection.InsertOneAsync(record);
        }

        public async Task<List<T>> GetAllAsync<T>(string table)
        {
            var collection = db.GetCollection<T>(table);
            return await collection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<T> GetAsync<T,Key>(string table,Key id)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("id", id);
            return await collection.Find(filter).FirstAsync();
        }

        [Obsolete]
        public async Task UpdateAsync<T>(string table,Guid id,T record)
        {
            var collection = db.GetCollection<T>(table);
           var result= await collection.ReplaceOneAsync(
                new BsonDocument("_id",id),
                record,
                new UpdateOptions {IsUpsert=true });
        }

      
        public  void UpdateByNameAsync<T>(string table, string name, T record)
        {
            var collection = db.GetCollection<T>(table);
            var result =  collection.ReplaceOne(
                 new BsonDocument("Name", name),
                 record,
                 new UpdateOptions { IsUpsert = true });
        }
    }
}
