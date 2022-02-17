namespace AspectOriented.CrossCutting.Shared.Aspect
{
    [AttributeUsage(AttributeTargets.All, Inherited = true)]
    public abstract class AspectBase : Attribute, IAspect
    {

    }
}