using NSubstitute;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class AudioTriggerTest
{

    [Test]
    public void CarTriggersAudio()
    {
        //Arrange
        var gameObject = new GameObject();

        //Act
        //Try to rename the GameObject
        var newGameObjectName = "My game object";
        gameObject.name = newGameObjectName;

        //Assert
        //The object has a new name
        Assert.AreEqual(newGameObjectName, gameObject.name);
    }
}
