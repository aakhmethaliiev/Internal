using System.Collections.Generic;
using System.ServiceModel;

namespace WcfChat
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ChatService : IChatService
    {
        private readonly ChatEngine _mainEngine = new ChatEngine();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public ChatUser ClientConnect(string userName)
        {
            return _mainEngine.AddNewChatUser(new ChatUser() { UserName = userName });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public List<ChatMessage> GetNewMessages(ChatUser user)
        {
            return _mainEngine.GetNewMessages(user);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newMessage"></param>
        public void SendNewMessage(ChatMessage newMessage)
        {
            _mainEngine.AddNewMessage(newMessage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ChatUser> GetAllUsers()
        {
            return _mainEngine.ConnectedUsers;
        }

        public void RemoveUser(ChatUser user)
        {
            _mainEngine.RemoveUser(user);
        }


    }
}
