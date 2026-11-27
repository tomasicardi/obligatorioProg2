using System;
using System.Collections.Generic;
using System.Text;
using Obligatorio_Entidades;

namespace Obligatorio_Negocio;

// Inicio de sesión y permisos por rol
public interface IAutenticacionServicio
{
    Usuario IniciarSesion(string usuario, string contrasena);
    bool TienePermiso(RolUsuario rol, Funcionalidad funcionalidad);
}

// CU01 a CU04
public interface IClienteServicio
{
    int Registrar(Cliente cliente);
    Cliente ObtenerPorId(int id);
    List<Cliente> Buscar(string criterio);
    void Modificar(Cliente cliente);
    void Desactivar(int id);
}

// CU05
public interface IDepositoServicio
{
    int Alta(Deposito deposito);
    void Modificar(Deposito deposito);
    void Baja(int id);
    List<Deposito> ObtenerTodos();
}

// CU06
public interface ITipoEquipamientoServicio
{
    int Alta(TipoEquipamiento tipo, List<int> caracteristicaIds);
    void Modificar(TipoEquipamiento tipo, List<int> caracteristicaIds);
    void Baja(int id);
    List<TipoEquipamiento> ObtenerTodos();
}

// CU31 (tipos de evento, tipos de incidencia, modalidades y características)
public interface ICatalogoServicio<T> where T : class
{
    int Alta(T item);
    void Modificar(T item);
    void Baja(int id);
    List<T> ObtenerTodos();
}

// CU28
public interface ITarifaServicio
{
    int Alta(Tarifa tarifa);
    void CerrarVigencia(int tarifaId, DateTime hasta);
    List<Tarifa> ObtenerPorTipo(int tipoId);
    Tarifa ObtenerVigente(int tipoId, Cliente cliente, TipoEvento evento, int dias, DateTime fecha);
}

// CU07, CU08, CU09, CU30
public interface IEquipamientoServicio
{
    int RegistrarUnidad(Unidad unidad);
    void ModificarUnidad(Unidad unidad);
    List<Unidad> BuscarUnidades(int? tipoId, int? depositoId, EstadoUnidad? estado);
    void CambiarEstado(int unidadId, EstadoUnidad nuevo);
    void AjustarStock(int depositoId, int tipoId, int cantidad);
    List<StockDeposito> ObtenerStock();
    int RegistrarMantenimiento(Mantenimiento mantenimiento);
    void FinalizarMantenimiento(int mantenimientoId, DateTime fin, string trabajo, string resultado, decimal costo);
}

// CU12 (solo consulta)
public interface IDisponibilidadServicio
{
    int ObtenerDisponible(int tipoId, DateTime desde, DateTime hasta);
    ResultadoDisponibilidad Verificar(List<ItemSolicitud> items, DateTime desde, DateTime hasta);
    List<Unidad> ObtenerUnidadesLibres(int tipoId, DateTime desde, DateTime hasta);
}

// CU10, CU11, CU13, CU14, CU15
public interface ISolicitudServicio
{
    int Registrar(Solicitud solicitud);
    ResultadoDisponibilidad Modificar(Solicitud solicitud);
    List<Solicitud> Buscar(int? clienteId, EstadoSolicitud? estado);
    Contratacion Aceptar(int solicitudId);
    void Rechazar(int solicitudId);
    void Cancelar(int solicitudId);
}

// CU17, CU18, CU29
public interface IContratacionServicio
{
    Contratacion ObtenerPorId(int id);
    void AsignarUnidades(int itemContratacionId, List<int> unidadIds);
    void SustituirUnidad(int asignacionId, int nuevaUnidadId, string motivo);
    void RegistrarEntrega(int contratacionId, Entrega entrega);
}

// CU19, CU20
public interface IDevolucionServicio
{
    int Registrar(int contratacionId, Devolucion devolucion);
    int RegistrarCargo(int incidenciaId, decimal monto, string concepto);
}

// CU21, CU22
public interface IPagoServicio
{
    int Registrar(int contratacionId, Pago pago);
    decimal ConsultarSaldo(int contratacionId);
}

// CU23 a CU27 (solo lectura)
public interface IReporteServicio
{
    List<ReporteMasAlquilado> MasAlquilado(DateTime desde, DateTime hasta);
    List<ReporteDisponibilidad> Disponibilidad(DateTime desde, DateTime hasta);
    List<ReporteCliente> ContratacionesPorCliente(DateTime desde, DateTime hasta);
    List<ReporteCuenta> CuentasPorCobrar();
    List<ReporteIncidencia> IncidenciasDevoluciones(DateTime desde, DateTime hasta);
}
