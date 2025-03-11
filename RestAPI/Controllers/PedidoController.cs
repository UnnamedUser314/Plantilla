using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Controllers.RestAPI.Controllers;
using RestAPI.Models.DTOs.PedidoDTO;
using RestAPI.Models.DTOs.ProductoDTO;
using RestAPI.Models.Entity;
using RestAPI.Repository.IRepository;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : BaseController<PedidoEntity, PedidoDto, CreatePedidoDto>
    {
        public PedidoController(IPedidoRepository pedidoRepository,
            IMapper mapper, ILogger<IPedidoRepository> logger)
            : base(pedidoRepository, mapper, logger)
        {

        }
    }
}
