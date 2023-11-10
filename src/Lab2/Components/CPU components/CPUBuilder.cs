namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class CPUBuilder : ICPUBuilder
{
    private CPU _cpu = new CPU(" ");

    public CPUBuilder(string name)
    {
        Reset(name);
    }

    public void Reset(string name)
    {
        _cpu = new CPU(name);
    }

    public void CoreFrequencyBuild(int frequency)
    {
        _cpu.SetCoreFrequency(frequency);
    }

    public void CountCoreBuild(int count)
    {
        _cpu.SetCountCore(count);
    }

    public void SocketBuild(string socket)
    {
        _cpu.SetSocket(socket);
    }

    public void GraficModificationBuild(bool modification)
    {
        _cpu.SetGraficModification(modification);
    }

    public void MemoryFrequencyBuild(int frequency)
    {
        _cpu.SetMemoryFrequency(frequency);
    }

    public void TDPBuild(int tdp)
    {
        _cpu.SetTDP(tdp);
    }

    public void PowerBuild(int power)
    {
        _cpu.SetPower(power);
    }

    public void Debuild(CPU cpu, string newName)
    {
        Reset(newName);
        CoreFrequencyBuild(cpu.CoreFrequency);
        CountCoreBuild(cpu.CountCore);
        SocketBuild(cpu.Socket);
        GraficModificationBuild(cpu.GraficModification);
        MemoryFrequencyBuild(cpu.MemoryFrequency);
        TDPBuild(cpu.TDP);
        PowerBuild(cpu.Power);
    }

    public CPU GetCPU()
    {
        CPU result = _cpu;
        Reset(" ");
        return result;
    }
}