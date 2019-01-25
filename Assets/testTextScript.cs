using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class testTextScript : MonoBehaviour
{
    public Stat test;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TMP_Text>().text = "test value : " + test.currentValue;
    }
}
