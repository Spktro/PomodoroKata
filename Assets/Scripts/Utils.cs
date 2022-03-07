using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PomodoroKata
{
    public static class Utils
    {
        public static bool IsEqualWithTolerance(float value1, float value2, float tolerance = 0.1f)
        {
            return Mathf.Abs(value1 - value2) < tolerance;
        }
    }
}
