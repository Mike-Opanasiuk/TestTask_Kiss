using Api.Repository.Abstract;
using Api.Repository;
using Api.UnitOfWork.Abstract;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Api.Entities;
namespace Api.UnitOfWork;


public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly AppDbContext context;

    public IRepository<UserEntity> Users { get; }
    public IRepository<ImageEntity> Images { get; }

    public UnitOfWork(AppDbContext context)
    {
        this.context = context;

        Users = new Repository<UserEntity>(context);
        Images = new Repository<ImageEntity>(context);
    }

    public void Dispose()
    {
        context.Dispose();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await context.SaveChangesAsync();
    }
}
