using SQLite;

namespace AgendaContactos.Models;

public class Contacto
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Nombre { get; set; }
    public string Apellidos { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
}
