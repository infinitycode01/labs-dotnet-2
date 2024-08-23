using System.Linq.Expressions;
using Lab3_AspNet_EF.Data;
using Microsoft.EntityFrameworkCore;

namespace Lab3_AspNet_EF.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{

        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T objModel)
        {
            _dbSet.Add(objModel);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<T> objModel)
        {
            _dbSet.AddRange(objModel);
            _context.SaveChanges();
        }

        public T? GetId(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<T?> GetIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public T? Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.SingleOrDefault(predicate);
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.SingleOrDefaultAsync(predicate);
        }

        public IEnumerable<T> GetList(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public int Count()
        {
            return _dbSet.Count();
        }

        public async Task<int> CountAsync()
        {
            return await _dbSet.CountAsync();
        }

        public void Update(T objModel)
        {
            _dbSet.Update(objModel);
            _context.SaveChanges();
        }

        public void Remove(T objModel)
        {
            _dbSet.Remove(objModel);
            _context.SaveChanges();
        }
}