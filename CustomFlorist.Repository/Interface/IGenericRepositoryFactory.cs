namespace CustomFlorist.Repository.Interface;

public interface IGenericRepositoryFactory
{
    IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
}