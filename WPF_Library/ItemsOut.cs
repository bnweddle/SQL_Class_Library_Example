using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Library
{
    public class ItemsOut
    {
        public int BookID { get; }

        public string Title { get; }

        public DateTime CheckOut { get; }

        /// <summary>
        /// New triggers this 
        /// </summary>
        public ItemsOut(int bookID, string title, DateTime checkout)
        {
            BookID = bookID;
            Title = title;
            CheckOut = checkout;
        }
    }
}
