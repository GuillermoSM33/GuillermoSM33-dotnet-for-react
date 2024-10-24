using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ApplicationCore.Wrappers;

namespace ApplicationCore.Commands
{
    public class EstudianteDeleteCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
}
