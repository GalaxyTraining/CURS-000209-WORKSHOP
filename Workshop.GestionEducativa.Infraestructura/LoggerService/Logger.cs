using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.GestionEducativa.Infraestructura.LoggerService
{
    public static class Logger
    {
        private static readonly object lockObject = new object();

        static Logger()
        {
            if(!Directory.Exists(Constantes.rutaLog))
            {
                Directory.CreateDirectory(Constantes.rutaLog);
            }
        }

        public static void LogInfo(string mensaje)
        {
            Log(mensaje, "INFO");
        }

        public static void LogError(string mensaje)
        {
            Log(mensaje, "ERROR");
        }

        private static void Log(string mensaje, string tipo)
        {
            if (string.IsNullOrWhiteSpace(mensaje))
            {
                throw new ArgumentException("El mensaje de log no puede estar vacio", nameof(mensaje));
            }

            string LogFilePath = Path.Combine(Constantes.rutaLog, $"{DateTime.Now:yyyyMMdd}.log");
            string LogMensaje = $"{DateTime.Now:HH:mm:ss}-[{tipo}] [{mensaje}]";

            try
            {
                lock (lockObject)
                {
                    using (StreamWriter writer = new StreamWriter(LogFilePath, true, Encoding.UTF8))
                    {
                        writer.WriteLine(LogMensaje);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al escribir log: {ex.Message}");
            }
        }

    }
}
