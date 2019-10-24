using System;
using System.Collections.Generic;
using System.Linq;

namespace WcfChat
{
    public class ChatEngine
    {
        private readonly Dictionary<string, List<ChatMessage>> _incomingMessages = new Dictionary<string, List<ChatMessage>>();
        public List<ChatUser> ConnectedUsers { get; } = new List<ChatUser>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ChatUser AddNewChatUser(ChatUser user)
        {
            var exists =
                from ChatUser e in this.ConnectedUsers
                where e.UserName == user.UserName
                select e;

            if (!exists.Any())
            {
                ConnectedUsers.Add(user);
                _incomingMessages.Add(user.UserName, new List<ChatMessage>
                {
                    new ChatMessage(){User=user,Message="Welcome to WPF simple chat",Date=DateTime.Now}
                });

                Console.WriteLine("New user connected: " + user);
                return user;
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newMessage"></param>
        public void AddNewMessage(ChatMessage newMessage)
        {
            Console.WriteLine(newMessage.User.UserName + " says :" + newMessage.Message + " at " + newMessage.Date);

            //se envian mensajes a todos los usuarios conectados menos al que lo envia
            foreach (var user in this.ConnectedUsers)
            {
                if (!newMessage.User.UserName.Equals(user.UserName))
                {
                    _incomingMessages[user.UserName].Add(newMessage);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ChatMessage> GetNewMessages(ChatUser user)
        {
            //se obtienen los nuevos mensajes
            List<ChatMessage> myNewMessages = _incomingMessages[user.UserName];
            //se borran de la "bandeja de entrada"
            _incomingMessages[user.UserName] = new List<ChatMessage>();

            if (myNewMessages.Count > 0)
                return myNewMessages;
            else
                return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public void RemoveUser(ChatUser user)
        {
            this.ConnectedUsers.RemoveAll(u => u.UserName == user.UserName);
        }
    }
}
