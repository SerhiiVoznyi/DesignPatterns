namespace DesignPatterns.Concurrent
{
    using System.Threading.Tasks;

    /// <summary>
    /// Adapter is a structural [Design Pattern], which allows incompatible objects to collaborate.
    /// The Adapter acts as a wrapper between two objects.
    /// It catches calls for one object and transforms them to format and interface recognizable by the second object.
    /// </summary>
    /// <typeparam name="TSource">The type of the source.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IAdapter<in TSource, TResult>
    {
        /// <summary>
        /// Adapts one type to another asynchronously.
        /// </summary>
        /// <param name="source">The source.</param>
        Task<TResult> AdaptAsync(TSource source);
    }
}
