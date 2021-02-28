using FirstXamarinProject.Database;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstXamarinProject.Services
{
    public class DbService
    {
        private SQLiteAsyncConnection connection;

        public SQLiteAsyncConnection Connection { get => connection; set => connection = value; }

        public DbService(string path)
        {
            Connection = new SQLiteAsyncConnection(path);
            Connection.CreateTableAsync<Book>();
        }

        public Task<int> Add<TTable>(TTable model) where TTable : BaseModel
        {
            if (model.Id == 0)
                return Connection.InsertAsync(model);
            else
                return Connection.UpdateAsync(model);
        }

        public Task<int> Update<TTable>(TTable model) where TTable : BaseModel
        {
            if (model.Id == 0)
                return Connection.InsertAsync(model);
            else
                return Connection.UpdateAsync(model);
        }

        public Task<List<TTable>> GetList<TTable>() where TTable : BaseModel,new()
        {
            return Connection.Table<TTable>().ToListAsync();
        }

        public Task<int> Delete<TTable>(int id)
        {
            return Connection.DeleteAsync<TTable>(id);
        }

        public AsyncTableQuery<TTable> GetTable<TTable>() where TTable : BaseModel, new()
        {
            return Connection.Table<TTable>();
        }
    }
}
