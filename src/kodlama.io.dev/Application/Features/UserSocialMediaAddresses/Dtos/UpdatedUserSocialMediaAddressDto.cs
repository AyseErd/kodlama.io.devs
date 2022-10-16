using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Application.Features.UserSocialMediaAddresses.Dtos
{
    public class UpdatedUserSocialMediaAddressDto
    {
        public int Id { get; set; }
        public SocialMediaType SocialMediaType { get; set; }
        public string UserSocialMediaAddress { get; set; }
        public string UserEmail { get; set; }
    }
}
