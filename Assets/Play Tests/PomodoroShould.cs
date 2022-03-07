using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using PomodoroKata;

namespace PlayTests
{
    public class PlayPomodoroShould
    {
        //CREATION
        //Be created with 25 minutes by default (edit)
        //Be created with custom time if specified (edit)

        //INITIATE
        //Start on stopped state when it's created (edit)
        //Init timer when started (play)
        //Not be able to finish if it hasn't started (edit)
        //Become completed when its time runs out (play)

        //INTERRUPT
        //Be able to be interrupted (edit)
        //Count time while interrupted (play)
        //Become canceled after being interrupted (edit)
        //Not be completable when is canceled (edit)
        //Not be interruptable when it hasn't started (edit)

        //RESTART
        //Be able to restart the timer and start from the beginning (play)
        //Be able to restart when after being canceled (play)

        private Pomodoro pomodoro;

        #region Initiate Tests

        [UnityTest]
        public IEnumerator InitTimerWhenStarted()
        {
            float startingTime = 10, endingTime = 5;
            GameObject pomodoroGO = new GameObject("Pomodoro");
            PomodoroController pomodoroController = pomodoroGO.AddComponent<PomodoroController>();
            pomodoroController.Initialize(startingTime);
            pomodoroController.StartTimer();

            Assert.IsTrue(Utils.IsEqualWithTolerance(pomodoroController.TimeLeft, startingTime));

            yield return new WaitForSeconds(5);

            Assert.IsTrue(Utils.IsEqualWithTolerance(pomodoroController.TimeLeft, endingTime));
        }

        #endregion
    }
}
