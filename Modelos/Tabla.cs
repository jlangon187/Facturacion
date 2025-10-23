using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionDAM.Modelos
{
    public class Tabla
    {
        private MySqlConnection _conexion;           // Cliente MySQL para comunicarnos con la base de datos
        private MySqlDataAdapter _dataAdapter;       // Adaptador de datos para la tabla
        private MySqlCommandBuilder _commandBuilder; // Objeto que nos facilita la generación de comandos SQL automáticamente
        private DataTable _tabla;                    // Objeto DataTable que contiene los datos de la tabla

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="conexion">MySqlConnection que representa la conexion a la base de datos</param>
        public Tabla(MySqlConnection conexion)
        {
            _conexion = conexion;
            _dataAdapter = new MySqlDataAdapter();
        }

        /// <summary>
        /// Inicializa los datos de la tabla a partir de una consulta SQL.
        /// </summary>
        /// <param name="sql">Sentencia SQL de acceso</param>
        /// <returns>True si se ha podido cargar, si no False</returns>
        public bool InicializarDatos(string sql)
        {
            try
            {
                _dataAdapter.SelectCommand = new MySqlCommand(sql, _conexion);
                _commandBuilder = new MySqlCommandBuilder(_dataAdapter);
                _tabla = new DataTable();
                _dataAdapter.Fill(_tabla);
                return true;
            }
            catch (Exception ex)
            {
                Program.appDAM.RegistrarLog("Tabla.InicializarDatos", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Actualiza los datos de la tabla desde la base de datos.
        /// </summary>
        public void Refrescar()
        {
            _tabla.Clear();
            _dataAdapter.Fill(_tabla);
        }

        /// <summary>
        /// Guarda los cambios realizados en la tabla de datos de vuelta a la base de datos.
        /// </summary>
        public void GuardarDatos()
        {
            _dataAdapter.Update(_tabla);
        }

        /// <summary>
        /// Libera los recursos utilizados por la tabla.
        /// </summary>
        public void Liberar() 
        { 
            _tabla?.Dispose();
            _dataAdapter?.Dispose();
            _commandBuilder = null;
        }

        /// <summary>
        /// Acceso al DataTable que contiene los datos de la tabla.
        /// </summary>
        public DataTable LaTabla => _tabla;
    }
}
