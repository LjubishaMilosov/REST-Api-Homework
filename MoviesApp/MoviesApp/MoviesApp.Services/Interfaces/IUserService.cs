using MoviesApp.Dtos;

namespace MoviesApp.Services.Interfaces
{
    public interface IUserService
    {
        void RegisterUser(RegisterUserDto registerUserDto);

        // login method returns a string- the token that we will use
        string Login(LoginUserDto loginUserDto);
    }
}
