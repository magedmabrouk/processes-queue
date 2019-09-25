using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OS_Test_GUI
{
    public partial class Form1 : Form
    {
        bool btn = false;
        int MaxProsNum = 0;

        public Form1()
        {
            InitializeComponent();

        }

        public static void assign_RR(double[] key_arr, double[] values, string[] names, double[] wait, float Quantum,
                                     List<double> timing, List<string> naming)
        {
            int size = key_arr.Length;
            int no_processes = size;
            int index = 0;
            List<int> previous_dead_processes = new List<int>();                // to check finished processes
            double[] values_ft = new double[size];                              // remaining/needed burst time
            double passed_time = key_arr[0];
            /** make array of float/double values **/
            for (int i = 0; i < size; i++)
            {
                values_ft[i] = values[i];
            }
            passed_time = System.Math.Round(passed_time, 3);
            //Console.Write("|" + passed_time + "|");
            timing.Add(passed_time);

            do
            {
                if (passed_time >= key_arr[index])
                {// case : current process didn't arrive yet
                    if (values_ft[index] <= 0)
                    {// this process finished its needed burst time
                        if (!previous_dead_processes.Contains(index))
                        {
                            previous_dead_processes.Add(index);
                            no_processes--;
                        }
                    }
                    else
                    {
                        //Console.Write("  ");
                        //Console.Write(names[index]);
                        //Console.Write("  ");
                        naming.Add(names[index]);
                        if (values_ft[index] - Quantum <= 0)
                        {// handling case: remaining time in this process < quantum
                            // also calculate departure time accurtely 
                            passed_time += values_ft[index];
                            wait[index] = passed_time - wait[index];
                            //Console.WriteLine(" " + names[index] + " waited for: " + wait[index] + "\n"); // check
                        }
                        else
                        {
                            passed_time += Quantum;
                        }
                        values_ft[index] -= Quantum;
                        passed_time = System.Math.Round(passed_time, 3);
                        //Console.Write("|" + passed_time + "|");
                        timing.Add(passed_time);
                    }
                    index = (index + 1) % size;
                }

                else
                {
                    index = (index + 1) % size;

                }
            } while (no_processes > 0);
        }

        public static void assign_FCFS(double[] key_arr, double[] values, string[] names, double[] wait,
                                      List<double> timing, List<string> naming)
        {
            int size = key_arr.Length; // process number
            double passed_time = key_arr[0];
            //Console.Write("|" + passed_time + "|");
            timing.Add(passed_time);
            for (int i = 0; i < size; i++)
            {
                passed_time += Convert.ToDouble(values[i]);
                if ((passed_time - values[i]) < key_arr[i])
                {/** handeling missing value like : |x| no process |y| **/
                    //Console.Write("  ");
                    //Console.Write("  ");
                    naming.Add("    ");
                    //Console.Write("|" + key_arr[i] + "|");
                    timing.Add(key_arr[i]);
                    passed_time += key_arr[i] - (passed_time - values[i]);
                    //Console.Write("  ");
                    //Console.Write(names[i] + "  ");
                    naming.Add(names[i]);
                    passed_time = System.Math.Round(passed_time, 3);
                    //Console.Write("|" + passed_time + "|");
                    timing.Add(passed_time);
                    wait[i] = passed_time - wait[i];                            // passed time now is departure time - (arrival + burst stored prev.)
                }
                else
                {
                    //Console.Write("  ");
                    //Console.Write(names[i] + "  ");
                    naming.Add(names[i]);
                    passed_time = System.Math.Round(passed_time, 3);
                    //Console.Write("|" + passed_time + "|");
                    timing.Add(passed_time);
                    wait[i] = passed_time - wait[i];                            // passed time now is departure time - (arrival + burst stored prev.)
                }
            }
        }

        public void Psort(int[,] processes, int NumOfProcesses, ref int[] ReadyQ, int ReadyNum) //priority sort
        {
            int min = 100;
            int temp;
            for (int i = 0; i < ReadyNum; i++)
            {
                for (int j = 0; j < NumOfProcesses; j++)
                    if (ReadyQ[i] == processes[j, 0])
                    {
                        if (processes[j, 3] < min) { min = processes[j, 3]; temp = ReadyQ[0]; ReadyQ[0] = ReadyQ[i]; ReadyQ[i] = temp; }
                    }
            }
        }
        public void sort(int[,] processes, int NumOfProcesses, ref int[] ReadyQ, int ReadyNum)// SJF sort
        {
            int min = 100;
            int temp;
            for (int i = 0; i < ReadyNum; i++)
            {
                for (int j = 0; j < NumOfProcesses; j++)
                    if (ReadyQ[i] == processes[j, 0])
                    {
                        if ((processes[j, 2] < min) && (processes[j, 2] > 0)) { min = processes[j, 2]; temp = ReadyQ[0]; ReadyQ[0] = ReadyQ[i]; ReadyQ[i] = temp; }
                    }
            }
        }
        public void running(int ReadyQ0, ref int[,] processes, int NumOfProcesses, int time)
        {
            for (int i = 0; i < NumOfProcesses; i++)
            {
                if (ReadyQ0 == processes[i, 0])
                {
                    processes[i, 2]--;
                    Console.WriteLine("at the second {0}: processing p{1}", time, processes[i, 0]);
                    break;
                }
            }

        }
        public void dequeue(ref int[,] processes, int NumOfProcesses, ref int[] ReadyQ, ref int ReadyNum, int time)
        {
            for (int i = 0; i < NumOfProcesses; i++)
            {
                if (ReadyQ[0] == processes[i, 0])
                {
                    if (processes[i, 2] == 0)
                    {
                        ReadyNum--;
                        ReadyQ[0] = ReadyQ[ReadyNum];
                        processes[i, 4] = time - processes[i, 1] - processes[i, 6] + 1;
                        processes[i, 5] = time - processes[i, 1] + 1;
                    }
                }
            }
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((TxtBoxMaxPrsNum.Text == "") || ((CmbBoxAlgorithm.Text != "first come first served") && (CmbBoxAlgorithm.Text != "shortest job first preemptive")
                && (CmbBoxAlgorithm.Text != "shortest job first non-preemptive") && (CmbBoxAlgorithm.Text != "priority preemptive")
                && (CmbBoxAlgorithm.Text != "priority non-preemptive") && (CmbBoxAlgorithm.Text != "round robin")))
            {
                MessageBox.Show("Please Enter The Max Process Number And The Required Algorithm Then Press OK"); 
            }
            else
            {
                button2.Visible = true;
                MaxProsNum = Convert.ToInt32(TxtBoxMaxPrsNum.Text);
                for (int i = 0; i < 6; i++)
                {
                    foreach (Control c in GrbBoxL.Controls)
                    {
                        if ((c.Tag != null) && (Convert.ToInt32(c.Tag) >= MaxProsNum))
                        {
                            c.Dispose();
                        }

                    }
                    foreach (Control c in GrbBoxArr.Controls)
                    {
                        if ((c.Tag != null) && (Convert.ToInt32(c.Tag) >= MaxProsNum))
                        {
                            c.Dispose();
                        }

                    } foreach (Control c in GrbBoxBurst.Controls)
                    {
                        if ((c.Tag != null) && (Convert.ToInt32(c.Tag) >= MaxProsNum))
                        {
                            c.Dispose();
                        }

                    } foreach (Control c in GrbBoxP.Controls)
                    {
                        if ((c.Tag != null) && (Convert.ToInt32(c.Tag) >= MaxProsNum))
                        {
                            c.Dispose();
                        }

                    }
                }

                if ((CmbBoxAlgorithm.Text == "priority preemptive") || (CmbBoxAlgorithm.Text == "priority non-preemptive"))
                {
                  /*  Label Arr = new Label(); Label Brst = new Label(); Label Priority = new Label();
                    Arr.Top = 70; Arr.Left = 90; Arr.Text = "Arrival Time"; Arr.Name = "x0"; Arr.Width = 59;Arr.Height = 20;
                    Brst.Top = 70; Brst.Left = 165; Brst.Text = "Burst Time"; Brst.Name = "y0"; Brst.Width = 59; Brst.Height = 20;
                    Priority.Top = 70; Priority.Left = 256; Priority.Text = "Priority"; Priority.Name = "z0"; Priority.Width = 59; Priority.Height = 20;
                    GrbBox.Controls.Add(Arr);
                    GrbBox.Controls.Add(Brst);
                    GrbBox.Controls.Add(Priority);*/
                    LblQuan.Visible = false ;
                    TxtBoxQuan.Visible = false;
                    GrbBoxP.Visible = true;
                    GrbBox.Visible = true;
                    Label[] labels = new Label[MaxProsNum];
                    TextBox[] textBoxsArr = new TextBox[MaxProsNum];
                    TextBox[] textBoxsBrst = new TextBox[MaxProsNum];
                    TextBox[] textBoxsP = new TextBox[MaxProsNum];
                    for (int i = 0; i < MaxProsNum; i++)
                    {
                        //Create label
                        labels[i] = new Label();
                        labels[i].Text = String.Format("P{0}", i);
                        labels[i].Name = String.Format("L{0}", i);
                        labels[i].Tag = i;
                        //Position label on screen
                        labels[i].Width = 59;
                        labels[i].Height = 20;
                        labels[i].Left = 4;
                        labels[i].Top = 41 + (i * 20);
                        //Create textbox
                        textBoxsArr[i] = new TextBox();
                        textBoxsArr[i].Name = String.Format("P{0}", i);
                        textBoxsArr[i].Tag = i;
                        textBoxsArr[i].Width = 59;
                        textBoxsArr[i].Height = 20;
                        textBoxsArr[i].Left = 4;
                        textBoxsArr[i].Top = 41 + (i * 20);
                        //Create textbox
                        textBoxsBrst[i] = new TextBox();
                        textBoxsBrst[i].Name = String.Format("B{0}", i);
                        textBoxsBrst[i].Tag = i;
                        textBoxsBrst[i].Width = 59;
                        textBoxsBrst[i].Height = 20;
                        textBoxsBrst[i].Left = 4;
                        textBoxsBrst[i].Top = 41 + (i * 20);
                        //Create textbox
                        textBoxsP[i] = new TextBox();
                        textBoxsP[i].Name = String.Format("H{0}", i);
                        textBoxsP[i].Tag = i;
                        textBoxsP[i].Width = 59;
                        textBoxsP[i].Height = 20;
                        textBoxsP[i].Left = 4;
                        textBoxsP[i].Top = 41 + (i * 20);
                        //Add controls to form
                        GrbBoxL.Controls.Add(labels[i]);
                        GrbBoxArr.Controls.Add(textBoxsArr[i]);
                        GrbBoxBurst.Controls.Add(textBoxsBrst[i]);
                        GrbBoxP.Controls.Add(textBoxsP[i]);
                    }
                }
                else if (CmbBoxAlgorithm.Text == "round robin")
                {
                    LblQuan.Visible = true ;
                    TxtBoxQuan.Visible = true;
                    GrbBoxP.Visible = false;
                    GrbBox.Visible = true;
                    Label[] labels = new Label[MaxProsNum];
                    TextBox[] textBoxsArr = new TextBox[MaxProsNum];
                    TextBox[] textBoxsBrst = new TextBox[MaxProsNum];
                    for (int i = 0; i < MaxProsNum; i++)
                    {
                        //Create label
                        labels[i] = new Label();
                        labels[i].Text = String.Format("P{0}", i);
                        labels[i].Name = String.Format("L{0}", i);
                        labels[i].Tag = i;
                        //Position label on screen
                        labels[i].Width = 59;
                        labels[i].Height = 20;
                        labels[i].Left = 4;
                        labels[i].Top = 41 + (i * 20);
                        //Create textbox
                        textBoxsArr[i] = new TextBox();
                        textBoxsArr[i].Name = String.Format("P{0}", i);
                        textBoxsArr[i].Tag = i;
                        textBoxsArr[i].Width = 59;
                        textBoxsArr[i].Height = 20;
                        textBoxsArr[i].Left = 4;
                        textBoxsArr[i].Top = 41 + (i * 20);
                        //Create textbox
                        textBoxsBrst[i] = new TextBox();
                        textBoxsBrst[i].Name = String.Format("B{0}", i);
                        textBoxsBrst[i].Tag = i;
                        textBoxsBrst[i].Width = 59;
                        textBoxsBrst[i].Height = 20;
                        textBoxsBrst[i].Left = 4;
                        textBoxsBrst[i].Top = 41 + (i * 20);
                        GrbBoxL.Controls.Add(labels[i]);
                        GrbBoxArr.Controls.Add(textBoxsArr[i]);
                        GrbBoxBurst.Controls.Add(textBoxsBrst[i]);
                    }
                }
                else
                {
                    LblQuan.Visible = false ;
                    TxtBoxQuan.Visible = false;
                    GrbBoxP.Visible = false;
                    GrbBox.Visible = true;
                    Label[] labels = new Label[MaxProsNum];
                    TextBox[] textBoxsArr = new TextBox[MaxProsNum];
                    TextBox[] textBoxsBrst = new TextBox[MaxProsNum];
                    for (int i = 0; i < MaxProsNum; i++)
                    {
                        //Create label
                        labels[i] = new Label();
                        labels[i].Text = String.Format("P{0}", i);
                        labels[i].Name = String.Format("L{0}", i);
                        labels[i].Tag = i;
                        //Position label on screen
                        labels[i].Width = 59;
                        labels[i].Height = 20;
                        labels[i].Left = 4;
                        labels[i].Top = 41 + (i * 20);
                        //Create textbox
                        textBoxsArr[i] = new TextBox();
                        textBoxsArr[i].Name = String.Format("P{0}", i);
                        textBoxsArr[i].Tag = i;
                        textBoxsArr[i].Width = 59;
                        textBoxsArr[i].Height = 20;
                        textBoxsArr[i].Left = 4;
                        textBoxsArr[i].Top = 41 + (i * 20);
                        //Create textbox
                        textBoxsBrst[i] = new TextBox();
                        textBoxsBrst[i].Name = String.Format("B{0}", i);
                        textBoxsBrst[i].Tag = i;
                        textBoxsBrst[i].Width = 59;
                        textBoxsBrst[i].Height = 20;
                        textBoxsBrst[i].Left = 4;
                        textBoxsBrst[i].Top = 41 + (i * 20);
                        GrbBoxL.Controls.Add(labels[i]);
                        GrbBoxArr.Controls.Add(textBoxsArr[i]);
                        GrbBoxBurst.Controls.Add(textBoxsBrst[i]);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((CmbBoxAlgorithm.Text != "first come first served") && (CmbBoxAlgorithm.Text != "shortest job first preemptive")
                && (CmbBoxAlgorithm.Text != "shortest job first non-preemptive") && (CmbBoxAlgorithm.Text != "priority preemptive")
                && (CmbBoxAlgorithm.Text != "priority non-preemptive") && (CmbBoxAlgorithm.Text != "round robin"))
            {
                MessageBox.Show("Please Enter The Required Algorithm Then Press OK");
            }
            else
            {
                for (int i = 0; i < 6; i++)
                {
                    foreach (Control c in flowLayoutPanel1.Controls)
                    {
                        flowLayoutPanel1.Controls.Remove(c);
                    }
                }
                groupBox1.Visible = true;
                SumBox.Visible = true;
                label2.Visible = true;
                SumBox.Clear();
                int NumOfProcesses = 0;
                foreach (Control c in GrbBoxArr.Controls)
                {
                    if (c is TextBox)
                    {
                        TextBox txt = new TextBox();
                        txt = (TextBox)c;
                        if (txt.Text != "")
                        {
                            NumOfProcesses++;
                        }
                    }
                }
                if ((CmbBoxAlgorithm.Text == "shortest job first preemptive") || (CmbBoxAlgorithm.Text == "shortest job first non-preemptive") ||
                    (CmbBoxAlgorithm.Text == "priority preemptive") || (CmbBoxAlgorithm.Text == "priority non-preemptive"))
                {
                    int[,] processes = new int[NumOfProcesses, 7];
                    int[] ReadyQ = new int[NumOfProcesses];
                    int ReadyNum = 0;
                    int PreTop = -1;
                    int time = 0;
                    bool finished = true;
                    List<string> GT_names = new List<string>();
                    List<int> GT_times = new List<int>();
                    int GT_counter = 0;
                    int counter1 = 0;  
                    int counter2 = 0;
                    int counter3 = 0;
                    foreach (Control c in GrbBoxArr.Controls)
                    {
                        if (c is TextBox)
                        {
                            TextBox txt = new TextBox();
                            txt = (TextBox)c;
                            if (txt.Text != "")
                            {
                                processes[counter1, 1]= (int)Convert.ToDouble(txt.Text);
                                processes[counter1, 0] = Convert.ToInt32(txt.Tag);
                                processes[counter1, 4] = 0;
                                processes[counter1, 5] = 0;
                                counter1++;
                            }
                        }
                    }
                    foreach (Control c in GrbBoxBurst.Controls)
                    {
                        if (c is TextBox)
                        {
                            TextBox txt = new TextBox();
                            txt = (TextBox)c;
                            if (txt.Text != "")
                            {
                                for (int i = 0; i < NumOfProcesses; i++)
                                {
                                    if (Convert.ToInt32(txt.Tag) == processes[i, 0])
                                    {
                                        processes[i, 2] = (int)Convert.ToDouble(txt.Text);
                                        processes[i, 3] = 0;
                                        processes[i, 6] = processes[i, 2];
                                        counter2++; 
                                    }
                                }
                            }
                        }
                    }
                    if ((CmbBoxAlgorithm.Text == "priority preemptive") || (CmbBoxAlgorithm.Text == "priority non-preemptive"))
                    {
                        foreach (Control c in GrbBoxP.Controls)
                        {
                            if (c is TextBox)
                            {
                                TextBox txt = new TextBox();
                                txt = (TextBox)c;
                                if (txt.Text != "")
                                {
                                    for (int i = 0; i < NumOfProcesses; i++)
                                    {
                                        if (Convert.ToInt32(txt.Tag) == processes[i, 0])
                                        {
                                            processes[i, 3] = Convert.ToInt32(txt.Text);
                                            counter3++;
                                        }
                                    }
                                }
                            }
                        }
                        if ((NumOfProcesses != counter1)|| (counter1!= counter2)|| (counter2 != counter3))
                        {
                            MessageBox.Show("Please Enter The Required Data In Their Fields");
                            return;
                        }
                    }
                    if ((NumOfProcesses != counter1) || (counter1 != counter2))
                    {
                        MessageBox.Show("Please Enter The Required Data In Their Fields");
                        return;
                    }
                    while (finished)
                    {
                        // lookking for new processes to enter the ready queue
                        for (int i = 0; i < NumOfProcesses; i++)
                        {
                            if (processes[i, 1] == time) { ReadyQ[ReadyNum] = processes[i, 0]; ReadyNum++; }
                        }

                        // sorting according to required algorithm
                        if (CmbBoxAlgorithm.Text == "shortest job first preemptive")
                        {
                            sort(processes, NumOfProcesses, ref ReadyQ, ReadyNum); //preemptive SJF
                        }
                        else if (CmbBoxAlgorithm.Text == "shortest job first non-preemptive")
                        {
                            if (PreTop != ReadyQ[0])
                                sort(processes, NumOfProcesses, ref ReadyQ, ReadyNum);  //non-preemptive SJF
                            PreTop = ReadyQ[0];
                        }
                        else if (CmbBoxAlgorithm.Text == "priority preemptive")
                        {
                            Psort(processes, NumOfProcesses, ref ReadyQ, ReadyNum); //preemptive priority
                        }
                        else if (CmbBoxAlgorithm.Text == "priority non-preemptive")
                        {
                            if (PreTop != ReadyQ[0])
                                Psort(processes, NumOfProcesses, ref ReadyQ, ReadyNum);//non-preemptive priority
                            PreTop = ReadyQ[0];
                        }


                        if (ReadyNum == 0)
                        {
                            Console.WriteLine("at the second {0}: No processes yet", time);
                            if (GT_names.Count != 0)
                            {
                                if (GT_names[GT_names.Count - 1] != "NOP")
                                {
                                    GT_times.Add(GT_counter + 1);
                                    GT_names.Add("NOP");
                                    GT_counter = 0;
                                }
                                else GT_counter++;
                            }
                            else { GT_counter = 0; GT_names.Add("NOP"); }
                        }
                        else
                        {
                            running(ReadyQ[0], ref processes, NumOfProcesses, time); //running the top queue process if there is any
                            if (GT_names.Count != 0)
                            {
                                if (string.Format("P{0}", ReadyQ[0]) == GT_names[GT_names.Count - 1])
                                {
                                    GT_counter++;
                                }
                                else
                                {
                                    GT_times.Add(GT_counter + 1);
                                    GT_names.Add(string.Format("P{0}", ReadyQ[0]));
                                    GT_counter = 0;
                                }
                            }
                            else { GT_counter = 0; GT_names.Add(string.Format("P{0}", ReadyQ[0])); }
                            dequeue(ref processes, NumOfProcesses, ref ReadyQ, ref ReadyNum, time); //removing the 0 remaining time process from ReadyQ if there is any
                        }

                        // checking if all processes have 0 remaining time then processing has been finished
                        int counter = 0;
                        for (int i = 0; i < NumOfProcesses; i++)
                        {
                            if (processes[i, 2] == 0) counter++;
                        }
                        if (counter == NumOfProcesses) { finished = false; GT_times.Add(GT_counter + 1); }
                        else time++;
                    }
                    double sum = 0;
                    for (int i = 0; i < NumOfProcesses; i++)
                    {
                        sum += processes[i, 4];
                    }
                    sum = sum / NumOfProcesses;
                    SumBox.Text = String.Format("{0}", sum);
                    
                    GT_times.Insert(0, 0);
                    string[] processes_arr = GT_names.ToArray();
                    int[] timing_arr = GT_times.ToArray();
                    for (int i = 1; i < timing_arr.Length; i++)
                    {
                        timing_arr[i] += timing_arr[i - 1];
                    }
                    flowLayoutPanel1.Visible = true;
                    flowLayoutPanel1.WrapContents = true;
                    flowLayoutPanel1.AutoScroll = true;
                    flowLayoutPanel1.Padding = new Padding(0);

                    for (int i = 0; i < processes_arr.Length; i++)
                    {
                        /** Create new labels **/
                        Label newLabel = new Label();  // process name
                        Label newLabel2 = new Label();  // starting time of this process
                        /** adjust labels' attributes **/
                        newLabel.Text = processes_arr[i];
                        newLabel2.Text = Convert.ToString(timing_arr[i]);
                        newLabel.BackColor = Color.Gray; // background color
                        newLabel.ForeColor = Color.White; // font color
                        newLabel2.BackColor = Color.Black; // background color
                        newLabel2.ForeColor = Color.White; // font color
                        newLabel2.Height = newLabel.Height;
                        newLabel2.Width = newLabel.Width / 4;
                        newLabel.Margin = new Padding(0); // erase spacings between labels
                        newLabel2.Margin = new Padding(0); // erase spacings between labels
                        newLabel.TextAlign = ContentAlignment.MiddleCenter; // allign text in center
                        newLabel2.TextAlign = ContentAlignment.MiddleCenter; // allign text in center
                        /** print labels in GUI **/
                        flowLayoutPanel1.Controls.Add(newLabel2);
                        flowLayoutPanel1.Controls.Add(newLabel);
                        if (i == processes_arr.Length - 1)
                        {// To handle the last time label printed
                            /** Create new label **/
                            Label newLabel3 = new Label(); // End time of last process
                            /** adjust label's attributes **/
                            newLabel3.Text = Convert.ToString(timing_arr[i+1]);
                            newLabel3.BackColor = Color.Black;
                            newLabel3.ForeColor = Color.White;
                            newLabel3.Height = newLabel.Height;
                            newLabel3.Width = newLabel.Width / 4;
                            newLabel3.Margin = new Padding(0); // erase spacings between labels
                            newLabel3.TextAlign = ContentAlignment.MiddleCenter; // allign text in center
                            /** print label in GUI **/
                            flowLayoutPanel1.Controls.Add(newLabel3);
                        }

                    }
                }


                else if ((CmbBoxAlgorithm.Text == "first come first served") || (CmbBoxAlgorithm.Text == "round robin"))
                {
                    double[] key_arr = new double [NumOfProcesses];
                    double[] values_arr = new double[NumOfProcesses];
                    string[] names_arr = new string[NumOfProcesses];
                    double[] key_arr2 = new double[NumOfProcesses];
                    double[] key_arr3 = new double[NumOfProcesses];
                    int counter1 = 0;
                    int counter2 = 0;
                    foreach (Control c in GrbBoxArr.Controls)
                    {
                        if (c is TextBox)
                        {
                            TextBox txt = new TextBox();
                            txt = (TextBox)c;
                            if (txt.Text != "")
                            {
                                key_arr[counter1] = Convert.ToDouble(txt.Text);
                                key_arr2[counter1] = Convert.ToDouble(txt.Text);
                                key_arr3[counter1] = Convert.ToDouble(txt.Text);
                                names_arr[counter1] = txt.Name;
                                counter1++;
                            }
                        }
                    }
                    
                    foreach (Control c in GrbBoxBurst.Controls)
                    {
                        if (c is TextBox)
                        {
                            TextBox txt = new TextBox();
                            txt = (TextBox)c;
                            if (txt.Text != "")
                            {
                                for (int i = 0; i < NumOfProcesses; i++)
                                {
                                    if (names_arr[i].Substring(1) == txt.Name.Substring(1))
                                    {
                                        values_arr[i] = Convert.ToDouble(txt.Text);
                                        counter2++;
                                    }
                                }
                            }
                        }
                    }
                    double[] waiting_arr = new double[NumOfProcesses];
                    for (int i = 0; i < NumOfProcesses; i++)
                    {
                        waiting_arr[i] = key_arr[i] + values_arr[i];
                    }
                    
                    if ( (NumOfProcesses != counter1) || (counter1 != counter2  ))
                    {
                        MessageBox.Show("Please Enter The Required Data In Their Fields");
                        return;
                    }
                    Array.Sort(key_arr, values_arr);
                    Array.Sort(key_arr2, names_arr); // to make P1 > first process entered by user not first process in arrival time
                    Array.Sort(key_arr3, waiting_arr);
                    List<double> timing_list = new List<double>();
                    List<string> naming_list = new List<string>();
                    if (CmbBoxAlgorithm.Text == "round robin")
                    {
                        if (TxtBoxQuan.Text == "") { MessageBox.Show("Please Enter The Required Data In Their Fields"); return; }
                        float Quantum = Convert.ToSingle(TxtBoxQuan.Text);
                        assign_RR(key_arr, values_arr, names_arr, waiting_arr, Quantum, timing_list, naming_list);
                    }
                    else
                    {
                        assign_FCFS(key_arr, values_arr, names_arr, waiting_arr, timing_list, naming_list);
                    }
                    double avg_wait = 0;
                    for (int i = 0; i < NumOfProcesses; i++)
                    {
                        avg_wait += waiting_arr[i];
                    }
                    avg_wait = avg_wait / NumOfProcesses;
                    avg_wait = System.Math.Round(avg_wait, 3);
                    SumBox.Text = Convert.ToString(avg_wait) ;

                    string[] processes_arr = naming_list.ToArray();
                    double[] timing_arr = timing_list.ToArray(); ;
                    flowLayoutPanel1.Visible = true;
                    flowLayoutPanel1.WrapContents = true;
                    flowLayoutPanel1.AutoScroll = true;
                    flowLayoutPanel1.Padding = new Padding(0);

                    for (int i = 0; i < processes_arr.Length; i++)
                    {
                        /** Create new labels **/
                        Label newLabel = new Label();  // process name
                        Label newLabel2 = new Label();  // starting time of this process
                        /** adjust labels' attributes **/
                        newLabel.Text = processes_arr[i];
                        newLabel2.Text = Convert.ToString(timing_arr[i]);
                        newLabel.BackColor = Color.Gray; // background color
                        newLabel.ForeColor = Color.White; // font color
                        newLabel2.BackColor = Color.Black; // background color
                        newLabel2.ForeColor = Color.White; // font color
                        newLabel2.Height = newLabel.Height;
                        newLabel2.Width = newLabel.Width / 4;
                        newLabel.Margin = new Padding(0); // erase spacings between labels
                        newLabel2.Margin = new Padding(0); // erase spacings between labels
                        newLabel.TextAlign = ContentAlignment.MiddleCenter; // allign text in center
                        newLabel2.TextAlign = ContentAlignment.MiddleCenter; // allign text in center
                        /** print labels in GUI **/
                        flowLayoutPanel1.Controls.Add(newLabel2);
                        flowLayoutPanel1.Controls.Add(newLabel);
                        if (i == processes_arr.Length - 1)
                        {// To handle the last time label printed
                            /** Create new label **/
                            Label newLabel3 = new Label(); // End time of last process
                            /** adjust label's attributes **/
                            newLabel3.Text = Convert.ToString(timing_arr[i + 1]);
                            newLabel3.BackColor = Color.Black;
                            newLabel3.ForeColor = Color.White;
                            newLabel3.Height = newLabel.Height;
                            newLabel3.Width = newLabel.Width / 4;
                            newLabel3.Margin = new Padding(0); // erase spacings between labels
                            newLabel3.TextAlign = ContentAlignment.MiddleCenter; // allign text in center
                            /** print label in GUI **/
                            flowLayoutPanel1.Controls.Add(newLabel3);
                        }

                    }
                }
            }
        }          

    }
}
