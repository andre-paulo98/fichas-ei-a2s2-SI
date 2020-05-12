using System.Collections.Generic;

namespace AuthService {
    public class AuthService : IAuthService {

        /// <summary>
        /// Exemplo
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string VerifyAcessToBD() {
            User user = SqlServerHelper.GetUser(1);
            if (user == null)
                return "Erro ao aceder à base de dados";
            return user.Name;
        }


        public User[] GetUsers(string username, string password) {
            if (SqlServerHelper.UserExists(username, password) > 0) {
                List<User> users = SqlServerHelper.GetUsers();
                return users.ToArray();
            }
            return null;
        }

        public string GetUserDescription(string username) {
            User user = SqlServerHelper.GetUser(username);
            if(user != null) {
                return user.Description;
            }
            return null;
        }

        public bool SetUserDescription(string login, string password, string description) {
            int id = SqlServerHelper.UserExists(login, password);
            if (id == 0) {
                return false;
            }
            return SqlServerHelper.UpdateUserDescription(id, description) == 1;
        }
    }

}
