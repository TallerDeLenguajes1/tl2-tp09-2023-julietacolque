using System.Data.SQLite;
using Models;
namespace Repository
{
    public class TareaRepository : ITareaRepository
    {
        private readonly string cadenaConexion = "Data Source=DB/kanban.db;Cache=Shared";
        public Tarea Create(int idTablero, Tarea tarea)
        {
            return tarea;
        }
        public void Update(int id, Tarea tarea)
        {

        }
        public Tarea GetById(int id)
        {
             var tarea = new Tarea();
            string query = "SELECT * FROM tarea where id=@id;";
            using (SQLiteConnection conexion = new(cadenaConexion))
            {
                SQLiteCommand command = new(query, conexion);
                command.Parameters.Add(new SQLiteParameter("@id", id));
                conexion.Open();
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                           tarea.Id = Convert.ToInt32(reader["id"]);
                           tarea.IdUsuarioAsignado = Convert.ToInt32(reader["id_usuario_asignado"]);
                           tarea.IdTablero = Convert.ToInt32(reader["idTa"]);
                    
                    }
                    conexion.Close();
                }
                   return tarea;
            }

         
        }
        public List<Tarea> GetAllByUser(int idUsuario)
        {
            List<Tarea> lista = new();
            return lista;
        }
        public List<Tarea> GetAllByTablero(int idTablero)
        {
            List<Tarea> lista = new();
            return lista;
        }
        public void Remove(int idTarea)
        {
            string query = "DELETE FROM tarea WHERE id=@id;";
            using SQLiteConnection conexion = new(cadenaConexion);
            var command = new SQLiteCommand(query, conexion);
            command.Parameters.Add(new SQLiteParameter("@id", idTarea));
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public void Asignar(int idUsuario, int idTarea)
        {

        }

    }
}