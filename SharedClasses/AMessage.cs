using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedClasses
{
    public class AMessage
    {   
        //Aquilo que enviamos no socket
        public byte[] Data { get; set; }
    }
}