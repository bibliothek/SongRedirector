public class Link {
    public string DisplayName {get;}

    public string Uri {get;}

    public int Probability {get;}

    public Link(string displayName, string uri, int probability = 1)
    {
        DisplayName = displayName;
        Uri = uri;
        Probability = probability;
    }
}