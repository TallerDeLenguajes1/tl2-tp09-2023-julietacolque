namespace Models
{
    public class Usuario
    {
        public int Id { get; set; }

        private string nombreUsuario;
        
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
    }
}