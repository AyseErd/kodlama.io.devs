using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserSocialMediaAddresses.Dtos
{
    public class CreatedSocialMediaAddressDto
    {
        public string Id { get; set; }
        public int UserId { get; set; }
        public string socialMediaUrl { get; set; }
    }
}
