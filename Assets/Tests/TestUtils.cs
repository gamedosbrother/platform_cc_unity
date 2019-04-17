using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestUtils
{
    
    public static void AreEqualFloat(float expected, float value, float diff = 0.1f)
    {
        Assert.Greater(expected + diff, value);
        Assert.Less(expected - diff, value);
    }

}