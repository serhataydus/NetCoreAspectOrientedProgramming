namespace AspectOriented.CrossCutting.Shared.Aspect
{
    public interface IBeforeVoidAspect : IAspect
    {
        void OnBefore();
    }
}