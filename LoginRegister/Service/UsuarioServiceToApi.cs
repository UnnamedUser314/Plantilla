using LoginRegister.Helpers;
using LoginRegister.Interface;
using LoginRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegister.Service
{
    public class UsuarioServiceToApi : IUsuarioServiceToApi
    {
        private readonly IHttpJsonProvider<UsuarioDTO> _httpJsonProvider;


        public UsuarioServiceToApi(IHttpJsonProvider<UsuarioDTO> httpJsonProvider)
        {
            _httpJsonProvider = httpJsonProvider;
        }



        public async Task<IEnumerable<UsuarioDTO>> GetUsuarios()
        {

            IEnumerable<UsuarioDTO> productos = await _httpJsonProvider.GetAsync(Constants.USUARIO_URL);

            return productos;
        }
        public async Task<IEnumerable<UsuarioDTO>> GetUsuarioByName(string name)
        {

            IEnumerable<UsuarioDTO> productos = await _httpJsonProvider.GetByNameAsync(Constants.USUARIO_NAME_URL, name);

            return productos;
        }

    }
}
