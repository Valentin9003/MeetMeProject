using MeetMe.Data;
using MeetMe.Data.Models;
using MeetMe.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//TODO

namespace MeetMe.Web.Hubs
{
    public static class UserHandler
    {
        public static HashSet<string> connectedIds;

    }
    public class ChatHub : Hub
    {
        //TODO: ChatHub
        private readonly IChatHubService service;
        private readonly HubConnectionContext connection;
        private readonly IUserIdProvider provider;
        private readonly MeetMeDbContext db;
        public ChatHub(MeetMeDbContext db, IUserIdProvider provider, HubConnectionContext connection, IChatHubService chatHubService)
        {
            this.provider = provider;
            this.connection = connection;
            this.db = db;
            this.service = chatHubService;
        }

        public async Task OnlineFriendsOnCurrentUser()
        {
            var userId = provider.GetUserId(connection);
         
            var friends = await db.User.Where(u => u.Id == userId)
                .Include(f => f.Friends)  // TODO   ????
                .Include(c => c.Contacts)
                .Select(rr => rr.Friends.ToList().Concat(rr.Contacts.ToList())).FirstOrDefaultAsync();


            var friendsList = MakeFriendsList(friends, userId);


        }

        private List<string> MakeFriendsList(IEnumerable<object> obj, string userId)
        {
            var onlineFriends = new List<string>();
            foreach (var item in obj.OfType<Friends>())   /// TOVA E ZA SYRVIS
            {
                var friend = item;
                var currentFriendId = item.ContactId == userId ? item.UserId : item.ContactId;


                if (UserHandler.connectedIds.Contains(currentFriendId))
                {
                    onlineFriends.Add(currentFriendId);
                }

            }
            return onlineFriends;
        }



        // Adds to HashSet with all online users and adds new ones when a user is online
        public override Task OnConnectedAsync()
        {
            var identityUserId = provider.GetUserId(connection);
            UserHandler.connectedIds.Add(identityUserId);
            return base.OnConnectedAsync();
        }


        // Removes users from HashSet with online users
        public override Task OnDisconnectedAsync(Exception exception)
        {
            var identityUserId = provider.GetUserId(connection);
            UserHandler.connectedIds.Remove(identityUserId);
            return base.OnDisconnectedAsync(exception);
        }
        public async Task SendMessage(string message, string targetUserName)
        {
            var identityUserId = provider.GetUserId(connection);
            var userName = this.Context.User.Identity.Name;



        }
        public async Task Recieve(object user, string message)
        {


        }

    }




    // Finds the ASP.NET user ID
    public class UserIdProvider : IUserIdProvider
    {
        // Get Current UserID from ASP.NET Identity
        public readonly MeetMeDbContext db;
        public readonly UserManager<User> userManager;
        public UserIdProvider(MeetMeDbContext db, UserManager<User> userManager)
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
