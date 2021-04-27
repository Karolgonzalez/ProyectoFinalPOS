public class Vendedor: Persona
{
    public string CodigoVendedor { get; set; }

    public Vendedor(int codigo, string nombre, string codigoVendedor)
    {
        Codigo = codigo;
        Nombre = nombre;
        CodigoVendedor = codigoVendedor;
    }
}