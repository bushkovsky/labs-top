using Itmo.ObjectOrientedProgramming.Lab2.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.RepositoryComponents;

public interface IRepository<T>
    where T : IComponent
{
    void Add(T component);
}
