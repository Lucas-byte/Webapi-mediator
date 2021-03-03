using Api_CQRS.Context;
using Api_CQRS.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Api_CQRS.Recursos.Queries
{
    public class GetPorProdutoPorIdQueryHandler : IRequestHandler<GetPorProdutoPorIdQuery, Produto>
    {
        private readonly AppDbContext _context;

        public GetPorProdutoPorIdQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Produto> Handle(GetPorProdutoPorIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Produtos.FirstOrDefaultAsync(x => x.Id == request.Id,cancellationToken);
        }
    }
}
