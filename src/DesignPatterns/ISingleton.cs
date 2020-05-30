namespace DesignPatterns
{
    /// <summary>
    /// The interface for implementation [Singleton] Design pattern.
    /// It ensures that only one object of its kind exists and provides a single point of access to it for any other code.
    /// </summary>
    /// <typeparam name="TThis">The type of this.</typeparam>
    public interface ISingleton<out TThis>
    {
        /// <summary>
        /// Gets the instance of type.
        /// </summary>
        TThis GetInstance();
    }

    /// <summary>
    /// The base implementation of [Singleton] Design pattern.
    /// </summary>
    /// <typeparam name="TThis">The type of the this.</typeparam>
    /// <seealso cref="DesignPatterns.ISingleton{TThis}" />
    public abstract class SingletonBase<TThis> : ISingleton<TThis> where TThis : new()
    {
        private static readonly TThis Instance = new TThis();
        public TThis GetInstance() => Instance;
    }
}
