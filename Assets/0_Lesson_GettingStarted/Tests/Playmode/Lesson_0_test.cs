using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Lesson_0;
using System;
using System.Reflection;
using UnityEngine.SceneManagement;

public class Lesson_0_test
{
    bool sceneLoaded;
    bool referencesSetup;
    MonoBehaviour script = null;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene("Lesson0", LoadSceneMode.Single);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene loaded");
        sceneLoaded = true;
    }
    
    void SetupReferences()
    {
        if (referencesSetup)
        {
            return;
        }

        Transform[] objects = Resources.FindObjectsOfTypeAll<Transform>();
        foreach (Transform t in objects)
        {
            HelloWorld hw = t.GetComponent<HelloWorld>();
            if(hw != null)
                script = hw;
        }
        
        Debug.Log("References set");
        referencesSetup = true;
    }

    [UnityTest]
    public IEnumerator CheckSetupTest()
    {
        yield return new WaitWhile(() => sceneLoaded == false);
        SetupReferences();
        Assert.IsNotNull(script, "Couldn't find the hello world script on any gameobjects in the scene");
    }

    


    [UnityTest]
    public IEnumerator HelloStringPublicStringExistsTest()
    {
        Type type = typeof(HelloWorld);
        MemberInfo[] a = type.GetMember("helloString");
        Assert.IsTrue(a.Length > 0, "couldn't find public string helloString");
        Assert.IsTrue((string)((FieldInfo)a[0]).GetValue(script) == "HelloWorld!", "Public helloString should have value HelloWorld!");
        yield return null;
    }

    [UnityTest]
    public IEnumerator StartMethodTest()
    {
        Type type = typeof(HelloWorld);
        MethodInfo method = type.GetMethod("Start");
        Assert.IsNotNull(method, "Couldn't find Start() method in class, are you sure you've spelled it right?");
        yield return null;
    }

    [UnityTest]
    public IEnumerator PrintHelloWorldMessageExistsTest()
    {
        Type type = typeof(HelloWorld);
        MethodInfo method = type.GetMethod("PrintHelloWorldMessage");
        Assert.IsNotNull(method, "Couldn't find PrintHelloWorldMessage() method in class, are you sure you've spelled it right?");
        yield return null;
    }

}
