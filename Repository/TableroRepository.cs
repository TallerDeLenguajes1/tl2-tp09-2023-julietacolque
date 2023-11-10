using System.Data.SQLite;
using Models;
namespace Repository
{
    public class TableroRepository : ITableroRepository
    {
        private readonly string cadenaConexion = "Data Source=DB/kanban.db;Cache=Shared";

        public void Create(Tablero tablero)
        {
            string query = "INSERT INTO tablero (id_usuario_propietario,nombre,descripcion) values (@id,@nombreT,@descripcion)";

            using (SQLiteConnection conexion = new(cadenaConexion))
            {
                SQLiteCommand command = new(query, conexion);
                command.Parameters.Add(new SQLiteParameter("@id", tablero.IdUsuarioPropietario));
                command.Parameters.Add(new SQLiteParameter("@nombreT", tablero.Nombre));
                command.Parameters.Add(new SQLiteParameter("@descripcion", tablero.Descripcion));

                conexion.Open();
                command.ExecuteNonQuery();
                conexion.Close();

            }

        }

        public void Update(int id, Tablero tablero)
        {
            string query = "UPDATE tablero SET nombre=@nombre,descripcion=@descripcion,id_usuario_propietario=@idU WHERE id=@idT;";
            using SQLiteConnection conexion = new(cadenaConexion);
            SQLiteCommand command = new(query, conexion);
            command.Parameters.Add(new SQLiteParameter("@nombre", tablero.Nombre));
            command.Parameters.Add(new SQLiteParameter("@descripcion", tablero.Descripcion));
            command.Parameters.Add(new SQLiteParameter("@idU", tablero.IdUsuarioPropietario));
            command.Parameters.Add(new SQLiteParameter("@idT", id));

            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();

        }

        public Tablero GetById(int id)
        {
            var tablero = new Tablero();
            string query = "SELECT * from tablero where id=@id";
            using (SQLiteConnection conexion = new(cadenaConexion))
            {
                SQLiteCommand command = new(query, conexion);
                command.Parameters.Add(new SQLiteParameter("@id", id));
                conexion.Open();
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tablero.Id = Convert.ToInt32(reader["id"]);
                        tablero.Nombre = reader["nombre"].ToString();
                        tablero.Descripcion = reader["descripcion"].ToString();
                        tablero.IdUsuarioPropietario = Convert.ToInt32(reader["id_usuario_propietario"]);
                    }
                    conexion.Close();
                }
            }
            return tablero;
        }

        public List<Tablero> GetAll()
        {
            var lista = new List<Tablero>();
            string query = "SELECT * FROM tablero";
            using (SQLiteConnection conexion = new(cadenaConexion))
            {
                SQLiteCommand command = new(query, conexion);
                conexion.Open();
                using SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var tableroAux = new Tablero()
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Nombre = reader["nombre"].ToString(),
                        Descripcion = reader["descripcion"].ToString(),
                        IdUsuarioPropietario = Convert.ToInt32(reader["id_usuario_propietario"])

                    };
                    lista.Add(tableroAux);
                }
                conexion.Close();
            }
            return lista;
        }

        public List<Tablero> GetByUser(int id) //devuelve todos los tableros asociados a un usuario en particular
        {
            var lista = new List<Tablero>();
            string query = "SELECT * FROM tablero inner join usuario ON(tablero.id_usuario_propietario = usuario.id) WHERE usuario.id=@idU;";
            using var conexion = new SQLiteConnection(cadenaConexion);
            SQLiteCommand command = new(query,conexion);
            command.Parameters.Add(new SQLiteParameter("@idU",id));
            conexion.Open();
            using(SQLiteDataReader reader = command.ExecuteReader()){
                while(reader.Read()){
                      var tableroAux = new Tablero()
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Nombre = reader["nombre"].ToString(),
                        Descripcion = reader["descripcion"].ToString(),
                        IdUsuarioPropietario = Convert.ToInt32(reader["id_usuario_propietario"])

                    };
                    lista.Add(tableroAux);
                }
            }
            return lista;
        }

        public void RemoveById(int id)
        {
            string query = "DELETE FROM tablero WHERE id=@id;";
            using SQLiteConnection conexion = new(cadenaConexion);
            var command = new SQLiteCommand(query, conexion);
            command.Parameters.Add(new SQLiteParameter("@id", id));
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }

    }
}