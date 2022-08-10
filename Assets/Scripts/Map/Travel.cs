using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class Travel : MonoBehaviour
{
    public Vector2 starticGamePozition;
    public Vector2 exitCave, enterCave;
    public Vector2 exitTemple, enterTemple;
    
    public VectorValue playerStorage;
    public CinemachineVirtualCamera CM;
    private void Start() {

        playerStorage.initialValue = starticGamePozition;
        
        
    }
    

    


    private void OnTriggerEnter2D(Collider2D collision) {

        
       
        gameObject.GetComponent<SpriteRenderer>().sortingOrder++;
        
        

        if (collision.gameObject.CompareTag("TempleExit")){
            playerStorage.initialValue = exitTemple;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            
        }
        if (collision.gameObject.CompareTag("CaveExit")){
            playerStorage.initialValue = exitCave;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
            
        }
        if (collision.gameObject.CompareTag("CaveEnter")){
            playerStorage.initialValue = enterCave;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            
        }
        if (collision.gameObject.CompareTag("TempleEnter")){
            playerStorage.initialValue = enterTemple;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
        }
          
    }
    
    private void OnTriggerExit2D(Collider2D collision) {
        
           
            gameObject.GetComponent<SpriteRenderer>().sortingOrder--;
    }


}
