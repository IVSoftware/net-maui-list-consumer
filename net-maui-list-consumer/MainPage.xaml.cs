using System.Collections.ObjectModel;

namespace net_maui_list_consumer
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            BindingContext = new MainPageModel();
            InitializeComponent();
        }
    }
    class MainPageModel
    {
        public ObservableCollection<Object> Fruits { get; } = new ObservableCollection<object>
        {
            new Fruit{ Name = "Apple", Color = Colors.Red },
            new Fruit{ Name = "Orange", Color = Colors.Orange },
            new Fruit{ Name = "Banana", Color = Color.FromRgb(255, 204, 0) },
        };
    }
    class Fruit
    {
        public string Name { get; set; }
        public Color Color { get; set; }
    }
}