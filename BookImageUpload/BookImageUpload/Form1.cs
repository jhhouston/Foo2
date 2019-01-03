using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookImageUpload
{
    public partial class Form1 : Form
    {
        //Class variables
        string fileName;
        //string title;
        //string author;
        List<bookInfo>list; //Database Name <bookInfo> made form Entity Framework

        public Form1()
        {
            InitializeComponent();
        }

        private void BookInfoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bookInfoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.booksDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'booksDataSet.bookInfo' table. You can move, or remove it, as needed.
            this.bookInfoTableAdapter.Fill(this.booksDataSet.bookInfo);

        }

        private void FillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.bookInfoTableAdapter.FillBy(this.booksDataSet.bookInfo);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        //Binary converter
        Image ConvertBinaryToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }

        private void ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView.FocusedItem !=null)
            {
                pictureBox.Image = ConvertBinaryToImage(list[listView.FocusedItem.Index].CoverImage);
                
            }
        }



        private void BtnOpen_Click(object sender, EventArgs e)
        {
            //Opens windows file folder & Filter
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "PNG|*.png", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    //if it opens 1) Take file name, 2) change label text on form 3) load the image to view
                    fileName = ofd.FileName;                    
                    pictureBox.Image = Image.FromFile(fileName);

                }
            }
        }

        //Convert image to binary
        byte[] ConvertImageToBinary(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            //booksEntities name created in Entity Framework wizard
            using (booksEntities db = new booksEntities())
            {
                                                  //Title     //Author                 //CoverArt
                bookInfo info = new bookInfo() {Title = txtTitle.Text, Author = txtAuthor.Text, CoverImage = ConvertImageToBinary(pictureBox.Image)};
                db.bookInfoes.Add(info);
                await db.SaveChangesAsync();

               


                MessageBox.Show("You have saved the info", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            listView.Items.Clear();
            using (booksEntities db = new booksEntities())
            {
                list = db.bookInfoes.ToList();
                foreach (bookInfo info in list)
                {
                    ListViewItem item = new ListViewItem(info.Author);
                   
                    //Populating Columns
                    listView.Items.Add(item);                    
                    item.SubItems.Add(info.Title);
                }


            }
        }
    }
}
