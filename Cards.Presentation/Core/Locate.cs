using System;
using System.Web;
using Cards.Lobby;
using Cards.Lobby.User;
using Cards.Presentation.Messaging.Pipeline.Exceptions;
using Microsoft.AspNet.SignalR.Hubs;
using StructureMap;

namespace Cards.Presentation.Core
{
    public class LocateBase
    {
        protected static IContainer Container { get; private set; }

        public static void SetContainer(IContainer container)
        {
            Container = container;
        }
        
    }

    public class Locate<T> : LocateBase
    {
        public static T Instance { get { return Container.GetInstance<T>(); } }

       
    }

    public static class Get
    {
        public static Player CurrentPlayer
        {
            get
            {
                return GetPlayerByName(HttpContext.Current.User.Identity.Name);
            }
        }

        public static Player CurrentPlayerFromContext(HubCallerContext hubContext)
        {
            return GetPlayerByName(hubContext.User.Identity.Name);
        }

        private static Player GetPlayerByName(string name)
        {
            var player = Locate<IUserManager>.Instance.GetPlayer(name);
            if (player.IsSuccessful)
                return player.Result;

            throw new NotFoundException("Player Not Found");
        }

        
    }
}