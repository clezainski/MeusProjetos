using CadastroCorrentista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadastroCorrentista.Controllers
{
    public class AgenciaController : BasePage
    {
        private static Agencia temp;
        public static bool Adicionar(Agencia agencia)
        {
            temp = new Agencia();

            if ((temp = BuscaDeAgenciaPorNome(agencia.Nome)) == null)
            {
                try
                {
                    agencia.Ativo = true;
                    contexto.Agencias.Add(agencia);
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
                if (temp.Ativo == false)
                {
                    try
                    {
                        temp.Ativo = true;
                        temp.Nome = agencia.Nome;
                        temp.Gerente = agencia.Gerente;

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
        }

        public static bool Editar (Agencia agencia)
        {
            if ((BuscaDeAgencia(agencia.Id)) != null)
            {
                try
                {
                    contexto.Entry(agencia).State =
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
        
        public static bool Excluir(Agencia agencia)
        {
            if (BuscaDeAgencia(agencia.Id) != null && ClienteController.VerificaAgenciaVinculadaACliente(agencia.Id)==false)
            {
                try
                {
                    agencia.Ativo = false;
                    contexto.Entry(agencia).State =
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

        public static Agencia BuscaDeAgencia(int id)
        {
            return contexto.Agencias.Find(id);
        }
        
        public static Agencia BuscaDeAgenciaPorNome(string nome)
        {
            return contexto.Agencias.FirstOrDefault(x=>x.Nome.Equals(nome));
        }

        public static Agencia BuscaDeAgenciasAtivas(string nome)
        {
            temp = new Agencia();
            if ((temp = BuscaDeAgenciaPorNome(nome)) != null)
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

        public static List<Agencia> ListarAgencias()
        {
            List<Agencia> temp = new List<Agencia>();

            foreach (Agencia itemAtivo in contexto.Agencias)
            {
                if (itemAtivo.Ativo == true)
                {
                    temp.Add(itemAtivo);
                }
            }
            return temp;
        }
    }
}