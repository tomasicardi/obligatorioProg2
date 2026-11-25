using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio_Entidades;

public enum EstadoUnidad
{
    Disponible,
    Reservado,
    EnPreparacion,
    Alquilado,
    EnMantenimiento,
    FueraDeServicio
}

public enum TipoCliente
{
    Particular,
    Empresa,
    Organizacion
}

public enum EstadoSolicitud
{
    Pendiente,
    Aceptada,
    Rechazada,
    Cancelada
}

public enum RolUsuario
{
    Administrativo,
    Encargado,
    Gerente
}