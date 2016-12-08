namespace MapperLibrary
{
    interface IMapper
    {
        TDestination Map<TSource, TDestination>(TSource source) where TDestination : new();
    }
}
