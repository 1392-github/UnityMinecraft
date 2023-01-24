using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class test2
{
    public bool test;
    public void cancel()
    {
        test = false;
    }
    public test2()
    {
        test = true;
    }
}

public class Test : MonoBehaviour
{
    public UnityEvent<test2> unityEvent;
    // Start is called before the first frame update
    void Start()
    {
        test2 test = new test2();
        unityEvent.Invoke(test);
        Debug.Log(test.test);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void test3(test2 test)
    {
        //test.cancel();
        //test.test = false;
    }
}
