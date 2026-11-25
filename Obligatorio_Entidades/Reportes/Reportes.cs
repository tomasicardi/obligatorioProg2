using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio_Entidades;

public class ReporteMasAlquilado
{
    public string Tipo { get; set; }
    public int UnidadesAlquiladas { get; set; }
    public int CantidadContrataciones { get; set; }
}

public class ReporteDisponibilidad
{
    public string Deposito { get; set; }
    public string Tipo { get; set; }
    public int Total { get; set; }
    public int Comprometido { get; set; }
    public int Disponible { get; set; }
}

public class ReporteCliente
{
    public string Cliente { get; set; }
    public int CantidadContrataciones { get; set; }
    public decimal ImporteTotal { get; set; }
    public DateTime Desde { get; set; }
    public DateTime Hasta { get; set; }
}

public class ReporteCuenta
{
    public int ContratacionId { get; set; }
    public string Cliente { get; set; }
    public decimal Total { get; set; }
    public decimal Pagos { get; set; }
    public decimal Saldo { get; set; }
}

public class ReporteIncidencia
{
    public string Equipamiento { get; set; }
    public int CantidadDevolucionesConIncidencias { get; set; }
    public string TipoIncidencia { get; set; }
    public decimal CargosAdicionales { get; set; }
}