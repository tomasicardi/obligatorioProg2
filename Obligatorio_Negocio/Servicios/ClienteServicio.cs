using Obligatorio_AccesoDatos;
using Obligatorio_Entidades;

namespace Obligatorio_Negocio;


public class ClienteServicio : IClienteServicio
{
    private IClienteRepositorio _repositorio;

    public ClienteServicio()
    {
        _repositorio = new ClienteArchivo(); 
    }

    public int Registrar(Cliente cliente)
    {
        Validar(cliente);

        if (_repositorio.ExisteDocumento(cliente.Identificacion, null))
            throw new ReglaNegocioException("Ya existe un cliente con ese documento/RUT.");

        cliente.Activo = true;
        cliente.Id = _repositorio.Alta(cliente);
        return cliente.Id;
    }

    public Cliente ObtenerPorId(int id)
    {
        Cliente cliente = _repositorio.ObtenerPorId(id);
        if (cliente == null)
            throw new EntidadNoEncontradaException("No se encontró el cliente.");
        return cliente;
    }

   
    public List<Cliente> Buscar(string criterio)
    {
        if (string.IsNullOrWhiteSpace(criterio))
            return _repositorio.ObtenerTodos();
        return _repositorio.BuscarPorNombre(criterio.Trim());
    }

    public void Modificar(Cliente cliente)
    {
        
        ObtenerPorId(cliente.Id);

        Validar(cliente);

        if (_repositorio.ExisteDocumento(cliente.Identificacion, cliente.Id))
            throw new ReglaNegocioException("Ya existe otro cliente con ese documento/RUT.");

        _repositorio.Modificar(cliente);
    }

    public void Desactivar(int id)
    {
        Cliente cliente = ObtenerPorId(id);
        if (!cliente.Activo)
            throw new EstadoInvalidoException("El cliente ya está desactivado.");

        

        _repositorio.Desactivar(id);
    }

    
    private void Validar(Cliente cliente)
    {
        if (cliente == null)
            throw new ValidacionException("No se recibieron los datos del cliente.");

        List<string> errores = cliente.Validar();
        if (errores.Count > 0)
            throw new ValidacionException(string.Join(Environment.NewLine, errores));
    }
}
