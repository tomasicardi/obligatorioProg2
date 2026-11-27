using Obligatorio_Entidades;

namespace Obligatorio_AccesoDatos;

public class DepositoArchivo : IDepositoRepositorio
{
    private string _rutaArchivo = Constantes.Ruta(Constantes.ARCHIVO_DEPOSITOS);
    private IFileProvider _fileProvider = new JsonFileProvider();

    public int Alta(Deposito deposito)
    {
        List<Deposito> depositos = LeerDepositos();
        deposito.Id = depositos.Count == 0 ? 1 : depositos.Max(d => d.Id) + 1;
        deposito.Activo = true;
        depositos.Add(deposito);
        GuardarDepositos(depositos);
        return deposito.Id;
    }

    public void Modificar(Deposito deposito)
    {
        List<Deposito> depositos = LeerDepositos();
        Deposito existente = depositos.FirstOrDefault(d => d.Id == deposito.Id);
        if (existente != null)
        {
            existente.Nombre = deposito.Nombre;
            existente.Direccion = deposito.Direccion;
            GuardarDepositos(depositos);
        }
    }

    public Deposito ObtenerPorId(int id)
    {
        return LeerDepositos().FirstOrDefault(d => d.Id == id);
    }

    
    public List<Deposito> ObtenerTodos()
    {
        return LeerDepositos()
            .Where(d => d.Activo)
            .OrderBy(d => d.Nombre)
            .ToList();
    }

    
    public bool TieneUnidadesOStock(int id)
    {
        List<Unidad> unidades = _fileProvider.LeerRegistros<Unidad>(Constantes.Ruta(Constantes.ARCHIVO_UNIDADES));
        List<StockDeposito> stock = _fileProvider.LeerRegistros<StockDeposito>(Constantes.Ruta(Constantes.ARCHIVO_STOCK));

        bool tieneUnidades = unidades.Any(u => u.Deposito.Id == id);
        bool tieneStock = stock.Any(s => s.Deposito.Id == id && s.Cantidad > 0);
        return tieneUnidades || tieneStock;
    }

   
    public void Desactivar(int id)
    {
        List<Deposito> depositos = LeerDepositos();
        Deposito deposito = depositos.FirstOrDefault(d => d.Id == id);
        if (deposito != null)
        {
            deposito.Activo = false;
            GuardarDepositos(depositos);
        }
    }

    private List<Deposito> LeerDepositos()
    {
        return _fileProvider.LeerRegistros<Deposito>(_rutaArchivo);
    }

    private void GuardarDepositos(List<Deposito> depositos)
    {
        _fileProvider.GuardarRegistros(_rutaArchivo, depositos);
    }
}
