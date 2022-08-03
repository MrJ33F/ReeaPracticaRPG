using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Travel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("TempleExit")){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
        }
    }
}
