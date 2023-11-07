using Models;
namespace Repository
{
    public interface IUsuarioRepository
    {
        public void Create(Usuario usuario);

        public void Update(int id, Usuario usuario);

        public List<Usuario> GetAll();

        public Usuario GetById(int id);

        public void Remove(int id);
    }
}
// Repositorio de Usuarios:
// Crear un repositorio llamado UsuarioRepository para gestionar todas las
// operaciones relacionadas con usuarios. Este repositorio debe incluir métodos para:
// ● Crear un nuevo usuario. (recibe un objeto Usuario)
// ● Modificar un usuario existente. (recibe un Id y un objeto Usuario)
// ● Listar todos los usuarios registrados. (devuelve un List de Usuarios)
// ● Obtener detalles de un usuario por su ID. (recibe un Id y devuelve un Usuario)
// ● Eliminar un usuario por ID
