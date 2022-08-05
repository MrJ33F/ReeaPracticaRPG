using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagering : MonoBehaviour
{
    public void LoadMenu()
    {
        Debug.Log("ok");
        SceneManager.LoadScene("MainMenu");
    }
}
