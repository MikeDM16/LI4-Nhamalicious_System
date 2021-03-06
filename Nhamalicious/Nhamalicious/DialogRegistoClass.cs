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
using ClassesPartilhadas;
using Java.Interop;

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
        private Utilizador u;

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

        public Utilizador Utilizador
        {
            get { return u; }
            set { u = value; }
        }


        public OnRegistoEventArgs(Utilizador u) : base()
        {
            Utilizador = u;
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
        private RadioGroup mRadioGroup;
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
            mRadioGroup = view.FindViewById<RadioGroup>(Resource.Id.radioGroup1);
            mBtnRegisto = view.FindViewById<Button>(Resource.Id.btnRegisto);
          

            mBtnRegisto.Click += MBtnRegisto_Click;
            return view;
        }

        private void MBtnRegisto_Click(object sender, EventArgs e)
        {
            RadioButton checkedRD = View.FindViewById<RadioButton>(mRadioGroup.CheckedRadioButtonId);
            if (mTxtPassword != mTxtConfirmPassword)
            {
                //Aparecer pop up a dizer que as passwords sao diferentes
            }
            if (checkedRD.Text == "Registo como Cliente")
            {
                string nome, username, password, email;
                int idade;
                nome = mTxtNome.Text; username = mTxtUsername.Text;
                password = mTxtPassword.Text; email = mTxtEmail.Text;
                idade = Convert.ToInt32(mTxtIdade.Text);
                Utilizador u = new Cliente((-1), nome, idade, username, password, email, null, null, null);



                RegistoEfetuado.Invoke(this, new OnRegistoEventArgs(u));
                this.Dismiss();
            }
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;
        }
    }
}