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

namespace ClassesPartilhadas.Classes
{
    public class AMessage
    {   
        //Aquilo que enviamos no socket
        public byte[] Data { get; set; }
    }
}