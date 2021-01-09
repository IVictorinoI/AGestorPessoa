using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;
using Application.Users.View;

namespace Application.Login.View
{
    public class LoginView
    {
        public UserView User { get; set; }
        public string Token { get; set; }
    }
}
