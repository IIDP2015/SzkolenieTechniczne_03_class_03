using System.Collections.Generic;
using Szkolenie.Techniczne3.Infrastucture.Dto;

namespace Szkolenie.Techniczne3.Infrastucture.Services
{
    public interface IUserService
    {
        UserDto Get(int id);
        IList<UserDto> GetAll();
        int InsertOrUpdate(UserDto item);
        void Remove(int id);
    }
}