using BE_Usuarios.Common.Models;
using BE_Usuarios.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BE_Usuarios.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private AplicationDbContext _context;
        private static List<Usuario> _usuarios = new List<Usuario>();
        

        public UsuarioRepository(IConfiguration configuration)
        {
            var con = configuration.GetSection("ConnectionStrings:DevConnection");
            _context = new AplicationDbContext(con.Value);
        }

        public async Task<List<Usuario>> ObtenerUsuarios()
        {
            _usuarios.Clear();
            var lista = from usuariosBD in _context.Usuario
                        select usuariosBD;

            foreach (var item in lista)
            {
                _usuarios.Add(new Usuario()
                {
                    Id = item.Id,
                    Nombre = item.Nombre,
                    Email = item.Email,
                    FechaCreacion = item.FechaCreacion
                });
            }

            return await Task.Run(() => _usuarios);
        }

        public async Task<bool> CrearUsuario(Usuario usuario)
        {
            Usuario usuarioBD = new Usuario()
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Email = usuario.Email,
                FechaCreacion = usuario.FechaCreacion
            };

            _context.Usuario.Add(usuarioBD);
            _context.SaveChanges();

            return await Task.Run(() => true);
        }

        public async Task<bool> BorrarUsuario(int id)
        {
            var lista = from usuarioDB in _context.Usuario
                        where usuarioDB.Id == id
                        select usuarioDB;


            foreach (var item in lista)
            {
                _context.Usuario.Remove(item);
            }

            _context.SaveChanges();

            return await Task.Run(() => true);
        }

        public async Task<bool> ModificarUsuario(Usuario usuario)
        {
            Usuario usuarioDB = new Usuario()
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Email = usuario.Email,
                FechaCreacion = usuario.FechaCreacion
            };

            _context.Usuario.Update(usuarioDB);
            _context.SaveChanges();

            return await Task.Run(() => true);
        }
    }
}
