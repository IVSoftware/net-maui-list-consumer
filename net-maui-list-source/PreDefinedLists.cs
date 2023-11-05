using System.Collections.ObjectModel;

namespace net_maui_list_source
{
    public class PreDefinedLists
    {
        public ObservableCollection<Fruit> Fruits { get; } = new ObservableCollection<Fruit>
        {
            new Fruit{ Name = "Apple", Color = Colors.Red },
            new Fruit{ Name = "Orange", Color = Colors.Orange },
            new Fruit{ Name = "Banana", Color = Colors.Yellow },
        };
    }
    public class Fruit
    {
        public string Name { get; set; }
        public Color Color { get; set; }
    }
}