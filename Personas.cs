using System;
public class Persona
{
    public int Codigo { get; set; }
    public string Nombre { get; set; }
    public string Telefono { get; set; }

    public void EnviarNotificacion()
    {
        Console.WriteLine("Correo enviado a: " + Nombre);
    }
}