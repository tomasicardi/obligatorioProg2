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
