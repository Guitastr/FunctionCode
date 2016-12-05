public abstract class SingletonManager<T> where T : new()
{
    private static readonly T _instance;

    static SingletonManager()
    {
        _instance = new T();
    }

    public static T Instance
    {
        get { return _instance; }
    }
}
