using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace PizzaParticipants
{
    public partial class Form1 : Form
    {
        string filename = "";
        public Form1()
        {
            var participantsNumber = 505000000;
            //var TypeNumber = 0;

            var openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            var input = File.ReadAllText(openFileDialog.FileName);
            var InputList = input.Split(" ").Select(n => int.Parse(n)).ToList();

            var sum=0;
            //var random = new Random();
            //var RandomList = new List<int>();
            //var RandomVar = 0;
            
            //while(RandomList.Count < InputList.Count)
            //{
            //    RandomVar = random.Next(InputList.Count);
            //    if (!RandomList.Contains(RandomVar))
            //        RandomList.Add(RandomVar);
            //}


            //RandomList.OrderBy(c => c);
            var indexList = new Dictionary<int,int>();
            var Result = "";
            var tempListIndex = new List<int>();
            for (int i = InputList.Count; i>=0; i--)
            {
                try
                {
                    if (sum + InputList[i-1] > participantsNumber)
                    {
                        
                        Result = participantsNumber + Environment.NewLine + sum + Environment.NewLine + (participantsNumber - sum);
                        tempListIndex = indexList.Select(item => item.Key).ToList();
                        //tempListIndex = tempListIndex.OrderBy(m => m).ToList();
                        Console.WriteLine(Result + Environment.NewLine + String.Join(", ", tempListIndex));
                        save(Result + Environment.NewLine + String.Join(", ", tempListIndex));
                        if (i >= 0)
                            continue;
                        break;
                    }
                    sum += InputList[i-1];
                    indexList.Add(i-1, InputList[i-1]);
                }
                catch (Exception)
                {

                    //throw;
                }
                //indexList.Add(i, RandomList[i - 1], InputList[RandomList[i - 1]]);

            }
            ///Process.Start(filename);
        }
        void save(string Data)
        {
            filename = @"C:\Users\Ameer\Documents\" + DateTime.Now.TimeOfDay.Hours
                                                     + "-" + DateTime.Now.TimeOfDay.Minutes
                                                     + "-" + DateTime.Now.TimeOfDay.Seconds
                                                     + ".txt";
            File.WriteAllText(filename, Data);
        }

    }
}
