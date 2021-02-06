using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Infrastuture
{
    public static class CookieExtension
    {
        public static void WriteCookie(this HttpContext httpContext,string key, object value)
        {

           string serial= JsonConvert.SerializeObject(value);
            CookieOptions options = new CookieOptions();
         
            options.Expires = DateTimeOffset.Now.AddDays(3);
          
            options.HttpOnly = true;
        

            string data=Encyptor.Encrypt(serial, "123");
            httpContext.Response.Cookies.Append(key, data, options);
        }

        public static T ReadCookie<T>(this HttpContext httpContext,string Key)
        {
            string value=httpContext.Request.Cookies[Key];
            value = Encyptor.Decrypt(value, "123");
            return JsonConvert.DeserializeObject<T>(value);
        }

        //public static void DeleteCookie(string key, HttpContext httpContext)
        //{
        //    httpContext.Response.Cookies.Delete(key);
        //}
    }
}
