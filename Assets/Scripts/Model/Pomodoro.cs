using System;

namespace PomodoroKata
{
    [Serializable]
    public class Pomodoro
    {
        public float InitTime { get; private set; } = 25 * 60f;
        public float TimeLeft { get; private set; }
        public PomodoroState State { get; internal set; }
        public float InterruptedTime { get; private set; } = 0;

        public Pomodoro() {
            State = PomodoroState.STOPPED;
        }      

        public Pomodoro(float customTime) : base()
        {
            InitTime = customTime;
        }

        public void StartTimer()
        {
            if (State == PomodoroState.STOPPED || State == PomodoroState.FINISHED)
            {
                State = PomodoroState.RUNNING;
                TimeLeft = InitTime;
            }
        }

        public void Interrupt()
        {
            if (State == PomodoroState.RUNNING)
            {
                State = PomodoroState.CANCELED;
            }
        }

        public void Run(float deltaTime) {
          
            switch (State)
            {    
                case PomodoroState.RUNNING:
                    if (TimeLeft >= 0)
                    {
                        TimeLeft -= deltaTime;
                        if (TimeLeft < 0)
                        {
                            TimeLeft = 0;
                            State = PomodoroState.FINISHED;
                        }
                    }
                    break;

                case PomodoroState.CANCELED:
                    InterruptedTime += deltaTime;                    
                    break;
                
                default:
                    break;
            }
            
        }

        public void Restart()
        {
            if (State == PomodoroState.CANCELED)
            {
                State = PomodoroState.RUNNING;
                TimeLeft = InitTime;
            }
        }
    }
}
