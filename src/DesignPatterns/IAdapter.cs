namespace DesignPatterns
{
    /// <summary>
    /// Adapter is a structural [Design Pattern], which allows incompatible objects to collaborate.
    /// The Adapter acts as a wrapper between two objects.
    /// It catches calls for one object and transforms them to format and interface recognizable by the second object.
    /// </summary>
    /// <typeparam name="TSource">The type of the source.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IAdapter<in TSource, out TResult>
    {
        TResult Adapt(TSource source);
    }
}
