using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOrderSystem
{
    public class OnlineOrder
    {
        private int _orderNumber = 0;
        public string Name;
        private DateTime timeOfOrder;
        public static int amountOfOrders;


        public DateTime _TimeOfOrder
        {
            get { return timeOfOrder; }
        }



        public OnlineOrder(string name)
        {
            Name = name;
            timeOfOrder = DateTime.Now;
            amountOfOrders++;
            Console.WriteLine($"{amountOfOrders} total order(s) made!\n");
            _orderNumber = amountOfOrders;
        }

     

    }
}
