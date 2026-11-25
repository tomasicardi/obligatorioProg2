using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio_Entidades;

public class Usuario
{
    public int Id { get; set; }
    public string NombreUsuario { get; set; }
    public string PasswordHash { get; set; }
    public RolUsuario Rol { get; set; }
    public bool Activo { get; set; } = true;
}