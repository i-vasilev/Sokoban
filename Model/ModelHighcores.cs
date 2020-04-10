using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Класс модели таблицы рекордов
    /// </summary>
    public class ModelHighcores
    {
        /// <summary>
        /// Путь к файлу рекордов
        /// </summary>
        private const string PATH_TO_FILE = "highscores.txt";
        /// <summary>
        /// Список рекордов
        /// </summary>
        public List<ModelHighscoreString> Highscores = new List<ModelHighscoreString>();

        /// <summary>
        /// Конструктор модели рекордов
        /// </summary>
        public ModelHighcores()
        {
            if (File.Exists(PATH_TO_FILE))
            {
                string[] v = File.ReadAllLines(PATH_TO_FILE);
                foreach (var item in v)
                {
                    string[] v1 = item.Split(' ');
                    if (v1.Length == 2)
                    {
                        ModelHighscoreString highscoreString = new ModelHighscoreString(v1[0], Int32.Parse(v1[1]));
                        Highscores.Add(highscoreString);
                    }
                }
            }
            else
            {
                File.Create(PATH_TO_FILE).Close();
            }
        }

        /// <summary>
        /// Запись списка 10 последних рекордов в файл
        /// </summary>
        public void WriteFile()
        {
            var file = File.OpenWrite(PATH_TO_FILE);
            Highscores.Sort(new Comparison<ModelHighscoreString>((a, b) => { return a.Score - b.Score; }));
            for (int i = 0; i < Highscores.Count && i < 10; i++)
            {
                string s = string.Format("{0} {1}\r\n", Highscores[i].Name, Highscores[i].Score.ToString());
                var bytes = Encoding.UTF8.GetBytes(s);
                file.Write(bytes, 0, bytes.Length);
            }
            file.Flush();
            file.Close();
        }

    }
}
