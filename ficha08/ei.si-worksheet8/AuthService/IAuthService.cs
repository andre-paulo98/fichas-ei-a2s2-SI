using System.ServiceModel;

namespace AuthService {
    [ServiceContract]
    public interface IAuthService {
        /// <summary>
        /// Verifica se é possível aceder à BD
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        string VerifyAcessToBD();



        [OperationContract]
        User[] GetUsers(string username, string password);


        [OperationContract]
        string GetUserDescription(string username);


        [OperationContract]
        bool SetUserDescription(string login, string password, string description);

    }

}
