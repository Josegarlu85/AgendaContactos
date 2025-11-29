namespace AgendaContactos.Pages;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        ColorPicker.SelectedIndexChanged += OnColorChanged;
    }

    private void OnColorChanged(object sender, EventArgs e)
    {
        var color = ColorPicker.SelectedItem?.ToString();

        BackgroundColor = color switch
        {
            "Rojo" => Colors.Red,
            "Azul" => Colors.LightBlue,
            "Verde" => Colors.LightGreen,
            _ => Colors.White
        };
    }
}
