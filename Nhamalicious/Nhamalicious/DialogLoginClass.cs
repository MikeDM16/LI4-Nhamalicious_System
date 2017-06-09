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
    public class OnLoginEventArgs : EventArgs
    {
        private string mUsername;
        private string mPassword;

        public string Username
        {
            get { return mUsername; }
            set { mUsername = value; }
        }

        public string Password
        {
            get { return mPassword; }
            set { mPassword = value; }
        }

        public OnLoginEventArgs(string username, string password) : base()
        {
            Username = username;
            Password = password;
        }
    }
    class DialogLoginClass : DialogFragment
    {
        private EditText mTxtUsername;
        private EditText mTxtPassword;
        private Button mBtnLogInReal;

        public event EventHandler<OnLoginEventArgs> LoginEfetuado;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.DialogLogIn, container, false);

            mTxtUsername = view.FindViewById<EditText>(Resource.Id.txtUsername);
            mTxtPassword = view.FindViewById<EditText>(Resource.Id.txtPassword);
            mBtnLogInReal = view.FindViewById<Button>(Resource.Id.btnLogin);

            mBtnLogInReal.Click += MBtnLogInReal_Click;
            return view;
        }

        private void MBtnLogInReal_Click(object sender, EventArgs e)
        {
            LoginEfetuado.Invoke(this, new OnLoginEventArgs(mTxtUsername.Text, mTxtPassword.Text));
        }


        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;
        }
    }
}