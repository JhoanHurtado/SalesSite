using SalesSite.Web.Utility;

namespace SalesSite.Web.Interface
{
    public interface IConsumeApi<T> where T : class
    {
        CollectionResult<T> PostApi(T t);
        CollectionResult<List<T>> GetApi(string parameters = "");
        CollectionResult<T> PutApi(T t);
        CollectionResult<T> DeleteApi(int id);
    }
}
