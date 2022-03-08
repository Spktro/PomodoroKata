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

        public float InterruptedTime => pomodoro.InterruptedTime;

        private void Awake()
        {
            pomodoro = new Pomodoro();
        }

        private void Update()
        {                       
            pomodoro.Run(Time.deltaTime);           
        }

        public void Initialize() {
            pomodoro = new Pomodoro();
        }

        public void Initialize(float customTime) {
            pomodoro = new Pomodoro(customTime);
        }

        public void StartTimer()
        {
            pomodoro.StartTimer();
        }

        public void Interrupt()
        {
            pomodoro.Interrupt();
        }

        public void Restart()
        {
            pomodoro.Restart();
        }
    }
}
