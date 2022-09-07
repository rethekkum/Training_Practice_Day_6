using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Practice_Day_6
{
    public partial class Video61
    {
        private string _firstname;
        private string _lastname;

        public string Lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }
        public string Firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }
    }
        public partial class Video61_1
        {
        //partial methods private by default, even if we try declaring partial and return type must also be void
        //Partial Methods cant have virtual etc
        //we try to just add partial to a method it will fail because declaration and implementation must be separate.
        //partial method can be implemented only once
        
        partial void SampleVideo61_1_Method(int i);

        /*        partial void SampleVideo61_1_Method()
        {
            Console.WriteLine("Partial Method implemented in second file");
        }
        */

    public void Samplepublicmethod() 
        {
            Console.WriteLine("Sample public method without partial class");
            SampleVideo61_1_Method(1);
        }
        }
}
