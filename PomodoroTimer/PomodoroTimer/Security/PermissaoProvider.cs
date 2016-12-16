
using PomodoroTimerDominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;

namespace PomodoroTimer.Security
{
    public class PermissaoProvider : RoleProvider
    {
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        //implementando como obter as permissoes de cada usuario
        public override string[] GetRolesForUser(string username)
        {
            Entities _ctx = new Entities();//adicionando um novo contexto
            
            //Retorna Usuario localizado, se Usuario constar no banco
            Login login = _ctx.Login.FirstOrDefault(l => l.Username.Equals(username)); 

            if(login == null)
            {
                return new String[] { };
            }
            
            //Seleciona as permissoes do usuario - Os modelos estao em Dominio/Models
            List<string> permissoes = login.Permissao.Select(p => p.Permissao1).ToList();
            
            //Converter para um array
            return permissoes.ToArray();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
