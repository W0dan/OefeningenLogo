using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OefeningenLogo.UI._Extensions
{
    public static class ListviewExtensions
    {
        public static IEnumerable<ListViewItem> GetItems(this ListView lv)
        {
            return lv.Items.Cast<ListViewItem>();
        }
    }
}