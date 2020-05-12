using System;
using System.Windows.Forms;
using WindowsClient.ServiceReference_AuthService;


namespace WindowsClient {
    public partial class FormMain : Form {
        public FormMain() {
            InitializeComponent();
        }


        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e) {

        }


        /// <summary>
        /// Obter a lista de utilizadores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGetUsers_Click(object sender, EventArgs e) {

            using (AuthServiceClient service = new AuthServiceClient()) {
                var users = service.GetUsers(txtLogin.Text, txtPassword.Text);
                if(users != null) {
                    lboxUsers.DataSource = users;
                    lboxUsers.DisplayMember = "Name";
                    lboxUsers.ValueMember = "Login";
                } else {
                    MessageBox.Show("Something went wrong while getting users.");
                    lboxUsers.DataSource = null;
                }
            }

            //// versão 1
            //lboxUsers.DataSource = users;
            //lboxUsers.DisplayMember = "Name";
            //lboxUsers.ValueMember = "Login";

            //// versão 2
            //lboxUsers.Items.Clear();
            //foreach (User user in users)
            //{
            //  lboxUsers.Items.Add(user.Login);
            //}

        }


        /// <summary>
        /// Obter a descrição de um utilizador 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGetDescription_Click(object sender, EventArgs e) {
            // proteção para que não se execute esta funcionalidade sem que um utilizador esteja selecionado
            if (lboxUsers.SelectedIndex == -1) {
                MessageBox.Show("tem que escolher um utilizador!");
                return;
            }

            using (AuthServiceClient service = new AuthServiceClient()) {
                string login = (string)lboxUsers.SelectedValue;
                string description = service.GetUserDescription(login);

                txtDescription.Text = description;
            }

            // todo: linha selecionada na listbox.... ((string)lboxUsers.SelectedValue)

        }

        /// <summary>
        /// Atualizar a descrição de um utilizador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSetDescription_Click(object sender, EventArgs e) {
            try {
                this.Cursor = Cursors.WaitCursor;
                Application.DoEvents();

                using (AuthServiceClient service = new AuthServiceClient()) {
                    string login = txtLogin.Text;
                    string password = txtPassword.Text;
                    string description = txtMyDescription.Text;

                    bool result = service.SetUserDescription(login, password, description);
                    if(result) {
                        MessageBox.Show("A descrição foi atualizada com sucesso.");
                    } else {
                        MessageBox.Show("Ocorreu um erro ao atualizar a descrição");
                    }
                    
                }

                // lembrar de usar o "using"

            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            } finally {
                this.Cursor = Cursors.Default;
            }
        }


    }
}
