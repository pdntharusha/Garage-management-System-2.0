using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Garage_management_System_2._0
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            PrintDocument printDocument = new PrintDocument();

            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
                printDocument.Print();
            }
        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font font = new Font("Arial", 12);

            float y = 100; // Initial vertical position

            // Header
            graphics.DrawString("Invoice", font, Brushes.Black, new PointF(100, y));
            y += 20;

            // Customer Information
            graphics.DrawString("Customer: " + txtCustomerName.Text, font, Brushes.Black, new PointF(100, y));
            y += 20;
            graphics.DrawString("Address: " + txtCustomerAddress.Text, font, Brushes.Black, new PointF(100, y));
            y += 40;

            // Invoice Items (Assuming you have a list of invoice items named 'invoiceItems')
            graphics.DrawString("Item Name", font, Brushes.Black, new PointF(100, y));
            graphics.DrawString("Quantity", font, Brushes.Black, new PointF(250, y));
            graphics.DrawString("Price", font, Brushes.Black, new PointF(350, y));
            graphics.DrawString("Total", font, Brushes.Black, new PointF(450, y));
            y += 20;

            foreach (var item in invoiceItems)
            {
                graphics.DrawString(item.ItemName, font, Brushes.Black, new PointF(100, y));
                graphics.DrawString(item.Quantity.ToString(), font, Brushes.Black, new PointF(250, y));
                graphics.DrawString(item.Price.ToString("C"), font, Brushes.Black, new PointF(350, y));
                graphics.DrawString(item.Total.ToString("C"), font, Brushes.Black, new PointF(450, y));
                y += 20;
            }

            // Total
            y += 20;
            graphics.DrawString("Total: " + lblTotal.Text, font, Brushes.Black, new PointF(350, y));
        }


    }
}
