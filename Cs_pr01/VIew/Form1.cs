using Cs_pr01.Controller;
using Cs_pr01.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cs_pr01
{
    public partial class Form1 : Form
    {
        private PostController postController = new PostController();

        public Form1()
        {
            InitializeComponent();
            LoadPosts();
        }

        private void LoadPosts()
        {
            var posts = postController.GetPosts();
            dataGridView1.DataSource = posts;
        }

        private void btnAddPost_Click(object sender, EventArgs e)
        {
            var post = new Post
            {
                Title = txtTitle.Text,
                Content = txtContent.Text
            };

            postController.AddPost(post);
            LoadPosts();
            txtTitle.Clear();
            txtContent.Clear();
        }
    }
}
