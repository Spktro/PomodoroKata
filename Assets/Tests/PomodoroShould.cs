using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PomodoroShould
{
    //CREATION
    //Be created with 25 minutes by default
    //Be created with n minutes if specified

    //INITIATE
    //Start on stopped state when it's created
    //Init timer when started
    //Not be able to finish if it hasn't started
    //Become completed when its time runs out

    //INTERRUPT
    //Be able to be interrupted
    //Count time while interrupted
    //Become canceled after being interrupted
    //Not be completable when is canceled
    //Not be interruptable when it hasn't started

    //RESTART
    //Be able to restart the timer and start from the beginning
    //Be able to restart when after being canceled

    [Test]
    public void PomodoroShouldSimplePasses()
    {
        
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator PomodoroShouldWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }


}
