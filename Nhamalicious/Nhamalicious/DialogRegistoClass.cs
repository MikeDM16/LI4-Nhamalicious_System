using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Nhamalicious
{
    public class OnRegistoEventArgs : EventArgs
    {
        private string mNome;
        private string mIdade;
        private string mUsername;
        private string mEmail;
        private string mPassword;
        private string mConfirmPassword;

        public string Nome
        {
            get { return mNome; }
            set { mNome = value; }
        }
        public string Idade
        {
            get { return mIdade; }
            set { mIdade = value; }
        }
        public string Username
        {
            get { return mUsername; }
            set { mUsername = value; }
        }
        public string Email
        {
            get { return mEmail; }
            set { mEmail = value; }
        }
        public string Password
        {
            get { return mPassword; }
            set { mPassword = value; }
        }

        public string ConfirmPassword
        {
            get { return mConfirmPassword; }
            set { mConfirmPassword = value; }
        }

        public OnRegistoEventArgs(string nome, string idade, string username, string email, string password, string confirmPassword) : base()
        {
            Nome = nome;
            Idade = idade;
            Username = username;
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
        }
    }
    class DialogRegistoClass : DialogFragment
    {
        private EditText mTxtNome;
        private EditText mTxtIdade;
        private EditText mTxtUsername;
        private EditText mTxtEmail;
        private EditText mTxtPassword;
        private EditText mTxtConfirmPassword;
        private Button mBtnRegisto;

        public event EventHandler<OnRegistoEventArgs> RegistoEfetuado;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.DialogPagRegisto, container, false);

            mTxtNome = view.FindViewById<EditText>(Resource.Id.txtNome);
            mTxtIdade = view.FindViewById<EditText>(Resource.Id.txtIdade);
            mTxtUsername = view.FindViewById<EditText>(Resource.Id.txtUsername);
            mTxtEmail = view.FindViewById<EditText>(Resource.Id.txtEmail);
            mTxtPassword = view.FindViewById<EditText>(Resource.Id.txtPassword);
            mTxtConfirmPassword = view.FindViewById<EditText>(Resource.Id.txtConfirmPassword);
            mBtnRegisto = view.FindViewById<Button>(Resource.Id.btnRegisto);

            mBtnRegisto.Click += MBtnRegisto_Click;
            return view;
        }

        private void MBtnRegisto_Click(object sender, EventArgs e)
        {
            RegistoEfetuado.Invoke(this, new OnRegistoEventArgs(mTxtNome.Text, mTxtIdade.Text, mTxtUsername.Text, mTxtEmail.Text, mTxtPassword.Text, mTxtConfirmPassword.Text));
            this.Dismiss();
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;
        }
    }
}