using AgendaContactos.Models;
using AgendaContactos.Services;

namespace AgendaContactos.Pages;

public partial class AddContactPage : ContentPage
{
    private readonly DatabaseService _db;

    public AddContactPage(DatabaseService db)
    {
        InitializeComponent();
        _db = db;
    }

    private async void OnGuardarClicked(object sender, EventArgs e)
    {
        var contacto = new Contacto
        {
            Nombre = NombreEntry.Text,
            Apellidos = ApellidosEntry.Text,
            Telefono = TelefonoEntry.Text,
            Email = EmailEntry.Text
        };

        await _db.AddContactoAsync(contacto);
        await DisplayAlert("OK", "Contacto guardado", "Aceptar");

        //  Limpieza de campos
        NombreEntry.Text = string.Empty;
        ApellidosEntry.Text = string.Empty;
        TelefonoEntry.Text = string.Empty;
        EmailEntry.Text = string.Empty;

        //  Opcional: enfocar el primer campo
        NombreEntry.Focus();
    }
}
