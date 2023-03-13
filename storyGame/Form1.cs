using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace storyGame
{
    public partial class Form1 : Form
    {
        private Dictionary<string, Events> currentDictionary = null;
        private string eventRandomlyPicked;
        private int[] kingdomCurrentValues;
        //this returns null.
        public PictureBox[] pictureBoxes;


        public Form1()
        {
            InitializeComponent();
            //if health = 0 game over.
            kingdomCurrentValues = new int[] { /*money: */1,/*population*/ 3,/*army*/ 2, /*health*/ 1, /*happiness*/ 2,/*relgion*/ 10 };
            PictureBox[] pictureBoxes = { pb_bar_money, pb_bar_population, pb_bar_army, pb_bar_health, pb_bar_happiness, pb_bar_relgion };
            drawBoxes(pictureBoxes, kingdomCurrentValues);
            Dictionary<string, Events> unluckyEventsDict = new Dictionary<string, Events>()
            {
                { "plague", new Events("A plague has taken over the land. Do you quarantine your people?", -10, -20, -20, -20, 0, -500, -10, -20, -20, -20, 0, -500) },
                { "famine", new Events("A famine has struck the land. Do you distribute food to the people?", -10, -20, 0, -20, 0, 0, -10, -20, -20, -20, 0, -500) },
                { "murder", new Events("A murder of a high nobel has taken place in the kingdom. Do you investigate and punish the culprit?", -10, -20, -20, -20, 0, -500, -10, -20, -20, -20, 0, -500) },
                { "assassinationAttempt", new Events("An assassination attempt has been made on your life. Do you increase security measures?", 10, -20, 10, -20, 0, 0, -10, -20, -20, -20, 0, -500) }
            };

            Dictionary<string, Events> luckyEventsDict = new Dictionary<string, Events>()
            {
                { "thrivingMarket", new Events("The market is booming. Do you increase taxes?", 10, 0, 10, 0, 0, 500, -10, -20, -20, -20, 0, -500) },
                { "populationBoom", new Events("The population is growing. Do you invest in infrastructure?", 0, 0, 20, 0, 0, 0, -10, -20, -20, -20, 0, -500) },
                { "greatSeason", new Events("The harvest is plentiful. Do you stockpile food for the future?", 0, 0, 10, 0, 0, 0,-10, -20, -20, -20, 0, -500) },
                { "festival", new Events("A festival is being held in your honor. Do you attend?", 0, 10, 0, 0, 0, 0, -10, -20, -20, -20, 0, -500) }
            };
            
            Dictionary<string, Events> naturalEventsDict = new Dictionary<string, Events>()
            {
                { "familyVisits", new Events("Your distant relatives visit you. Do you treat them with luxury or save money?", 10, 10, 0, 10, 0, -50, -10, -20, -20, -20, 0, -500) },
                { "nothing", new Events("Nothing of note happens this year. Do you use the time to prepare or slack off?", 0, 0, 0, 0, 0, 0, -10, -20, -20, -20, 0, -500) }
            };
            

            Dictionary<string, Events> tragedyEventsDict = new Dictionary<string, Events>()
            {
                { "invasion", new Events("Your kingdom is being invaded. Will you fight or flee?", -20, -20, -20, -20, 0, -500, -20, -20, -20, -20, 0, -500) },
                { "war", new Events("A war has broken out. Will you join the fight or stay neutral?", -10, -20, 0, -20, 0, -200, -20, -20, -20, -20, 0, -500) },
                { "rebellion", new Events("A rebellion has started. Will you suppress it or negotiate?", -20, -20, -20, -20, 0, -500, -20, -20, -20, -20, 0, -500) },
                { "naturalEvent", new Events("A natural disaster has occurred. Will you provide aid or ignore it?", -10, -20, -10, -20, 0, -200, -20, -20, -20, -20, 0, -500) }
                
            };

            int kama = 10;
            
            int listPicker = 0;


            //int randomNumberINT;

            static string randomEventPicked(Dictionary<string, Events> eventDict)
            {
                Random random = new Random();
                int index = random.Next(eventDict.Count);
                string eventKey = eventDict.Keys.ElementAt(index);
                return eventKey;
            }

            //using this for now
            //eventRandomlyPicked = randomEventPicked(tragedyEventsDict);

            
            if (kama >= 10)
            {
                eventRandomlyPicked = randomEventPicked(naturalEventsDict);
                listPicker += 1;
                if (kama > 5)
                {
                    eventRandomlyPicked = randomEventPicked(unluckyEventsDict);
                    listPicker += 1;
                    if (kama > 2)
                    {
                        eventRandomlyPicked = randomEventPicked(tragedyEventsDict);
                        listPicker += 1;
                    }
                }
            }
            else
            {
                eventRandomlyPicked = randomEventPicked(luckyEventsDict);

            }
            

            switch (listPicker)
            {
                case 0:
                    // luck list
                    currentDictionary = unluckyEventsDict;

                    break;
                case 1:

                    //nutral list
                    currentDictionary = naturalEventsDict;
                    break;
                case 2:

                    // unlucky list
                    currentDictionary = unluckyEventsDict;

                    break;
                case 3:

                    // tragedyList
                    currentDictionary = tragedyEventsDict;
                    break;
                
                default:
                    MessageBox.Show("listpicker error");
                    // code block
                    break;
            }


        }
        static void Start()
        {

        }
        static void Update()
        {

        }



        static void drawBoxes(PictureBox[] pictureBoxes, int[] kingdomCurrentValues)
        {
            for (int i = 0; i < kingdomCurrentValues.Length; i++)
            {
                if(pictureBoxes[i] != null)
                {
                    Bitmap bitmap = new Bitmap(pictureBoxes[i].Width, pictureBoxes[i].Height);
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        graphics.FillRectangle(Brushes.Red, new Rectangle(0, 0, pictureBoxes[i].Width / kingdomCurrentValues[i], pictureBoxes[i].Height));
                    }
                    pictureBoxes[i].Image = bitmap;
                }
                else
                {
                    MessageBox.Show($"picture box error {pictureBoxes[i]}");
                }
            }
        }

        static void CurrentHandleEvent(string eventPicked, bool userDecision, Dictionary<string, Events> dictionary, Label lblDisplayPromp, int[] kingdomCurrentValues)
        {
            foreach (KeyValuePair<string, Events> kvp in dictionary)
            {
                if (kvp.Key == eventPicked)
                {
                    lblDisplayPromp.Text = kvp.Value.eventPrompt;
                    //lblDisplayPromp.TextAlign = ContentAlignment.MiddleCenter;
                  
                    if (userDecision == false)
                    {
                        //need to add karma as a stat.
                        //kingdom class
                        kingdomCurrentValues[0] -= dictionary[eventPicked].NOhealth;
                        kingdomCurrentValues[1] -= dictionary[eventPicked].NOhappiness;
                        kingdomCurrentValues[2] -= dictionary[eventPicked].NOpopulation;
                        kingdomCurrentValues[3] -= dictionary[eventPicked].NOarmy;
                        kingdomCurrentValues[4] -= dictionary[eventPicked].NOculture;
                        kingdomCurrentValues[5] -= dictionary[eventPicked].NOgold;
                    }

                    else if(userDecision == true)
                    {
                        kingdomCurrentValues[0] -= dictionary[eventPicked].YEShealth;
                        kingdomCurrentValues[1] -= dictionary[eventPicked].YEShappiness;
                        kingdomCurrentValues[2] -= dictionary[eventPicked].YESpopulation;
                        kingdomCurrentValues[3] -= dictionary[eventPicked].YESarmy;
                        kingdomCurrentValues[4] -= dictionary[eventPicked].YESculture;
                        kingdomCurrentValues[5] -= dictionary[eventPicked].YESgold;
                    }

                    else
                    {
                        MessageBox.Show("CurrentHandleEvent method error");
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public string button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender; 
            string buttonText = button.Text;
            return buttonText;
        }
        //btw creating two variables for userDecision.

        public void btnOptionYes_Click(object sender, EventArgs e)
        {
            if (button_Click(sender, e) == "Yes")
            {
                 bool userDecision = true;
                 CurrentHandleEvent(eventRandomlyPicked, userDecision, currentDictionary, lblDisplayPromp, kingdomCurrentValues);
            }
            else
            {
                MessageBox.Show("btnOptionYes_Click error");
            }

        }

        public void btnOptionNo_Click(object sender, EventArgs e)
        {
            if (button_Click(sender, e) == "No")
            {
                bool userDecision = false;
                CurrentHandleEvent(eventRandomlyPicked, userDecision, currentDictionary, lblDisplayPromp, kingdomCurrentValues);
                drawBoxes(pictureBoxes, kingdomCurrentValues);
            }
            else
            {
                MessageBox.Show("btnOptionNo_Click error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
