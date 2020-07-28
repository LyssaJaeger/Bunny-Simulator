using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item: MonoBehaviour
{
    public string name;
    public int id;

     public Item(string name, int id)
    {
        this.name = name;
        this.id = id;
    }
}
