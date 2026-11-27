using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Obligatorio_Entidades;


// Como Cliente es abstracta, al guardarla en JSON hay que indicar sus clases hijas.
// Así el archivo guarda "$type": "Particular" (o Empresa / Organizacion) y al leerlo
// se vuelve a crear el objeto del tipo correcto.
[JsonDerivedType(typeof(Particular), "Particular")]
[JsonDerivedType(typeof(Empresa), "Empresa")]
[JsonDerivedType(typeof(Organizacion), "Organizacion")]
public abstract class Cliente
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public string Direccion { get; set; }
    public bool Activo { get; set; } = true;

    public abstract TipoCliente ObtenerTipo();

    // Propiedades de solo lectura para poder mostrarlas en la grilla.
    // [JsonIgnore]: no se guardan en el archivo porque se calculan solas.
    [JsonIgnore]
    public TipoCliente Tipo => ObtenerTipo();
    [JsonIgnore]
    public string Identificacion => ObtenerIdentificacion();

    // Particular devuelve su Documento; Empresa y Organización, su RUT.
    public abstract string ObtenerIdentificacion();


    public virtual List<string> Validar()
    {
        var errores = new List<string>();
        if (string.IsNullOrWhiteSpace(Nombre)) errores.Add("El nombre es obligatorio.");
        if (string.IsNullOrWhiteSpace(Telefono)) errores.Add("El teléfono es obligatorio.");
        if (string.IsNullOrWhiteSpace(Email)) errores.Add("El email es obligatorio.");
        else if (!Email.Contains("@")) errores.Add("El email no tiene un formato válido.");
        if (string.IsNullOrWhiteSpace(Direccion)) errores.Add("La dirección es obligatoria.");
        return errores;
    }

    public void Desactivar()
    {
        Activo = false;
    }
}

public class Particular : Cliente
{
    public string Documento { get; set; }

    public override TipoCliente ObtenerTipo() => TipoCliente.Particular;
    public override string ObtenerIdentificacion() => Documento;

    public override List<string> Validar()
    {
        var errores = base.Validar();
        if (string.IsNullOrWhiteSpace(Documento)) errores.Add("El documento es obligatorio.");
        return errores;
    }
}

public class Empresa : Cliente
{
    public string Rut { get; set; }

    public override TipoCliente ObtenerTipo() => TipoCliente.Empresa;
    public override string ObtenerIdentificacion() => Rut;

    public override List<string> Validar()
    {
        var errores = base.Validar();
        if (string.IsNullOrWhiteSpace(Rut)) errores.Add("El RUT es obligatorio.");
        return errores;
    }
}

public class Organizacion : Cliente
{
    public string Rut { get; set; }
    public string TipoOrganizacion { get; set; }

    public override TipoCliente ObtenerTipo() => TipoCliente.Organizacion;
    public override string ObtenerIdentificacion() => Rut;

    public override List<string> Validar()
    {
        var errores = base.Validar();
        if (string.IsNullOrWhiteSpace(Rut)) errores.Add("El RUT es obligatorio.");
        if (string.IsNullOrWhiteSpace(TipoOrganizacion)) errores.Add("El tipo de organización es obligatorio.");
        return errores;
    }
}