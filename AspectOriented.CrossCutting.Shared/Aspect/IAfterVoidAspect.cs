namespace AspectOriented.CrossCutting.Shared.Aspect
{
    public interface IAfterVoidAspect : IAspect
    {
        void OnAfter(object value);
    }
}