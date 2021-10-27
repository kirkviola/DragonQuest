using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonQuest.Items
{
    public class Tonic : Item
    {
        public Tonic() {
            this.Name = "Tonic";
            this.Description = "This will increase one of your attributes by one point";
            this.Value = 1;
        }
    }
}
