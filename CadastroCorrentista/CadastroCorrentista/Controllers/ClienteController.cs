using CadastroCorrentista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadastroCorrentista.Controllers
{
    public class ClienteController : BasePage
    {
        private static Cliente temp;

        //adiciona cliente
        public static bool Adicionar(Cliente cliente)
        {
            temp = new Cliente();

            if ((temp = BuscaDeCliente(cliente.Cpf)) == null)
            {
                if (VerificaSeContaExiste(cliente) == null)
                {
                    try
                    {
                        cliente.Ativo = true;
                        contexto.Clientes.Add(cliente);
                        contexto.SaveChanges();
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
            else
            {
                if (temp.Ativo == false)
                {
                    if (VerificaSeContaExiste(temp) == null)
                    {
                        try
                        {
                            temp.AgenciaId = cliente.AgenciaId;
                            temp.Ativo = true;
                            temp.Conta = cliente.Conta;
                            temp.Nome = cliente.Nome;
                            temp.Sexo = cliente.Sexo;

                            contexto.Entry(temp).State =
                            System.Data.Entity.EntityState.Modified;
                            contexto.SaveChanges();
                            return true;
                        }
                        catch (Exception)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        //Altera os dados dos clientes
        public static bool Editar(Cliente cliente)
        {
            if (VerificaSeContaExiste(cliente) == null)
            {
                try
                {
                    contexto.Entry(cliente).State =
                        System.Data.Entity.EntityState.Modified;
                    contexto.SaveChanges();
                    return true;

                }
                catch (Exception)
                {
                    return false;
                }
            }
            else return false;

        }

        //Torna o cliente inativo
        public static bool Excluir(Cliente cliente)
        {
            if ((cliente = BuscaDeCliente(cliente.Cpf)) != null)
            {
                try
                {
                    cliente.Ativo = false;
                    contexto.Entry(cliente).State =
                        System.Data.Entity.EntityState.Modified;
                    contexto.SaveChanges();
                    return true;

                }
                catch (Exception)
                {
                    return false;
                }
            }
            else return false;
        }
        
        //Busca todos os clientes cadastrados
        public static Cliente BuscaDeCliente(string cpf)
        {
            return contexto.Clientes.FirstOrDefault(x => x.Cpf.Equals(cpf));
        }

        //Busca somente clientes ativos
        public static Cliente BuscaDeClienteAtivos(string cpf)
        {
            temp = new Cliente();
            if ((temp = BuscaDeCliente(cpf)) != null)
            {
                if (temp.Ativo == true)
                {
                    return temp;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        //não permite exlusão da agência caso haja cliente cadastrado
        public static bool VerificaAgenciaVinculadaACliente(int agenciaid)
        {
            if (contexto.Clientes.FirstOrDefault(x => x.AgenciaId == agenciaid) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Verifica se há cliente ativo com  a mesma conta e agência cadastrados
        public static Cliente VerificaSeContaExiste(Cliente cliente)
        {
            return contexto.Clientes.FirstOrDefault(x => x.Conta.Equals(cliente.Conta) &&
            x.AgenciaId == cliente.AgenciaId && x.Ativo == true);
        }

        //Lista todos os clientes
        //public static List<Cliente> ListarClientes()
        //{
        //    List<Cliente> temp = new List<Cliente>();

        //    foreach (Cliente itemAtivo in contexto.Clientes)
        //    {
        //        if (itemAtivo.Ativo == true)
        //        {
        //            temp.Add(itemAtivo);
        //        }
        //    }
        //    return temp;
        //}
    }
}