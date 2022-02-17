using AspectOriented.Business.Shared.Services;

namespace AspectOriented.Business.Services
{
    public class ProductServiceAspect : IProductServiceAspect
    {
        public IEnumerable<string> GetAll()
        {
            return new string[] { "Pencil", "Eraser", "Notebook" };
        }
    }
}
