namespace Itmo.ObjectOrientedProgramming.Lab2.Components.WIFIcomponents;

public interface IWiFiModuleBuilder
{
    public void Reset(string productName);

    public void VersionBuild(int version);

    public void BluetoothBuild(bool bluetooth);

    public void PciEBuild(int pcie);

    public void PowerBuild(int power);

    public void Debuild(WIFIModule wifiModule, string newName);

    public WIFIModule GetWiFIModule();
}