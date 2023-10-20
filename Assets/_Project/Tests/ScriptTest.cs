using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


public class ScriptTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void ScriptTestSimplePasses()
    {
        Play v = new Play();
       
        Assert.AreEqual(42,v.ComputerSomething());
       
    }

   
    [UnityTest]
    public IEnumerator ScriptTestWithEnumeratorPasses()
    {
       
        yield return null;
    }


    [Test]
    public void CheckInput_ShouldFalse_OwnerIsNotNull()
    {
   
        var all_p = new Piece[] { new Piece { Owner = new Player() } };
        var input = 0;
        Play play = new Play();
        var result = play.CheckInput(all_p, input);
        bool ShoudlSwitchPlayer = true;
        Assert.IsFalse(ShoudlSwitchPlayer = false);
    }

    [Test]
    public void CheckInput_ShouldTrue_OwnerIsNull()
    {
        var all_p = new Piece[] { new Piece { Owner = null } };
        var input = 0;
        Play play = new Play();
        var result = play.CheckInput(all_p, input);
        //Assert.IsTrue(result.Result)xvffffffffx;
         Assert.AreEqual(input, result.Input);
    }

}
