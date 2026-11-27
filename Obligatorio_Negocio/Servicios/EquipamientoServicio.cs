using Obligatorio_AccesoDatos;
using Obligatorio_Entidades;

namespace Obligatorio_Negocio;


public class EquipamientoServicio : IEquipamientoServicio
{
    private IUnidadRepositorio _unidadRepositorio;
    private IStockRepositorio _stockRepositorio;
    private ITipoEquipamientoRepositorio _tipoRepositorio;
    private IDepositoRepositorio _depositoRepositorio;

    public EquipamientoServicio()
    {
        _unidadRepositorio = new UnidadArchivo(); // Cuando esté la base de datos: new UnidadDb()
        _stockRepositorio = new StockArchivo(); // Cuando esté la base de datos: new StockDb()
        _tipoRepositorio = new TipoEquipamientoArchivo(); // Cuando esté la base de datos: new TipoEquipamientoDb()
        _depositoRepositorio = new DepositoArchivo(); // Cuando esté la base de datos: new DepositoDb()
    }

    // ---------------- Unidades (equipos individualizados) ----------------

    public int RegistrarUnidad(Unidad unidad)
    {
        ValidarUnidad(unidad);

        if (_unidadRepositorio.ExisteCodigoSerie(unidad.CodigoSerie, null))
            throw new ReglaNegocioException("Ya existe una unidad con ese código de serie.");

        unidad.Estado = EstadoUnidad.Disponible; // toda unidad nueva entra disponible
        unidad.Id = _unidadRepositorio.Alta(unidad);
        return unidad.Id;
    }

    public void ModificarUnidad(Unidad unidad)
    {
        ValidarUnidad(unidad);

        if (_unidadRepositorio.ObtenerPorId(unidad.Id) == null)
            throw new EntidadNoEncontradaException("No se encontró la unidad.");

        if (_unidadRepositorio.ExisteCodigoSerie(unidad.CodigoSerie, unidad.Id))
            throw new ReglaNegocioException("Ya existe otra unidad con ese código de serie.");

        _unidadRepositorio.Modificar(unidad);
    }

    public List<Unidad> BuscarUnidades(int? tipoId, int? depositoId, EstadoUnidad? estado)
    {
        return _unidadRepositorio.Buscar(tipoId, depositoId, estado);
    }

    // Desde la pantalla de unidades solo se puede pasar a Disponible, En mantenimiento
    // o Fuera de servicio. Reservado, En preparación y Alquilado los maneja el sistema
    // cuando se trabaje con contrataciones (Entrega 4).
    public void CambiarEstado(int unidadId, EstadoUnidad nuevo)
    {
        Unidad unidad = _unidadRepositorio.ObtenerPorId(unidadId);
        if (unidad == null)
            throw new EntidadNoEncontradaException("No se encontró la unidad.");

        if (nuevo != EstadoUnidad.Disponible
            && nuevo != EstadoUnidad.EnMantenimiento
            && nuevo != EstadoUnidad.FueraDeServicio)
            throw new EstadoInvalidoException(
                "Ese estado lo asigna el sistema al trabajar con contrataciones. Elija Disponible, En mantenimiento o Fuera de servicio.");

        if (unidad.Estado == EstadoUnidad.Reservado
            || unidad.Estado == EstadoUnidad.EnPreparacion
            || unidad.Estado == EstadoUnidad.Alquilado)
            throw new EstadoInvalidoException(
                $"La unidad está {unidad.Estado} por una contratación; no se puede cambiar manualmente.");

        if (unidad.Estado == nuevo)
            throw new EstadoInvalidoException($"La unidad ya está en estado {nuevo}.");

        unidad.CambiarEstado(nuevo);
        _unidadRepositorio.CambiarEstado(unidadId, unidad.Estado);
    }

    // ---------------- Stock (elementos administrados por cantidad) ----------------

    // Fija la cantidad total que hay de un tipo en un depósito.
    // Si todavía no había stock registrado, lo crea.
    public void AjustarStock(int depositoId, int tipoId, int cantidad)
    {
        if (cantidad < 0)
            throw new ValidacionException("La cantidad no puede ser negativa.");

        Deposito deposito = _depositoRepositorio.ObtenerPorId(depositoId);
        if (deposito == null || !deposito.Activo)
            throw new EntidadNoEncontradaException("Debe seleccionar un depósito válido.");

        TipoEquipamiento tipo = _tipoRepositorio.ObtenerPorId(tipoId);
        if (tipo == null || !tipo.Activo)
            throw new EntidadNoEncontradaException("Debe seleccionar un tipo de equipamiento válido.");

        if (tipo.Individualizable)
            throw new ReglaNegocioException(
                "Ese tipo es individualizable: se registra por unidad (código de serie), no por cantidad.");

        StockDeposito stock = _stockRepositorio.Obtener(depositoId, tipoId);
        if (stock == null)
        {
            stock = new StockDeposito { Deposito = deposito, Tipo = tipo, Cantidad = cantidad };
            _stockRepositorio.Alta(stock);
        }
        else
        {
            stock.Cantidad = cantidad;
            _stockRepositorio.Modificar(stock);
        }
    }

    public List<StockDeposito> ObtenerStock()
    {
        return _stockRepositorio.ObtenerTodos();
    }

    // ---------------- Mantenimiento (Entrega 4) ----------------

    public int RegistrarMantenimiento(Mantenimiento mantenimiento)
    {
        throw new NotImplementedException("Se implementa en la Entrega 4.");
    }

    public void FinalizarMantenimiento(int mantenimientoId, DateTime fin, string trabajo, string resultado, decimal costo)
    {
        throw new NotImplementedException("Se implementa en la Entrega 4.");
    }

    // ---------------- Validaciones ----------------

    private void ValidarUnidad(Unidad unidad)
    {
        if (unidad == null)
            throw new ValidacionException("No se recibieron los datos de la unidad.");
        if (string.IsNullOrWhiteSpace(unidad.CodigoSerie))
            throw new ValidacionException("El código de serie es obligatorio.");
        if (unidad.Tipo == null)
            throw new ValidacionException("Debe seleccionar el tipo de equipamiento.");
        if (unidad.Deposito == null)
            throw new ValidacionException("Debe seleccionar el depósito.");

        TipoEquipamiento tipo = _tipoRepositorio.ObtenerPorId(unidad.Tipo.Id);
        if (tipo == null || !tipo.Activo)
            throw new EntidadNoEncontradaException("El tipo de equipamiento no existe o está dado de baja.");
        if (!tipo.Individualizable)
            throw new ReglaNegocioException(
                "Ese tipo se administra por cantidad: cárguelo desde la pantalla de Stock.");

        Deposito deposito = _depositoRepositorio.ObtenerPorId(unidad.Deposito.Id);
        if (deposito == null || !deposito.Activo)
            throw new EntidadNoEncontradaException("El depósito no existe o está dado de baja.");
    }
}
