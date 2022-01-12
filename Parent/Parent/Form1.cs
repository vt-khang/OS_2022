using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Dropbox.Api;
using Dropbox.Api.Files;

namespace Parent
{
    public partial class Form : System.Windows.Forms.Form
    {
        static string path = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().IndexOf("Parent")) + @"Parent";
        static string subpath = "";
        static string AccessToken = "r8d6PBzZBuEAAAAAAAAAAe_43Ery2nmzzh81x5QMmxZNdWPq94UekSxRSJF93UWk";
        static string remote_path = "";
        static string local_path = "";
        static List<string> listSubfolder = new List<string>();
        static int index = 0;

        public Form()
        {
            InitializeComponent();
            ListView.ColumnWidthChanging += new ColumnWidthChangingEventHandler(ListView_ColumnWidthChanging);
            //
            // Form
            //
            this.Controls.Add(this.TimePickerTo);
            this.Controls.Add(this.TimePickerFrom);
            this.Controls.Add(this.ListView);
            this.Controls.Add(this.ButtonRemove);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.ButtonEdit);
            this.Controls.Add(this.TextBoxSum);
            this.Controls.Add(this.LabelSum);
            this.Controls.Add(this.TextBoxInterrupt);
            this.Controls.Add(this.LabelInterrupt);
            this.Controls.Add(this.TextBoxDuration);
            this.Controls.Add(this.LabelDuration);
            this.Controls.Add(this.LabelTo);
            this.Controls.Add(this.LabelFrom);
        }

        static async Task UploadToCloud()
        {
            using (var dbx = new DropboxClient(AccessToken))
            {
                // var full = await dbx.Users.GetCurrentAccountAsync();
                using (var mem = new MemoryStream(File.ReadAllBytes(local_path)))
                {
                    var updated = dbx.Files.UploadAsync(remote_path, WriteMode.Overwrite.Instance, body: mem);
                    updated.Wait();
                }
            }
        }
        static async Task DownloadFromCloud()
        {
            using (var dbx = new DropboxClient(AccessToken))
            {
                using (var response = await dbx.Files.DownloadAsync(remote_path))
                {
                    var s = response.GetContentAsByteArrayAsync();
                    s.Wait();
                    var d = s.Result;
                    
                    File.WriteAllBytes(local_path, d);
                }
            }
        }
        static async Task DeleteDropbox()
        {
            using (var dbx = new DropboxClient(AccessToken))
            {
                var reponse = await dbx.Files.DeleteV2Async(path: remote_path);
            }
        }
        static async Task Run()
        {
            using (var dbx = new DropboxClient(AccessToken))
            {
                var listFolder = await dbx.Files.ListFolderAsync(path: "/Image");
                foreach (var folder in listFolder.Entries.Where(i => i.IsFolder))
                {
                    if (listFolder.Entries.Count > 5)
                    {
                        var task = Task.Run((Func<Task>)Form.DeleteDropbox);
                        task.Wait();
                        continue;
                    }
                    var listFile = await dbx.Files.ListFolderAsync(path: "/Image/" + folder.Name);
                    foreach (var file in listFile.Entries.Where(j => j.IsFile))
                    {
                        remote_path = "/Image/" + folder.Name + "/" + file.Name;
                        if (!Directory.Exists(path + "\\Image\\" + folder.Name))
                            Directory.CreateDirectory(path + "\\Image\\" + folder.Name);
                        local_path = path + "\\Image\\" + folder.Name + "\\" + file.Name;
                        var task = Task.Run((Func<Task>)Form.DownloadFromCloud);
                        task.Wait();
                    }
                }
            }
            remote_path = "";
            local_path = "";
        }

        public void LoadItemsListView()
        {
            remote_path = "/Public/Time.txt";
            local_path = path + "\\Cloud\\Time.txt";
            var task = Task.Run((Func<Task>)Form.DownloadFromCloud);
            task.Wait();

            List<TimeTable> TimeTable = new List<TimeTable>();
            string[] lines = File.ReadAllLines(path + "\\Cloud\\Time.txt");

            foreach(string line in lines)
            {
                string[] split_line = line.Split(' ');
                Time F = new Time(split_line[0].Substring(1));
                Time T = new Time(split_line[1].Substring(1));

                if (split_line.Length == 2)
                    TimeTable.Add(new TimeTable(F, T));
                else if (split_line.Length == 3)
                {
                    int S = Int32.Parse(split_line[2].Substring(1));
                    TimeTable.Add(new TimeTable(F, T, S));
                }
                else if (split_line.Length == 4)
                {
                    int D = Int32.Parse(split_line[2].Substring(1));
                    int I = Int32.Parse(split_line[3].Substring(1));
                    TimeTable.Add(new TimeTable(F, T, D, I));
                }
                else if (split_line.Length == 5)
                {
                    int D = Int32.Parse(split_line[2].Substring(1));
                    int I = Int32.Parse(split_line[3].Substring(1));
                    int S = Int32.Parse(split_line[4].Substring(1));
                    TimeTable.Add(new TimeTable(F, T, D, I, S));
                }
                else continue;
            }

            for (int i = 0; i < TimeTable.Count; i++)
            {
                ListViewItem item = new ListViewItem();

                item.Text = (i + 1).ToString();
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = TimeTable[i].F.ToString() });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = TimeTable[i].T.ToString() });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = TimeTable[i].D.ToString() });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = TimeTable[i].I.ToString() });
                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = TimeTable[i].S.ToString() });

                ListView.Items.Add(item);
            }

            remote_path = "";
            local_path = "";
        }

        public void LoadTimePickerToDefault()
        {
            TimePickerFrom.Value = DateTime.Parse("00:00");
            TimePickerTo.Value = DateTime.Parse("00:00");
        }

        public void LoadAllImage()
        {
            
            DeleteAllImage();

            var task = Task.Run((Func<Task>)Form.Run);
            task.Wait();
            

            DirectoryInfo di = new DirectoryInfo(path + "\\Image");
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                ComboBox.Items.Add(dir.Name.Substring(0, 2) + "/" + dir.Name.Substring(2, 2) + "/" + dir.Name.Substring(4));
                listSubfolder.Add(dir.Name);
            }
            subpath = listSubfolder[listSubfolder.Count - 1];
            ComboBox.Text = subpath.Substring(0, 2) + "/" + subpath.Substring(2, 2) + "/" + subpath.Substring(4);

            di = new DirectoryInfo(path + "\\Image\\" + subpath);
            string filename = "";
            foreach (FileInfo file in di.GetFiles())
            {
                filename = file.Name;
                break;
            }

            PictureBox.Image = Image.FromFile(path + "\\Image\\" + subpath + "\\" + filename);
            PictureBox.ImageLocation = path + "\\Image\\" + subpath + "\\" + filename;
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void LoadPassword()
        {
            remote_path = "/Public/PasswordChildren.txt";
            local_path = path + "\\Cloud\\PasswordChildren.txt";
            var task1 = Task.Run((Func<Task>)Form.DownloadFromCloud);
            task1.Wait();
            remote_path = "/Public/PasswordParent.txt";
            local_path = path + "\\Cloud\\PasswordParent.txt";
            var task2 = Task.Run((Func<Task>)Form.DownloadFromCloud);
            task2.Wait();

            remote_path = "";
            local_path = "";

            PasswordChildrenTextBox.Text = File.ReadAllText(path + "\\Cloud\\PasswordChildren.txt");
            PasswordParentTextBox.Text = File.ReadAllText(path + "\\Cloud\\PasswordParent.txt");
        }

        public void LoadLogTime()
        {
            remote_path = "/Public/LogTime.txt";
            local_path = path + "\\Cloud\\LogTime.txt";
            var task = Task.Run((Func<Task>)Form.DownloadFromCloud);
            task.Wait();

            remote_path = "";
            local_path = "";

            string[] lines = File.ReadAllLines(path + "\\Cloud\\LogTime.txt");
            string log_date = "";
            for (int i = 0; i < lines.Length; i++)
            {
                if (i == 0) { log_date = lines[i]; continue; }

                if (lines[i].IndexOf(' ') != lines[i].LastIndexOf(' '))
                {
                    lines[i] = String.Format("[{0} - {1}] Thời gian sử dụng {2}", 
                                            lines[i].Substring(0, lines[i].IndexOf(' ')),
                                            lines[i].Substring(lines[i].IndexOf(' ') + 1, lines[i].LastIndexOf(' ') - lines[i].IndexOf(' ') - 1),
                                            lines[i].Substring(lines[i].LastIndexOf(' ') + 1));
                }
                else continue;
            }
            RichTextBox.Text = string.Join("\n", lines);
        }

        public static void DeleteAllImage()
        {
            DirectoryInfo di = new DirectoryInfo(path + "\\Image");
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach(DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        public void UpdateAndExportItemsListView()
        {
            string[] lines = new string[ListView.Items.Count];

            for (int i = 0; i < ListView.Items.Count; i++)
            {
                ListView.Items[i].Text = (i + 1).ToString();

                string text = "";

                text += "F" + ListView.Items[i].SubItems[1].Text;
                text += " T" + ListView.Items[i].SubItems[2].Text;

                if (ListView.Items[i].SubItems[3].Text != "0" && ListView.Items[i].SubItems[4].Text != "0")
                {
                    text += " D" + ListView.Items[i].SubItems[3].Text;
                    text += " I" + ListView.Items[i].SubItems[4].Text;
                }
                if (ListView.Items[i].SubItems[5].Text != "0")
                    text += " S" + ListView.Items[i].SubItems[5].Text;

                lines[i] = text;
            }

            File.WriteAllLines(path + "\\Cloud\\Time.txt", lines);
            File.WriteAllText(path + "\\Cloud\\~CHANGED.txt", "1");

            Thread th = new Thread(() =>
            {
                remote_path = "/Public/Time.txt";
                local_path = path + "\\Cloud\\Time.txt";
                var task1 = Task.Run((Func<Task>)Form.UploadToCloud);
                task1.Wait();
                remote_path = "/Public/~CHANGED.txt";
                local_path = path + "\\Cloud\\~CHANGED.txt";
                var task2 = Task.Run((Func<Task>)Form.UploadToCloud);
                task2.Wait();

                File.Delete(path + "\\Cloud\\~CHANGED.txt");
            });
            th.Start();
            remote_path = "";
            local_path = "";
        }

        public bool CheckTextBox()
        {
            if (Regex.IsMatch(TextBoxDuration.Text, @"^\d+$|^$") == false 
                || Regex.IsMatch(TextBoxInterrupt.Text, @"^\d+$|^$") == false)
            {
                MessageBox.Show("Nhập chuỗi không hợp lệ", "Thông báo", MessageBoxButtons.OK);
                TextBoxDuration.Focus();
                return false;
            }
            if (Regex.IsMatch(TextBoxSum.Text, @"^\d+$|^$") == false)
            {
                MessageBox.Show("Nhập chuỗi không hợp lệ", "Thông báo", MessageBoxButtons.OK);
                TextBoxSum.Focus();
                return false;
            }
            if (new Time(TimePickerFrom.Value.ToString("HH:mm")) > new Time(TimePickerTo.Value.ToString("HH:mm")))
            {
                MessageBox.Show("Thời gian không hợp lệ", "Thông báo", MessageBoxButtons.OK);
                TimePickerFrom.Focus();
                return false;
            }
            if ((TextBoxSum.Text != "") && 
                (Int32.Parse(TextBoxSum.Text) > Time.Convert(TimePickerTo.Value.ToString("HH:mm")) - Time.Convert(TimePickerFrom.Value.ToString("HH:mm"))))
            {
                MessageBox.Show("Thời gian không hợp lệ", "Thông báo", MessageBoxButtons.OK);
                TextBoxSum.Focus();
                return false;
            }
            if ((TextBoxDuration.Text != "" && TextBoxInterrupt.Text != "") &&
                (Int32.Parse(TextBoxDuration.Text) + Int32.Parse(TextBoxInterrupt.Text) > Time.Convert(TimePickerTo.Value.ToString("HH:mm")) - Time.Convert(TimePickerFrom.Value.ToString("HH:mm"))))
            {
                MessageBox.Show("Thời gian không hợp lệ", "Thông báo", MessageBoxButtons.OK);
                TextBoxSum.Focus();
                return false;
            }

            return true;
        }

        public bool CheckTimeTable()
        {
            if (ListView.Items.Count != 0)
            {
                int F = Time.Convert(TimePickerFrom.Value.ToString("HH:mm"));
                int T = Time.Convert(TimePickerTo.Value.ToString("HH:mm"));
                bool FromStatus = true;
                bool ToStatus = true;

                for (int i = 0; i < ListView.Items.Count; i++)
                {
                    int F_tmp = Time.Convert(ListView.Items[i].SubItems[1].Text);
                    int T_tmp = Time.Convert(ListView.Items[i].SubItems[2].Text);
                    if (F_tmp <= F && F <= T_tmp)
                    {
                        FromStatus = false;
                        break;
                    }
                }
                for (int i = 0; i < ListView.Items.Count; i++)
                {
                    int F_tmp = Time.Convert(ListView.Items[i].SubItems[1].Text);
                    int T_tmp = Time.Convert(ListView.Items[i].SubItems[2].Text);
                    if (F_tmp <= T && T <= T_tmp)
                    {
                        ToStatus = false;
                        break;
                    }
                }

                if (FromStatus == false || ToStatus == false)
                {
                    MessageBox.Show("Thời gian không hợp lệ", "Thông báo", MessageBoxButtons.OK);
                    TimePickerFrom.Focus();
                    return false;
                }
            }

            return true;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            LoadItemsListView();
            LoadTimePickerToDefault();
            LoadAllImage();
            LoadPassword();
            LoadLogTime();
        }

        private void ListView_DoubleClick(object sender, EventArgs e)
        {
            for (int i = 0; i < ListView.Items.Count; i++)
            {
                if (ListView.Items[i].Selected)
                {
                    TimePickerFrom.Value = DateTime.Parse(ListView.Items[i].SubItems[1].Text);
                    TimePickerTo.Value = DateTime.Parse(ListView.Items[i].SubItems[2].Text);

                    if (ListView.Items[i].SubItems[3].Text == "0" && ListView.Items[i].SubItems[4].Text == "0")
                    {
                        TextBoxDuration.Text = "";
                        TextBoxInterrupt.Text = "";
                    }
                    else
                    {
                        TextBoxDuration.Text = ListView.Items[i].SubItems[3].Text;
                        TextBoxInterrupt.Text = ListView.Items[i].SubItems[4].Text;
                    }

                    if (ListView.Items[i].SubItems[5].Text == "0")
                        TextBoxSum.Text = "";
                    else
                        TextBoxSum.Text = ListView.Items[i].SubItems[5].Text;

                    break;
                }
            }
        }

        private void ListView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = ListView.Columns[e.ColumnIndex].Width;
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ListView.Items.Count; i++)
            {
                if (ListView.Items[i].Selected)
                {
                    if (CheckTextBox())
                    {
                        try
                        {
                            ListViewItem item = new ListViewItem();

                            item.Text = (i + 1).ToString();
                            item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = TimePickerFrom.Value.ToString("HH:mm") });
                            item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = TimePickerTo.Value.ToString("HH:mm") });

                            if (TextBoxDuration.Text == "" && TextBoxInterrupt.Text == "")
                            {
                                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = "0" });
                                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = "0" });
                                if (TextBoxSum.Text == "")
                                    item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = "0" });
                                else
                                    item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = TextBoxSum.Text });
                            }
                            else
                            {
                                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = TextBoxDuration.Text });
                                item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = TextBoxInterrupt.Text });
                                if (TextBoxSum.Text == "")
                                    item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = "0" });
                                else
                                    item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = TextBoxSum.Text });
                            }

                            ListView.Items[i] = item;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                    break;
                }
            }

            UpdateAndExportItemsListView();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (CheckTextBox() && CheckTimeTable())
            {
                try
                {
                    int n = ListView.Items.Count;

                    ListViewItem item = new ListViewItem();

                    item.Text = (n + 1).ToString();
                    item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = TimePickerFrom.Value.ToString("HH:mm") });
                    item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = TimePickerTo.Value.ToString("HH:mm") });

                    if (TextBoxDuration.Text == "" && TextBoxInterrupt.Text == "")
                    {
                        item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = "0" });
                        item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = "0" });
                        if (TextBoxSum.Text == "")
                            item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = "0" });
                        else
                            item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = TextBoxSum.Text });
                    }
                    else
                    {
                        item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = TextBoxDuration.Text });
                        item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = TextBoxInterrupt.Text });
                        if (TextBoxSum.Text == "")
                            item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = "0" });
                        else
                            item.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = TextBoxSum.Text });
                    }

                    ListView.Items.Add(item);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            UpdateAndExportItemsListView();
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ListView.Items.Count; i++)
            {
                if (ListView.Items[i].Selected)
                {
                    ListView.Items[i].Remove();
                    break;
                }
            }

            UpdateAndExportItemsListView();
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            Process.Start(PictureBox.ImageLocation);
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = 0;
            subpath = ComboBox.SelectedItem.ToString().Replace("/", "");
            DirectoryInfo di = new DirectoryInfo(path + "\\Image\\" + subpath);
            string filename = di.GetFiles()[index].Name;

            PictureBox.Image = Image.FromFile(path + "\\Image\\" + subpath + "\\" + filename);
            PictureBox.ImageLocation = path + "\\Image\\" + subpath + "\\" + filename;
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void LeftButton_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(path + "\\Image\\" + subpath);
            if (index == 0) index = di.GetFiles().Length - 1;
            else index = index - 1;
            string filename = di.GetFiles()[index].Name;

            PictureBox.Image = Image.FromFile(path + "\\Image\\" + subpath + "\\" + filename);
            PictureBox.ImageLocation = path + "\\Image\\" + subpath + "\\" + filename;
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void RightButton_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(path + "\\Image\\" + subpath);
            if (index == di.GetFiles().Length - 1) index = 0;
            else index = index + 1;
            string filename  = di.GetFiles()[index].Name;

            PictureBox.Image = Image.FromFile(path + "\\Image\\" + subpath + "\\" + filename);
            PictureBox.ImageLocation = path + "\\Image\\" + subpath + "\\" + filename;
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void XemThoiGianToolStripMenu_Click(object sender, EventArgs e)
        {
            this.Controls.Add(this.TimePickerTo);
            this.Controls.Add(this.TimePickerFrom);
            this.Controls.Add(this.ListView);
            this.Controls.Add(this.ButtonRemove);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.ButtonEdit);
            this.Controls.Add(this.TextBoxSum);
            this.Controls.Add(this.LabelSum);
            this.Controls.Add(this.TextBoxInterrupt);
            this.Controls.Add(this.LabelInterrupt);
            this.Controls.Add(this.TextBoxDuration);
            this.Controls.Add(this.LabelDuration);
            this.Controls.Add(this.LabelTo);
            this.Controls.Add(this.LabelFrom);
            this.Controls.Remove(this.PictureBox);
            this.Controls.Remove(this.ComboBox);
            this.Controls.Remove(this.LeftButton);
            this.Controls.Remove(this.RightButton);
            this.Controls.Remove(this.ButtonEditAndSavePasswordParent);
            this.Controls.Remove(this.ButtonEditAndSavePasswordChildren);
            this.Controls.Remove(this.PasswordParentTextBox);
            this.Controls.Remove(this.PasswordChildrenTextBox);
            this.Controls.Remove(this.PasswordParentLabel);
            this.Controls.Remove(this.PasswordChildrenLabel);
            this.Controls.Remove(this.RichTextBox);
        }

        private void AnhChupToolStripMenu_Click(object sender, EventArgs e)
        {
            this.Controls.Remove(this.TimePickerTo);
            this.Controls.Remove(this.TimePickerFrom);
            this.Controls.Remove(this.ListView);
            this.Controls.Remove(this.ButtonRemove);
            this.Controls.Remove(this.ButtonAdd);
            this.Controls.Remove(this.ButtonEdit);
            this.Controls.Remove(this.TextBoxSum);
            this.Controls.Remove(this.LabelSum);
            this.Controls.Remove(this.TextBoxInterrupt);
            this.Controls.Remove(this.LabelInterrupt);
            this.Controls.Remove(this.TextBoxDuration);
            this.Controls.Remove(this.LabelDuration);
            this.Controls.Remove(this.LabelTo);
            this.Controls.Remove(this.LabelFrom);
            this.Controls.Add(this.RightButton);
            this.Controls.Add(this.LeftButton);
            this.Controls.Add(this.ComboBox);
            this.Controls.Add(this.PictureBox);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.Controls.Remove(this.ButtonEditAndSavePasswordParent);
            this.Controls.Remove(this.ButtonEditAndSavePasswordChildren);
            this.Controls.Remove(this.PasswordParentTextBox);
            this.Controls.Remove(this.PasswordChildrenTextBox);
            this.Controls.Remove(this.PasswordParentLabel);
            this.Controls.Remove(this.PasswordChildrenLabel);
            this.Controls.Remove(this.RichTextBox);
        }

        private void MatKhauToolStripMenu_Click(object sender, EventArgs e)
        {
            this.Controls.Remove(this.TimePickerTo);
            this.Controls.Remove(this.TimePickerFrom);
            this.Controls.Remove(this.ListView);
            this.Controls.Remove(this.ButtonRemove);
            this.Controls.Remove(this.ButtonAdd);
            this.Controls.Remove(this.ButtonEdit);
            this.Controls.Remove(this.TextBoxSum);
            this.Controls.Remove(this.LabelSum);
            this.Controls.Remove(this.TextBoxInterrupt);
            this.Controls.Remove(this.LabelInterrupt);
            this.Controls.Remove(this.TextBoxDuration);
            this.Controls.Remove(this.LabelDuration);
            this.Controls.Remove(this.LabelTo);
            this.Controls.Remove(this.LabelFrom);
            this.Controls.Remove(this.PictureBox);
            this.Controls.Remove(this.ComboBox);
            this.Controls.Remove(this.LeftButton);
            this.Controls.Remove(this.RightButton);
            this.Controls.Add(this.ButtonEditAndSavePasswordParent);
            this.Controls.Add(this.ButtonEditAndSavePasswordChildren);
            this.Controls.Add(this.PasswordParentTextBox);
            this.Controls.Add(this.PasswordChildrenTextBox);
            this.Controls.Add(this.PasswordParentLabel);
            this.Controls.Add(this.PasswordChildrenLabel);
            this.Controls.Remove(this.RichTextBox);
        }

        private void LichSuDungMayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Controls.Remove(this.TimePickerTo);
            this.Controls.Remove(this.TimePickerFrom);
            this.Controls.Remove(this.ListView);
            this.Controls.Remove(this.ButtonRemove);
            this.Controls.Remove(this.ButtonAdd);
            this.Controls.Remove(this.ButtonEdit);
            this.Controls.Remove(this.TextBoxSum);
            this.Controls.Remove(this.LabelSum);
            this.Controls.Remove(this.TextBoxInterrupt);
            this.Controls.Remove(this.LabelInterrupt);
            this.Controls.Remove(this.TextBoxDuration);
            this.Controls.Remove(this.LabelDuration);
            this.Controls.Remove(this.LabelTo);
            this.Controls.Remove(this.LabelFrom);
            this.Controls.Remove(this.RightButton);
            this.Controls.Remove(this.LeftButton);
            this.Controls.Remove(this.ComboBox);
            this.Controls.Remove(this.PictureBox);
            this.Controls.Remove(this.ButtonEditAndSavePasswordParent);
            this.Controls.Remove(this.ButtonEditAndSavePasswordChildren);
            this.Controls.Remove(this.PasswordParentTextBox);
            this.Controls.Remove(this.PasswordChildrenTextBox);
            this.Controls.Remove(this.PasswordParentLabel);
            this.Controls.Remove(this.PasswordChildrenLabel);
            this.Controls.Add(this.RichTextBox);
        }

        private void ButtonEditAndSavePasswordChildren_Click(object sender, EventArgs e)
        {
            if (ButtonEditAndSavePasswordChildren.Text == "Edit")
            {
                PasswordChildrenTextBox.ReadOnly = false;
                PasswordChildrenTextBox.UseSystemPasswordChar = false;
                ButtonEditAndSavePasswordChildren.Text = "Save";
            }
            else if (ButtonEditAndSavePasswordChildren.Text == "Save")
            {
                PasswordChildrenTextBox.ReadOnly = true;
                PasswordChildrenTextBox.UseSystemPasswordChar = true;
                File.WriteAllText(path + "\\Cloud\\PasswordChildren.txt", PasswordChildrenTextBox.Text);
                Thread th = new Thread(() =>
                {
                    remote_path = "/Public/PasswordChildren.txt";
                    local_path = path + "\\Cloud\\PasswordChildren.txt";
                    var task = Task.Run((Func<Task>)Form.UploadToCloud);
                    task.Wait();
                });
                th.Start();
                ButtonEditAndSavePasswordChildren.Text = "Edit";
                remote_path = "";
                local_path = "";
            }
        }

        private void ButtonEditAndSavePasswordParent_Click(object sender, EventArgs e)
        {
            if (ButtonEditAndSavePasswordParent.Text == "Edit")
            {
                PasswordParentTextBox.ReadOnly = false;
                PasswordParentTextBox.UseSystemPasswordChar = false;
                ButtonEditAndSavePasswordParent.Text = "Save";
            }
            else if (ButtonEditAndSavePasswordParent.Text == "Save")
            {
                PasswordParentTextBox.ReadOnly = true;
                PasswordParentTextBox.UseSystemPasswordChar = true;
                File.WriteAllText(path + "\\Cloud\\PasswordParent.txt", PasswordParentTextBox.Text);
                Thread th = new Thread(() =>
                {
                    remote_path = "/Public/PasswordParent.txt";
                    local_path = path + "\\Cloud\\PasswordParent.txt";
                    var task = Task.Run((Func<Task>)Form.UploadToCloud);
                    task.Wait();
                });
                th.Start();
                ButtonEditAndSavePasswordParent.Text = "Edit";
                remote_path = "";
                local_path = "";
            }
        }
    }
}
