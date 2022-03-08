﻿using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using PomodoroKata;
using System;

namespace PlayTests
{
    public class PlayPomodoroShould
    {
        //CREATION
        //Be created with 25 minutes by default (edit) - 
        //Be created with custom time if specified (edit) - 

        //INITIATE
        //Start on stopped state when it's created (edit) - 
        //Init timer when started (play) -  
        //Not be able to finish if it hasn't started (play) -
        //Become Finihsed when its time runs out (play) -

        //INTERRUPT
        //Be able to be interrupted (edit)
        //Count time while interrupted (play)
        //Become canceled after being interrupted (edit)
        //Not be completable when is canceled (edit)
        //Not be interruptable when it hasn't started (edit)

        //RESTART
        //Be able to restart the timer and start from the beginning (play)
        //Be able to restart when after being canceled (play)

       // private Pomodoro pomodoro;

        private PomodoroController pomodoroController;

        #region Initiate Tests
        [SetUp]
        public void SetUp()
        {
            GivenPomodoro();
        }

        [TearDown]
        public void TearDown()
        {
            DisposePomodoro();
        }

        private void DisposePomodoro()
        {
            GameObject.Destroy(pomodoroController.gameObject);            
        }

        [UnityTest]
        public IEnumerator InitTimerWhenStarted()
        {
            float startingTime = 1, waitingTime = 0.5f;

            pomodoroController.Initialize(startingTime);
            pomodoroController.StartTimer();

            Assert.IsTrue(Utils.IsEqualWithTolerance(pomodoroController.TimeLeft, startingTime));

            yield return new WaitForSeconds(waitingTime);

            Assert.IsTrue(Utils.IsEqualWithTolerance(pomodoroController.TimeLeft, Mathf.Abs(startingTime - waitingTime)));
        }

        [UnityTest]
        public IEnumerator NotBeableToFinishIfItHasntStarted()
        {
            float startingTime = 1, waitingTime = 0.5f;
            pomodoroController.Initialize(startingTime);          
            
            yield return new WaitForSeconds(waitingTime);

            Assert.AreNotEqual(pomodoroController.State, PomodoroState.FINISHED);
        }

        [UnityTest]
        public IEnumerator BecomeFinishedWhenItsTimeRunsOut()
        {
            float startingTime = 1, waitingTime = 1.1f;
            pomodoroController.Initialize(startingTime);
            pomodoroController.StartTimer();

            Assert.AreEqual(pomodoroController.State, PomodoroState.RUNNING);

            yield return new WaitForSeconds(waitingTime);

            Assert.AreEqual(pomodoroController.State, PomodoroState.FINISHED);
        }

        public void GivenPomodoro()
        {            
            GameObject pomodoroGO = new GameObject("Pomodoro");
            pomodoroController = pomodoroGO.AddComponent<PomodoroController>();            
        }

        #endregion
    }
}