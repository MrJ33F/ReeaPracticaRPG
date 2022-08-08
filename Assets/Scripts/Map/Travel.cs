using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class Travel : MonoBehaviour
{
    
    public Vector2 exitCave, enterCave;
    public Vector2 exitTemple, enterTemple;
    
    public VectorValue playerStorage;
    public CinemachineVirtualCamera CM;
    private void Start() {

        
        transform.position = playerStorage.initialValue;
        
    }
    

    


    private void OnTriggerEnter2D(Collider2D collision) {

        
       
        gameObject.GetComponent<SpriteRenderer>().sortingOrder++;
        
        

        if (collision.gameObject.CompareTag("TempleExit")){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        playerStorage.initialValue = exitTemple;
        }
        if (collision.gameObject.CompareTag("CaveExit")){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        playerStorage.initialValue = exitCave;
        }
        if (collision.gameObject.CompareTag("CaveEnter")){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        playerStorage.initialValue = enterCave;
        }
        if (collision.gameObject.CompareTag("TempleEnter")){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            playerStorage.initialValue = enterTemple;
        }
          
    }
    
    private void OnTriggerExit2D(Collider2D collision) {
        
           
            gameObject.GetComponent<SpriteRenderer>().sortingOrder--;
    }


}
