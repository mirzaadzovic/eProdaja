using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using Flurl;
using eProdaja.Model;

namespace eProdaja.WinForms
{
    public class APIService
    {
        private string _route = null;

        public APIService(string route)
        {
            _route = route;
        }

        public async Task<T> Get<T>(object request=null)
        {
            string url = $"{Properties.Settings.Default.APIUrl}/{_route}";
            if (request != null)
            {
                url += "?";
                url += await request.ToQueryString();
            }

            var result = await url.GetJsonAsync<T>();
            return result;
        }
        public async Task<T> GetById<T>(object id)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";
            var result = await url.GetJsonAsync<T>();
            return result;
        }
        public async Task<T> Update<T>(object id, object request)
        {
            string url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";
            var result = await url.PutJsonAsync(request).ReceiveJson<T>();
            return result;
        }
        public async Task<T> Insert<T>(object request)
        {
            string url = $"{Properties.Settings.Default.APIUrl}/{_route}";
            var result = await url.PostJsonAsync(request).ReceiveJson<T>();
            return result;
        }
    }
}
