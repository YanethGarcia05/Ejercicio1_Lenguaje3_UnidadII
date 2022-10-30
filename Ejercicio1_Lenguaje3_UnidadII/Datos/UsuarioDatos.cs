using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;

namespace Datos
{
    public class UsuarioDatos
    {
        public async Task<bool> LoginAsync(string codigocorreo, string contraseña)
        {
            bool valido = false;
            try
            {
                string sql = "SELECT 1 FROM datosusuario WHERE CodigoCorreo=@CodigoCorreo AND Contraseña=@Contraseña;";

                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text; 
                        comando.Parameters.Add("@CodigoCorreo", MySqlDbType.VarChar, 50).Value = codigocorreo;
                        comando.Parameters.Add("@Contraseña", MySqlDbType.VarChar, 100).Value = contraseña;
                        valido = Convert.ToBoolean(await comando.ExecuteScalarAsync());
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return valido;
        }

        public async Task<DataTable> DevolverListaAsync()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM datosusuario";
                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        MySqlDataReader dr = (MySqlDataReader)await comando.ExecuteReaderAsync();
                        dt.Load(dr);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return dt;
        }

        public async Task<bool> InsertarAsync(Usuario datosusuario)
        {
            bool inserto = false;
            try
            {
                string sql = "INSERT INTO datosusuario VALUES (@CodigoCorreo, @Contraseña)";
                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add("@CodigoCorreo", MySqlDbType.VarChar, 50).Value = datosusuario.CodigoCorreo;
                        comando.Parameters.Add("@Clave", MySqlDbType.VarChar, 100).Value = datosusuario.Contraseña;

                        await comando.ExecuteNonQueryAsync();
                        inserto = true;
                    }
                }
            }
            catch (Exception)
            {
            }
            return inserto;
        }

        public async Task<bool> ActualizarAsync(Usuario datosusuario)
        {
            bool actualizo = false;
            try
            {
                string sql = "UPDATE datosusuario SET  Contraseña=@Contraseña WHERE CodigoCorreo=@CodigoCorreo";
                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add("@CodigoCorreo", MySqlDbType.VarChar, 50).Value = datosusuario.CodigoCorreo;
                        comando.Parameters.Add("@Contraseña", MySqlDbType.VarChar, 100).Value = datosusuario.Contraseña;

                        await comando.ExecuteNonQueryAsync();
                        actualizo = true;
                    }
                }
            }
            catch (Exception)
            {
            }
            return actualizo;
        }

        public async Task<bool> EliminarAsync(string codigocorreo)
        {
            bool elimino = false;
            try
            {
                string sql = "DELETE FROM datousuario WHERE CodigoCorreo = @CodigoCorreo";
                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add("@CodigoCorreo", MySqlDbType.VarChar, 50).Value = codigocorreo;
                        await comando.ExecuteNonQueryAsync();
                        elimino = true;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return elimino;
        }
    }
}
