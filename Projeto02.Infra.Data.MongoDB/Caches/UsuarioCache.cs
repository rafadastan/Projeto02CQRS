using MongoDB.Driver;
using Projeto02.Domain.DTOs;
using Projeto02.Domain.Interfaces.Caches;
using Projeto02.Infra.Data.MongoDB.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto02.Infra.Data.MongoDB.Caches
{
    public class UsuarioCache : IUsuarioCache
    {
        //atributo..
        private readonly MongoDbContext mongoDbContext;

        //construtor para a injeção de dependência..
        public UsuarioCache(MongoDbContext mongoDbContext)
        {
            this.mongoDbContext = mongoDbContext;
        }

        public void Create(UsuarioDTO entity)
        {
            mongoDbContext.Usuarios.InsertOne(entity);
        }

        public void Update(UsuarioDTO entity)
        {
            var filter = Builders<UsuarioDTO>.Filter.Eq(u => u.Id, entity.Id);
            mongoDbContext.Usuarios.ReplaceOne(filter, entity);
        }

        public void Delete(UsuarioDTO entity)
        {
            var filter = Builders<UsuarioDTO>.Filter.Eq(u => u.Id, entity.Id);
            mongoDbContext.Usuarios.DeleteOne(filter);
        }

        public List<UsuarioDTO> GetAll()
        {
            var filter = Builders<UsuarioDTO>.Filter.Where(u => true);
            return mongoDbContext.Usuarios.Find(filter).ToList();
        }

        public UsuarioDTO GetById(Guid id)
        {
            var filter = Builders<UsuarioDTO>.Filter.Eq(u => u.Id, id);
            return mongoDbContext.Usuarios.Find(filter).FirstOrDefault();
        }
    }
}
