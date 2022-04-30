using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Enrollment_Sorter
{
    public partial class EnrollmentSorter : Form
    {
        private int RecordCounter = 0;

        public EnrollmentSorter()
        {
            InitializeComponent();
        }
        public class EnrollmentRecord
        {
            public int User_Id { get; set; }
            public string First_Name { get; set; }
            public string Last_Name { get; set; }
            public int Version { get; set; }
            public string Insurance_Company { get; set; }
        }

        List<EnrollmentRecord> RecordList = new List<EnrollmentRecord>();
        List<string> ProviderList = new List<string>();
        List<List<EnrollmentRecord>> ListOfRecordList = new List<List<EnrollmentRecord>>();

        private void processCSV_Click(object sender, EventArgs e)
        {
            RecordList.Clear();
            ProviderList.Clear();
            ListOfRecordList.Clear();

            RecordCounter = 0;

            using (var reader = new StreamReader(@textBox1.Text))
            {
                while (!reader.EndOfStream)
                {
                    var record = reader.ReadLine();
                    var data = record.Split(',');

                    // Skip header 
                    if (RecordCounter++ > 0)
                    {
                        EnrollmentRecord enrollmentRecord = new EnrollmentRecord();
                        enrollmentRecord.User_Id = Convert.ToInt32(data[0]);
                        string[] first_last = data[1].Split(' ');
                        enrollmentRecord.First_Name = first_last[0];
                        enrollmentRecord.Last_Name = first_last[1];
                        enrollmentRecord.Version = Convert.ToInt32(data[2]);
                        enrollmentRecord.Insurance_Company = data[3];

                        // Collect unique providers
                        if(!ProviderList.Contains(enrollmentRecord.Insurance_Company))
                        {
                            ProviderList.Add(enrollmentRecord.Insurance_Company);
                        }

                        RecordList.Add(enrollmentRecord);
                    }
                }

                reader.Close();
            }

            var duplicates = RecordList.GroupBy(s => s.User_Id)
                             .Where(g => g.Count() > 1)
                             .SelectMany(g => g); 

            // Remove any duplicates 
            if (duplicates.Count() > 0)
            {
                for (int i = 0; i < duplicates.Count(); i++)
                {
                    if (duplicates.ElementAt(i).Insurance_Company == duplicates.ElementAt(i + 1).Insurance_Company &&
                        duplicates.ElementAt(i).User_Id == duplicates.ElementAt(i + 1).User_Id)
                    {
                        if(duplicates.ElementAt(i).Version > duplicates.ElementAt(i + 1).Version)
                        {
                            RecordList.Remove(duplicates.ElementAt(i + 1));
                        }
                        else
                        {
                            RecordList.Remove(duplicates.ElementAt(i));
                        }
                        
                    }
                }
            }

            // Sort by last name
            RecordList.Sort((x, y) => string.Compare(x.Last_Name, y.Last_Name));
                       
            // Divide records by Insurance Companies
            foreach (var provider in ProviderList)
            {
                ListOfRecordList.Add(RecordList.FindAll(
                    delegate (EnrollmentRecord rec)
                    {
                        return rec.Insurance_Company == provider;
                    }));

            }

            MessageBox.Show("Raw CSV file processed!");
        }

        private void exportCSV_Click(object sender, EventArgs e)
        {            
            string fileName = "InsuranceProvider";
            foreach(List<EnrollmentRecord> list in ListOfRecordList)
            {
                var lineOutput = new StringBuilder();
                fileName = list.FirstOrDefault().Insurance_Company.ToString();

                for (int i = 0; i < list.Count; i++)
                {
                    var newLine = string.Format("{0}, {1}, {2}, {3}",
                        list[i].User_Id, list[i].Last_Name + " " + list[i].First_Name, list[i].Version, list[i].Insurance_Company);

                    lineOutput.AppendLine(newLine);
                }

                // Create and write the csv file
                File.WriteAllText(Directory.GetCurrentDirectory() + "..\\..\\..\\..\\" + fileName + ".csv", lineOutput.ToString());
            }
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Open CSV File";
            fileDialog.Filter = "CSV files|*.csv";
            fileDialog.InitialDirectory = @"\\";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fileDialog.FileName;
            }
        }
    }
}