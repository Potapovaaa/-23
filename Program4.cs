using static System.Console;
using static System.ConsoleKey;


namespace egednevnik
{
    internal class egednevnik
    {
        static void Main()
        {

            notes();
        }
        static void Date(DateTime date, List<Note> myNotes)//дата
        {
            Clear();
            WriteLine(date.ToLongDateString());

            List<Note> sortedNotes = myNotes.Where(note => note.data.Date == date.Date).ToList();
            foreach (Note note in sortedNotes)
            {
                WriteLine("  " + note.Name);
            }
        }
        public static void notes() //создаем заметки с помощью нашего класса
        {
            Note zametka1 = new()
            {
                Name = "сходить в магазин",
                Dopolnenie = "купить молоко,хлеб и сметану",
                data = new DateTime(2022, 10, 24)
            };

            Note zametka2 = new()
            {
                Name = "Встретить сестру",
                Dopolnenie = "в 14:00 встретить сестру на вокзале",
                data = new DateTime(2022, 10, 26)
            };

            Note zametka3 = new()
            {
                Name = "убраться в комнате",
                Dopolnenie = "пропылесосить,помыть пол и вытереть пыль с воей комнате",
                data = new DateTime(2022, 10, 26)
            };

            Note zametka4 = new()
            {
                Name = "сделать зарядку",
                Dopolnenie = "сделать комплекс физических упражнений",
                data = new DateTime(2022, 10, 25)
            };

            Note zametka5 = new()
            {
                Name = "Поехать утром в колледж",
                Dopolnenie = "хотя бы проснуться",
                data = new DateTime(2022, 10, 25)
            };

            Note zametka6 = new Note()
            {
                Name = "Сходить на тренировку",
                Dopolnenie = "Сходить на тренировку по футболу в 15:30",
                data = new DateTime(2022, 10, 29)
            };

            List<Note> allNotes = new()//добавляем все заметки в один лист
            {
                zametka1,
                zametka2,
                zametka3,
                zametka4,
                zametka5,
                zametka6
            };
            static void pokazat(int position, DateTime date, List<Note> myNotes)// выводим пользователю заметки
            {
                List<Note> sortedNotes = myNotes.Where(note => note.data.Date == date.Date).ToList();
                WriteLine(sortedNotes[position - 1].data.Date + "\n" + " " + sortedNotes[position - 1].Dopolnenie + "\n" + "\n" + "для выхода в меню нажмите на любую кнопку");
            }

                DateTime dayNow = new(2022, 10, 24);
                int position = 1;
                var key = ReadKey();
                while (key.Key != Enter)
                {
                    switch (key.Key)
                    {

                        case DownArrow:
                            position++;
                            break;
                        case UpArrow:
                            position--;
                            break;
                        case RightArrow:
                            dayNow = dayNow.AddDays(1);
                            break;
                        case LeftArrow:
                            dayNow = dayNow.AddDays(-1);
                            break;
                        case Escape:
                            Clear();
                            Environment.Exit(0);
                            break;
                    }

                    Clear();

                    Date(dayNow, allNotes);

                    SetCursorPosition(0, position);
                    WriteLine("->");

                    key = ReadKey();
                }

                Clear();
                pokazat(position, dayNow, allNotes);
                notes();
            
            }

        }
}
