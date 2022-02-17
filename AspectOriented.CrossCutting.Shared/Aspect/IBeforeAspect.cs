namespace AspectOriented.CrossCutting.Shared.Aspect
{
    public interface IBeforeAspect : IAspect
    {
        object OnBefore();
    }
}