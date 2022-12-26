namespace Tareq.Api.Pos.Interface
{
    public interface IRefreshTokenGenerator
    {
        string GenerateToken(string username);
    }
}
