Looking at your repo, you're making a custom view in one project and you want to consume that view in a second project that holds a reference to it. First, let's look at an example class that will consume the custom view:

```
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
```

And we want to use our external `DisplayList` component to display it in some customized way:

[![imported custom list view][1]][1]

___

So in a project we'll call `IVSoftware.Maui.Demo.Components`, the custom view might be defined like this:

**CS**

```
namespace IVSoftware.Maui.Demo.Components;

public partial class DisplayList : ListView
{
	public DisplayList() => InitializeComponent();
}
```

**Xaml**

```
<?xml version="1.0" encoding="utf-8" ?>
<ListView xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="IVSoftware.Maui.Demo.Components.DisplayList">
    
        <ListView.ItemTemplate>
            <DataTemplate>
                <ViewCell>
                    <StackLayout>
                        <Frame 
                            HeightRequest="80"
                            CornerRadius="20"
                            BackgroundColor="{Binding Color}">
                            <Label 
                                Text="{Binding Name}" 
                                TextColor="White" 
                                FontSize="Small"
                                VerticalTextAlignment="Center"/>
                        </Frame>
                    </StackLayout>
                </ViewCell>
            </DataTemplate>
        </ListView.ItemTemplate>

</ListView>
```
___

And the "trick" to using the `DisplayList` from the external project is to qualify the assembly in the `xmlns` as shown here:

**Xaml in the main project**

```
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:ivs="clr-namespace:IVSoftware.Maui.Demo.Components;assembly=IVSoftware.Maui.Demo.Components"
             x:Class="net_maui_list_consumer.MainPage">

    <Grid>
        <ivs:DisplayList
            ItemsSource="{Binding Fruits}"
            RowHeight="80"
        />
    </Grid>

</ContentPage>
```


  [1]: https://i.stack.imgur.com/mmeaN.png