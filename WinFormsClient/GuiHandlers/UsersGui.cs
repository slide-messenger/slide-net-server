using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Entities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using WinFormsClient.Api;

namespace WinFormsClient.GuiHandlers
{
    public class UsersGui : GuiHandler
    {
        public User CurrentUser = new();
        public UsersGui(Main main) : base(main)
        {
        }
        public async Task<bool> UpdateCurrentUser(string? username = null)
        {
            var user = await ReadFromJson<User>(
                UsersApi.Get(username ?? CurrentUser.UserId.ToString()));
            if (user is null) { return false; }
            CurrentUser = user;

            return true;
        }
    }
}
