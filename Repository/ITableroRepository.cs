using Models;
namespace Repository

{
    public interface ITableroRepository
    {
        public void Create(Tablero tablero);

        public void Update(int id,Tablero tablero);

        public Tablero GetById(int id);

        public List<Tablero> GetAll();

        public List<Tablero> GetByUser(int id);

        public void RemoveById(int id);


    }
}

// Repositorio de Tableros:
// Crear un repositorio llamado TableroRepository para gestionar todas las operaciones
// relacionadas con tableros. Este repositorio debe incluir métodos para:
// ● Crear un nuevo tablero (devuelve un objeto Tablero)
// ● Modificar un tablero existente (recibe un id y un objeto Tablero)
// ● Obtener detalles de un tablero por su ID. (recibe un id y devuelve un Tablero)
// ● Listar todos los tableros existentes (devuelve un list de tableros)
// ● Listar todos los tableros de un usuario específico. (recibe un IdUsuario, devuelve un
// list de tableros)
// ● Eliminar un tablero por ID


