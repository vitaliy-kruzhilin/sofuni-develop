using System.Threading.Tasks;

namespace RentVacation.Dealers.Services
{
    public interface IDataService<in TEntity>where TEntity : class
    {
        Task Save(TEntity entity);
    }
}
