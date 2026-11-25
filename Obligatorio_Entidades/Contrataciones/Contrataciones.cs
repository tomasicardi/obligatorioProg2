using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio_Entidades;

public class Asignacion
{
    public int Id { get; set; }
    public Unidad Unidad { get; set; }
    public DateTime Fecha { get; set; }
    public bool Vigente { get; set; } = true;
    public string MotivoSustitucion { get; set; }
}

public class ItemContratacion
{
    public int Id { get; set; }
    public TipoEquipamiento Tipo { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioDiario { get; set; }
    public List<Asignacion> Asignaciones { get; set; } = new();

    public decimal CalcularImporte(int dias) => Cantidad * PrecioDiario * dias;
}

public class Pago
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Monto { get; set; }
    public string Observaciones { get; set; }
}

public class Entrega
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public Modalidad Modalidad { get; set; }
    public string Observaciones { get; set; }
}

public class CargoAdicional
{
    public int Id { get; set; }
    public decimal Monto { get; set; }
    public string Concepto { get; set; }
}

public class Incidencia
{
    public int Id { get; set; }
    public TipoIncidencia TipoIncidencia { get; set; }
    public TipoEquipamiento Tipo { get; set; }
    public Unidad Unidad { get; set; }
    public string Descripcion { get; set; }
    public int Cantidad { get; set; }
    public CargoAdicional Cargo { get; set; }
    public Mantenimiento Mantenimiento { get; set; }
}

public class Devolucion
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public Modalidad Modalidad { get; set; }
    public string Observaciones { get; set; }
    public List<Incidencia> Incidencias { get; set; } = new();

    public bool TieneIncidencias() => Incidencias.Count > 0;
}

public class Contratacion
{
    public int Id { get; set; }
    public Solicitud Solicitud { get; set; }
    public DateTime FechaDesde { get; set; }
    public DateTime FechaHasta { get; set; }
    public List<ItemContratacion> Items { get; set; } = new();
    public List<Pago> Pagos { get; set; } = new();
    public List<CargoAdicional> Cargos { get; set; } = new();
    public Entrega Entrega { get; set; }
    public Devolucion Devolucion { get; set; }

  
    public int Dias => (FechaHasta.Date - FechaDesde.Date).Days + 1;

    public decimal CalcularImporteItems() => Items.Sum(i => i.CalcularImporte(Dias));
    public decimal CalcularTotalCargos() => Cargos.Sum(c => c.Monto);
    public decimal CalcularTotalPagos() => Pagos.Sum(p => p.Monto);

  
    public decimal CalcularSaldo() => CalcularImporteItems() + CalcularTotalCargos() - CalcularTotalPagos();
}