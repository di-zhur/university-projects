namespace Strategy.Entity
{
    public interface IParamsEntitys<out TMain, TItem> : IParamsEntity<TItem> where TMain : class where TItem : class
    {
        TMain GetMain();
    }

}