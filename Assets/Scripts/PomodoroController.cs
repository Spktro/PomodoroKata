using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PomodoroKata
{
    public class PomodoroController : MonoBehaviour
    {
        [SerializeField]
        private Pomodoro pomodoro;

        public float TimeLeft => pomodoro.TimeLeft;
        public PomodoroState State => pomodoro.State;

        private void Awake()
        {
            pomodoro = new Pomodoro();
        }

        private void Update()
        {            
            if (pomodoro.State == PomodoroState.RUNNING) {
                pomodoro.Run(Time.deltaTime);
            }
        }

        public void Initialize() {
            pomodoro = new Pomodoro();
        }

        public void Initialize(float customTime) {
            pomodoro = new Pomodoro(customTime);
        }

        public void StartTimer()
        {
            pomodoro.State = PomodoroState.RUNNING;
        }

        public void Interrupt()
        {
            pomodoro.Interrupt();
        }
    }
}
