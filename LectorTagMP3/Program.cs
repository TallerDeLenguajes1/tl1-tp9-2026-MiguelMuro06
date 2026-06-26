using LectorTagMP3;
using System.Text;

using (FileStream fs = new FileStream("De musica ligera.mp3", FileMode.Open, FileAccess.Read))
{
    Id3v1Tag datos = new Id3v1Tag();
    
    // Nos movemos 128 bytes antes del final
    fs.Seek(-128, SeekOrigin.End);

    byte[] buffer = new byte[128];

    int bytesLeidos = fs.Read(buffer, 0, 128);

    // Evaluamos los bytes reales leídos en lugar del tamaño físico del buffer
    if (bytesLeidos < 128)
    {
        Console.WriteLine("Archivo inválido o demasiado corto para contener TAG ID3v1.");
    }
    else
    {
        datos.Header = Encoding.Latin1.GetString(buffer, 0, 3).TrimEnd('\0');
        
        // Es buena idea validar si realmente empieza con "TAG" antes de seguir
        if (datos.Header != "TAG")
        {
            Console.WriteLine("El archivo no tiene una etiqueta ID3v1 válida.");
            return; // Salimos si no es un tag válido
        }

        datos.Titulo = Encoding.Latin1.GetString(buffer, 3, 30).TrimEnd('\0');
        datos.Artista = Encoding.Latin1.GetString(buffer, 33, 30).TrimEnd('\0');
        datos.Album = Encoding.Latin1.GetString(buffer, 63, 30).TrimEnd('\0');
        
        string anioTexto = Encoding.Latin1.GetString(buffer, 93, 4).TrimEnd('\0');
        if (int.TryParse(anioTexto, out int anio))
        {
            datos.Anio = anio;
        }
        else
        {
            datos.Anio = 0; 
        }

        datos.Comentario = Encoding.Latin1.GetString(buffer, 97, 30).TrimEnd('\0');
        
        
        // Si tu clase "datos.Genero" espera un string, podés guardar el número como texto por ahora:
        byte idGenero = buffer[127]; 
        datos.Genero = idGenero.ToString(); // O mapearlo a una lista de géneros si querés el nombre real.

        // Mostrar en consola
        Console.WriteLine("Título: " + datos.Titulo);
        Console.WriteLine("Artista: " + datos.Artista);
        Console.WriteLine("Álbum: " + datos.Album);
        Console.WriteLine("Año: " + datos.Anio);
        Console.WriteLine("ID Género: " + datos.Genero);
    }
}