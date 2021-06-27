using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Lab16
{
    public interface IHttpClientHandlerService
    {
        HttpClientHandler GetInsecuretHandler();
    }
}
