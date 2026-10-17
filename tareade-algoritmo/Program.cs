public class Program
{
    public static void Main(string[] args)
    {
        GastoRepositorio repositorio = new GastoRepositorio();

        string opcion;

        do
        {
            opcion = LeerOpcionMenu();

            switch (opcion)
            {
                case "1":
                    RegistrarGasto(repositorio);
                    break;

                case "2":
                    ListarGastos(repositorio);
                    break;

                case "3":
                    Console.WriteLine("Saliendo...");
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
        while (opcion != "3");
    }

    private static string LeerOpcionMenu()
    {
        Console.WriteLine();
        Console.WriteLine("=== REGISTRO DE GASTOS ===");
        Console.WriteLine("1. Registrar gasto");
        Console.WriteLine("2. Listar gastos");
        Console.WriteLine("3. Salir");
        Console.Write("Elige una opción: ");

        return Console.ReadLine() ?? "";
    }

    private static void RegistrarGasto(GastoRepositorio repositorio)
    {
        Console.Write("Descripción: ");
        string descripcion = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(descripcion))
        {
            Console.WriteLine("La descripción no puede estar vacía.");
            return;
        }

        Console.Write("Monto: ");

        if (!decimal.TryParse(Console.ReadLine(), out decimal monto)
            || monto <= 0)
        {
            Console.WriteLine("Datos inválidos.");
            return;
        }

        Console.Write("Categoría: ");
        string categoria = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(categoria))
        {
            Console.WriteLine("La categoría no puede estar vacía.");
            return;
        }

        Gasto gasto = new Gasto
        {
            Descripcion = descripcion.Trim(),
            Monto = monto,
            Categoria = categoria.Trim()
        };

        repositorio.Insertar(gasto);

        Console.WriteLine("Gasto registrado.");
    }

    private static void ListarGastos(GastoRepositorio repositorio)
    {
        List<Gasto> lista = repositorio.ListarTodos();

        if (lista.Count == 0)
        {
            Console.WriteLine("No hay gastos registrados.");
            return;
        }

        decimal totalGastado = 0;

        for (int i = 0; i < lista.Count; i++)
        {
            Console.WriteLine(lista[i].ToString());
            totalGastado = totalGastado + lista[i].Monto;
        }

        Console.WriteLine($"TOTAL GASTADO: Q {totalGastado:N2}");
    }
}