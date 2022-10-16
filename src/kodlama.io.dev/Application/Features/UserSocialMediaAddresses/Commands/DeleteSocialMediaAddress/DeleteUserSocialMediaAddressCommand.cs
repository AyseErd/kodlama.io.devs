using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.UserSocialMediaAddresses.Dtos;
using Application.Features.UserSocialMediaAddresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.UserSocialMediaAddresses.Commands.DeleteSocialMediaAddress;

public class DeleteUserSocialMediaAddressCommand : IRequest<DeletedUserSocialMediaAddressDto>
{
    public int Id { get; set; }

    public class DeleteUserSocialMediaAddressCommandHandler : IRequestHandler<DeleteUserSocialMediaAddressCommand,
        DeletedUserSocialMediaAddressDto>
    {
        private readonly IUserSocialMediaAddressRepository _userSocialMediaAddressRepository;
        private readonly IMapper _mapper;
        private readonly UserSocialMediaAddressesRules _userSocialMediaAddressBusinessRules;

        public DeleteUserSocialMediaAddressCommandHandler(
            IUserSocialMediaAddressRepository userSocialMediaAddressRepository, IMapper mapper,
            UserSocialMediaAddressesRules userSocialMediaAddressBusinessRules)
        {
            _userSocialMediaAddressRepository = userSocialMediaAddressRepository;
            _mapper = mapper;
            _userSocialMediaAddressBusinessRules = userSocialMediaAddressBusinessRules;
        }

        public async Task<DeletedUserSocialMediaAddressDto> Handle(DeleteUserSocialMediaAddressCommand request,
            CancellationToken cancellationToken)
        {
            var userSocialMediaAddress = await _userSocialMediaAddressRepository.GetAsync(x => x.Id == request.Id);
            _userSocialMediaAddressBusinessRules.SocialMediaAddressShouldExistWhenRequested(userSocialMediaAddress);

            var deletedUserSocialMediaAddress =
                await _userSocialMediaAddressRepository.DeleteAsync(userSocialMediaAddress);
            var mappedDeletedUserSocialMediaAddressDto =
                _mapper.Map<DeletedUserSocialMediaAddressDto>(deletedUserSocialMediaAddress);
            return mappedDeletedUserSocialMediaAddressDto;
        }
    }
}
