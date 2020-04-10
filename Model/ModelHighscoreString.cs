namespace Model
{
    /// <summary>
    /// Класс, представляющий строку таблицы рекордов
    /// </summary>
    public class ModelHighscoreString
    {
        /// <summary>
        /// Рекорд
        /// </summary>
        private int _score;
        /// <summary>
        /// Имя игрока
        /// </summary>
        private string _name;

        /// <summary>
        /// Имя игрока
        /// </summary>
        public string Name { get => _name; set => _name = value; }
        /// <summary>
        /// Рекорд
        /// </summary>
        public int Score { get => _score; set => _score = value; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="parName">Имя игрока</param>
        /// <param name="parScore">Рекорд</param>
        public ModelHighscoreString(string parName, int parScore)
        {
            Score = parScore;
            Name = parName;
        }
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public ModelHighscoreString()
        {

        }
    }
}
