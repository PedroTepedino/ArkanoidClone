using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float SpawnRate = 1f;
    private float timer = 0;

    public Transform LeftMargin;
    public Transform RightMargin;
    
    public GameObject[] Prefab;

    private readonly float[] ANGLES = { 0, 90, 180, 270 };

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Spawn();
            timer = SpawnRate;
        }
    }

    private void Spawn()
    {
        Vector3 point = Vector3.Lerp(LeftMargin.position, RightMargin.position, Random.Range(0f, 1f));
        point.z += Random.Range(0f, 1f);

        float rotation = ANGLES[Random.Range(0, 4)];

        Instantiate(Prefab[Random.Range(0, Prefab.Length)], point, Quaternion.Euler(0, 0, rotation));
    }
}
