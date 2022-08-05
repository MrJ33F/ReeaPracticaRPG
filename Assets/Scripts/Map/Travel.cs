using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Travel : MonoBehaviour
{
    public GameObject templeKey;
    
    
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("TempleExit")){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        if (collision.gameObject.CompareTag("CaveExit")){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        }
        if (collision.gameObject.CompareTag("CaveEnter")){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
        if (collision.gameObject.CompareTag("TempleEnter")){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (collision.gameObject.CompareTag("TempleKey")){
            templeKey.SetActive(true);
            
        }
    }


}
