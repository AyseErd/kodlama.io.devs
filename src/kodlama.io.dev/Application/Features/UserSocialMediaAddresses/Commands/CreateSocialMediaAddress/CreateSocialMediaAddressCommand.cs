using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.UserSocialMediaAddresses.Dtos;
using Application.Features.UserSocialMediaAddresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserSocialMediaAddresses.Commands.CreateSocialMediaAddress
{
    public class CreateSocialMediaAddressCommand:IRequest<CreatedSocialMediaAddressDto>
    {
        public int UserId  { get; set; }
        public string SocialMediaUrl { get; set; }
        public class CreateSocialMediaAddressCommandHandler:IRequestHandler<CreateSocialMediaAddressCommand,CreatedSocialMediaAddressDto>
        {
            private readonly IUserSocialMediaAddressRepository _socialMediaAddressRepository;
            private readonly IMapper _mapper;
            private readonly UserSocialMediaAddressesRules _userSocialMediaAddressesRules;

            public CreateSocialMediaAddressCommandHandler(IUserSocialMediaAddressRepository socialMediaAddressRepository, IMapper mapper, UserSocialMediaAddressesRules userSocialMediaAddressesRules)
            {
                _socialMediaAddressRepository = socialMediaAddressRepository;
                _mapper = mapper;
                _userSocialMediaAddressesRules = userSocialMediaAddressesRules;
            }

            public async Task<CreatedSocialMediaAddressDto> Handle(CreateSocialMediaAddressCommand request, CancellationToken cancellationToken)
            {
                await _userSocialMediaAddressesRules.UserShouldBeExist(request.UserId);
                await _userSocialMediaAddressesRules.UserSocialMediaAddressUrlCanNotBeDuplicated(request.SocialMediaUrl);

                var mappedUserSocialMediaAddress = _mapper.Map<UserSocialMediaAddress>(request);
                var createdUserSocialMediaAddress = await _socialMediaAddressRepository.AddAsync(mappedUserSocialMediaAddress);
                var mappedCreatedUserSocialMediaAddressDto = _mapper.Map<CreatedSocialMediaAddressDto>(createdUserSocialMediaAddress);
                return mappedCreatedUserSocialMediaAddressDto;

            }
        }
    }
}
