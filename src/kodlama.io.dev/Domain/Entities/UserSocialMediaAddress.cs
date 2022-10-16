using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Domain.Enums;

namespace Domain.Entities
{
    public class UserSocialMediaAddress:Entity
    {
        public string UserId { get; set; }
        public SocialMediaType SocialMediaType { get; set; }
        public string SocialMediaUrl { get; set; }
        public User? User { get; set; }

        public UserSocialMediaAddress()
        {
        }

        public UserSocialMediaAddress(int id,string userId, SocialMediaType socialMediaType, string socialMediaUrl)
        {
            Id = id;
            UserId = userId;
            SocialMediaType = socialMediaType;
            SocialMediaUrl = socialMediaUrl;
        }
    }
}
