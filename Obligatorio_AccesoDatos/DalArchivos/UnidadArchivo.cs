using Obligatorio_Entidades;

namespace Obligatorio_AccesoDatos;

public class UnidadArchivo : IUnidadRepositorio
{
    private string _rutaArchivo = Constantes.Ruta(Constantes.ARCHIVO_UNIDADES);
    private IFileProvider _fileProvider = new JsonFileProvider();

    public int Alta(Unidad unidad)
    {
        List<Unidad> unidades = LeerUnidades();
        unidad.Id = unidades.Count == 0 ? 1 : unidades.Max(u => u.Id) + 1;
        unidades.Add(unidad);
        GuardarUnidades(unidades);
        return unidad.Id;
    }

    // El estado NO se cambia acá, se cambia con CambiarEstado.
    public void Modificar(Unidad unidad)
    {
        List<Unidad> unidades = LeerUnidades();
        Unidad existente = unidades.FirstOrDefault(u => u.Id == unidad.Id);
        if (existente != null)
        {
            existente.CodigoSerie = unidad.CodigoSerie;
            existente.Marca = unidad.Marca;
            existente.Modelo = unidad.Modelo;
            existente.Tipo = unidad.Tipo;
            existente.Deposito = unidad.Deposito;
            GuardarUnidades(unidades);
        }
    }

    public Unidad ObtenerPorId(int id)
    {
        return LeerUnidades().FirstOrDefault(u => u.Id == id);
    }

    public List<Unidad> ObtenerTodos()
    {
        return Buscar(null, null, null);
    }

    // Los filtros que vienen en null no se aplican.
    public List<Unidad> Buscar(int? tipoId, int? depositoId, EstadoUnidad? estado)
    {
        List<Unidad> unidades = LeerUnidades();

        if (tipoId.HasValue)
            unidades = unidades.Where(u => u.Tipo.Id == tipoId.Value).ToList();
        if (depositoId.HasValue)
            unidades = unidades.Where(u => u.Deposito.Id == depositoId.Value).ToList();
        if (estado.HasValue)
            unidades = unidades.Where(u => u.Estado == estado.Value).ToList();

        return unidades.OrderBy(u => u.Tipo.Nombre).ThenBy(u => u.CodigoSerie).ToList();
    }

    public bool ExisteCodigoSerie(string codigoSerie, int? excluirId)
    {
        return LeerUnidades()
            .Any(u => u.CodigoSerie.ToLower() == codigoSerie.ToLower() && u.Id != excluirId);
    }

    public void CambiarEstado(int unidadId, EstadoUnidad nuevo)
    {
        List<Unidad> unidades = LeerUnidades();
        Unidad unidad = unidades.FirstOrDefault(u => u.Id == unidadId);
        if (unidad != null)
        {
            unidad.CambiarEstado(nuevo);
            GuardarUnidades(unidades);
        }
    }

    // Necesita las contrataciones: se implementa en la Entrega 4.
    public List<Unidad> ObtenerLibresEnPeriodo(int tipoId, DateTime desde, DateTime hasta)
    {
        throw new NotImplementedException("Se implementa en la Entrega 4 (contrataciones).");
    }

    // ---------------- Métodos auxiliares ----------------

    // Lee las unidades y completa el tipo y el depósito con los datos actuales
    // (por si se les cambió el nombre después de crear la unidad).
    private List<Unidad> LeerUnidades()
    {
        List<Unidad> unidades = _fileProvider.LeerRegistros<Unidad>(_rutaArchivo);
        List<TipoEquipamiento> tipos =
            _fileProvider.LeerRegistros<TipoEquipamiento>(Constantes.Ruta(Constantes.ARCHIVO_TIPOS_EQUIPAMIENTO));
        List<Deposito> depositos =
            _fileProvider.LeerRegistros<Deposito>(Constantes.Ruta(Constantes.ARCHIVO_DEPOSITOS));

        foreach (Unidad unidad in unidades)
        {
            unidad.Tipo = tipos.FirstOrDefault(t => t.Id == unidad.Tipo.Id) ?? unidad.Tipo;
            unidad.Deposito = depositos.FirstOrDefault(d => d.Id == unidad.Deposito.Id) ?? unidad.Deposito;
        }
        return unidades;
    }

    private void GuardarUnidades(List<Unidad> unidades)
    {
        _fileProvider.GuardarRegistros(_rutaArchivo, unidades);
    }
}
