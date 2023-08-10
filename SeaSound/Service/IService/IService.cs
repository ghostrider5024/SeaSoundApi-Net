﻿using SeaSound.Repository;
using SeaSound.Repository.Model;
using System.Linq.Expressions;

namespace SeaSound.Service.IService
{
    public interface IService<T> where T : class
    {
        #region GET
        public Task<List<T>> GetAllObjectAsync(int pageNumber = -1, int pageSize = -1);
        public Task<List<T>> SearchObjectAsync(Expression<Func<Song, bool>> predicate = null, int pageNumber = -1, int pageSize = -1);
        public Task<T?> GetObjectAsync(params object[] id);
        #endregion GET

        #region POST
        public Task<T?> AddObjectAsync(T obj);

        #endregion POST

        #region PUT
        public Task<T?> UpdateObjectAsync(T obj);
        #endregion PUT

        #region DELETE
        public Task<T?> DeleteObjectSync(params object[] id);
        #endregion DELETE
    }
}