﻿using Api_CQRS.Context;
using Api_CQRS.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Api_CQRS.Recursos.Commands
{
    public class ProdutoCreateCommandHandler : IRequestHandler<ProdutoCreateCommand, Produto>
    {
        private readonly AppDbContext _context;

        public ProdutoCreateCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Produto> Handle(ProdutoCreateCommand request, CancellationToken cancellationToken)
        {
            var produto = new Produto();
            produto.Nome = request.Nome;
            produto.Preco = request.Preco;
            produto.Taxa = request.Taxa;
            produto.Descricao = request.Descricao;
            produto.CodigoBarras = request.CodigoBarras;

            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return produto;
        }
    }
}
