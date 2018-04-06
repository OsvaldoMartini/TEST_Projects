using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Binding.StaticResource.AddNew.Model
{
    public class ListOfStrings : List<String>
    {
        public ListOfStrings()
        {
            this.Add("Vodka");
            this.Add("Whiskey");
            this.Add("Run   ");
            this.Add("Wine");
            this.Add("Pepsi");
            this.Add("Fanta");
            this.Add("Coca-Cola");
            this.Add("Water");

        }
    }
}
