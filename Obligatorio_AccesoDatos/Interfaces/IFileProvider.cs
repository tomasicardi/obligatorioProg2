namespace Obligatorio_AccesoDatos;


internal interface IFileProvider
{
    List<T> LeerRegistros<T>(string rutaArchivo);

    void GuardarRegistros<T>(string rutaArchivo, List<T> registros);
}
