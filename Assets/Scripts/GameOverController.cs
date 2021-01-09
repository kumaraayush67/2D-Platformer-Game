using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public Button lobbyButton;

    private void Awake() {
        lobbyButton.onClick.AddListener(RestartLevel);
    }
    public void PlayerDied(){
        gameObject.SetActive(true);
    }

    public void RestartLevel(){
        SceneManager.LoadScene((int)SceneEnum.Lobby);
    }
}
