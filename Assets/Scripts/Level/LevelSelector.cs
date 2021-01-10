using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LevelSelector : MonoBehaviour
{
    private Button levelButton;
    public int LevelIndex;

    private void Awake() {
        levelButton = gameObject.GetComponent<Button>();
        levelButton.onClick.AddListener(LoadLevel);
    }

    private void LoadLevel(){
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(LevelIndex);
        if (levelStatus == LevelStatus.Locked){
            Debug.Log("Level is Locked");
        }
        else {
            SceneManager.LoadScene(LevelIndex);
        }
    }
}
