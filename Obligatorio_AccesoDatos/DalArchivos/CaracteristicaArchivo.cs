using Obligatorio_Entidades;

namespace Obligatorio_AccesoDatos;

public class CaracteristicaArchivo : ICatalogoRepositorio<Caracteristica>
{
    private string _rutaArchivo = Constantes.Ruta(Constantes.ARCHIVO_CARACTERISTICAS);
    private IFileProvider _fileProvider = new JsonFileProvider();

    public int Alta(Caracteristica caracteristica)
    {
        List<Caracteristica> lista = LeerCaracteristicas();
        caracteristica.Id = lista.Count == 0 ? 1 : lista.Max(c => c.Id) + 1;
        lista.Add(caracteristica);
        GuardarCaracteristicas(lista);
        return caracteristica.Id;
    }

    public void Modificar(Caracteristica caracteristica)
    {
        List<Caracteristica> lista = LeerCaracteristicas();
        Caracteristica existente = lista.FirstOrDefault(c => c.Id == caracteristica.Id);
        if (existente != null)
        {
            existente.Nombre = caracteristica.Nombre;
            GuardarCaracteristicas(lista);
        }
    }

    public Caracteristica ObtenerPorId(int id)
    {
        return LeerCaracteristicas().FirstOrDefault(c => c.Id == id);
    }

    public List<Caracteristica> ObtenerTodos()
    {
        return LeerCaracteristicas().OrderBy(c => c.Nombre).ToList();
    }

    public bool ExisteNombre(string nombre, int? excluirId)
    {
        return LeerCaracteristicas()
            .Any(c => c.Nombre.ToLower() == nombre.ToLower() && c.Id != excluirId);
    }

    // Está en uso si algún tipo de equipamiento la tiene asignada.
    public bool EstaEnUso(int id)
    {
        List<TipoEquipamiento> tipos =
            _fileProvider.LeerRegistros<TipoEquipamiento>(Constantes.Ruta(Constantes.ARCHIVO_TIPOS_EQUIPAMIENTO));
        return tipos.Any(t => t.Caracteristicas.Any(c => c.Id == id));
    }

    // Baja física: solo se llama si la característica NO está en uso.
    public void Baja(int id)
    {
        List<Caracteristica> lista = LeerCaracteristicas();
        lista.RemoveAll(c => c.Id == id);
        GuardarCaracteristicas(lista);
    }

    private List<Caracteristica> LeerCaracteristicas()
    {
        return _fileProvider.LeerRegistros<Caracteristica>(_rutaArchivo);
    }

    private void GuardarCaracteristicas(List<Caracteristica> lista)
    {
        _fileProvider.GuardarRegistros(_rutaArchivo, lista);
    }
}
