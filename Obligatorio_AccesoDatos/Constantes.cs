namespace Obligatorio_AccesoDatos;

internal class Constantes
{
   
    internal const string CARPETA_ARCHIVOS = "C:\\Temporales\\Obligatorio.Files";

    internal const string ARCHIVO_CLIENTES = "clientes.json";
    internal const string ARCHIVO_DEPOSITOS = "depositos.json";
    internal const string ARCHIVO_CARACTERISTICAS = "caracteristicas.json";
    internal const string ARCHIVO_TIPOS_EQUIPAMIENTO = "tiposEquipamiento.json";
    internal const string ARCHIVO_UNIDADES = "unidades.json";
    internal const string ARCHIVO_STOCK = "stock.json";

   
    internal static string Ruta(string archivo)
    {
        return Path.Combine(CARPETA_ARCHIVOS, archivo);
    }
}
