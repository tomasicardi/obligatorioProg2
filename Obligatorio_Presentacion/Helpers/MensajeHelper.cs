using Obligatorio_Negocio;

namespace Obligatorio_Presentacion
{
    internal static class MensajeHelper
    {
       
        public static void MostrarError(Exception ex)
        {
            if (ex is NegocioException)
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Ocurrió un error inesperado:" + Environment.NewLine + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void MostrarInfo(string mensaje)
        {
            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool Confirmar(string pregunta)
        {
            DialogResult resultado = MessageBox.Show(pregunta, "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return resultado == DialogResult.Yes;
        }
    }
}
