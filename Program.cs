using System;

namespace _ProyectoFinalPOS
{
    class Program
    {
        static void Main(string[] args)
        {
            DatosdePrueba datos = new DatosdePrueba();
            string opcion = "";

            while (true)
            {
                Console.Clear();
                Console.WriteLine("= Sistema POS =");
                Console.WriteLine("");
                Console.WriteLine("01 - Lista de Productos");
                Console.WriteLine("02 - Crear Venta");
                Console.WriteLine("03 - Lista de Clientes");
                Console.WriteLine("04 - Lista de Vendedores");
                Console.WriteLine("05 - Reporte de Ventas");
                Console.WriteLine("0 - Salir");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        datos.ListarProductos();
                        break;
                    case "2":
                        datos.CrearVenta();1
                        break;
                    case "3":
                        datos.ListarClientes();
                        break;
                    case "4":
                        datos.ListarVendedores();
                        break;      
                    case "5":
                        datos.ListarVentas();
                        break;                                          
                    default:
                        break;
                }

                if (opcion == "0") {
                    break;
                }
            }
        }
    }
}
