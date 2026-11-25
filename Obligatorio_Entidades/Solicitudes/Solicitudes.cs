
using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio_Entidades;

public class ItemSolicitud
{
    public int Id { get; set; }
    public TipoEquipamiento Tipo { get; set; }
    public int Cantidad { get; set; }
}

public class Solicitud
{
    public int Id { get; set; }
    public Cliente Cliente { get; set; }
    public TipoEvento TipoEvento { get; set; }
    public DateTime FechaDesde { get; set; }
    public DateTime FechaHasta { get; set; }
    public string Ubicacion { get; set; }
    public TimeSpan HoraInicio { get; set; }
    public TimeSpan HoraFin { get; set; }
    public int AsistentesEstimados { get; set; }
    public EstadoSolicitud Estado { get; set; } = EstadoSolicitud.Pendiente;
    public List<ItemSolicitud> Items { get; set; } = new();

    public bool PuedePasarA(EstadoSolicitud nuevo)
    {
        switch (Estado)
        {
            case EstadoSolicitud.Pendiente:
                return nuevo == EstadoSolicitud.Aceptada
                    || nuevo == EstadoSolicitud.Rechazada
                    || nuevo == EstadoSolicitud.Cancelada;
            case EstadoSolicitud.Aceptada:
                return nuevo == EstadoSolicitud.Cancelada;
            default:
                return false;
        }
    }

    public void CambiarEstado(EstadoSolicitud nuevo)
    {
        if (!PuedePasarA(nuevo))
            throw new InvalidOperationException($"No se puede pasar de {Estado} a {nuevo}.");
        Estado = nuevo;
    }
}