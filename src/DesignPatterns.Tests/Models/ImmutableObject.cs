using System;

namespace DesignPatterns.Tests.Models;

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
