using System;
using System.Collections.Generic;
using System.Text;
using Obligatorio_Entidades;

namespace Obligatorio_Negocio;

// Áreas del sistema, usadas para los permisos por rol.
public enum Funcionalidad
{
    Clientes,
    Solicitudes,
    Equipamiento,
    Contrataciones,
    Devoluciones,
    Pagos,
    Reportes,
    Configuracion
}

public class DetalleDisponibilidad
{
    public TipoEquipamiento Tipo { get; set; }
    public int Solicitada { get; set; }
    public int Disponible { get; set; }
}

public class ResultadoDisponibilidad
{
    public List<DetalleDisponibilidad> Detalle { get; set; } = new();

    // Hay disponibilidad si para cada tipo alcanza lo disponible.
    public bool Disponible => Detalle.All(d => d.Disponible >= d.Solicitada);
}
