using AgendaContactos.Models;
using AgendaContactos.Services;

namespace AgendaContactos.Pages;

public partial class AgendaContactPage : ContentPage
{
    private readonly DatabaseService _db;

    public AgendaContactPage(DatabaseService db)
    {
        InitializeComponent();
        _db = db;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        ContactosView.ItemsSource = await _db.GetContactosAsync();
    }

    private async void OnModificarClicked(object sender, EventArgs e)
    {
        if (ContactosView.SelectedItem is not Contacto c)
            return;

        // ? Solicitar nuevos valores para todos los campos
        string nuevoNombre = await DisplayPromptAsync("Modificar", "Nuevo nombre:", initialValue: c.Nombre);
        string nuevosApellidos = await DisplayPromptAsync("Modificar", "Nuevos apellidos:", initialValue: c.Apellidos);
        string nuevoTelefono = await DisplayPromptAsync("Modificar", "Nuevo teléfono:", initialValue: c.Telefono);
        string nuevoEmail = await DisplayPromptAsync("Modificar", "Nuevo email:", initialValue: c.Email);

        // ? Validar que no se canceló
        if (nuevoNombre is null || nuevosApellidos is null || nuevoTelefono is null || nuevoEmail is null)
            return;

        // ? Actualizar el contacto
        c.Nombre = nuevoNombre;
        c.Apellidos = nuevosApellidos;
        c.Telefono = nuevoTelefono;
        c.Email = nuevoEmail;

        await _db.UpdateContactoAsync(c);
        await DisplayAlert("OK", "Contacto actualizado", "Aceptar");

        ContactosView.ItemsSource = await _db.GetContactosAsync();
    }

    private async void OnBorrarClicked(object sender, EventArgs e)
    {
        if (ContactosView.SelectedItem is not Contacto c)
            return;

        await _db.DeleteContactoAsync(c);
        ContactosView.ItemsSource = await _db.GetContactosAsync();
    }
}
