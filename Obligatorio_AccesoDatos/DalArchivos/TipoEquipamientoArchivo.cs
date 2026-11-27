using Obligatorio_Entidades;
using Obligatorio_AccesoDatos;

namespace Obligatorio_AccesoDatos;

public class TipoEquipamientoArchivo : ITipoEquipamientoRepositorio
{
    private string _rutaArchivo = Constantes.Ruta(Constantes.ARCHIVO_TIPOS_EQUIPAMIENTO);
    private IFileProvider _fileProvider = new JsonFileProvider();

    public int Alta(TipoEquipamiento tipo)
    {
        List<TipoEquipamiento> tipos = LeerTipos();
        tipo.Id = tipos.Count == 0 ? 1 : tipos.Max(t => t.Id) + 1;
        tipo.Activo = true;
        tipo.Caracteristicas = new List<Caracteristica>(); 
        tipos.Add(tipo);
        GuardarTipos(tipos);
        return tipo.Id;
    }

    public void Modificar(TipoEquipamiento tipo)
    {
        List<TipoEquipamiento> tipos = LeerTipos();
        TipoEquipamiento existente = tipos.FirstOrDefault(t => t.Id == tipo.Id);
        if (existente != null)
        {
            existente.Nombre = tipo.Nombre;
            existente.Descripcion = tipo.Descripcion;
            existente.Individualizable = tipo.Individualizable;
            GuardarTipos(tipos);
        }
    }

    public TipoEquipamiento ObtenerPorId(int id)
    {
        return LeerTipos().FirstOrDefault(t => t.Id == id);
    }

   
    public List<TipoEquipamiento> ObtenerTodos()
    {
        return LeerTipos()
            .Where(t => t.Activo)
            .OrderBy(t => t.Nombre)
            .ToList();
    }


    public List<Caracteristica> ObtenerCaracteristicas(int tipoId)
    {
        TipoEquipamiento tipo = ObtenerPorId(tipoId);
        if (tipo == null)
            return new List<Caracteristica>();

        List<Caracteristica> todas =
            _fileProvider.LeerRegistros<Caracteristica>(Constantes.Ruta(Constantes.ARCHIVO_CARACTERISTICAS));

        return todas
            .Where(c => tipo.Caracteristicas.Any(tc => tc.Id == c.Id))
            .OrderBy(c => c.Nombre)
            .ToList();
    }


    public void GuardarCaracteristicas(int tipoId, List<int> caracteristicaIds)
    {
        List<TipoEquipamiento> tipos = LeerTipos();
        TipoEquipamiento tipo = tipos.FirstOrDefault(t => t.Id == tipoId);
        if (tipo == null)
            return;

        tipo.Caracteristicas = new List<Caracteristica>();
        foreach (int id in caracteristicaIds)
        {
            tipo.Caracteristicas.Add(new Caracteristica { Id = id });
        }
        GuardarTipos(tipos);
    }

    
    public bool EstaEnUso(int tipoId)
    {
        List<Unidad> unidades = _fileProvider.LeerRegistros<Unidad>(Constantes.Ruta(Constantes.ARCHIVO_UNIDADES));
        List<StockDeposito> stock = _fileProvider.LeerRegistros<StockDeposito>(Constantes.Ruta(Constantes.ARCHIVO_STOCK));

        return unidades.Any(u => u.Tipo.Id == tipoId) || stock.Any(s => s.Tipo.Id == tipoId);
    }

   
    public void Desactivar(int id)
    {
        List<TipoEquipamiento> tipos = LeerTipos();
        TipoEquipamiento tipo = tipos.FirstOrDefault(t => t.Id == id);
        if (tipo != null)
        {
            tipo.Activo = false;
            GuardarTipos(tipos);
        }
    }

    private List<TipoEquipamiento> LeerTipos()
    {
        return _fileProvider.LeerRegistros<TipoEquipamiento>(_rutaArchivo);
    }

    private void GuardarTipos(List<TipoEquipamiento> tipos)
    {
        _fileProvider.GuardarRegistros(_rutaArchivo, tipos);
    }
}
