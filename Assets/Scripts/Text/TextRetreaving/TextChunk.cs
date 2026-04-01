public class TextChunk
{
    TextManager manager;

    public string Key { get; }
    public string Value { get; }
    string next;

    public TextChunk? Next { get => manager.Retrieve(next); }

    public TextChunk(TextManager manager, string key, string value, string next)
    {
        this.manager = manager;
        Key = key;
        Value = value;
        this.next = next;
    }
    
}