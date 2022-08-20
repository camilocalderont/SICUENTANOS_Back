namespace SICUENTANOS_Back.Services
{
    public interface IGenericService where T : class
    {
         Task<IEnumerable<T>> GetAsync();

         void CreateAsync();

         void UpdateAsync();

         void DeleteAsync();
    }

}