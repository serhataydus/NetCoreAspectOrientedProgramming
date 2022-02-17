namespace AspectOriented.CrossCutting.Shared.Aspect
{
    public interface IAfterAspect : IAspect
    {
        object OnAfter(object value);
    }
}