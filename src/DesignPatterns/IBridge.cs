namespace DesignPatterns
{
    /// <summary>
    /// Bridge is a structural design pattern that divides business logic
    /// or huge class into separate class hierarchies that can be developed independently.
    /// </summary>
    public interface IBridge<out TImplementation>
    {
        /// <summary>
        /// Gets the implementation
        /// <see>
        ///     <cref>{TImplementation}</cref>
        /// </see>
        /// for abstraction
        /// <see>
        ///     <cref>{TAbstraction}</cref>
        /// </see>
        /// </summary>
        /// <value>
        /// The implementer.
        /// </value>
        TImplementation Implementer { get; }
    }
}
