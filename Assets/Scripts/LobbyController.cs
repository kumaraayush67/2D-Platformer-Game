using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    public Button playButton;
    public GameObject LevelSelection;

    private void Awake() {
        playButton.onClick.AddListener(StartGame);
    }

    public void StartGame(){
        Debug.Log("Start Game");
        // SceneManager.LoadScene(2);
        playButton.gameObject.SetActive(false);
        LevelSelection.SetActive(true);
    }
}
