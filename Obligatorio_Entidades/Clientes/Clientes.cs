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


