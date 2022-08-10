using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Up()
    {
        Debug.Log("up");
        Debug.Log(GameObject.Find("Sav").GetComponentInChildren<Text>().text);
        Debug.Log("up");
    }
}
