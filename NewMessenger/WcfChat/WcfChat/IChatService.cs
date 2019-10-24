using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WcfChat
{
    [ServiceContract(SessionMode = SessionMode.Allowed)]
    public interface IChatService
    {
        [OperationContract]
        ChatUser ClientConnect(string userName);

        [OperationContract]
        List<ChatMessage> GetNewMessages(ChatUser user);

        [OperationContract]
        void SendNewMessage(ChatMessage newMessage);

        [OperationContract]
        List<ChatUser> GetAllUsers();

        [OperationContract]
        void RemoveUser(ChatUser user);
    }

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class ChatMessage
    {
        [DataMember]
        public ChatUser User { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public DateTime Date { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class ChatUser
    {
        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string IpAddress { get; set; }

        [DataMember]
        public string HostName { get; set; }

        public override string ToString()
        {
            return this.UserName;
        }
    }
}
