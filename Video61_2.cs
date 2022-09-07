using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Practice_Day_6
{
    public partial class Video61
    {
        public string GetFullName()
        {
            return _firstname + " ," + _lastname;
        }
    }

    public partial class Video61_1
    {
        partial void SampleVideo61_1_Method(int i)
        {
            Console.WriteLine("Partial Method implemented in second file");
        }
    }

    }
