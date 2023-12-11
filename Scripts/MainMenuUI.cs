using System.Collections;
using System.Collections.Generic;
// using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;

    private void Awake(){
        playButton.onClick.AddListener(()=>{
            Debug.Log("click");
            Loader.Load(Loader.Scene.Level1);

        });

        quitButton.onClick.AddListener(()=>{
            Application.Quit();
        });
    }
}
