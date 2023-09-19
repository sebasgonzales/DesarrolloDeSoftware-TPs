// See https://aka.ms/new-console-template for more information
namespace GestorDeTareasConsolaTP1
{
    class Program
    {
        static List<string> tareas = new List<string>();
        static void Main(string[] args)
        {
            while (true)
            {
                //Console.Clear();
                Console.WriteLine("Gestor de Tareas");
                Console.WriteLine("1. Agregar Tarea");
                Console.WriteLine("2. Marcar Tarea como Completada");
                Console.WriteLine("3. Listar Tareas Pendientes");
                Console.WriteLine("4. Salir");

                try
                {
                    int opcion = int.Parse(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            AgregarTarea();
                            break;
                        case 2:
                            MarcarTarea();
                            break;
                        case 3:
                            //ListarTareas();
                            break;
                        case 4:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Opción inválida, sólo números del 1 al 4");
                            break;
                    }
                }
                catch (FormatException) 
                {
                    Console.WriteLine("Error: Formato incorrecto, se esperaba un número.");

                }

            }
        }
        static void AgregarTarea()
        {
            try
            {
                Console.WriteLine("¿Cuál es la tarea a agregar?");
                string nuevaTarea = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nuevaTarea))
                {
                    tareas.Add(nuevaTarea);
                    Console.WriteLine("La tarea fue agregada con éxito");
                }
                else
                {
                    Console.WriteLine("Error: La tarea no puede ser nula o estar en blanco.");
                }
            }
            catch (FormatException) 
            {
                Console.WriteLine("Error: Formato incorrecto se esperaba un String.");
                AgregarTarea();
            }
            Thread.Sleep(1000);
            Console.Clear();
        }
        
        static void MarcarTarea()
        {
            Console.WriteLine("Lista de Tareas:");
            for (int i = 0; i < tareas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tareas[i]}");
            }
            Console.WriteLine("Selecciona el numero de la tarea completada");
            try
            {
                int numeroTarea = int.Parse(Console.ReadLine());

                if (numeroTarea >= 1 && numeroTarea <= tareas.Count)
                {
                    tareas.RemoveAt(numeroTarea - 1);
                    Console.WriteLine("Tarea marcada como completada.");
                }
                else
                {
                    Console.WriteLine("Número de tarea no válido.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Formato incorrecto, se esperaba un int.");
            }
        }
        static void ListarTareasPendientes()
        {
            Console.WriteLine("Tareas Pendientes:");
            for (int i = 0; i < tareas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tareas[i]}");
            }
        }

    }
}