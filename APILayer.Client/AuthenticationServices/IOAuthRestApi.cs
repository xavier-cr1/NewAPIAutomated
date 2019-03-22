using CrossLayer.Models.API;
using System;
using System.Collections.Generic;
using System.Text;

namespace APILayer.Client.Authentication
{
    public interface IOAuthRestApi
    {
        Token RequestOAuthToken();
    }
}
