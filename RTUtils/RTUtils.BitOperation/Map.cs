namespace RTUtils.BitOperation
{
    public class Map
    {
        public string Name { get; private set; }
        public int Index { get; private set; }

        public Map(string name, int index)
        {
            Name = name;
            Index = index;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Index)}: {Index}";
        }
    }
}