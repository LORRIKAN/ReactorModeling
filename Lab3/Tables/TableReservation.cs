namespace Researcher.Tables
{
    public class TableReservation
    {
        public string ComponentName { get; set; }

        public string Name => $"Таблица значений концентраций компонента {ComponentName}";
    }
}