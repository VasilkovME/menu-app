namespace Domain.Contracts
{
    public interface IMapper<TSource,TTarget>
    {
        TTarget Map(TSource source);
        TSource Map(TTarget source);
    }
}
