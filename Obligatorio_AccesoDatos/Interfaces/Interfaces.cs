using System;
using System.Collections.Generic;
using System.Text;
using Obligatorio_Entidades;

namespace Obligatorio_AccesoDatos;

public interface IRepositorio<T> where T : class
{
    int Alta(T entidad);
    void Modificar(T entidad);
    T ObtenerPorId(int id);
    List<T> ObtenerTodos();
}

public interface IClienteRepositorio : IRepositorio<Cliente>
{
    Cliente BuscarPorDocumento(string documentoORut);
    List<Cliente> BuscarPorNombre(string nombre);
    bool ExisteDocumento(string documentoORut, int? excluirId);
    void Desactivar(int id);
}

public interface IDepositoRepositorio : IRepositorio<Deposito>
{
    bool TieneUnidadesOStock(int id);
    void Desactivar(int id);
}

public interface ITipoEquipamientoRepositorio : IRepositorio<TipoEquipamiento>
{
    List<Caracteristica> ObtenerCaracteristicas(int tipoId);
    void GuardarCaracteristicas(int tipoId, List<int> caracteristicaIds);
    bool EstaEnUso(int tipoId);
    void Desactivar(int id);
}

public interface ICatalogoRepositorio<T> : IRepositorio<T> where T : class
{
    bool ExisteNombre(string nombre, int? excluirId);
    bool EstaEnUso(int id);
    void Baja(int id);
}

public interface IUnidadRepositorio : IRepositorio<Unidad>
{
    bool ExisteCodigoSerie(string codigoSerie, int? excluirId);
    List<Unidad> Buscar(int? tipoId, int? depositoId, EstadoUnidad? estado);
    List<Unidad> ObtenerLibresEnPeriodo(int tipoId, DateTime desde, DateTime hasta);
    void CambiarEstado(int unidadId, EstadoUnidad nuevo);
}

public interface IStockRepositorio : IRepositorio<StockDeposito>
{
    StockDeposito Obtener(int depositoId, int tipoId);
    List<StockDeposito> ObtenerPorTipo(int tipoId);
}

public interface IMantenimientoRepositorio : IRepositorio<Mantenimiento>
{
    List<Mantenimiento> ObtenerPorUnidad(int unidadId);
    Mantenimiento ObtenerAbiertoPorUnidad(int unidadId);
}

public interface ITarifaRepositorio : IRepositorio<Tarifa>
{
    List<Tarifa> ObtenerPorTipo(int tipoId);
    List<Tarifa> ObtenerVigentes(int tipoId, DateTime fecha);
    void CerrarVigencia(int tarifaId, DateTime hasta);
}

public interface ISolicitudRepositorio : IRepositorio<Solicitud>
{
    List<Solicitud> Buscar(int? clienteId, EstadoSolicitud? estado);
}

public interface IContratacionRepositorio : IRepositorio<Contratacion>
{
    Contratacion ObtenerPorSolicitud(int solicitudId);
    List<Contratacion> Buscar(int? clienteId, DateTime? desde, DateTime? hasta);
    int ObtenerCantidadComprometida(int tipoId, DateTime desde, DateTime hasta);
    bool ClienteTieneContratacionesSinDevolver(int clienteId);
    int AgregarAsignacion(int itemContratacionId, Asignacion asignacion);
    void MarcarAsignacionNoVigente(int asignacionId, string motivo);
    void RegistrarEntrega(int contratacionId, Entrega entrega);
}

public interface IDevolucionRepositorio : IRepositorio<Devolucion>
{
    Devolucion ObtenerPorContratacion(int contratacionId);
    int AltaCargo(int contratacionId, int incidenciaId, CargoAdicional cargo);
    decimal ObtenerTotalCargos(int contratacionId);
}

public interface IPagoRepositorio : IRepositorio<Pago>
{
    List<Pago> ObtenerPorContratacion(int contratacionId);
    decimal ObtenerTotalPagado(int contratacionId);
}

public interface IUsuarioRepositorio : IRepositorio<Usuario>
{
    Usuario ObtenerPorNombreUsuario(string nombreUsuario);
}

public interface IReporteRepositorio
{
    List<ReporteMasAlquilado> MasAlquilado(DateTime desde, DateTime hasta);
    List<ReporteDisponibilidad> Disponibilidad(DateTime desde, DateTime hasta);
    List<ReporteCliente> ContratacionesPorCliente(DateTime desde, DateTime hasta);
    List<ReporteCuenta> CuentasPorCobrar();
    List<ReporteIncidencia> IncidenciasDevoluciones(DateTime desde, DateTime hasta);
}
