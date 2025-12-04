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
        private static DataTable _cacheProvincias;   // Cache estático para las provincias

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
        /// Ejercuta un comando SQL con parámetros y devuelve el número de filas afectadas.
        /// </summary>
        /// <param name="aSql">La sentencia SQL a ejecutar</param>
        /// <param name="aParameters">El diccionario de parámetros</param>
        /// <returns>Devuelve el resultado de la ejecicion de la sentencia</returns>
        public int EjecutarComando(string aSql, Dictionary<string, object> aParameters)
        {
            using var cmd = new MySqlCommand(aSql, _conexion);
            foreach (var param in aParameters)
                cmd.Parameters.AddWithValue(param.Key, param.Value);
            
            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Acceso al DataTable que contiene los datos de la tabla.
        /// </summary>
        public DataTable LaTabla => _tabla;

        // Emisor que esta en uso
        public bool EmisorEnUso(string v, string v1, int idEmisor)
        {
            try
            {
                // Comprueba si el emisor activo en la aplicación es el mismo que intentas borrar
                if (Program.appDAM.emisor != null && Program.appDAM.emisor.id == idEmisor)
                {
                    return true; // Está en uso (activo en la aplicación)
                }

                return false; // No está en uso
            }
            catch (Exception ex)
            {
                Program.appDAM.RegistrarLog("Tabla.EmisorEnUso", ex.Message);
                return true; // Por seguridad, asumimos que está en uso si hay error
            }
        }

        /// <summary>
        /// Metodo que devuelve una tabla con las provincias.
        /// </summary>
        /// <returns></returns>
        internal object ObtenerTablaProvincias()
        {
            try
            {
                if (_cacheProvincias != null && _cacheProvincias.Rows.Count > 0)
                {
                    return _cacheProvincias;
                }
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT id, nombreprovincia FROM provincias ORDER BY nombreprovincia;", _conexion);
                DataTable provinciasTable = new DataTable();
                _cacheProvincias = new DataTable();
                da.Fill(_cacheProvincias);

                return _cacheProvincias;
            }
            catch (Exception ex)
            {
                Program.appDAM.RegistrarLog("Tabla.ObtenerTablaProvincias", ex.Message);
                return new DataTable();
            }
        }

        internal object ObtenerTablaTiposDeIVA()
        {
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT id, descripcion, porcentaje FROM tiposiva ORDER BY porcentaje;", _conexion);
                DataTable tiposIVATable = new DataTable();
                da.Fill(tiposIVATable);
                return tiposIVATable;
            }
            catch (Exception ex)
            {
                Program.appDAM.RegistrarLog("Tabla.ObtenerTablaTiposDeIVA", ex.Message);
                return new DataTable();
            }
        }
    }
}
