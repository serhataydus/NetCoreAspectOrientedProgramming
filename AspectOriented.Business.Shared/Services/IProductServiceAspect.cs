using AspectOriented.CrossCutting.Caching.Attributes;
using AspectOriented.CrossCutting.Loging.Attributes;

namespace AspectOriented.Business.Shared.Services
{
    public interface IProductServiceAspect
    {
        [Cache(Key = "GetAll", TTL = 60)]
        [Log]
        IEnumerable<string> GetAll();
    }
}
