
using FacturacionDAM.Formularios;
using MySql.Data.MySqlClient;
using System.Text.Json;

namespace FacturacionDAM.Modelos {
    public class AppDAM {

        public ConfiguracionConexion configConexion;        // Objeto con la configuración de la conexión a la BD.
        public EstadoApp estadoApp;                         // Estado de la aplicación en el momento actual.
        public Emisor emisor;                               // Emisor de las facturas.
        public string rutaBase { get; private set; }        // Ruta base de la aplicación.
        public string rutaConfigDB;                         // Ruta al archivo de configuración de la base de datos.

        // Me indica si estoy conectado a la base de datos o no.
        public bool conectado => (_conexion != null) && (_conexion.State == System.Data.ConnectionState.Open);

        public string ultimoError { get; private set; }     // Ultimo error registrado.

        private MySqlConnection _conexion = null;           // Cliente MySQL para comunicarnos con la base de datos

        private DebugDAM debug;                          // Objeto para gestionar el log de depuración.

        /// <summary>
        /// Constructor.
        /// </summary>
        public AppDAM() {

            // Estado inicial de la App.
            estadoApp = EstadoApp.Iniciando;

            // Instancio el cliente mysql.
            _conexion = new MySqlConnection();

            // Inicializo el objeto emisor.
            emisor = null;

            // Inicializo la aplicación
            InitApp();            
        }

        /// <summary>
        /// Inicializa la aplicación (conexión a la base de datos, log de errores, etc.).
        /// </summary>
        private void InitApp () {
            // Ruta por defecto en Documentos
            rutaBase = AppDomain.CurrentDomain.BaseDirectory;

            // Ruta al archivo de configuración de la base de datos
            rutaConfigDB = Path.Combine(rutaBase, "configDB.json");

            // Inicializa el sistema de logs
            debug = new DebugDAM(rutaBase);

            // Configuro y me conecto a la base de datos.
            ConfiguraYConectaDB(rutaConfigDB);
        }

        public void ConfiguraYConectaDB(string aRutaConfig)  {
            // Inicializo la variable que guarda el último error
            ultimoError = "";

            // Cargo los datos de conexión a la base de datos.
            configConexion = CargarConfiguracionDB(aRutaConfig);

            // Intento la conexión a la base de datos
            if (configConexion != null)
            {
                if (ConectarDB())
                    estadoApp = EstadoApp.Conectado;
                else
                    estadoApp = (ultimoError != "") ? EstadoApp.Error : EstadoApp.SinConexion;
                    RegistrarLog("ConfiguraYConectaDB", $"Estado de la aplicación: {estadoApp.ToString()}");
            }
            else
                estadoApp = (ultimoError != "") ? EstadoApp.Error : EstadoApp.SinConexion;
                RegistrarLog("ConfiguraYConectaDB", $"Estado de la aplicación: {estadoApp.ToString()}");

        }

        /// <summary>
        /// Carga la configuración de la base de datos en un objeto de la clase "ConfiguracionConexion",
        /// retornando dicho objeto. La configuración la intentará cargar de un archivo llamado
        /// "configDB.json" en el directorio base de la aplicación.
        /// </summary>
        /// <returns>Retorna el objeto de tipo "ConfiguracionConexion" con la configuración de la base
        /// de datos, null si no lo ha conseguido.</returns>
        private ConfiguracionConexion CargarConfiguracionDB(string aRuta)  {
            
            ConfiguracionConexion resultado = null;
            
            if (File.Exists(aRuta)) {
                try {
                    string jsonText = File.ReadAllText(aRuta);
                    resultado = JsonSerializer.Deserialize<ConfiguracionConexion>(jsonText);
                }
                catch (Exception ex) {
                    ultimoError = "Error al cargar archivo de configuración.\n" + ex.Message;
                    RegistrarLog("CargarConfiguracionDB", ultimoError);
                }
            }
            return resultado;
        }

        /// <summary>
        /// Intenta conectarse a la base de datos con la configuración de las propiedades de la clase.
        /// Si durante el intenta de conexión se produce alguna excepción, almacena el mensaje de error
        /// en el campo "UltimoError".
        /// </summary>
        /// <returns>True si se ha conectado correctamente, false sino.</returns>
        public bool ConectarDB () {
            
            // Si está conectado me aseguro de cerrar antes de iniciar una nueva conexión.
            if (conectado)
                _conexion.Close();

            // Asigno la cadena de conexión.
            _conexion.ConnectionString = configConexion.CadenaDeConexion();

            // Intento la conexión.
            try {
                _conexion.Open();
            }
            catch (Exception ex) {
                ultimoError = "Error al intentar la conexión a la base de datos.\n" + ex.Message;
                RegistrarLog("ConectarDB", ultimoError);
            }
            estadoApp = (conectado) ? EstadoApp.Conectado : EstadoApp.SinConexion;
            return conectado;
        }

        /// <summary>
        /// Cierra la conexión a la base de datos.
        /// </summary>
        public void DesconectarDB()
        {
            if (conectado)
            {
                try
                {
                    _conexion.Close();
                }
                catch (Exception ex)
                {
                    ultimoError = "Error al intentar cerrar conexión a la base de datos.\n" + ex.Message;
                    RegistrarLog("DesconectarDB", ultimoError);
                }
            }
            estadoApp = (conectado) ? EstadoApp.Conectado : EstadoApp.SinConexion;
        }

        public void RegistrarLog(string proceso, string mensaje)
        {
            string linea = $"{DateTime.Now:dd-MM-yyyy} | {DateTime.Now:HH:mm:ss} | {proceso} | {mensaje}";
            debug.GuardarLog(linea);
        }


    }
}