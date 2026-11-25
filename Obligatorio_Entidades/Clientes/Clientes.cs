using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio_Entidades;


public abstract class Cliente
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public string Direccion { get; set; }
    public bool Activo { get; set; } = true;

    public abstract TipoCliente ObtenerTipo();


    public virtual List<string> Validar()
    {
        var errores = new List<string>();
        if (string.IsNullOrWhiteSpace(Nombre)) errores.Add("El nombre es obligatorio.");
        if (string.IsNullOrWhiteSpace(Telefono)) errores.Add("El teléfono es obligatorio.");
        if (string.IsNullOrWhiteSpace(Email)) errores.Add("El email es obligatorio.");
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

    public override List<string> Validar()
    {
        var errores = base.Validar();
        if (string.IsNullOrWhiteSpace(Rut)) errores.Add("El RUT es obligatorio.");
        if (string.IsNullOrWhiteSpace(TipoOrganizacion)) errores.Add("El tipo de organización es obligatorio.");
        return errores;
    }
}