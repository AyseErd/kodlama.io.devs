using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.LanguageFrameworks.Constants;
using Application.Features.UserSocialMediaAddresses.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.UserSocialMediaAddresses.Rules
{
    public class UserSocialMediaAddressesRules
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserSocialMediaAddressRepository _socialMediaAddressRepository;

        public UserSocialMediaAddressesRules(IUserRepository userRepository, IUserSocialMediaAddressRepository socialMediaAddressRepository)
        {
            _userRepository = userRepository;
            _socialMediaAddressRepository = socialMediaAddressRepository;
        }

        public async Task UserShouldBeExist(int requestUserId)
        {
            var user = await _userRepository.GetAsync(x => x.Id == requestUserId);

            if (user is null)
                throw new BusinessException(UserSocialMediaAddressMessages.UserNotFound);
        }

        public async Task UserSocialMediaAddressUrlCanNotBeDuplicated(string requestSocialMediaUrl)
        {
            IPaginate<UserSocialMediaAddress>
                result = await _socialMediaAddressRepository.GetListAsync(lf => lf.SocialMediaUrl == requestSocialMediaUrl);
            if (result.Items.Any()) throw new BusinessException(UserSocialMediaAddressMessages.SocialMediaUrlCannotBeDuplicated);
        }

        public async Task SocialMediaAddressShouldExistWhenRequested(UserSocialMediaAddress? userSocialMediaAddress)
        {
            if (userSocialMediaAddress is null)
                throw new BusinessException(UserSocialMediaAddressMessages.UserSocialMediaAddressIsNotFound);
        }
    }
}
