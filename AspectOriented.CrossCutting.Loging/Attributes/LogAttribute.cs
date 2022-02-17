using AspectOriented.CrossCutting.Shared.Aspect;
using System.Text;

namespace AspectOriented.CrossCutting.Loging.Attributes
{
    public class LogAttribute : AspectBase, IBeforeVoidAspect, IAfterVoidAspect
    {
        public void OnBefore()
        {
            Console.WriteLine($"Loging OnBefore : Method Name: {AspectContext.Instance.MethodName} - Arguments: {string.Join(",", AspectContext.Instance.Arguments)}");
        }

        public void OnAfter(object value)
        {
            Console.WriteLine("Loging OnAfter");
        }
    }
}