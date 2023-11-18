namespace Itmo.ObjectOrientedProgramming.Lab2.Components.WIFIcomponents;

public class WiFiModuleBuilder : IWiFiModuleBuilder
{
    private WIFIModule _wifiModule = new WIFIModule(" ");

    public WiFiModuleBuilder(string productName)
    {
        Reset(productName);
    }

    public void Reset(string productName)
    {
        _wifiModule = new WIFIModule(productName);
    }

    public void VersionBuild(int version)
    {
        _wifiModule.SetVersion(version);
    }

    public void BluetoothBuild(bool bluetooth)
    {
        _wifiModule.SetBluetooth(bluetooth);
    }

    public void PciEBuild(int pcie)
    {
        _wifiModule.SetPCIE(pcie);
    }

    public void PowerBuild(int power)
    {
        _wifiModule.SetPower(power);
    }

    public void Debuild(WIFIModule wifiModule, string newName)
    {
        Reset(newName);
        VersionBuild(wifiModule.Version);
        BluetoothBuild(wifiModule.Bluetooth);
        PciEBuild(wifiModule.PCIE);
        PowerBuild(wifiModule.Power);
    }

    public WIFIModule GetWiFIModule()
    {
        WIFIModule result = _wifiModule;
        Reset(" ");
        return result;
    }
}