using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    
    void Update()
    {
        scoreText.text = $"Score  {GameManager.Score}";
    }
}
