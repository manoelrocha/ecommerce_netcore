using ProjetoAPI02.Cryptography;
using ProjetoAPI02.Domain.Entities;
using ProjetoAPI02.DomainServices.Exceptions;
using ProjetoAPI02.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoAPI02.DomainServices
{
    public class ClienteDomainService
    {
        private IUnitOfWork unitOfWork;

        public ClienteDomainService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Método para cadastro de cliente no ECommerce
        /// </summary>
        /// <param name="cliente">Entidade Cliente</param>
        /// <param name="enderecos">Lista de Endereços do Cliente</param>
        public void CadastrarCliente(Cliente cliente, List<Endereco> enderecos)
        {
            #region Verificar se o email do cliente ja está cadastrado

            if (unitOfWork.ClienteRepository.GetByEmail(cliente.Email) != null)
                throw new EmailDeveSerUnicoException(cliente.Email);

            #endregion

            #region Criptografar a senha do cliente

            cliente.Senha = MD5Encrypt.GetHash(cliente.Senha);

            #endregion

            #region Transação para cadastro do cliente

            try
            {
                unitOfWork.BeginTransaction();

                unitOfWork.ClienteRepository.Insert(cliente);

                foreach (var item in enderecos)
                {
                    item.IdCliente = cliente.IdCliente;
                    unitOfWork.EnderecoRepository.Insert(item);
                }

                unitOfWork.Commit();
            }
            catch (Exception e)
            {
                unitOfWork.Rollback();
                throw new Exception(e.Message);
            }

            #endregion
        }

        /// <summary>
        /// Método para retornar 1 cliente baseado no email e senha
        /// </summary>
        /// <param name="email">Email do Cliente</param>
        /// <param name="senha">Senha do Cliente</param>
        /// <returns>Dados do Cliente obtido ou null se nenhum cliente for encontrado</returns>
        public Cliente ObterCliente(string email, string senha)
        {
            senha = MD5Encrypt.GetHash(senha);

            return unitOfWork.ClienteRepository
                .GetByEmailSenha(email, senha);
        }

        /// <summary>
        /// Método para retornar 1 cliente baseado no email
        /// </summary>
        /// <param name="email">Email do Cliente</param>
        /// <returns>Dados do Cliente obtido ou null se nenhum cliente for encontrado</returns>
        public Cliente ObterCliente(string email)
        {
            return unitOfWork.ClienteRepository
                .GetByEmail(email);
        }
    }
}

