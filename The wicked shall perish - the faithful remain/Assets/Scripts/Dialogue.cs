using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public string name;

    [TextArea(3, 10)]
    public string[] sentences;
}
