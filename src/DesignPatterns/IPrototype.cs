namespace DesignPatterns
{
    /// <summary>
    /// Specify the kinds of objects to create using a prototypical instance, and create new objects by copying this prototype.
    /// Co-opt one instance of a class for use as a breeder of all future instances.
    /// The [new] operator considered harmful.
    /// </summary>
    /// <typeparam name="TThis">The type of this object.</typeparam>
    public interface IPrototype<out TThis>
    {
        TThis Clone();
    }
}
