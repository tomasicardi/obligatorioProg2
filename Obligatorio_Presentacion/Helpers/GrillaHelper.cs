namespace Obligatorio_Presentacion
{
    internal static class GrillaHelper
    {
      
        public static void OcultarColumna(DataGridView grilla, string nombreColumna)
        {
            if (grilla.Columns.Contains(nombreColumna))
                grilla.Columns[nombreColumna].Visible = false;
        }

        public static void CambiarTitulo(DataGridView grilla, string nombreColumna, string titulo)
        {
            if (grilla.Columns.Contains(nombreColumna))
                grilla.Columns[nombreColumna].HeaderText = titulo;
        }

        
        public static T ObtenerSeleccionado<T>(DataGridView grilla) where T : class
        {
            if (grilla.SelectedRows.Count == 0)
                return null;
            return grilla.SelectedRows[0].DataBoundItem as T;
        }
    }
}
