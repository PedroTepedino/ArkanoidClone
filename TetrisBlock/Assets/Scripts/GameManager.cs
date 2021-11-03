using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    
    [SerializeField] private Ball ballPrefab;
    private List<Ball> balls;
    
    public static int Score = 0;

    private void Awake()
    {
        balls = new List<Ball>();
    }

    private void Start()
    {
        Score = 0;
    }

    private void OnEnable()
    {
        SpawnPlayerBall();
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
    }

    public static void GetPoint()
    {
        Score++;
    }

    public static void LosePoint()
    {
        Score--;
    }

    private Ball SpawnBall()
    {
        Ball ball = Instantiate(ballPrefab, player.transform, true);
        balls.Add(ball);
        
        return ball;
    }
}
