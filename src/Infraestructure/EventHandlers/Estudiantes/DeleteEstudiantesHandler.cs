using ApplicationCore.Commands;
using ApplicationCore.Interfaces;
using ApplicationCore.Wrappers;
using AutoMapper;
using Infraestructure.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Infraestructure.EventHandlers.Estudiantes
{
    public class DeleteEstudiantesHandler : IRequestHandler<EstudianteDeleteCommand, Response<int>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IEstudiantesService _service;

        public DeleteEstudiantesHandler(ApplicationDbContext context, IMapper mapper, IEstudiantesService service)
        {
            _context = context;
            _mapper = mapper;
            _service = service;
        }

        public async Task<Response<int>> Handle(EstudianteDeleteCommand command, CancellationToken cancellationToken)
        {
            var estudiante = await _context.Estudiantes.FindAsync(command.Id);
            if (estudiante == null)
            {
                return new Response<int>("Estudiante no encontrado");
            }

            _context.Estudiantes.Remove(estudiante);
            await _context.SaveChangesAsync(cancellationToken);
            return new Response<int>(estudiante.Id, "Eliminación exitosa");
        }
    }
}