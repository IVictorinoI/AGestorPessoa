using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Login.Dto
{
    public class ExternalAuthenticationDto
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
