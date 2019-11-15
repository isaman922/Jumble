using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Windows.Forms;

namespace WordJumble
{
    class GetPuzzle
    {
        //Class which retrieves the puzzle data from the XML file and sets the game data

        Game currentGame;

        //Contains the words and hints
        string[,] puzzleData = new string[6,2];

        //Contains the list of silver square locations at [question #][square #]
        bool[,] silverSquares = new bool[5,12];

        public GetPuzzle(Game sender)
        {
            currentGame = sender;
            OpenFile();
            SetGame();
        }

        public void OpenFile()
        {
            //Open XML File
            XmlTextReader reader = new XmlTextReader(Path.GetDirectoryName(Application.ExecutablePath).ToString() + @"\..\..\Resources\CurrentXML.xml");

            int firstArray = 0;
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:

                        switch (reader.Name)
                        {
                            case "jumble":
                                break;
                            case "gameData":
                                currentGame.Controls.Find("title", true)[0].Text = reader.GetAttribute("title");
                                currentGame.Controls.Find("subtitle", true)[0].Text = reader.GetAttribute("subtitle");
                                string test1 = currentGame.Controls.Find("title", true)[0].Text;
                                string test2 = currentGame.Controls.Find("subtitle", true)[0].Text;
                                currentGame.Manager = reader.GetAttribute("supervisor");
                                break;

                            case "word":
                                if(reader.GetAttribute("round") == "reg")
                                {
                                    for (int n = 0; n < reader.GetAttribute("index").Length; n++)
                                    {
                                        int index = Convert.ToInt32(reader.GetAttribute("index")[n].ToString())-1;
                                        silverSquares[firstArray, index] = true;
                                    }
                                }
                                puzzleData[firstArray, 0] = reader.GetAttribute("answer");
                                puzzleData[firstArray, 1] = reader.GetAttribute("hint");
                                firstArray++;
                                break;
                        }
                        break;
                    case XmlNodeType.EndElement:
                        break;
                }
            }
        }

        public void SetGame()
        {
            //Set silver squares
            char[] marker = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L' };

            for (int q = 1; q <= 5; q++)
            {
                for (int s = 1; s <= 12; s++)
                {
                    if (silverSquares[q-1,s-1])
                    {
                        currentGame.Controls.Find($"guess{q}{marker[s-1].ToString()}", true)[0].BackColor = Color.Silver;
                    }
                }
            }

            //Set words and hints
            currentGame.Word1 = puzzleData[0, 0].ToUpper();
            currentGame.Word2 = puzzleData[1, 0].ToUpper();
            currentGame.Word3 = puzzleData[2, 0].ToUpper();
            currentGame.Word4 = puzzleData[3, 0].ToUpper();
            currentGame.Word5 = puzzleData[4, 0].ToUpper();
            currentGame.FinalWord = puzzleData[5, 0].ToUpper();

            for (int i = 1; i <= 5; i++)
            {
                currentGame.Controls.Find($"jumble{i}", true)[0].Text = Scramble(puzzleData[i-1, 0]);
                currentGame.Controls.Find($"hint{i}", true)[0].Text = $"Hint: {puzzleData[i-1, 1]}";
            }

            currentGame.Controls.Find($"hintFinal", true)[0].Text = puzzleData[5, 1];
        }

        private string Scramble(string word)
        {
            //Scrambles the string and returns the scrambled version
            Random rnd = new Random();

            var list = new SortedList<int, char>();
            foreach (var c in word)
            {
                list.Add(rnd.Next(), c);
            }
            string newword = new string(list.Values.ToArray());
            return newword.ToUpper();
        }
    }
}
