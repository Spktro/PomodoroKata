using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using PomodoroKata;
using UnityEngine;
using UnityEngine.TestTools;

namespace EditorTests
{

    public class EditPomodoroShould
    {

        //CREATION
        //Be created with 25 minutes by default (edit)
        //Be created with custom time if specified (edit)

        //INITIATE
        //Start on stopped state when it's created (edit)
        //Init timer when started (play)
        //Not be able to finish if it hasn't started (play)
        //Become completed when its time runs out (play)

        //INTERRUPT
        //Be able to be interrupted (edit) -
        //Count time while interrupted (play) - 
        //Become canceled after being interrupted (edit) -
        //Not be finishable when is canceled (play) -
        //Not be interruptable when it hasn't started (edit) -

        //RESTART
        //Be able to restart the timer and start from the beginning (play)
        //Be able to restart only after being canceled (play)

        private Pomodoro pomodoro;

        #region Creation Tests
        [Test]
        public void BeCreatedWith25MinutesByDefault()
        {
            pomodoro = new Pomodoro();

            Assert.IsTrue(Utils.IsEqualWithTolerance(pomodoro.InitTime, 25 * 60f));
        }

        [Test]
        public void BeCreatedWithCustomTimeIfSpecified()
        {
            float customTime = 10 * 60f;
            pomodoro = new Pomodoro(customTime);

            Assert.IsTrue(Utils.IsEqualWithTolerance(pomodoro.InitTime, customTime));
        }
        #endregion

        #region Initiate Tests
        [Test]
        public void StartOnStoppedStateWhenItsCreated()
        {
            pomodoro = new Pomodoro();

            Assert.AreEqual(pomodoro.State, PomodoroState.STOPPED);
        }

        #endregion

        #region Interrupted Test
        
        [Test]
        public void BecomeCanceledAfterBeingInterrupted()
        {
            pomodoro = new Pomodoro();            
            pomodoro.StartTimer();
            pomodoro.Interrupt();
            Assert.AreEqual(pomodoro.State, PomodoroState.CANCELED);
        }

        [Test]
        public void NotBeInterruptableWhenItHasntStarted()
        {
            pomodoro = new Pomodoro();
            PomodoroState currentState = pomodoro.State;
            pomodoro.Interrupt();
            Assert.AreEqual(currentState, pomodoro.State);
        }

        #endregion

    }
}
