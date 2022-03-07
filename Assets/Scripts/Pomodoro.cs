namespace PomodoroKata
{
    public class Pomodoro
    {
        public float TimeLeft { get; private set; } = 25 * 60f;
        public PomodoroState State { get; internal set; }

        public Pomodoro() { }

        public Pomodoro(float customTime)
        {
            TimeLeft = customTime;
        }

    }
}
