using AspectOriented.Business.Shared.Services;

namespace AspectOriented.Business.Services
{
    public class ProductService : IProductService
    {
        public IEnumerable<string> GetAll()
        {
            return new string[] { "Pencil", "Eraser", "Notebook" };
        }
    }
}
