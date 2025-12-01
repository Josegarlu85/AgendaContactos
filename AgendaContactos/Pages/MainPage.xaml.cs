namespace AgendaContactos.Pages
{
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

            switch (color)
            {
                case "Rojo":
                    BackgroundColor = Colors.Red;
                    break;
                case "Azul":
                    BackgroundColor = Colors.LightBlue;
                    break;
                case "Verde":
                    BackgroundColor = Colors.LightGreen;
                    break;
                default:
                    BackgroundColor = Colors.White;
                    break;
            }
        }
    }
}