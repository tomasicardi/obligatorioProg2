using Obligatorio_AccesoDatos;
using Obligatorio_Entidades;

namespace Obligatorio_Negocio;


public class TipoEquipamientoServicio : ITipoEquipamientoServicio
{
    private ITipoEquipamientoRepositorio _repositorio;

    public TipoEquipamientoServicio()
    {
        _repositorio = new TipoEquipamientoArchivo();
    }

    public int Alta(TipoEquipamiento tipo, List<int> caracteristicaIds)
    {
        Validar(tipo);
        tipo.Id = _repositorio.Alta(tipo);
        _repositorio.GuardarCaracteristicas(tipo.Id, caracteristicaIds ?? new List<int>());
        return tipo.Id;
    }

    public void Modificar(TipoEquipamiento tipo, List<int> caracteristicaIds)
    {
        Validar(tipo);

        TipoEquipamiento anterior = _repositorio.ObtenerPorId(tipo.Id);
        if (anterior == null)
            throw new EntidadNoEncontradaException("No se encontró el tipo de equipamiento.");

        
        if (anterior.Individualizable != tipo.Individualizable && _repositorio.EstaEnUso(tipo.Id))
            throw new ReglaNegocioException(
                "No se puede cambiar 'Individualizable' porque el tipo ya tiene unidades o stock cargado.");

        _repositorio.Modificar(tipo);
        _repositorio.GuardarCaracteristicas(tipo.Id, caracteristicaIds ?? new List<int>());
    }

    public void Baja(int id)
    {
        if (_repositorio.ObtenerPorId(id) == null)
            throw new EntidadNoEncontradaException("No se encontró el tipo de equipamiento.");

        if (_repositorio.EstaEnUso(id))
            throw new ReglaNegocioException("No se puede dar de baja: existen unidades o stock de este tipo.");

        _repositorio.Desactivar(id);
    }

   
    public List<TipoEquipamiento> ObtenerTodos()
    {
        List<TipoEquipamiento> tipos = _repositorio.ObtenerTodos();
        foreach (TipoEquipamiento tipo in tipos)
        {
            tipo.Caracteristicas = _repositorio.ObtenerCaracteristicas(tipo.Id);
        }
        return tipos;
    }

    private void Validar(TipoEquipamiento tipo)
    {
        if (tipo == null)
            throw new ValidacionException("No se recibieron los datos del tipo de equipamiento.");
        if (string.IsNullOrWhiteSpace(tipo.Nombre))
            throw new ValidacionException("El nombre del tipo de equipamiento es obligatorio.");
    }
}
