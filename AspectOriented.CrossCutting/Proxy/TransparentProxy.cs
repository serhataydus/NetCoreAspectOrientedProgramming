using AspectOriented.CrossCutting.Shared.Aspect;
using System.Reflection;

namespace AspectOriented.CrossCutting.Proxy
{
    public class TransparentProxy<T> : DispatchProxy
    {
        private T _decorated;

        protected override object? Invoke(MethodInfo? targetMethod, object?[]? args)
        {
            Type? realType = typeof(T);
            MethodInfo? mInfo = realType.GetMethod(targetMethod.Name);
            object[]? aspects = mInfo.GetCustomAttributes(typeof(IAspect), true);
            AspectContext.Instance.MethodName = targetMethod.Name;
            AspectContext.Instance.Arguments = args;

            object response = null;
            CheckBeforeAspect(response, aspects);

            object? result = null;
            if (response != null)
            {
                return response;
            }
            else
            {
                result = targetMethod.Invoke(_decorated, args);
            }

            CheckAfterAspect(result, aspects);

            return result;
        }

        public static T Create(T decorated)
        {
            T? proxy = Create<T, TransparentProxy<T>>();
            (proxy as TransparentProxy<T>).SetParameters(decorated);

            return proxy;
        }

        private void SetParameters(T decorated)
        {
            if (decorated == null)
            {
                throw new ArgumentNullException(nameof(decorated));
            }
            _decorated = decorated;
        }


        private void CheckBeforeAspect(object response, object[] aspects)
        {
            foreach (IAspect loopAttribute in aspects)
            {
                if (loopAttribute is IBeforeVoidAspect)
                {
                    ((IBeforeVoidAspect)loopAttribute).OnBefore();
                }
                else if (loopAttribute is IBeforeAspect)
                {
                    response = ((IBeforeAspect)loopAttribute).OnBefore();
                }
            }
        }

        private void CheckAfterAspect(object result, object[] aspects)
        {
            foreach (IAspect loopAttribute in aspects)
            {
                if (loopAttribute is IAfterVoidAspect)
                {
                    ((IAfterVoidAspect)loopAttribute).OnAfter(result);
                }
            }
        }
    }
}
