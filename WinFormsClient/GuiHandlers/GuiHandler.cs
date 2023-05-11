using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsClient.GuiHandlers
{
    public class GuiHandler
    {
        public Main MainForm;
        public GuiHandler(Main main)
        {
            MainForm = main;
        }
        public async Task<T?> ReadFromJson<T>(HttpResponseMessage response)
        {
            switch(response.StatusCode)
            {
                case HttpStatusCode.OK:
                    break;
                case HttpStatusCode.ServiceUnavailable:
                    MainForm.ShowErrorAsync();
                    return default;
                default:
                    MainForm.ShowErrorAsync(response.StatusCode.ToString());
                    return default;
            }
            var result = await response.Content.ReadFromJsonAsync<T>();
            if (result is null)
            {
                MainForm.ShowErrorAsync("JsonConvertationFailed");
                return default;
            }
            return result;
        }
        public async Task<T?> ReadFromJson<T>(Task<HttpResponseMessage> responseTask)
        {
            return await ReadFromJson<T>(await responseTask);
        }
    }
}
