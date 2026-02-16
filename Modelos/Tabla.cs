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

        public enum TipoEntidad
        {
            Cliente,
            Proveedor
        }

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
                if (_dataAdapter.SelectCommand != null) _dataAdapter.SelectCommand.Dispose();

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
            if (_tabla != null)
            {
                _tabla.Clear();
                _dataAdapter.Fill(_tabla);
            }
        }

        /// <summary>
        /// Metodo que guarda los cambios realizados en el DataTable de la tabla en la base de datos. Si se le pasa una transacción, se asignará a los comandos generados para asegurar que las operaciones se realicen dentro de esa transacción.
        /// </summary>
        /// <param name="transaccion"></param>
        /// <returns></returns>
        public bool GuardarDatos(MySqlTransaction transaccion = null)
        {
            try
            {
                // Si nos pasan una transacción, asignarla a los comandos generados
                if (transaccion != null && _dataAdapter.SelectCommand != null)
                {
                    _dataAdapter.SelectCommand.Transaction = transaccion;

                    // Generamos los comandos de inserción, actualización y eliminación utilizando el CommandBuilder
                    var ins = _commandBuilder.GetInsertCommand();
                    var upd = _commandBuilder.GetUpdateCommand();
                    var del = _commandBuilder.GetDeleteCommand();

                    ins.Transaction = transaccion;
                    upd.Transaction = transaccion;
                    del.Transaction = transaccion;

                    _dataAdapter.InsertCommand = ins;
                    _dataAdapter.UpdateCommand = upd;
                    _dataAdapter.DeleteCommand = del;
                }

                _dataAdapter.Update(_tabla);
                return true;
            }
            catch (Exception ex)
            {
                Program.appDAM.RegistrarLog("Tabla.GuardarDatos", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Metodo que libera los recursos utilizados por la tabla, como el DataTable, el DataAdapter y el CommandBuilder.
        /// Es importante llamar a este método cuando ya no se necesite la tabla para liberar memoria y evitar posibles fugas de memoria.
        /// </summary>
        public void Liberar()
        {
            _tabla?.Dispose();
            _dataAdapter?.Dispose();
            _commandBuilder = null;
        }

        /// <summary>
        /// Metodo que ejecuta un comando SQL de tipo INSERT, UPDATE o DELETE con parámetros. Si se le pasa una transacción, el comando se ejecut
        /// </summary>
        /// <param name="aSql"></param>
        /// <param name="aParameters"></param>
        /// <param name="transaccion"></param>
        /// <returns></returns>
        public int EjecutarComando(string aSql, Dictionary<string, object> aParameters, MySqlTransaction transaccion = null)
        {
            try
            {
                using var cmd = new MySqlCommand(aSql, _conexion);

                // Asignar transacción si existe
                if (transaccion != null) cmd.Transaction = transaccion;

                if (aParameters != null)
                {
                    foreach (var param in aParameters)
                        cmd.Parameters.AddWithValue(param.Key, param.Value);
                }

                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Program.appDAM.RegistrarLog("Tabla.EjecutarComando", ex.Message + " SQL: " + aSql);
                throw;
            }
        }

        /// <summary>
        /// Acceso al DataTable que contiene los datos de la tabla.
        /// </summary>
        public DataTable LaTabla => _tabla;

        /// <summary>
        /// Comprueba si un emisor está en uso en la aplicación (es el activo).
        /// </summary>
        /// <param name="idEmisor">ID del emisor a comprobar</param>
        public bool EmisorEnUso(int idEmisor)
        {
            try
            {
                if (Program.appDAM.emisor != null && Program.appDAM.emisor.id == idEmisor)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Program.appDAM.RegistrarLog("Tabla.EmisorEnUso", ex.Message);
                return true;
            }
        }

        /// <summary>
        /// Metodo que devuelve una tabla con las provincias. Se implementa un sistema de cache para evitar ir a la base de datos cada vez que se necesitan las provincias, ya que estas no cambian frecuentemente.
        /// Si el cache está vacío o no existe, se carga desde la base de datos y se almacena en el cache para futuras consultas.
        /// </summary>
        /// <returns>Retorna un DataTable con las provincias</returns>
        internal DataTable ObtenerTablaProvincias()
        {
            try
            {
                if (_cacheProvincias != null && _cacheProvincias.Rows.Count > 0)
                {
                    return _cacheProvincias;
                }

                using (var da = new MySqlDataAdapter("SELECT id, nombreprovincia FROM provincias ORDER BY nombreprovincia;", _conexion))
                {
                    _cacheProvincias = new DataTable();
                    da.Fill(_cacheProvincias);
                }

                return _cacheProvincias;
            }
            catch (Exception ex)
            {
                Program.appDAM.RegistrarLog("Tabla.ObtenerTablaProvincias", ex.Message);
                return new DataTable(); // Devuelve tabla vacía para no romper el programa
            }
        }

        /// <summary>
        /// Metodo que devuelve una tabla con los tipos de IVA. Se ordenan por porcentaje para facilitar su uso en la aplicación.
        /// No se implementa cache porque los tipos de IVA pueden cambiar más frecuentemente que las provincias, aunque si se quisiera se podría implementar un sistema de cache similar al de las provincias.
        /// </summary>
        /// <returns>Retorna un DataTable con los tipos de IVA</returns>
        internal DataTable ObtenerTablaTiposDeIVA()
        {
            try
            {
                using (var da = new MySqlDataAdapter("SELECT id, descripcion, porcentaje FROM tiposiva ORDER BY porcentaje;", _conexion))
                {
                    DataTable tiposIVATable = new DataTable();
                    da.Fill(tiposIVATable);
                    return tiposIVATable;
                }
            }
            catch (Exception ex)
            {
                Program.appDAM.RegistrarLog("Tabla.ObtenerTablaTiposDeIVA", ex.Message);
                return new DataTable();
            }
        }

        /// <summary>
        /// Metodo que devuelve una tabla con los tipos de factura. Se ordenan por descripción para facilitar su uso en la aplicación.
        /// </summary>
        public void Dispose()
        {
            _tabla?.Dispose();
            _dataAdapter?.Dispose();
            _commandBuilder?.Dispose();
        }

        /// <summary>
        /// Metodo que comprueba si una entidad (cliente o proveedor) tiene facturas asociadas. Esto es importante para evitar eliminar un cliente o proveedor que tenga facturas relacionadas, lo que podría causar inconsistencias en la base de datos.
        /// </summary>
        /// <param name="idEntidad"></param>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public bool TieneFacturas(int idEntidad, TipoEntidad tipo)
        {
            try
            {
                string sql = "";

                // Seleccionamos la consulta dependiendo del tipo
                if (tipo == TipoEntidad.Cliente)
                {
                    // Busca en facturas emitidas por idcliente
                    sql = "SELECT COUNT(*) FROM facemi WHERE idcliente = @idEntidad;";
                }
                else
                {
                    // Busca en facturas recibidas por idproveedor
                    sql = "SELECT COUNT(*) FROM facrec WHERE idproveedor = @idEntidad;";
                }

                using var cmd = new MySqlCommand(sql, _conexion);
                cmd.Parameters.AddWithValue("@idEntidad", idEntidad);

                object result = cmd.ExecuteScalar();
                int count = result != null ? Convert.ToInt32(result) : 0;

                return count > 0;
            }
            catch (Exception ex)
            {
                Program.appDAM.RegistrarLog("Tabla.TieneFacturas", ex.Message);
                return true;
            }
        }
    }
}
