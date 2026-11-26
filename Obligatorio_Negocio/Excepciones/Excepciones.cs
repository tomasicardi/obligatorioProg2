using System;
using System.Collections.Generic;
using System.Text;
using Obligatorio_Entidades;

namespace Obligatorio_Negocio;

// Excepción base de la capa de Negocio.
public class NegocioException : Exception
{
    public NegocioException(string mensaje) : base(mensaje) { }
}

public class ValidacionException : NegocioException
{
    public ValidacionException(string mensaje) : base(mensaje) { }
}

public class EntidadNoEncontradaException : NegocioException
{
    public EntidadNoEncontradaException(string mensaje) : base(mensaje) { }
}

public class EstadoInvalidoException : NegocioException
{
    public EstadoInvalidoException(string mensaje) : base(mensaje) { }
}

public class DisponibilidadInsuficienteException : NegocioException
{
    public DisponibilidadInsuficienteException(string mensaje) : base(mensaje) { }
}

public class ReglaNegocioException : NegocioException
{
    public ReglaNegocioException(string mensaje) : base(mensaje) { }
}

public class CredencialesInvalidasException : NegocioException
{
    public CredencialesInvalidasException(string mensaje) : base(mensaje) { }
}
