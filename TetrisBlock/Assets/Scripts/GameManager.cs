using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Ball ball;

    public static int Score = 0;

    private void Start()
    {
        Score = 0;
    }

    private void Update()
    {
        if (!ball.gameObject.activeInHierarchy)
        {
            // Perdeu vida
            ball.transform.SetParent(player.transform);
            ball.transform.localPosition = new Vector3(0f, 0.25f, 0f);
            ball.gameObject.SetActive(true);
        }
    }
}
