using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bookstore.common.presentation
{
    public static class ScreenService
    {
        public static void FlowLayout_ChangeSize(object sender, EventArgs e)
        {
            if(sender is FlowLayoutPanel fLayout)
            {
                foreach(Control widget in fLayout.Controls)
                {
                    widget.Size = GetValidSizeWidget(widget, fLayout);
                }
            }
        }

        public static Size GetValidSizeWidget(Control widget, Control parent)
        {
            return new Size(parent.Width - parent.Padding.Horizontal - widget.Margin.Horizontal, widget.Height);
        }

        public static LinkLabel[] GeneratePages(long page, long maxPage, Action<long> changePage)
        {
            LinkLabel[] pages = new LinkLabel[maxPage + 2];
            pages[0] = new LinkLabel()
            {
                Text = ">",
                LinkColor = Color.Black,
                LinkBehavior = LinkBehavior.NeverUnderline,
                AutoSize = true
            };
            pages[0].LinkClicked += (sender, e) =>
            {
                changePage?.Invoke(page + 1);
            };
            pages[pages.Length - 1] = new LinkLabel()
            {
                Text = "<",
                LinkColor = Color.Black,
                LinkBehavior = LinkBehavior.NeverUnderline,
                AutoSize = true
            };
            pages[pages.Length - 1].LinkClicked += (sender, e) =>
            {
                changePage?.Invoke(page - 1);
            };
            for (int i = pages.Length - 2; i > 0; i--)
            {
                int localIndex = i;
                pages[i] = new LinkLabel()
                {
                    Text = (maxPage - i + 1).ToString(),
                    LinkColor = Color.Black,
                    LinkBehavior = maxPage - i == page ? LinkBehavior.AlwaysUnderline : LinkBehavior.NeverUnderline,
                    AutoSize = true
                };
                pages[i].LinkClicked += (sender, e) =>
                {
                    changePage?.Invoke(maxPage - localIndex);
                };
            }

            return pages;
        }
    }
}
