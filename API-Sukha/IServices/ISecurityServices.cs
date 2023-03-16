namespace API_Sukha.IServices
{
    public interface ISecurityServices
    {
        bool ValidateUserCredentials(string userUsuario, string userPassWord, int idRol);
    }
}
