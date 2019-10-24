using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WcfChat;
using System.ServiceModel;

namespace ChatClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            lblStatus.Text = "Disconnected";
        }

        private ChannelFactory<IChatService> _remoteFactory;
        private IChatService _remoteProxy;
        private ChatUser _clientUser;
        private bool _isConnected;


        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Connecting...";
                LoginForm loginDialog = new LoginForm();
                loginDialog.ShowDialog(this);
                if (!String.IsNullOrEmpty(loginDialog.UserName))
                {
                    _remoteFactory = new ChannelFactory<IChatService>("ChatConfig");
                    _remoteProxy = _remoteFactory.CreateChannel();
                    _clientUser = _remoteProxy.ClientConnect(loginDialog.UserName);

                    if (_clientUser != null)
                    {
                        usersTimer.Enabled = true;
                        messagesTimer.Enabled = true;
                        loginToolStripMenuItem.Enabled = false;
                        btnSend.Enabled = true;
                        txtMessage.Enabled = true;
                        _isConnected = true;
                        lblStatus.Text = "Connected as: " + _clientUser.UserName;
                    }
                }
                else
                    lblStatus.Text = "Disconnected";
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has ocurred\nClient cannot connect\nMessage:" + ex.Message,
                    "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void usersTimer_Tick(object sender, EventArgs e)
        {
            List<ChatUser> listUsers = _remoteProxy.GetAllUsers();
            lstUsers.DataSource = listUsers;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtMessage.Text))
            {
                ChatMessage newMessage = new ChatMessage()
                {
                    Date = DateTime.Now,
                    Message = txtMessage.Text,
                    User = _clientUser
                };

                _remoteProxy.SendNewMessage(newMessage);
                InsertMessage(newMessage);
                txtMessage.Text = String.Empty;
            }


        }

        private void messagesTimer_Tick(object sender, EventArgs e)
        {
            List<ChatMessage> messages = _remoteProxy.GetNewMessages(_clientUser);

            if (messages != null)
                foreach (var message in messages)
                    InsertMessage(message);
        }

        private void InsertMessage(ChatMessage message)
        {
            txtChat.AppendText("\n" + message.User.UserName + " says (" + message.Date + "):\n" + message.Message + "\n" + Environment.NewLine);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isConnected)
            {
                _remoteProxy.SendNewMessage(new ChatMessage()
                {
                    Date = DateTime.Now,
                    Message = "i'm logged out",
                    User = _clientUser
                });
                _remoteProxy.RemoveUser(_clientUser);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)13)
            //{
            //    btnSend_Click(sender, e);
            //    txtChat.Text = String.Empty;
            //}

        }
    }
}
