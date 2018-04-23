using System.Collections.Generic;
using AutoMapper;
using Szkolenie.Techniczne3.Infrastucture.Dto;
using Szkolenie.Techniczne3.Infrastucture.Repositories;
using SzkolenieTechniczne3.Core.Domain;
using SzkolenieTechniczne3.Core.Repositories;

namespace Szkolenie.Techniczne3.Infrastucture.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper)
        {
            _repository = new UserRepository();
            _mapper = mapper;
        }

        public UserDto Get(int id)
        {
            var user = _repository.Get(id);
            return _mapper.Map<UserDto>(user);
        }

        public IList<UserDto> GetAll()
        {
            var users = _repository.GetAll();
            return _mapper.Map<IList<UserDto>>(users);
        }

        public int InsertOrUpdate(UserDto item)
        {
            var user = _mapper.Map<User>(item);
            return _repository.InsertOrUpdate(user);
        }

        public void Remove(int id)
        {
            _repository.Remove(id);
        }
    }
}