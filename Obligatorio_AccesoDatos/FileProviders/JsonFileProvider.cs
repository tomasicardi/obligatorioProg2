using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Obligatorio_AccesoDatos;

internal class JsonFileProvider : IFileProvider
{
  
    private JsonSerializerOptions _opciones = new JsonSerializerOptions
    {
        WriteIndented = true,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        Converters = { new JsonStringEnumConverter() }
    };

    public List<T> LeerRegistros<T>(string rutaArchivo)
    {
        if (!File.Exists(rutaArchivo))
            return new List<T>();

        string json = File.ReadAllText(rutaArchivo);
        return JsonSerializer.Deserialize<List<T>>(json, _opciones) ?? new List<T>();
    }

    public void GuardarRegistros<T>(string rutaArchivo, List<T> registros)
    {
        
        Directory.CreateDirectory(Path.GetDirectoryName(rutaArchivo));

        string json = JsonSerializer.Serialize(registros, _opciones);
        File.WriteAllText(rutaArchivo, json);
    }
}
