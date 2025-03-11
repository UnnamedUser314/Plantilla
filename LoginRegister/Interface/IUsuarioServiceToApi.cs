using LoginRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegister.Interface
{
    public interface IUsuarioServiceToApi
    {
        // Obtiene un Dicatadores desde la API
        Task<IEnumerable<UsuarioDTO>> GetUsuarios();
        Task<IEnumerable<UsuarioDTO>> GetUsuarioByName(string name);

    }
}
