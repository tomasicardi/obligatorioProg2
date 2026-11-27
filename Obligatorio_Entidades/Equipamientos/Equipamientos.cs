using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio_Entidades;

public class Deposito
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public bool Activo { get; set; } = true;

    // Se usa para mostrar el depósito en ComboBox y grillas.
    public override string ToString() => Nombre;
}

public class TipoEquipamiento
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public bool Individualizable { get; set; }
    public bool Activo { get; set; } = true;
    public List<Caracteristica> Caracteristicas { get; set; } = new();

    public override string ToString() => Nombre;
}

public class ValorCaracteristica
{
    public Caracteristica Caracteristica { get; set; }
    public string Valor { get; set; }
}

public class Unidad
{
    public int Id { get; set; }
    public string CodigoSerie { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public TipoEquipamiento Tipo { get; set; }
    public Deposito Deposito { get; set; }
    public EstadoUnidad Estado { get; set; } = EstadoUnidad.Disponible;
    public List<ValorCaracteristica> Valores { get; set; } = new();

    public void CambiarEstado(EstadoUnidad nuevo)
    {
        Estado = nuevo;
    }
}

public class StockDeposito
{
    public int Id { get; set; }
    public Deposito Deposito { get; set; }
    public TipoEquipamiento Tipo { get; set; }
    public int Cantidad { get; set; }
}

public class Mantenimiento
{
    public int Id { get; set; }
    public Unidad Unidad { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }
    public string Motivo { get; set; }
    public string TrabajoRealizado { get; set; }
    public string Resultado { get; set; }
    public decimal Costo { get; set; }
}

public class Tarifa
{
    public int Id { get; set; }
    public TipoEquipamiento Tipo { get; set; }
    public decimal PrecioDiario { get; set; }
    public DateTime VigenteDesde { get; set; }
    public DateTime? VigenteHasta { get; set; }
    public int? DiasMin { get; set; }
    public int? DiasMax { get; set; }


    public TipoCliente? CondicionTipoCliente { get; set; }
    public TipoEvento CondicionTipoEvento { get; set; }

    public bool EsAplicable(Cliente cliente, TipoEvento evento, int dias, DateTime fecha)
    {
        if (fecha < VigenteDesde) return false;
        if (VigenteHasta.HasValue && fecha > VigenteHasta.Value) return false;
        if (DiasMin.HasValue && dias < DiasMin.Value) return false;
        if (DiasMax.HasValue && dias > DiasMax.Value) return false;
        if (CondicionTipoCliente.HasValue && cliente.ObtenerTipo() != CondicionTipoCliente.Value) return false;
        if (CondicionTipoEvento != null && (evento == null || evento.Id != CondicionTipoEvento.Id)) return false;
        return true;
    }
}