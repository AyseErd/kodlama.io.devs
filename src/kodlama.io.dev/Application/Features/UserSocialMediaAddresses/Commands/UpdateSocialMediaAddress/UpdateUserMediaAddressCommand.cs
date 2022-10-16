using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.UserSocialMediaAddresses.Dtos;
using Microsoft.EntityFrameworkCore;
using Application.Features.UserSocialMediaAddresses.Rules;

namespace Application.Features.UserSocialMediaAddresses.Commands.UpdateSocialMediaAddress
{
    public class UpdateUserMediaAddressCommand : IRequest<UpdatedUserSocialMediaAddressDto>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string SocialMediaAddressUrl { get; set; }

        public class UpdateUserSocialMediaAddressCommandHandler : IRequestHandler<UpdateUserMediaAddressCommand,
            UpdatedUserSocialMediaAddressDto>
        {
            private readonly IUserSocialMediaAddressRepository _userSocialMediaAddressRepository;
            private readonly IMapper _mapper;
            private readonly UserSocialMediaAddressesRules _userSocialMediaAddressBusinessRules;

            public UpdateUserSocialMediaAddressCommandHandler(
                IUserSocialMediaAddressRepository userSocialMediaAddressRepository, IMapper mapper,
                UserSocialMediaAddressesRules userSocialMediaAddressBusinessRules)
            {
                _userSocialMediaAddressRepository = userSocialMediaAddressRepository;
                _mapper = mapper;
                _userSocialMediaAddressBusinessRules = userSocialMediaAddressBusinessRules;
                // Added User Social Media Address Entity
            }

            public async Task<UpdatedUserSocialMediaAddressDto> Handle(UpdateUserMediaAddressCommand request,
                CancellationToken cancellationToken)
            {
                await _userSocialMediaAddressBusinessRules.UserSocialMediaAddressUrlCanNotBeDuplicated(
                    request.SocialMediaAddressUrl);

                var userSocialMediaAddress =
                    await _userSocialMediaAddressRepository.GetAsync(sm => sm.Id == request.Id);

                await _userSocialMediaAddressBusinessRules.UserShouldBeExist(request.UserId);
                await _userSocialMediaAddressBusinessRules.SocialMediaAddressShouldExistWhenRequested(
                    userSocialMediaAddress);

                userSocialMediaAddress.SocialMediaUrl = request.SocialMediaAddressUrl;

                  var updatedUserSocialMediaAddress =
                    await _userSocialMediaAddressRepository.UpdateAsync(userSocialMediaAddress);
                var mappedUpdatedUserSocialMediaAddressDto =
                    _mapper.Map<UpdatedUserSocialMediaAddressDto>(updatedUserSocialMediaAddress);
                return mappedUpdatedUserSocialMediaAddressDto;
            }
        }
    }
}