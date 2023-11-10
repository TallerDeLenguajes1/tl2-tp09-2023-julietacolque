using System.Data.SQLite;
using Models;
namespace Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string cadenaConexion = "Data Source=DB/kanban.db;Cache=Shared";

        public void Create(Usuario usuario)
        {
            string query = $"INSERT INTO  usuario (nombre_de_usuario) VALUES(@nombre_de_usuario)"; //creo la consulta con los @para insertar parametros luego

            using SQLiteConnection conexion = new(cadenaConexion); //creo la conexion



            var command = new SQLiteCommand(query, conexion); //crea un objeto de tipo command asociado a una conexion.


            command.Parameters.Add(new SQLiteParameter("@nombre_de_usuario", usuario.NombreUsuario));

            conexion.Open(); //abro la conexion
            command.ExecuteNonQuery(); //ejecuta consultas que no devuelve resultados,pero si realiza una accion en la bd

            conexion.Close();
        }

        public void Update(int id, Usuario usuario)
        {
            string query = $"UPDATE usuario SET nombre_de_usuario = @nombre where id = @id;";
            using (SQLiteConnection conexion = new(cadenaConexion))
            {
                conexion.Open();
                var command = new SQLiteCommand(query, conexion);

                command.Parameters.Add(new SQLiteParameter("@nombre", usuario.NombreUsuario));
                command.Parameters.Add(new SQLiteParameter("@id", id));

                command.ExecuteNonQuery();
                conexion.Close();

            }
        }

        public List<Usuario> GetAll()
        {
            string query = "SELECT * FROM usuario;";

            var lista = new List<Usuario>();

            using (SQLiteConnection conexion = new(cadenaConexion))
            {

                SQLiteCommand command = new(query, conexion);

                conexion.Open();

                using (SQLiteDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        var usuario = new Usuario
                        {
                            NombreUsuario = reader["nombre_de_usuario"].ToString()
                        };
                        lista.Add(usuario);

                    }
                }
                conexion.Close();
            }

            return lista;
        }

        public Usuario GetById(int id)
        {
            var usuario = new Usuario();
            string query = "SELECT * FROM usuario WHERE id=@id;";
            using (var conexion = new SQLiteConnection(cadenaConexion))
            {

                SQLiteCommand command = new(query, conexion);
                command.Parameters.Add(new SQLiteParameter("@id", id));

                conexion.Open();
                using SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    usuario.NombreUsuario = reader["nombre_de_usuario"].ToString();
                    usuario.Id = Convert.ToInt32(reader["id"]);
                }
                conexion.Close();
            }
            return usuario;
        }

        public void Remove(int id)
        {
            string query = "DELETE FROM usuario WHERE id=@id;";
            using SQLiteConnection conexion = new(cadenaConexion);
            var command = new SQLiteCommand(query, conexion);
            command.Parameters.Add(new SQLiteParameter("@id", id));
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
    }
}

// Usuario
// ○ id (int) - PK - NOT NULL
// ○ nombre_de_usuario - (text) - NOT NUL

// name espace
//luego es una clase llamada usuario repository que hereda  la interfaz IUsuarioRepository
//CADENA DE CONEXION
//funcion crear armo la consulta
//hago la conexion con sqliteconnection