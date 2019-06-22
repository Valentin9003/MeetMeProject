using MeetMe.Data;
using MeetMe.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetMe.Web.Hubs
{
    public class ChatHub : Hub
    {
        //TODO: ChatHub
        private readonly HubConnectionContext connection;
        private readonly IUserIdProvider provider;
        private readonly MeetMeDbContext db;
        public ChatHub(MeetMeDbContext db, IUserIdProvider provider, HubConnectionContext connection)
        {
            this.provider = provider;
            this.connection = connection;
            this.db = db;
        }

        public async Task AllFriendsOnCurrentUser()
        {
            var userId =   provider.GetUserId(connection);
            var FriendsList = await db.User.Where(u => u.Id == userId)
                .Include(f => f.Friends)
                .Include(c => c.Contacts)
                .Select(rr => rr.Friends.ToList().Concat(rr.Contacts.ToList())).ToListAsync();


        }

        public async Task SendMessage(string message, string targetUserName)
        {
            var userId = provider.GetUserId(connection);
            var userName = this.Context.User.Identity.Name;

            if (true)
            {
                //Is Connected
            }
            else
            {
                //Is Not Connected

            }
        }
        public async Task Recieve(object user, string message)
        {


        }

    }

    //[[[
  
        public class CustomUserIdProvider : IUserIdProvider
    {
        // Get Current UserID from ASP.NET Identity
        public readonly MeetMeDbContext db;
        public readonly UserManager<User> userManager;
        public CustomUserIdProvider(MeetMeDbContext db, UserManager<User> userManager)
        {
            this.db = db;
            this.userManager = userManager;
            
        }

        public string GetUserId(HubConnectionContext connection)
        {
            var userId = userManager
                .FindByEmailAsync(connection.User.Identity.Name)
                .GetAwaiter()
                .GetResult()
                .Id;

            return userId.ToString();
        }
    }
    //]]]
}
