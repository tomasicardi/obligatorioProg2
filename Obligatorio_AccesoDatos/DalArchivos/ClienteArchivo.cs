using Obligatorio_Entidades;

namespace Obligatorio_AccesoDatos;

public class ClienteArchivo : IClienteRepositorio
{
    private string _rutaArchivo = Constantes.Ruta(Constantes.ARCHIVO_CLIENTES);
    private IFileProvider _fileProvider = new JsonFileProvider();

    public int Alta(Cliente cliente)
    {
        List<Cliente> clientes = LeerClientes();
        // El Id nuevo es el mayor que exista + 1 (en SQL lo hará el IDENTITY).
        cliente.Id = clientes.Count == 0 ? 1 : clientes.Max(c => c.Id) + 1;
        clientes.Add(cliente);
        GuardarClientes(clientes);
        return cliente.Id;
    }

    public void Modificar(Cliente cliente)
    {
        List<Cliente> clientes = LeerClientes();
        int posicion = clientes.FindIndex(c => c.Id == cliente.Id);
        if (posicion >= 0)
        {
            clientes[posicion] = cliente;
            GuardarClientes(clientes);
        }
    }

    public Cliente ObtenerPorId(int id)
    {
        return LeerClientes().FirstOrDefault(c => c.Id == id);
    }

    public List<Cliente> ObtenerTodos()
    {
        return LeerClientes().OrderBy(c => c.Nombre).ToList();
    }

    public Cliente BuscarPorDocumento(string documentoORut)
    {
        return LeerClientes().FirstOrDefault(c => c.Identificacion == documentoORut);
    }

    // Busca por nombre o por documento/RUT (que contenga el texto, sin importar mayúsculas).
    public List<Cliente> BuscarPorNombre(string nombre)
    {
        return LeerClientes()
            .Where(c => Contiene(c.Nombre, nombre) || Contiene(c.Identificacion, nombre))
            .OrderBy(c => c.Nombre)
            .ToList();
    }

    // excluirId: al modificar, no tenemos que compararnos con nosotros mismos.
    public bool ExisteDocumento(string documentoORut, int? excluirId)
    {
        return LeerClientes().Any(c => c.Identificacion == documentoORut && c.Id != excluirId);
    }

    public void Desactivar(int id)
    {
        List<Cliente> clientes = LeerClientes();
        Cliente cliente = clientes.FirstOrDefault(c => c.Id == id);
        if (cliente != null)
        {
            cliente.Desactivar();
            GuardarClientes(clientes);
        }
    }

    // ---------------- Métodos auxiliares ----------------

    private List<Cliente> LeerClientes()
    {
        return _fileProvider.LeerRegistros<Cliente>(_rutaArchivo);
    }

    private void GuardarClientes(List<Cliente> clientes)
    {
        _fileProvider.GuardarRegistros(_rutaArchivo, clientes);
    }

    private bool Contiene(string valor, string texto)
    {
        return valor != null && valor.ToLower().Contains(texto.ToLower());
    }
}
