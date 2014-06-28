namespace OefeningenLogo.UI
{
    public class ListviewKeyValuePair<T>
    {
        public string Key { get; private set; }
        public T Value { get; private set; }

        public ListviewKeyValuePair(string key, T value)
        {
            Key = key;
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}