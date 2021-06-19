using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Lab15.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(HttpClienteHandlerService))]
namespace Lab15.Droid
{
    class HttpClienteHandlerService : IHttpClientHandlerService
    {
        public HttpClientHandler GetInsecuretHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) =>
                {
                    if (cert.Issuer.Equals("CN=192.168.100.22"))
                    {
                        return true;
                    }
                    return errors == System.Net.Security.SslPolicyErrors.None;
                };
            return handler;
        }
    }
}