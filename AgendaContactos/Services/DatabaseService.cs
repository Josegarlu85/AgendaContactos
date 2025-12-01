using SQLite;
using AgendaContactos.Models;


namespace AgendaContactos.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _db;

        public DatabaseService(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<Contacto>().Wait();
        }

        public Task<List<Contacto>> GetContactosAsync()
        {
            return _db.Table<Contacto>().ToListAsync();
        }

        public Task<int> AddContactoAsync(Contacto contacto)
        {
            return _db.InsertAsync(contacto);
        }

        public Task<int> UpdateContactoAsync(Contacto contacto)
        {
            return _db.UpdateAsync(contacto);
        }

        public Task<int> DeleteContactoAsync(Contacto contacto)
        {
            return _db.DeleteAsync(contacto);
        }
    }
}
