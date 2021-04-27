using System;
using System.Collections.Generic;
public class DatosdePrueba
{
    public List<Producto> ListadeProductos { get; set; }
    public List<Cliente> ListadeClientes { get; set; }
    public List<Vendedor> ListadeVendedores { get; set; }
    public List<Venta> ListaVentas { get; set; }

    public DatosdePrueba()
    {
        ListadeProductos = new List<Producto>();
        cargarProductos();

        ListadeClientes = new List<Cliente>();
        cargarClientes();

        ListadeVendedores = new List<Vendedor>();
        cargarVendedores();

        ListaVentas = new List<Venta>();
    }

    private void cargarProductos()
    {
        Producto p1 = new Producto(1, "iPhone X", 300000);
        ListadeProductos.Add(p1);

        Producto p2 = new Producto(2, "Laptop Dell Latitude Inspiron", 9000);
        ListadeProductos.Add(p2);

        Producto p3 = new Producto(3, "Monitor DEll", 20000);
        ListadeProductos.Add(p3);

        Producto p4 = new Producto(4, " Mouse Xtech", 15000);
        ListadeProductos.Add(p4);

        Producto p5 = new Producto(5, "Airpods12 ", 12000);
        ListadeProductos.Add(p5);

        Producto p6 = new Producto(6, "Teclado Logitech", 2000);
        ListadeProductos.Add(p6);
    }

    private void cargarClientes()
    {
        Cliente c1 = new Cliente(1, "Dina Praxedes", "1811-1967-00127");
        ListadeClientes.Add(c1);

        Cliente c2 = new Cliente(2, "Adriana PErez ", "0501-1998-12130");
        ListadeClientes.Add(c2);

        Cliente c3 = new Cliente(3, "Cristian Bladimir", "0501-1999-09090");
        ListadeClientes.Add(c3);
    }

    private void cargarVendedores()
    {
        Vendedor v1 = new Vendedor(01, "Karol Castro", "V0001");
        ListadeVendedores.Add(v1);

        Vendedor v2 = new Vendedor(02, "Bryan Rodriguez", "V0002");
        ListadeVendedores.Add(v2);
    }

    public void ListarProductos()
    {
        Console.Clear();
        Console.WriteLine("= Lista de Productos =");
        Console.WriteLine("");
        
        foreach (var producto in ListadeProductos)
        {
            Console.WriteLine(producto.Codigo + " | " + producto.Descripcion + " | " + producto.Precio);
        }

        Console.ReadLine();
    }

    public void ListarClientes()
    {
        Console.Clear();
        Console.WriteLine("= Lista de Clientes =");
        Console.WriteLine("");
        
        foreach (var cliente in ListadeClientes)
        {
            Console.WriteLine(cliente.Codigo + " | " + cliente.Nombre + " | " + cliente.Telefono);
        }

        Console.ReadLine();
    }

    public void ListarVendedores()
    {
        Console.Clear();
        Console.WriteLine("= Lista de Vendedores =");
        Console.WriteLine("");
        
        foreach (var vendedor in ListadeVendedores)
        {
            Console.WriteLine(vendedor.Codigo + " | " + vendedor.Nombre + " | " + vendedor.CodigoVendedor);
        }

        Console.ReadLine();
    }

    public void CrearVenta()
    {
        Console.WriteLine("= Creando Venta =");
        Console.WriteLine("");

        Console.WriteLine("Ingrese el codigo del cliente: ");
        string codigoCliente = Console.ReadLine();

        Cliente cliente = ListadeClientes.Find(c => c.Codigo.ToString() == codigoCliente);        
        if (cliente == null)
        {
            Console.WriteLine("Cliente no encontrado");
            Console.ReadLine();
            return;
        } else {
            Console.WriteLine("Cliente: " + cliente.Nombre);
            Console.WriteLine("");
        }

        Console.WriteLine("Ingrese el codigo del vendedor: ");
        string codigoVendedor = Console.ReadLine();

        Vendedor vendedor = ListadeVendedores.Find(v => v.Codigo.ToString() == codigoVendedor);
        if (vendedor == null) 
        {
            Console.WriteLine("Vendedor no encontrado");
            Console.ReadLine();
            return;
        } else {
            Console.WriteLine("Vendedor: " + vendedor.Nombre);
            Console.WriteLine("");
        }

        int nuevoCodigo = ListaVentas.Count + 1;

        Venta nuevaVenta = new Venta(nuevoCodigo, DateTime.Now, "San Pedro Sula" + nuevoCodigo, cliente, vendedor);
        ListaVentas.Add(nuevaVenta);

        while(true)
        {
            Console.WriteLine("Ingrese el producto: ");
            string codigoProducto = Console.ReadLine();
            Producto producto = ListadeProductos.Find(p => p.Codigo.ToString() == codigoProducto);        
            if (producto == null)
            {
                Console.WriteLine("Producto no encontrado");
                Console.ReadLine();
            } else {
                Console.WriteLine("Producto agregado: " + producto.Descripcion + " con precio de: " + producto.Precio);
                nuevaVenta.AgregarProducto(producto);
            }

            Console.WriteLine("Desea continuar? s/n");
            string continuar = Console.ReadLine();
            if (continuar.ToLower() == "n") {
                break;
            }
        }

        Console.WriteLine("SubTotal de la venta es de: " + nuevaVenta.SubTotal);

        Console.WriteLine("Impuesto de la venta es de: " + nuevaVenta.Impuesto);

        Console.WriteLine("Total de la venta es de: " + nuevaVenta.Total);
        Console.ReadLine();
    }

    public void ListarVentas()
    {
        Console.Clear();
        Console.WriteLine("= Lista de Ventas =");
        Console.WriteLine("");  
        Console.WriteLine("= Codigo | Fecha | SubTotal | Impuesto | Total =");
        Console.WriteLine("=              Cliente | Vendedor              =");
        Console.WriteLine("");  

        foreach (var venta in ListaVentas)
        {
            Console.WriteLine(venta.Codigo + " | " + venta.Fecha + " | " + venta.SubTotal + " | " + venta.Impuesto + " | " + venta.Total);
            Console.WriteLine(venta.Cliente.Nombre + " | " + venta.Vendedor.Nombre);
            
            foreach (var detalle in venta.ListaVentaDetalle)
            {
                Console.WriteLine("     " + detalle.Producto.Descripcion + " | " + detalle.Cantidad + " | " + detalle.Precio);
            }

            Console.WriteLine();
        } 

        Console.ReadLine();
    }
}