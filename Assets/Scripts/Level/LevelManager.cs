using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

    private void Awake() {
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        if (GetLevelStatus((int)SceneEnum.Level1) == LevelStatus.Locked){
            SetLevelStatus(SceneEnum.Level1, LevelStatus.Unlocked);
        }
    }

    public LevelStatus GetLevelStatus(int levelIndex) {
        return (LevelStatus)PlayerPrefs.GetInt(Utils.getLevelNameByIndex(levelIndex), (int)LevelStatus.Locked);
        // Scene selectedScene = SceneManager.GetSceneByBuildIndex(levelIndex);
    }

    public void SetLevelStatus(SceneEnum level, LevelStatus levelStatus) {
        string levelName = Utils.getLevelNameByIndex((int)level);
        PlayerPrefs.SetInt(levelName, (int)levelStatus);
        Debug.Log("Level: " + levelName + ", Status: " + levelStatus);

    }
}
