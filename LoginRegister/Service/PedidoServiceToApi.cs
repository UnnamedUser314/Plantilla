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
    public class PedidoServiceToApi : IPedidoServiceToApi
    {
        private readonly IHttpJsonProvider<PedidoDTO> _httpJsonProvider;


        public PedidoServiceToApi(IHttpJsonProvider<PedidoDTO> httpJsonProvider)
        {
            _httpJsonProvider = httpJsonProvider;
        }



        public async Task<IEnumerable<PedidoDTO>> GetPedidos()
        {

            IEnumerable<PedidoDTO> pedidos = await _httpJsonProvider.GetAsync(Constants.PEDIDO_URL);

            return pedidos;
        }

        public async Task<PedidoDTO> GetPedidoById(int id)
        {

            PedidoDTO pedido = await _httpJsonProvider.GetByIdAsync(Constants.PEDIDO_URL, id);

            return pedido;
        }

        public async Task PostPedido(PedidoDTO pedido)
        {
            try
            {
                if (pedido == null) return;
                var response = await _httpJsonProvider.PostAsync(Constants.PEDIDO_URL, pedido);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task PutPedido(PedidoDTO pedido)
        {
            try
            {
                if (pedido == null) return;
                var response = await _httpJsonProvider.PutAsync(Constants.PEDIDO_URL + "/" + pedido.Id, pedido);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task DeletePedido(int pedidoIndex)
        {
            try
            {
                var response = await _httpJsonProvider.Delete(Constants.PEDIDO_URL + "/", pedidoIndex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
