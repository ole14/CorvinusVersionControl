using MicroSimulation.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicroSimulation
{
    public partial class Form1 : Form
    {
        List<Person> Population = new List<Person>();
        List<BirthProbability> BirthProbabilities = new List<BirthProbability>();
        List<DeathProbability> DeathProbabilities = new List<DeathProbability>();
        List<Male> MaleNumbers = new List<Male>();
        List<Female> FemaleNumbers = new List<Female>();
        Random rng = new Random(1234);
        public Form1()
        {
            InitializeComponent();
            numericUpDown1.Maximum = 2100;
            numericUpDown1.Minimum = 1900;
            numericUpDown1.Value = 2024;
        }

        private void Simulation()
        {
            richTextBox1.Clear();
            MaleNumbers.Clear();
            FemaleNumbers.Clear();
            Population = GetPopulation(textBox1.Text);
            BirthProbabilities = GetBirthProbabilities(@"C:\Temp\születés.csv");
            DeathProbabilities = GetDeathProbabilities(@"C:\Temp\halál.csv");

            for (int year = 2005; year <= numericUpDown1.Value; year++)
            {
                for (int i = 0; i < Population.Count; i++)
                {
                    SimStep(year, Population[i]);
                }

                int Malepop = (from x in Population
                               where x.Gender == Gender.Male && x.IsAlive
                               select x).Count();
                int Femalepop = (from x in Population
                                 where x.Gender == Gender.Felmale && x.IsAlive
                                 select x).Count();

                Console.WriteLine(
                    string.Format("Év:{0} Fiúk:{1} Lányok:{2}", year, Malepop, Femalepop));


                List<Male> males = new List<Male>();
                males.Add(new Male()
                {
                    Year = year,
                    NbrPopul = Malepop
                });

                List<Female> females = new List<Female>();
                females.Add(new Female()
                {
                    Year = year,
                    NbrPopul = Femalepop
                });

                Displayresults();
            }
        }

        private void Displayresults()
        {
            for (int year = 2005; year <= numericUpDown1.Value; year++)
            {
                var maleno = (from x in MaleNumbers
                                  where x.Year == year
                                  select x.NbrPopul);

                var femaleno = (from x in FemaleNumbers
                                   where x.Year == year
                                   select x.NbrPopul);

                richTextBox1.Text = "Szimulációs év: " + year.ToString()
                                    + "\n \t Fiúk: " + maleno.ToString()
                                    + "\n \t Lányok: " + femaleno.ToString() + "\n";
            }
        }

        private void SimStep(int year, Person person)
        {
            if (!person.IsAlive) return;

            byte Age = (byte)(year - person.BirthYear);

            double pDeath = (from x in DeathProbabilities
                             where x.Gender == person.Gender && x.Age == Age
                             select x.Probability).FirstOrDefault();

            if (rng.NextDouble() <= pDeath)
                person.IsAlive = false;

            if(person.IsAlive == true && person.Gender == Gender.Felmale)
            {
                double pBirth = (from x in BirthProbabilities
                              where x.Age == Age
                              select x.Probability).FirstOrDefault();

                if (rng.NextDouble() <= pBirth)
                {
                    Person uj = new Person();
                    uj.BirthYear = year;
                    uj.NbrOfChildren = 0;
                    uj.Gender = (Gender)rng.Next(1, 3);
                    Population.Add(uj);
                }
            }
        }

        public List<Person> GetPopulation(string csvpath)
        {
            List<Person> population = new List<Person>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    population.Add(new Person()
                    {
                        BirthYear = int.Parse(line[0]),
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[1]),
                        NbrOfChildren = int.Parse(line[2])
                    });
                }
                return population;
            }
        }

        

        public List<BirthProbability> GetBirthProbabilities(string csvpath)
        {
            List<BirthProbability> birthProbabilities = new List<BirthProbability>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    birthProbabilities.Add(new BirthProbability()
                    {
                        Age = int.Parse(line[0]),
                        NbrOfChildren = int.Parse(line[1]),
                        Probability = double.Parse(line[2].Replace(',','.'))
                    });
                }
            }
            return birthProbabilities;
        }

        public List<DeathProbability> GetDeathProbabilities(string csvpath)
        {
            List<DeathProbability> deathProbabilities = new List<DeathProbability>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while(!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    string prob = line[2];
                    deathProbabilities.Add(new DeathProbability()
                    {
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[0]),
                        Age = int.Parse(line[1]),
                        Probability = double.Parse(line[2].Replace(',', '.'))
                    });
                }
            }
            return deathProbabilities;
        }

        private void start_Click(object sender, EventArgs e)
        {
            Simulation();
        }

        private void browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            textBox1.Text = ofd.FileName.ToString();
        }
    }
}
