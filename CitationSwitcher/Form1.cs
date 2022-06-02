using System.Text.RegularExpressions;
using System.IO;

namespace CitationSwitcher
{
    public partial class Form1 : Form
    {
        int numberingStyle;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Proper citation style, comma with every initals
            richTextBox2.Clear();
            richTextBox3.Clear();
            richTextBox4.Clear();
            
            String text = richTextBox1.Text;
            String[] TextLine = text.Split('\n');

            List<String> LineNumbers = new List<String>();
            List<String> Citations = new List<String>();
            StreamWriter writer1 = new StreamWriter(@"C:\Users\i-x\Desktop\CFiles\Numbers.txt");
            StreamWriter writer2 = new StreamWriter(@"C:\Users\i-x\Desktop\CFiles\Authors.txt");

            foreach (String line in TextLine)
            {
                if (line.Length > 0)
                {
                    //Split IEEE style numbers
                    String[] num = line.Split('[', ']');
                    LineNumbers.Add("[" + num[1] + "]");
                    Citations.Add(num[2].Trim());

                    //Split Year
                    String[] pieces1 = line.Split(new[] { ')' }, 2);
                    String[] pieces2 = pieces1[0].Split('(');
                    String year = pieces2[1];

                    //Split Authors
                    String[] pieces3 = pieces2[0].Split('[', ']');
                    String number = pieces3[1];

                    String AllAuthors = pieces3[2].Trim();
                    String AllAuthors2 = AllAuthors.Replace("&", String.Empty);
                    String[] Authors = AllAuthors2.Split(',');

                    String FinalAuthors = "";

                    if (Authors.Length == 1)
                        FinalAuthors = "(" + Authors[0].Trim() + ", " + year + ")";
                    else
                    {
                        //IEEE Style, change to name first
                        if (Authors[0].Contains('.'))
                        {
                            for (int i = 0; i < Authors.Length; i += 2)
                            {
                                String temp = Authors[i];
                                Authors[i] = Authors[i + 1];
                                Authors[i + 1] = temp;
                            }
                        }

                        if (Authors.Length > 4)
                        {
                            FinalAuthors = "(" + Authors[0].Trim() + " et al., " + year + ")";
                        }
                        else if (Authors.Length > 2)
                        {
                            
                            FinalAuthors = "(" + Authors[0].Trim() + " & " + Authors[2].Trim() + ", " + year + ")";
                        }
                        else
                        {
                            FinalAuthors = "(" + Authors[0].Trim() + ", " + year + ")";
                        }

                    }

                    richTextBox3.AppendText("[" + number + "]" + "*");
                    richTextBox4.AppendText(FinalAuthors + "*");
                    writer1.WriteLine("[" + number + "]");
                    writer2.WriteLine(FinalAuthors);
                }
            }

            writer1.Close();
            writer2.Close();

            string combinedString = string.Join("\n", Citations);
            richTextBox2.AppendText(combinedString);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //citation style, no comma with every initals
            richTextBox2.Clear();
            richTextBox3.Clear();
            richTextBox4.Clear();
            
            String text = richTextBox1.Text;
            String[] TextLine = text.Split('\n');

            List<String> LineNumbers = new List<String>();
            List<String> Citations = new List<String>();
            StreamWriter writer1 = new StreamWriter(@"C:\Users\i-x\Desktop\CFiles\Numbers.txt");
            StreamWriter writer2 = new StreamWriter(@"C:\Users\i-x\Desktop\CFiles\Authors.txt");

            foreach (String line in TextLine)
            {
                if (line.Length > 0)
                {
                    //Split IEEE style numbers
                    String[] num = line.Split(new[] { ']' }, 2);
                    Citations.Add(num[1].Trim());

                    //Split Year
                    String[] pieces1 = line.Split(new[] { ')' }, 2);
                    String[] pieces2 = pieces1[0].Split('(');
                    String year = pieces2[1];

                    //Split Authors
                    String[] pieces3 = pieces2[0].Split('[', ']');
                    String number = pieces3[1];

                    String AllAuthors = pieces3[2].Trim();
                    String AllAuthors2 = AllAuthors.Replace("&", String.Empty);
                    String[] Authors = AllAuthors2.Split(' ');

                    String FinalAuthors = "";

                    if (Authors[0].Length < 2)
                    {
                        String temp = Authors[0];
                        Authors[0] = Authors[1];
                        Authors[1] = temp;
                    }

                    if (Authors.Length == 1)
                        FinalAuthors = "(" + Authors[0].Replace(',',' ').Trim() + ", " + year + ")";
                    else
                    {
                        //IEEE Style, change to name first
                        //if (Authors[0].Contains('.'))
                        //{
                        //    for (int i = 0; i < Authors.Length; i += 2)
                        //    {
                        //        String temp = Authors[i];
                        //        Authors[i] = Authors[i + 1];
                        //        Authors[i + 1] = temp;
                        //    }
                        //}

                        if (Authors.Length > 5)
                        {
                            FinalAuthors = "(" + Authors[0].Replace(',', ' ').Trim() + " et al., " + year + ")";
                        }
                        else if (Authors.Contains("and"))
                        {
                            
                            FinalAuthors = "(" + Authors[0].Replace(',', ' ').Trim() + " & " + Authors[3].Replace(',', ' ').Trim() + ", " + year + ")";
                        }
                        else
                        {
                            FinalAuthors = "(" + Authors[0].Replace(',', ' ').Trim() + ", " + year + ")";
                        }

                    }

                    richTextBox3.AppendText("[" + number + "]" + "*");
                    richTextBox4.AppendText(FinalAuthors + "*");
                    writer1.WriteLine("[" + number + "]");
                    writer2.WriteLine(FinalAuthors);
                }
            }

            writer1.Close();
            writer2.Close();

            string combinedString = string.Join("\n", Citations);
            richTextBox2.AppendText(combinedString);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //citation style, no comma with every initals, year at the end
            richTextBox2.Clear();
            richTextBox3.Clear();
            richTextBox4.Clear();

            String text = richTextBox1.Text;
            String[] TextLine = text.Split('\n');

            List<String> LineNumbers = new List<String>();
            List<String> Citations = new List<String>();
            StreamWriter writer1 = new StreamWriter(@"C:\Users\i-x\Desktop\CFiles\Numbers.txt");
            StreamWriter writer2 = new StreamWriter(@"C:\Users\i-x\Desktop\CFiles\Authors.txt");

            foreach (String line in TextLine)
            {
                if (line.Length > 0)
                {
                    //Split IEEE style numbers
                    String[] num = line.Split(new[] { ']' }, 2);
                    Citations.Add(num[1].Trim());

                    //Split Year
                    String[] pieces1 = line.Split(' ');
                    String year = pieces1[pieces1.Length - 1];

                    //Split Authors
                    String[] pieces2 = pieces1[0].Split('[', ']');
                    String number = pieces2[1];

                    String pieces3 = line.Split('“')[0];
                    pieces3 = pieces3.Split(new[] { ']' }, 2)[1];

                    String AllAuthors = pieces3.Trim();
                    String AllAuthors2 = AllAuthors.Replace("&", String.Empty);
                    String[] Authors = AllAuthors2.Split(',');

                    String FinalAuthors = "";

                    if (Authors[0].Contains('.'))
                    {
                        String[] temp = Authors[0].Split('.');
                        Authors[0] = temp[temp.Length - 1];
                    }

                    if ((Authors.Length - 1) == 1)
                        FinalAuthors = "(" + Authors[0].Replace(',', ' ').Trim() + ", " + year + ")";
                    else
                    {
                        ////IEEE Style, change to name first
                        //if (Authors[0].Contains('.'))
                        //{
                        //    for (int i = 0; i < Authors.Length; i += 2)
                        //    {
                        //        String temp = Authors[i];
                        //        Authors[i] = Authors[i + 1];
                        //        Authors[i + 1] = temp;
                        //    }
                        //}

                        if ((Authors.Length - 1) > 4)
                        {
                            FinalAuthors = "(" + Authors[0].Replace(',', ' ').Trim() + " et al., " + year + ")";
                        }
                        else if (Authors.Contains("and"))
                        {

                            FinalAuthors = "(" + Authors[0].Replace(',', ' ').Trim() + " & " + Authors[3].Replace(',', ' ').Trim() + ", " + year + ")";
                        }
                        else
                        {
                            FinalAuthors = "(" + Authors[0].Replace(',', ' ').Trim() + ", " + year + ")";
                        }

                    }

                    richTextBox3.AppendText("[" + number + "]" + "*");
                    richTextBox4.AppendText(FinalAuthors + "*");
                    writer1.WriteLine("[" + number + "]");
                    writer2.WriteLine(FinalAuthors);
                }
            }

            writer1.Close();
            writer2.Close();

            string combinedString = string.Join("\n", Citations);
            richTextBox2.AppendText(combinedString);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int count = 0;

            //try
            //{
                //citation style, the most intelligent
                richTextBox2.Clear();
                richTextBox3.Clear();
                richTextBox4.Clear();

                String text = richTextBox1.Text;
                String[] TextLine = text.Split('\n');

                //List<String> LineNumbers = new List<String>();
                //List<String> Citations = new List<String>();
                List<String> years = new List<string>();

                StreamWriter writer1 = new StreamWriter(@"C:\Users\i-x\Desktop\CFiles\Numbers.txt");
                StreamWriter writer2 = new StreamWriter(@"C:\Users\i-x\Desktop\CFiles\Authors.txt");

                foreach (String line in TextLine)
                {
                    if (line.Length > 30)
                    {
                        //Find year
                        String[] spaces = line.Split(' ');
                        String year = "";

                        for (int i = 0; i < spaces.Length; i++)
                        {
                            //Characters scanning, if contains other characters than years
                            if (spaces[i].Contains('.'))
                            {
                                spaces[i] = spaces[i].Replace('.', ' ');
                                spaces[i] = spaces[i].TrimEnd();
                            }

                            if (spaces[i].Contains(','))
                            {
                                spaces[i] = spaces[i].Replace(',', ' ');
                                spaces[i] = spaces[i].TrimEnd();
                            }

                            if (spaces[i].Contains('(') || spaces[i].Contains(')'))
                            {
                                spaces[i] = spaces[i].Replace('(', ' ');
                                spaces[i] = spaces[i].Replace(')', ' ');
                                spaces[i] = spaces[i].Trim();
                            }

                            if (spaces[i].Length == 4)
                            {
                                if ((spaces[i][0] == '2' && spaces[i][1] == '0') || (spaces[i][0] == '1' && spaces[i][1] == '9') || (spaces[i][0] == '1' && spaces[i][1] == '8'))
                                {
                                    year = spaces[i];
                                    years.Add(year);
                                    break;
                                }
                            }
                        }

                        if (year == "")
                            years.Add("n.d.");

                        //Find Authors
                        String fullLine = line;
                        String FinalAuthor = "";
                        String FrontEnd = "";
                        String BackEnd = "";

                        //Bracket Style
                        int set1 = fullLine.IndexOf("(20");
                        int set2 = fullLine.IndexOf("(19");
                        //int set3 = fullLine.IndexOf("(18");

                        int startPoint = set1 + set2;

                        if (startPoint > 1)
                        {
                            String onlyLine = line.Substring(0, startPoint);
                            String LineBack = line.Substring(startPoint + 1);

                            int startPoint2 = onlyLine.IndexOf(']');
                            String onlyAuthor = onlyLine.Substring(startPoint2 + 1).Trim();

                            FrontEnd = onlyAuthor;
                            BackEnd = LineBack;

                            String[] authors = onlyAuthor.Split(' ');

                            List<String> authorsList = new List<String>();

                            for (int i = 0; i < authors.Length; i++)
                            {
                                if (authors[i].Contains('.'))
                                {
                                    authors[i] = authors[i].Replace('.', ' ');
                                    authors[i] = authors[i].Trim();
                                }

                                if (authors[i].Contains(','))
                                {
                                    authors[i] = authors[i].Replace(',', ' ');
                                    authors[i] = authors[i].Trim();
                                }

                                if (authors[i] == "and")
                                {
                                    authors[i] = authors[i].Replace("and", " ");
                                    authors[i] = authors[i].Trim();
                                }

                                if (authors[i].Length > 1)
                                {
                                    authorsList.Add(authors[i]);
                                }
                            }

                            if (authorsList.Count > 2)
                            {
                                FinalAuthor = "(" + authorsList[0] + " et al., " + years[count] + ")";
                            }
                            else if (authorsList.Count == 2)
                            {

                                FinalAuthor = "(" + authorsList[0] + " & " + authorsList[1] + ", " + years[count] + ")";
                            }
                            else
                            {
                                FinalAuthor = "(" + authorsList[0] + ", " + years[count] + ")";
                            }
                        }

                        //Quote Style
                        else if (fullLine.Contains('“') && fullLine.Contains('”'))
                        {
                            int setQ = fullLine.IndexOf("“");
                            String onlyLine = fullLine.Substring(0, setQ);
                            String LineBack = line.Substring(setQ + 1);

                            int startPoint2 = onlyLine.IndexOf(']');
                            String onlyAuthor = onlyLine.Substring(startPoint2 + 1).Trim();

                            FrontEnd = onlyAuthor;
                            BackEnd = LineBack;

                            String[] authors = onlyAuthor.Split(' ');

                            List<String> authorsList = new List<String>();

                            for (int i = 0; i < authors.Length; i++)
                            {
                                if (authors[i].Contains('.'))
                                {
                                    authors[i] = authors[i].Replace('.', ' ');
                                    authors[i] = authors[i].Trim();
                                }

                                if (authors[i].Contains(','))
                                {
                                    authors[i] = authors[i].Replace(',', ' ');
                                    authors[i] = authors[i].Trim();
                                }

                                if (authors[i] == "and")
                                {
                                    authors[i] = authors[i].Replace("and", " ");
                                    authors[i] = authors[i].Trim();
                                }

                                if (authors[i].Length > 1)
                                {
                                    authorsList.Add(authors[i]);
                                }
                            }

                            if (authorsList.Count > 2)
                            {
                                FinalAuthor = "(" + authorsList[0] + " et al., " + years[count] + ")";
                            }
                            else if (authorsList.Count == 2)
                            {

                                FinalAuthor = "(" + authorsList[0] + " & " + authorsList[1] + ", " + years[count] + ")";
                            }
                            else
                            {
                                FinalAuthor = "(" + authorsList[0] + ", " + years[count] + ")";
                            }
                        }
                        //No style. What the heck man
                        else
                        {
                            String onlyLine = line.Substring(0);

                            int startPoint2 = onlyLine.IndexOf(']');
                            String onlyAuthor = onlyLine.Substring(startPoint2 + 1).Trim();

                            FrontEnd = onlyAuthor;
                            BackEnd = "";

                            String[] authors = onlyAuthor.Split(' ');

                            List<String> authorsList = new List<String>();

                            for (int i = 0; i < authors.Length; i++)
                            {
                                if (authors[i].Contains('.'))
                                {
                                    authors[i] = authors[i].Replace('.', ' ');
                                    authors[i] = authors[i].Trim();
                                }

                                if (authors[i].Contains(','))
                                {
                                    authors[i] = authors[i].Replace(',', ' ');
                                    authors[i] = authors[i].Trim();
                                }

                                if (authors[i] == "and")
                                {
                                    authors[i] = authors[i].Replace("and", " ");
                                    authors[i] = authors[i].Trim();
                                }

                                if (authors[i].Length > 1)
                                {
                                    authorsList.Add(authors[i]);
                                }
                            }

                            if (authorsList.Count > 2)
                            {
                                FinalAuthor = "(" + authorsList[0] + " et al., " + years[count] + ")";
                            }
                            else if (authorsList.Count == 2)
                            {

                                FinalAuthor = "(" + authorsList[0] + " & " + authorsList[1] + ", " + years[count] + ")";
                            }
                            else
                            {
                                FinalAuthor = "(" + authorsList[0] + ", " + years[count] + ")";
                            }
                        }

                        if (radioButton1.Checked == true)
                            numberingStyle = 0;
                        else if (radioButton2.Checked == true)
                            numberingStyle = 1;
                        else
                            numberingStyle = 2;

                        if (numberingStyle == 0)
                        {
                            richTextBox2.AppendText(FrontEnd + BackEnd + "\n");
                            richTextBox3.AppendText("[" + (count + 1) + "]" + " ");
                            richTextBox4.AppendText((count + 1) + "-" + FinalAuthor + " ");
                            writer1.WriteLine("[" + (count + 1) + "]");
                            writer2.WriteLine(FinalAuthor);
                        }
                        else if (numberingStyle == 1)
                        {
                            richTextBox2.AppendText(FrontEnd + BackEnd + "\n");
                            richTextBox3.AppendText("[" + (count + 1) + "]" + " ");
                            richTextBox4.AppendText((count + 1) + "-" + " ");
                            writer1.WriteLine("(" + (count + 1) + ")");
                            writer2.WriteLine(FinalAuthor);
                        }
                        else
                        {
                            richTextBox2.AppendText(FrontEnd + BackEnd + "\n");
                            richTextBox3.AppendText("[" + (count + 1) + "]" + " ");
                            richTextBox4.AppendText((count + 1) + "-" + FinalAuthor + " ");

                            writer1.WriteLine("[" + (count + 1) + "]");
                            writer2.WriteLine(FinalAuthor);

                            writer1.WriteLine("[" + (count + 1) + ",");
                            writer2.WriteLine(FinalAuthor + ",");

                            writer1.WriteLine("," + (count + 1) + ",");
                            writer2.WriteLine(FinalAuthor + ",");

                            writer1.WriteLine("," + (count + 1) + "]");
                            writer2.WriteLine(FinalAuthor);
                        }
                    }
                    else
                    {
                        int startPoint = line.IndexOf(']');
                        String FinalAuthor = line.Substring(startPoint + 1);
                        FinalAuthor = FinalAuthor.Replace('.', ' ').Trim();
                        FinalAuthor = "(" + FinalAuthor + ")";
                        years.Add("n.d.");

                        richTextBox2.AppendText(FinalAuthor + "\n");
                        richTextBox3.AppendText("[" + (count + 1) + "]" + " ");
                        richTextBox4.AppendText((count + 1) + "-" + FinalAuthor + " ");
                        writer1.WriteLine("[" + (count + 1) + "]");
                        writer2.WriteLine(FinalAuthor);
                    }

                    count++;
                }

                writer1.Close();
                writer2.Close();
                MessageBox.Show("Macro File Successfully Generated");
            //}
            //catch (Exception err)
            //{
            //    MessageBox.Show("Error in citation line number " + (count + 1) + " " + err.Message);
            //}
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.ShowDialog();
        }
    }
}