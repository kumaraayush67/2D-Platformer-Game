using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public Button restartButton;

    private void Awake() {
        restartButton.onClick.AddListener(RestartLevel);
    }
    public void PlayerDied(){
        gameObject.SetActive(true);
    }

    public void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
