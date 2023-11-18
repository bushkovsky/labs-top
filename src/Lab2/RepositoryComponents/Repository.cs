using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.RepositoryComponents;

public class Repository<T> : IRepository<T>
    where T : IComponent
{
    private readonly IList<T> _components;

    public Repository()
    {
        _components = new List<T>();
    }

    public void Add(T component)
    {
        _components.Add(component);
    }
}
