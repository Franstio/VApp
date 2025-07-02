using AutoScrewing.Database.Models;
using AutoScrewing.Database.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoScrewing.Dialogue
{
    public partial class LoginForm : Form
    {
        private readonly ConfigRepository configRepository = new ConfigRepository();
        private UserConfigModel? _user;
        public UserConfigModel? GetLogin()
        {
            return _user;
        }
        public LoginForm()
        {
            InitializeComponent();
            DialogResult = DialogResult.Abort;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
             _user = await configRepository.LoginAsync(usernameBox.Text,passwordBox.Text);
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
