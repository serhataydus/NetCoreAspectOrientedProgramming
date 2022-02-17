using AspectOriented.CrossCutting.Shared.Aspect;

namespace AspectOriented.CrossCutting.Caching.Attributes
{
    public class CacheAttribute : AspectBase, IBeforeAspect, IAfterVoidAspect
    {
        public int TTL { get; set; }
        public string Key { get; set; }

        public object OnBefore()
        {
            Console.WriteLine("Caching OnBefore");
            return null; // Get Cache Value
        }

        public void OnAfter(object value)
        {
            //Set cache value
            Console.WriteLine("Caching OnAfter");
        }
    }
}
