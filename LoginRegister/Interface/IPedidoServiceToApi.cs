using LoginRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginRegister.Interface
{
    public interface IPedidoServiceToApi
    {
        Task<IEnumerable<PedidoDTO>> GetPedidos();
        Task<PedidoDTO> GetPedidoById(int id);

        Task PostPedido(PedidoDTO dicatador);

        Task PutPedido(PedidoDTO dicatador);
        Task DeletePedido(int id);
    }
}
