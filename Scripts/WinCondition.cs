using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour
{
    [SerializeField] public Button mainMenuButton;
    [SerializeField] public Button resumeButton;
    public GameObject winUI;

    private void Awake(){
        mainMenuButton.onClick.AddListener(()=>{
           Loader.Load(Loader.Scene.MainMenu);

        });
        resumeButton.onClick.AddListener(()=>{
           Loader.Load(Loader.Scene.Level2);

        });
    }
    // Start is called before the first frame update
    void Start()
    {
        winUI.SetActive(false);
    }
    
    void OnTriggerStay(Collider col){
        Debug.Log("Detected: " + col.gameObject.name);
        if (col.gameObject.name == "karakter")
        {
            winUI.SetActive(true);
            // Time.timeScale = 0f;
            Debug.Log("Detect - Menang");
        }
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
