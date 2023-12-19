using Api.Entities;
using Api.Repository.Abstract;
using Microsoft.EntityFrameworkCore.ChangeTracking;
namespace Api.UnitOfWork.Abstract;

public interface IUnitOfWork
{
    IRepository<UserEntity> Users { get; }
    IRepository<ImageEntity> Images { get; }

    Task<int> SaveChangesAsync();
}