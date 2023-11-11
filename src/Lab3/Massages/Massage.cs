namespace Itmo.ObjectOrientedProgramming.Lab3.Massages;

public record Massage
{
    public Massage(string title, string body, int relevanceLevel)
    {
        Title = title;
        Body = body;
        RelevanceLevel = relevanceLevel;
    }

    public string Title { get; }
    public string Body { get; }
    public int RelevanceLevel { get; }
}