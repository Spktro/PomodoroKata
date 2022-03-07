using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using PomodoroKata;

namespace PlayTests
{
    public class PomodoroShould
    {
        private Pomodoro pomodoro;

        #region Initiate Tests

        [UnityTest]
        public IEnumerator InitTimerWhenStarted()
        {
            pomodoro = new Pomodoro(10);

            Assert.IsTrue(Utils.IsEqualWithTolerance(pomodoro.TimeLeft, 10));

            yield return new WaitForSeconds(5);

            Assert.IsTrue(Utils.IsEqualWithTolerance(pomodoro.TimeLeft, 5));
        }

        #endregion
    }
}
