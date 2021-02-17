using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.IO;

namespace CustomerDetialsList
{   [Serializable]
    class Customer: ISerializable
    {
       public string fname
        {
            get;
            set;
        }
        public string lname { set; get; }
        public string address { set; get; }
        public int phoneno { get; set; }
        public string email { get; set; }

        public Customer(string fname,string lname,string address,int phoneno,string email)
        {
            this.fname = fname;
            this.lname = lname;
            this.address = address;
            this.phoneno = phoneno;
            this.email=email;
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("fname", fname);
            info.AddValue("lname", lname);
            info.AddValue("address", address);
            info.AddValue("phoneno", phoneno);
            info.AddValue("email", email);
        }

        public Customer(SerializationInfo info, StreamingContext context)
        {
            fname = (string)info.GetValue("fname", typeof(string));
            lname= (string)info.GetValue("lname", typeof(string));
            address = (string)info.GetValue("address", typeof(string));
            phoneno = (int)info.GetValue("phoneno", typeof(int));
            
            email = (string)info.GetValue("Name", typeof(string));
        }
    }
}
