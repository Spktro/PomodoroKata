using System;

namespace PomodoroKata
{
    [Serializable]
    public class Pomodoro
    {
        public float TimeLeft { get; private set; } = 25 * 60f;
        public PomodoroState State { get; internal set; }

        public Pomodoro() {
            State = PomodoroState.STOPPED;
        }

        public Pomodoro(float customTime) : base()
        {
            TimeLeft = customTime;
        }

        public void Run(float deltaTime) {
            if (TimeLeft >= 0)
            {
                TimeLeft -= deltaTime;
                if (TimeLeft < 0)
                {
                    TimeLeft = 0;
                    State = PomodoroState.FINISHED;
                }
            } 
            
        }

        

    }
}
