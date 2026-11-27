using Obligatorio_AccesoDatos;
using Obligatorio_Entidades;

namespace Obligatorio_Negocio;


public class CaracteristicaServicio : ICatalogoServicio<Caracteristica>
{
    private ICatalogoRepositorio<Caracteristica> _repositorio;

    public CaracteristicaServicio()
    {
        _repositorio = new CaracteristicaArchivo(); 
    }

    public int Alta(Caracteristica item)
    {
        Validar(item);
        if (_repositorio.ExisteNombre(item.Nombre.Trim(), null))
            throw new ReglaNegocioException("Ya existe una característica con ese nombre.");

        item.Nombre = item.Nombre.Trim();
        item.Id = _repositorio.Alta(item);
        return item.Id;
    }

    public void Modificar(Caracteristica item)
    {
        Validar(item);
        if (_repositorio.ExisteNombre(item.Nombre.Trim(), item.Id))
            throw new ReglaNegocioException("Ya existe otra característica con ese nombre.");

        item.Nombre = item.Nombre.Trim();
        _repositorio.Modificar(item);
    }

    public void Baja(int id)
    {
        if (_repositorio.EstaEnUso(id))
            throw new ReglaNegocioException("No se puede eliminar: hay tipos de equipamiento que usan esta característica.");
        _repositorio.Baja(id);
    }

    public List<Caracteristica> ObtenerTodos()
    {
        return _repositorio.ObtenerTodos();
    }

    private void Validar(Caracteristica item)
    {
        if (item == null || string.IsNullOrWhiteSpace(item.Nombre))
            throw new ValidacionException("El nombre de la característica es obligatorio.");
    }
}
