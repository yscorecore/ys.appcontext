namespace YS.AppContext
{
    public interface IAppContextValue
    {
        string ContextKey { get; }
        object GetContextValue(IAppContext context);
    }
}
