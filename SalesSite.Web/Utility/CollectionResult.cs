namespace SalesSite.Web.Utility
{
    public class CollectionResult<T>
    {
        public string message { get; set; }
        public bool isSuccess { get; set; }
        public T result { get; set; }

    }

    public class Result
    {
        public int id { get; set; }
        public string name { get; set; }
        public double unitValue { get; set; }
    }

}
