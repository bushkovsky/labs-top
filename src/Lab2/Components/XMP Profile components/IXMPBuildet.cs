namespace Itmo.ObjectOrientedProgramming.Lab2.Components.XMPProfilecomponents;

public interface IXMPBuildet
{
    public void Reset(string productName);

    public void TimeBuild(int time);

    public void VoltageBuild(int voltage);

    public void FrequencyBuild(int frequency);

    public void Debuild(XMPProfile xmp, string newName);

    public XMPProfile GetXmpProfile();
}