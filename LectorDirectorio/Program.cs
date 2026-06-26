//Console.WriteLine("Hello, World!");
// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

string path;
do
{
    Console.WriteLine("Ingrese un path de directorio:");
    path = Console.ReadLine();
    if (!Directory.Exists(path))
    {
        Console.WriteLine("El directorio no existe. Por favor, intente de nuevo.");
    }
} while (!Directory.Exists(path));

string[] archivos = Directory.GetFiles(path);
string[] subdirectorios = Directory.GetDirectories(path);

if (archivos.Length > 0 || subdirectorios.Length > 0)
{
     Console.WriteLine("\n - Subdirectorios encontrados:");
    foreach (string subdir in subdirectorios)
    {
        DirectoryInfo dirInfo = new DirectoryInfo(subdir);
        Console.WriteLine($"Subdirectorio: {dirInfo.Name}");
    }
    
    Console.WriteLine("\n - Archivos encontrados:");
    for (int i = 0; i < archivos.Length; i++)
    {
        FileInfo fileInfo = new FileInfo(archivos[i]);
        Console.WriteLine($"Archivo: {fileInfo.Name}, Tamaño: {fileInfo.Length/1024} KB");
    }
}
else
{
    Console.WriteLine("No se encontraron archivos ni subdirectorios en el directorio especificado.");
}

string PathNuevo = Path.Combine(path, "reporte_archivos.csv");

if (!File.Exists(PathNuevo))
{
   var nuevo = File.Create(PathNuevo);
    nuevo.Close();
}

StreamWriter escritor = new StreamWriter(PathNuevo);

for (int i = 0; i < archivos.Length; i++)
{
    FileInfo Info = new FileInfo(archivos[i]);
    double tamanioKB = Math.Round(Info.Length / 1024.0, 2);
    escritor.WriteLine($"{Info.Name};{tamanioKB};{Info.LastWriteTime}"); 
}
escritor.Close();


//--------------------PARA LEER CSV------------------------

/*using System;
using System.IO;

Console.WriteLine("Ingrese la ruta del archivo CSV:");
string rutaCSV = Console.ReadLine();

if (File.Exists(rutaCSV))
{
    using (StreamReader lector = new StreamReader(rutaCSV))
    {
        string linea;
        Console.WriteLine("Contenido del CSV:");
        while ((linea = lector.ReadLine()) != null)
        {
            string[] datos = linea.Split(';');
            bool lineaValida = true;

            if (datos.Length < 3)
            {
                Console.WriteLine("Línea mal formada: " + linea);
                lineaValida = false;
            }

            string nombre = datos.Length > 0 ? datos[0] : "";
            double tamanio = 0;
            DateTime fecha = DateTime.MinValue;

            if (lineaValida && !double.TryParse(datos[1], out tamanio))
            {
                Console.WriteLine($"Tamaño inválido en la línea: {linea}");
                lineaValida = false;
            }
            if (lineaValida && !DateTime.TryParse(datos[2], out fecha))
            {
                Console.WriteLine($"Fecha inválida en la línea: {linea}");
                lineaValida = false;
            }

            if (lineaValida)
            {
                Console.WriteLine($"Nombre: {nombre}, Tamaño: {tamanio} KB, Fecha: {fecha}");
            }
        }
    }
}
else
{
    Console.WriteLine("No se encontró el archivo CSV.");
}
*/