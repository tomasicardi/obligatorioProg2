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
}

public class TipoEquipamiento
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public bool Individualizable { get; set; }
    public bool Activo { get; set; } = true;
    public List<Caracteristica> Caracteristicas { get; set; } = new();
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