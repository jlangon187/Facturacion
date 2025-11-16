using Google.Protobuf.Reflection;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FacturacionDAM.Utils
{
    public static class Validaciones
    {

        /// <summary>
        /// Verifica si el email recibido como parámetro es un email válido.
        /// </summary>
        /// <param name="email">El email a verificar.</param>
        /// <returns>Retorna true si el email es válido, false sino.</returns>
        public static bool EsEmailValido(string email)
        {
            bool emailValido = true;
            // Validación general con MailAddress
            var addr = new System.Net.Mail.MailAddress(email);
            if (addr.Address != email)
                emailValido = false;

            // Validación adicional con expresión regular
            string patronEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, patronEmail))
                emailValido = false;

            return emailValido;
        }

        /// <summary>
        /// Comprueba la existencia registros en una tabla (primer parámetro) que tengan un campo (segundo parámetro)
        /// cuyo valor coincida con el valor pasado como tercer parámetro. El cuarto parámetro nos permite ignorar
        /// registros en la tabla cuyo campo "id" coincida con ese valor pasado como 4º parámetro. 
        /// </summary>
        /// <param name="tabla">El nombre de la tabla.</param>
        /// <param name="campo">El nombre del campo cuyo valor queremos comparar.</param>
        /// <param name="valor">El valor a comparar.</param>
        /// <param name="idActual">Parámetro entero opcional, que representa el valor "id" de los registros a ignorar.</param>
        /// <returns>Retorna true si encuentra registros, false sino.</returns>
        public static bool EsValorCampoUnico(string tabla, string campo, string valor, int? idActual = null)
        {
            string consulta = $"SELECT COUNT(*) FROM {tabla} WHERE {campo} = @valor";
            using var cmd = new MySqlCommand(consulta, Program.appDAM.LaConexion);
            cmd.Parameters.AddWithValue("@valor", valor);

            if (idActual != null)
            {
                cmd.CommandText += " AND id <> @id";
                cmd.Parameters.AddWithValue("@id", idActual);
            }

            return Convert.ToInt32(cmd.ExecuteScalar()) == 0;
        }

        /// <summary>
        /// Metodo que valida si un código postal es válido según el formato español.
        /// </summary>
        /// <param name="codigoPostal"></param>
        /// <returns></returns>
        public static bool CodigoPostalValido(string codigoPostal)
        {
            // Patrón para códigos postales españoles (5 dígitos)
            string patronCodigoPostal = @"^\d{5}$";
            return Regex.IsMatch(codigoPostal, patronCodigoPostal);
        }

        /// <summary>
        /// Metodo que valida la entrada de un TextBox para que solo acepte números y un solo separador decimal (coma o punto).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void ValidarPrecio(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            // Permitir teclas de control (como retroceso)
            if (char.IsControl(e.KeyChar))
            {
                return;
            }
            // Permitir solo dígitos y un solo separador decimal (coma o punto)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true; // Bloquear la entrada
                return;
            }
            // Verificar si ya hay un separador decimal en el texto
            if ((e.KeyChar == ',' || e.KeyChar == '.') && (textBox.Text.Contains(',') || textBox.Text.Contains('.')))
            {
                e.Handled = true; // Bloquear la entrada
            }
        }
    }
}
