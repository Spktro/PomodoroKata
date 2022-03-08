using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace PomodoroKata
{

    [RequireComponent(typeof(PomodoroController))]
    public class PomodoroView : MonoBehaviour
    {
        [SerializeField] private InputField initTimeInp;
        [SerializeField] private Text timerTxt;
        [SerializeField] private Text stateTxt;
        [SerializeField] private Button startBtn;
        [SerializeField] private Button interruptBtn;
        [SerializeField] private Button restartBtn;

        private PomodoroController pomodoroController;
        private PomodoroState previousState;

        private void Awake()
        {
            pomodoroController = GetComponent<PomodoroController>();
            previousState = pomodoroController.State;
        }

        private void Start()
        {
            UpdateButtons();
        }

        private void Update()
        {
            switch (pomodoroController.State)
            {
                case PomodoroState.RUNNING:
                    timerTxt.text = $"Timer: {pomodoroController.TimeLeft}";
                    break;
                case PomodoroState.CANCELED:
                    timerTxt.text = $"Canceled: {pomodoroController.InterruptedTime}";
                    break;
                default:
                    timerTxt.text = "Timer: ...";
                    break;
            }

            stateTxt.text = $"State: {pomodoroController.State}";
            if (previousState != pomodoroController.State) {
                OnStateChanged();
            }
        }

        private void OnStateChanged()
        {
            UpdateButtons();
            previousState = pomodoroController.State;
        }

        public void OnStartClicked()
        {
            float initTime;
            initTime = ReadInitTime();
            if (initTime > 0)
                pomodoroController.Initialize(initTime);
            else
                pomodoroController.Initialize();
            pomodoroController.StartTimer();

            UpdateButtons();
        }

        private float ReadInitTime()
        {
            float initTime = -1;
            float.TryParse(initTimeInp.text, out initTime);
            return initTime;
        }

        public void OnInterruptClicked()
        {
            pomodoroController.Interrupt();
            UpdateButtons();
        }

        public void OnRestartClicked()
        {
            pomodoroController.Restart();
            UpdateButtons();
        }

        private void UpdateButtons()
        {
            initTimeInp.interactable = false;
            startBtn.interactable = false;
            interruptBtn.interactable = false;
            restartBtn.interactable = false;
            switch (pomodoroController.State)
            {
                case PomodoroState.STOPPED:
                    initTimeInp.interactable = true;
                    startBtn.interactable = true;
                    break;
                case PomodoroState.RUNNING:
                    interruptBtn.interactable = true;
                    break;
                case PomodoroState.CANCELED:
                    restartBtn.interactable = true;
                    break;
                case PomodoroState.FINISHED:
                    initTimeInp.interactable = true;
                    startBtn.interactable = true;
                    break;
            }

        }
    }
}
