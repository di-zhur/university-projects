namespace Strategy.Entity
{
    public interface IParamsEntity<T> where T : class
    {
        T Get();
    }
}