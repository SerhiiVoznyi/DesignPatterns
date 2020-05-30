namespace DesignPatterns.Tests.Models
{
    using System;

    public class ImmutableObject
    {
        public ImmutableObject(string name, DateTime pointInTime)
        {
            Name = name;
            PointInTime = pointInTime;
        }

        public string Name { get; protected set; }
        public DateTime PointInTime { get; protected set; }
    }
}
