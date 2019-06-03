using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SupplementCRUDAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupplementCRUDAPI.Services
{
    public class SupplementService
    {
        private readonly IMongoCollection<Supplement> _supplement;

        public SupplementService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("SupplementDB"));
            var database = client.GetDatabase("SupplementDB");
            _supplement = database.GetCollection<Supplement>("Supplements");
        }

        public List<Supplement> Get()
        {
            return _supplement.Find(s => true).ToList();
        }

        public Supplement Get(string id)
        {
            return _supplement.Find(s => s.Id == id).FirstOrDefault();
        }

        public Supplement Create(Supplement s)
        {
            _supplement.InsertOne(s);
            return s;
        }

        public void Update(string id, Supplement s)
        {
            _supplement.ReplaceOne(su => su.Id == id, s);
        }


        public void Remove(Supplement s)
        {
            _supplement.DeleteOne(su => su.Id == s.Id);
        }

        public void Remove(string id)
        {
            _supplement.DeleteOne(su => su.Id == id);
        }

    }
}
