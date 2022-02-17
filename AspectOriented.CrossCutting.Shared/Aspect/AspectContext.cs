namespace AspectOriented.CrossCutting.Shared.Aspect
{
    public class AspectContext
    {
        private static readonly Lazy<AspectContext> _Instance = new Lazy<AspectContext>(() => new AspectContext());

        private AspectContext()
        {
        }

        public static AspectContext Instance
        {
            get
            {
                return _Instance.Value;
            }
        }

        public string MethodName { get; set; }
        public object[] Arguments { get; set; }
    }
}