using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Button tryButton;
    [SerializeField] private Button menuButton;
    public GameObject loseMenu;
    public Transform karakter;
    // Start is called before the first frame update

    private void Awake(){
        tryButton.onClick.AddListener(()=>{
           Loader.Load(Loader.Scene.Level2);

        });
        menuButton.onClick.AddListener(()=>{
           Loader.Load(Loader.Scene.MainMenu);

        });
    }
    void Start()
    {
        loseMenu.SetActive(false);
    }
    void OnTriggerStay(Collider col){
        Debug.Log("Detected: " + col.gameObject.name);
        if (col.gameObject.name == "karakter")
        {
            loseMenu.SetActive(true);
            Time.timeScale = 0f;
            Debug.Log("Detect - Kalah");
        }
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    
}
