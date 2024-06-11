using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject obj;
    public float spavnDelay;
    float nextSpawn = 0.0f;

    // ������ ��� ���������� ������ ������ ������
    public float spawnAreaWidth = 16f;
    public float spawnAreaHeight = 1f;
    public float objectLifetime = 1.7f;
    public int sortingOrder = 5; // ������ ��� ������������ ������� ����������

    void Start()
    {
        // �������� ��������� ������������� ��� ����� ��������
    }

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spavnDelay;
            float randomX = Random.Range(-spawnAreaWidth / 2, spawnAreaWidth / 2);
            Vector2 whereToSpawn = new Vector2(randomX, transform.position.y);
            GameObject Enemi = Instantiate(obj, whereToSpawn, Quaternion.identity);
            Destroy(Enemi, objectLifetime);

            // ������������ sortingOrder ��� ������ ��'����
            SpriteRenderer spriteRenderer = Enemi.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sortingOrder = sortingOrder;
            }
        }
    }

    // ����� ��� ���������� ������ ������
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green; // ���� ������ ������
        Gizmos.DrawWireCube(transform.position, new Vector3(spawnAreaWidth, spawnAreaHeight, 1));
    }
}
