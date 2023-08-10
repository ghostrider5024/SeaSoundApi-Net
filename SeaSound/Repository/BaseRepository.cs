using SeaSound.Data;

namespace SeaSound.Repository
{
    public class BaseRepository<T> where T : class
    {
        protected readonly DataContext _context;
        protected BaseRepository()
        {
            _context = new DataContext();
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            try
            {
                return _context.Set<T>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting entity: {ex.Message}", ex);
            }
        }

        public async Task<T?> GetByIdAsync(params object[] Id)
        {
            try
            {
                var entity = await _context.Set<T>().FindAsync(Id);
                return entity;
            }
            catch
            {
                return null;
            }
        }

        public async Task<T> AddAsync(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding entity: {ex.Message}", ex);
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating entity: {ex.Message}", ex);
            }
        }
    }
}
