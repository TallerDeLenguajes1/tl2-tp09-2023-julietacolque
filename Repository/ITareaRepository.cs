using Models;
namespace Repository
{
    public interface ITareaRepository
    {
        public Tarea Create(int idTablero);
        public void Update(int id, Tarea tarea);
        public Tarea GetById(int id);
        public List<Tarea> GetAllByUser(int idUsuario);
        public List<Tarea> GetAllByTablero(int idTablero);
        public void Remove(int idTarea);
        public void Asignar(int idUsuario, int idTarea);


    }
}

// Repositorio de Tareas:
// Crear un repositorio llamado TareaRepository para gestionar todas las operaciones
// relacionadas con tareas. Este repositorio debe incluir métodos para:
// ● Crear una nueva tarea en un tablero. (recibe un idTablero, devuelve un objeto Tarea)
// ● Modificar una tarea existente. (recibe un id y un objeto Tarea)
// ● Obtener detalles de una tarea por su ID. (devuelve un objeto Tarea)
// ● Listar todas las tareas asignadas a un usuario específico.(recibe un idUsuario,
// devuelve un list de tareas)
// ● Listar todas las tareas de un tablero específico. (recibe un idTablero, devuelve un list
// de tareas)
// ● Eliminar una tarea (recibe un IdTarea)
// ● Asignar Usuario a Tarea (recibe idUsuario y un idTarea)
