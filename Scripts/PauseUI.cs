using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button menuButton;
    public GameObject pauseMenu;
    public bool isPaused;

    
    // Start is called before the first frame update
    private void Awake(){
        resumeButton.onClick.AddListener(()=>{
           ResumeGame();

        });
      
        menuButton.onClick.AddListener(()=>{
            Debug.Log("click");
            Loader.Load(Loader.Scene.MainMenu);

        });
    }
    void Start()
    {
        pauseMenu.SetActive(false);
    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                ResumeGame();
            }else{
                PauseGame();
            }
        }
    }

    public void PauseGame(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        
    }
    public void ResumeGame(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
