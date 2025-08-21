using System;
using System.IO;

public class OrganizadorArchivos
{
    public static void Main(string[] args)
    {
        string directorioOrigen = @"C:\Users\laloe\Documents\Organizador";

        Console.WriteLine($"Organizando archivos en: {directorioOrigen}");

        try
        {
            //  Obtener todos los archivos del directorio de origen.
            string[] archivos = Directory.GetFiles(directorioOrigen);

            //  Iterar sobre cada archivo.
            foreach (string rutaArchivo in archivos)
            {
                // Obtener la extensión del archivo (ej: .accdb, .xlsx, .html, .pdf, .pptx, .docx,).
          string extension = Path.GetExtension(rutaArchivo).ToLower();
                // Obtener el nombre del archivo sin la ruta.
                string nombreArchivo = Path.GetFileName(rutaArchivo);
                //  Definir el directorio de destino basado en la extensión.
                string directorioDestino = Path.Combine(directorioOrigen, extension.TrimStart('.'));
                //  Crear el directorio de destino si no existe.
                if (!Directory.Exists(directorioDestino))
                {
                    Directory.CreateDirectory(directorioDestino);
                }
                // 6 Mover el archivo al directorio de destino.
                string rutaDestino = Path.Combine(directorioDestino, nombreArchivo);
                File.Move(rutaArchivo, rutaDestino);
                Console.WriteLine($"Movido: {nombreArchivo} a {directorioDestino}");
            }
            Console.WriteLine("Organización completada.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}