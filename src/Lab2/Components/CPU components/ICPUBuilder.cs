namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public interface ICPUBuilder
{
    public void Reset(string name);

    public void CoreFrequencyBuild(int frequency);

    public void CountCoreBuild(int count);

    public void SocketBuild(string socket);

    public void GraficModificationBuild(bool modification);

    public void MemoryFrequencyBuild(int frequency);

    public void TDPBuild(int tdp);

    public void PowerBuild(int power);

    public void Debuild(CPU cpu, string newName);

    public CPU GetCPU();
}