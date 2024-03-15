namespace ASP.NET_Core_Web_API.DAL
{
    public interface IRepository<T> where T : class
    {
       
        List<T> GetAll();
        T GetSingleEntityByID(int ID);
        T GetSingleEntity(T entity);
        List<T> Add(T entity);
        List<T> UpdateEntity(T entity);
        List<T> DeleteEntityByID(int ID);
        List<T> DeleteEntity(T entity);

    }
}
