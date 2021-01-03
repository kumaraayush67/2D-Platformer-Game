using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeartTextController : MonoBehaviour
{
    private TextMeshProUGUI heartText;

    private void Awake(){
        heartText = GetComponent<TextMeshProUGUI>();
    }

    public void RefreshUI(int heartsLeft){
        heartText.text = "Heart: " + heartsLeft;
    }
}
