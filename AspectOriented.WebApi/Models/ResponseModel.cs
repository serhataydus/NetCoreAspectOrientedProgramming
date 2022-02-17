namespace AspectOriented.WebApi.Models
{
    public class ResponseModel<T>
    {
        public T Data { get; private set; }
        public long ResponseTime { get; private set; }

        public ResponseModel(T data, long responseTime)
        {
            Data = data;
            ResponseTime = responseTime;
        }
    }
}
