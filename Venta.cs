using System;
using System.Collections.Generic;

public class Venta
{
    public int Codigo { get; set; }
    public DateTime Fecha { get; set; }
    public string NumerodeVenta { get; set; }
    public Cliente Cliente { get; set; }
    public Vendedor Vendedor { get; set; }
    public List<VentaDetalle> ListaVentaDetalle { get; set; }
    public double SubTotal { get; set; }
    public double Impuesto { get; set; }
    public double Total { get; set; }

    public Venta(int codigo, DateTime fecha, string numeroVenta, Cliente cliente, Vendedor vendedor)
    {
        Codigo = codigo;
        Fecha = fecha;
        NumerodeVenta = numeroVenta;
        Cliente = cliente;
        Vendedor = vendedor;
        ListaVentaDetalle = new List<VentaDetalle>();
    }

    public void AgregarProducto(Producto producto)
    {
        int nuevoCodigo = ListaVentaDetalle.Count + 1;
        int cantidad = 1;

        VentaDetalle o = new VentaDetalle(nuevoCodigo, 1, producto);
        ListaVentaDetalle.Add(o);

        SubTotal += cantidad * producto.Precio;
        Impuesto += SubTotal * 0.15;
        Total += SubTotal + Impuesto;
    }
}