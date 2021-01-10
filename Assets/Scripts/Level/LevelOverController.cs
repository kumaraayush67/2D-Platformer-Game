using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.GetComponent<PlayerController>() != null){
            Debug.Log("Level is completed");
            int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
            int nextLevelIndex = currentLevelIndex + 1;
            LevelManager.Instance.SetLevelStatus((SceneEnum)currentLevelIndex, LevelStatus.Completed);
            LevelManager.Instance.SetLevelStatus((SceneEnum)nextLevelIndex, LevelStatus.Unlocked);
            SceneManager.LoadScene(nextLevelIndex);
        }
    }
}
