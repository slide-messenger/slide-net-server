using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Entities;

namespace WinFormsClient.GuiHandlers
{
    public class UsersGui : GuiHandler
    {
        public User CurrentUser = new();
        public UsersGui(Main main) : base(main)
        {
        }
    }
}
