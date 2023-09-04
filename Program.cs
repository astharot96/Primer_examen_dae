using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Libro> libros = new List<Libro>();

        while (true)
        {
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Calcular costo de llamada telefónica internacional");
            Console.WriteLine("2. Gestionar libros en la biblioteca");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    CalcularCostoLlamada();
                    break;
                case "2":
                    GestionarLibros(libros);
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }

    static void CalcularCostoLlamada()
    {
        // Solicitar al usuario que ingrese la clave de la zona y el número de minutos
        Console.Write("Ingrese la clave de la zona: ");
        int claveZona = int.Parse(Console.ReadLine());

        Console.Write("Ingrese el número de minutos: ");
        int minutos = int.Parse(Console.ReadLine());


        double costoPorMinuto;


        switch (claveZona)
        {
            case 12:
                costoPorMinuto = 2;
                break;
            case 15:
                costoPorMinuto = 2.2;
                break;
            case 18:
                costoPorMinuto = 4.5;
                break;
            case 19:
                costoPorMinuto = 3.5;
                break;
            case 23:
                costoPorMinuto = 6;
                break;

            default:
                Console.WriteLine("La clave de zona ingresada no es válida.");
                Console.ReadKey();
                return;
        }

        double costoTotal = costoPorMinuto * minutos;

        Console.WriteLine($"El costo de la llamada es: {costoTotal:C}");
        Console.ReadKey();
    }

    static void GestionarLibros(List<Libro> libros)
    {
        while (true)
        {
            Console.WriteLine("\nMenú de gestión de libros:");
            Console.WriteLine("1. Agregar libro");
            Console.WriteLine("2. Mostrar listado de libros");
            Console.WriteLine("3. Buscar libro por código");
            Console.WriteLine("4. Editar información de un libro");
            Console.WriteLine("5. Regresar al menú principal");
            Console.Write("Seleccione una opción: ");

            string opcionLibros = Console.ReadLine();

            switch (opcionLibros)
            {
                case "1":
                    AgregarLibro(libros);
                    break;
                case "2":
                    MostrarListadoLibros(libros);
                    break;
                case "3":
                    BuscarLibroPorCodigo(libros);
                    break;
                case "4":
                    EditarLibroPorCodigo(libros);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }

    static void AgregarLibro(List<Libro> libros)
    {
        Console.Write("Ingrese el código del libro: ");
        string codigo = Console.ReadLine();
        Console.Write("Ingrese el título del libro: ");
        string titulo = Console.ReadLine();
        Console.Write("Ingrese el ISBN del libro: ");
        string isbn = Console.ReadLine();
        Console.Write("Ingrese la edición del libro: ");
        string edicion = Console.ReadLine();
        Console.Write("Ingrese el autor del libro: ");
        string autor = Console.ReadLine();

        libros.Add(new Libro(codigo, titulo, isbn, edicion, autor));
        Console.WriteLine("Libro agregado con éxito.");
    }

    static void MostrarListadoLibros(List<Libro> libros)
    {
        if (libros.Count == 0)
        {
            Console.WriteLine("No hay libros en la biblioteca.");
        }
        else
        {
            Console.WriteLine("\nListado de libros:");
            foreach (Libro libro in libros)
            {
                Console.WriteLine("\n" + libro);
            }
        }
    }

    static void BuscarLibroPorCodigo(List<Libro> libros)
    {
        Console.Write("Ingrese el código del libro a buscar: ");
        string codigoBusqueda = Console.ReadLine();

        Libro libroEncontrado = libros.Find(libro => libro.Codigo == codigoBusqueda);

        if (libroEncontrado != null)
        {
            Console.WriteLine("\nLibro encontrado:");
            Console.WriteLine(libroEncontrado);
        }
        else
        {
            Console.WriteLine("Libro no encontrado.");
        }
    }

    static void EditarLibroPorCodigo(List<Libro> libros)
    {
        Console.Write("Ingrese el código del libro a editar: ");
        string codigoEdicion = Console.ReadLine();

        Libro libroExistente = libros.Find(libro => libro.Codigo == codigoEdicion);

        if (libroExistente != null)
        {
            Console.WriteLine("Editar libro:");
            Console.WriteLine(libroExistente);

            Console.Write("Nuevo título (deje en blanco para mantener el actual): ");
            string nuevoTitulo = Console.ReadLine();
            Console.Write("Nuevo ISBN (deje en blanco para mantener el actual): ");
            string nuevoISBN = Console.ReadLine();
            Console.Write("Nueva edición (deje en blanco para mantener el actual): ");
            string nuevaEdicion = Console.ReadLine();
            Console.Write("Nuevo autor (deje en blanco para mantener el actual): ");
            string nuevoAutor = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(nuevoTitulo))
            {
                libroExistente.Titulo = nuevoTitulo;
            }
            if (!string.IsNullOrWhiteSpace(nuevoISBN))
            {
                libroExistente.ISBN = nuevoISBN;
            }
            if (!string.IsNullOrWhiteSpace(nuevaEdicion))
            {
                libroExistente.Edicion = nuevaEdicion;
            }
            if (!string.IsNullOrWhiteSpace(nuevoAutor))
            {
                libroExistente.Autor = nuevoAutor;
            }

            Console.WriteLine("Libro editado con éxito.");
            
        }
        else
        {
            Console.WriteLine("Libro no encontrado.");
        }
    }
}

class Libro
{
    public string Codigo { get; set; }
    public string Titulo { get; set; }
    public string ISBN { get; set; }
    public string Edicion { get; set; }
    public string Autor { get; set; }

    public Libro(string codigo, string titulo, string isbn, string edicion, string autor)
    {
        Codigo = codigo;
        Titulo = titulo;
        ISBN = isbn;
        Edicion = edicion;
        Autor = autor;
    }

    public override string ToString()
    {
        return $"Código: {Codigo}\nTítulo: {Titulo}\nISBN: {ISBN}\nEdición: {Edicion}\nAutor: {Autor}";
    }
}