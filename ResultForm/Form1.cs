using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SampleDb;

namespace ResultForm
{
    public partial class Results : Form
    {
        public Results()
        {
            InitializeComponent();
        }

        private void Results_Load(object sender, EventArgs e)
        {
            var allUsers = DataCollector.GetAllUsers();
            usersGridView.DataSource = allUsers
                .Select(u => new
                {
                    StudentNumber = u.StdNumber,
                    TestResult = u.TestResult,
                    Ratios = u.Ratios
                }).ToList();

            var groups = DataAnalayser.CreateGroups(allUsers, GroupingConfigs.GroupSize);

            var nl = Environment.NewLine;

            groupsRichTextBox.Clear();
            groupsRichTextBox.Enabled = false;
            groupsRichTextBox.SelectionColor = Color.Red;
            groupsRichTextBox.SelectedText = "List of roommates " + nl;

            int roomNumber = 1;
            foreach (var g in groups)
            {
                groupsRichTextBox.SelectedText = "Room number " + roomNumber++ + " :" + nl;

                groupsRichTextBox.SelectionBullet = true;

                foreach (var user in g)
                    groupsRichTextBox.SelectedText = user.StdNumber + nl;

                groupsRichTextBox.SelectionBullet = false;
            }
        }

        private void writeButton_Click(object sender, EventArgs e)
        {
            var allUsers = DataCollector.GetAllUsers();
            var groups = DataAnalayser.CreateGroups(allUsers, GroupingConfigs.GroupSize);

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            var dialogResult = dialog.ShowDialog();

            if (dialogResult != DialogResult.OK)
                return;

            var path = dialog.SelectedPath;

            StringBuilder builder = new StringBuilder();
            int roomNumber = 1;
            string nl = Environment.NewLine;
            foreach (var g in groups)
                builder.Append("Room " + roomNumber++ + " : " +
                               string.Join(", ", g.Select(u => u.StdNumber)) + nl);

            Console.WriteLine(builder.ToString());
//            File.WriteAllText(Path.Combine(path, "Groups.txt"), builder.ToString());
        }
    }
}
