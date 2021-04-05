using ProjetoAPI02.Domain.Entities;
using ProjetoAPI02.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoAPI02.DomainServices
{
    public class ProdutoDomainService
    {
        private IUnitOfWork unitOfWork;

        public ProdutoDomainService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<Produto> ConsultarProdutos()
        {
            return unitOfWork.ProdutoRepository.GetAll();
        }
    }
}
