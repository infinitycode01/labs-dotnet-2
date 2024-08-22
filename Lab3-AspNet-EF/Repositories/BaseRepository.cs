using Lab3_AspNet_EF.Data;
using Microsoft.EntityFrameworkCore;

namespace Lab3_AspNet_EF.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    private readonly AppDbContext _context;
    
    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public void Add(TEntity model)
    {
        _context.Set<TEntity>().Add(model);
        _context.SaveChanges();
    }

    public void AddRange(IEnumerable<TEntity> model)
    {
        _context.Set<TEntity>().AddRange(model);
        _context.SaveChanges();
    }

    public TEntity? GetId(int id)
    {
        return _context.Set<TEntity>().Find(id);
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _context.Set<TEntity>().ToList();
    }

    public int Count()
    {
        return _context.Set<TEntity>().Count();
    }

    public void Update(TEntity objModel)
    {
        _context.Entry(objModel).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Remove(TEntity objModel)
    {
        _context.Set<TEntity>().Remove(objModel);
        _context.SaveChanges();
    }
}