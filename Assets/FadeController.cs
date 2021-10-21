using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FadeController : MonoBehaviour
{
    // Start is called before the first frame update
   
    Animator animator;
    public string nextScene;
 
    void Start()
    {
        
        
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("fadeout", true);
        }
    }

    public void OnFadeOut()
    {
        int indexActualScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(indexActualScene+1);
      
    }
}
