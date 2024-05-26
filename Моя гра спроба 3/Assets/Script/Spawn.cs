using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject obj;
    private float randomX;
    Vector2 whereToSpawn;
    public float spavnDelay;
    float nextSpawn = 0.0f;

    // ������ ��� ���������� ������ ������ ������
    public float spawnAreaWidth = 16f;
    public float spawnAreaHeight = 1f;

    void Start()
    {

    }

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spavnDelay;
            randomX = Random.Range(-spawnAreaWidth / 2, spawnAreaWidth / 2);
            whereToSpawn = new Vector2(randomX, transform.position.y);
            GameObject Enemi = Instantiate(obj, whereToSpawn, Quaternion.identity);
        }
    }

    // ����� ��� ���������� ������ ������
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green; // ���� ������ ������
        Gizmos.DrawWireCube(transform.position, new Vector3(spawnAreaWidth, spawnAreaHeight, 1));
    }
}
