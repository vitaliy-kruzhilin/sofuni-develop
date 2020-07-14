using System.Threading.Tasks;

namespace RentVacation.Common.Services.Data
{
    public interface IDataService<in TEntity>
        where TEntity : class
    {
        Task Save(TEntity entity);
    }
}
