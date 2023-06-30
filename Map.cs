using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzer
{
    class Map
    {
        public List<MapCell> map = new List<MapCell>();
        public Map() {}
        private void AddElement(string word, string[] heapWords)
        {
            MapCell cell = new MapCell(word, TextProcessingStage.WordCount(word, heapWords));
            MapCell temp;
            map.Add(cell);
            for (int i = 0; i < map.Count - 1; i++)
            {
                for (int j = 0; j < map.Count - i - 1; j++)
                {
                    if (map[j].Count < map[j + 1].Count)
                    {
                        temp = map[j];
                        map[j] = map[j + 1];
                        map[j + 1] = temp;
                    }
                }
            }
        }
        public void Fill(string[] uniqueWords, string[] heapWords)
        {
            foreach (string word in uniqueWords)
            {
                AddElement(word, heapWords);
            }
        }

        public MapCell FindCellByWord(string word)
        {
            MapCell foundedCell = new MapCell();
            foreach(var cell in map)
            {
                if (cell.Word == word)
                {
                    foundedCell = cell;
                }
            }
            return foundedCell;
        }
        public MapCell FindCellByCount(int count)
        {
            MapCell foundedCell = new MapCell();
            foreach (var cell in map)
            {
                if (cell.Count == count)
                {
                    foundedCell = cell;
                }
            }
            return foundedCell;
        }

        public void Print()
        {
            foreach(var cell in map)
            {
                Console.WriteLine($"{cell.Word}\t\t\t\t:\t{cell.Count}");
            }
        }
    }
    struct MapCell
    {
        public MapCell() {}
        public MapCell (string word, int count)
        {
            this.word = word;
            this.count = count;
        }

        private string word = "";
        private int count = 0;
        public string Word 
        { 
            private set
            {
                word = value;
            } 
            get
            {
                return this.word;
            } 
        }
        public int Count 
        {
            set
            {
                count = value;
            }
            get
            {
                return this.count;
            }
        }
    }
}
