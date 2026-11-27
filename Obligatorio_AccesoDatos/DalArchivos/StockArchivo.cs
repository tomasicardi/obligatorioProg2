using Obligatorio_Entidades;


namespace Obligatorio_AccesoDatos;

public class StockArchivo : IStockRepositorio
{
    private string _rutaArchivo = Constantes.Ruta(Constantes.ARCHIVO_STOCK);
    private IFileProvider _fileProvider = new JsonFileProvider();

    public int Alta(StockDeposito stock)
    {
        List<StockDeposito> lista = LeerStock();
        stock.Id = lista.Count == 0 ? 1 : lista.Max(s => s.Id) + 1;
        lista.Add(stock);
        GuardarStock(lista);
        return stock.Id;
    }

    // Solo se modifica la cantidad.
    public void Modificar(StockDeposito stock)
    {
        List<StockDeposito> lista = LeerStock();
        StockDeposito existente = lista.FirstOrDefault(s => s.Id == stock.Id);
        if (existente != null)
        {
            existente.Cantidad = stock.Cantidad;
            GuardarStock(lista);
        }
    }

    public StockDeposito ObtenerPorId(int id)
    {
        return LeerStock().FirstOrDefault(s => s.Id == id);
    }

    public List<StockDeposito> ObtenerTodos()
    {
        return LeerStock()
            .OrderBy(s => s.Deposito.Nombre)
            .ThenBy(s => s.Tipo.Nombre)
            .ToList();
    }

    // Devuelve null si ese depósito todavía no tiene stock de ese tipo.
    public StockDeposito Obtener(int depositoId, int tipoId)
    {
        return LeerStock().FirstOrDefault(s => s.Deposito.Id == depositoId && s.Tipo.Id == tipoId);
    }

    public List<StockDeposito> ObtenerPorTipo(int tipoId)
    {
        return LeerStock()
            .Where(s => s.Tipo.Id == tipoId)
            .OrderBy(s => s.Deposito.Nombre)
            .ToList();
    }

    // Lee el stock y completa depósito y tipo con los datos actuales.
    private List<StockDeposito> LeerStock()
    {
        List<StockDeposito> lista = _fileProvider.LeerRegistros<StockDeposito>(_rutaArchivo);
        List<TipoEquipamiento> tipos =
            _fileProvider.LeerRegistros<TipoEquipamiento>(Constantes.Ruta(Constantes.ARCHIVO_TIPOS_EQUIPAMIENTO));
        List<Deposito> depositos =
            _fileProvider.LeerRegistros<Deposito>(Constantes.Ruta(Constantes.ARCHIVO_DEPOSITOS));

        foreach (StockDeposito stock in lista)
        {
            stock.Tipo = tipos.FirstOrDefault(t => t.Id == stock.Tipo.Id) ?? stock.Tipo;
            stock.Deposito = depositos.FirstOrDefault(d => d.Id == stock.Deposito.Id) ?? stock.Deposito;
        }
        return lista;
    }

    private void GuardarStock(List<StockDeposito> lista)
    {
        _fileProvider.GuardarRegistros(_rutaArchivo, lista);
    }
}
