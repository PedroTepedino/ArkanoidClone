using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    
    [SerializeField] private Ball ballPrefab;
    private List<Ball> balls;

    private static Action OnSpawnNewBall;
    
    public static int Score = 0;

    private static int newBallcounter = 0;

    public static bool lost = false;
    
    private void Awake()
    {
        balls = new List<Ball>();
    }

    private void Start()
    {
        Score = 10;
        lost = false;
    }

    private void OnEnable()
    {
        SpawnPlayerBall();
        newBallcounter = 0;

        OnSpawnNewBall += SpawnBallBall;
    }

    private void OnDisable()
    {
        OnSpawnNewBall -= SpawnBallBall;
    }

    private void Update()
    {
        Debug.Log(balls.Count);
        
        if (balls.Count == 0)
        {
            SpawnPlayerBall();
        }

        balls.RemoveAll(obj => obj == null);
    }

    private void SpawnPlayerBall()
    {
        var ball = SpawnBall();
        ball.transform.localPosition = new Vector3(0f, 0.25f, 0f);
        ball.gameObject.SetActive(true);
        balls.Add(ball);
    }

    private void SpawnBallBall()
    {
        var ball = SpawnBall();
        ball.transform.parent = null;
        ball.transform.position = balls[0].transform.position;
        ball.Unlock();
        balls.Add(ball);
    }

    public static void GetPoint()
    {
        Score++;
        newBallcounter++;

        if (newBallcounter >= 5)
        {
            OnSpawnNewBall?.Invoke();
            newBallcounter = 0;
        }
    }

    public static void LosePoints(int points = 1)
    {
        Score -= points;

        if (Score < 0)
        {
            lost = true;
        }
    }

    private Ball SpawnBall()
    {
        Ball ball = Instantiate(ballPrefab, player.transform, true);
        balls.Add(ball);
        
        return ball;
    }
}
