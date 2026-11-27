using Obligatorio_AccesoDatos;
using Obligatorio_Entidades;

namespace Obligatorio_Negocio;


public class DepositoServicio : IDepositoServicio
{
    private IDepositoRepositorio _repositorio;

    public DepositoServicio()
    {
        _repositorio = new DepositoArchivo(); 
    }

    public int Alta(Deposito deposito)
    {
        Validar(deposito);
        deposito.Id = _repositorio.Alta(deposito);
        return deposito.Id;
    }

    public void Modificar(Deposito deposito)
    {
        Validar(deposito);
        if (_repositorio.ObtenerPorId(deposito.Id) == null)
            throw new EntidadNoEncontradaException("No se encontró el depósito.");
        _repositorio.Modificar(deposito);
    }

    
    public void Baja(int id)
    {
        if (_repositorio.ObtenerPorId(id) == null)
            throw new EntidadNoEncontradaException("No se encontró el depósito.");

        if (_repositorio.TieneUnidadesOStock(id))
            throw new ReglaNegocioException(
                "No se puede dar de baja: el depósito tiene unidades o stock. Muévalos a otro depósito primero.");

        _repositorio.Desactivar(id);
    }

    public List<Deposito> ObtenerTodos()
    {
        return _repositorio.ObtenerTodos();
    }

    private void Validar(Deposito deposito)
    {
        if (deposito == null)
            throw new ValidacionException("No se recibieron los datos del depósito.");
        if (string.IsNullOrWhiteSpace(deposito.Nombre))
            throw new ValidacionException("El nombre del depósito es obligatorio.");
        if (string.IsNullOrWhiteSpace(deposito.Direccion))
            throw new ValidacionException("La dirección del depósito es obligatoria.");
    }
}
