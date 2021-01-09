using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    private Button levelButton;
    public int LevelIndex;

    private void Awake() {
        levelButton = gameObject.GetComponent<Button>();
        levelButton.onClick.AddListener(LoadLevel);
    }

    private void LoadLevel(){
        SceneManager.LoadScene(LevelIndex);
    }
}
