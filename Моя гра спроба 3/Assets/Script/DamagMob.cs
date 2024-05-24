using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagMob : MonoBehaviour
{
    public int collisionDamage = 10;
    public string collisionTag;
    public float damageInterval = 1f; // �������� �� ���������� ����� � ��������

    private float damageTimer = 0f;

    private void Update()
    {
        damageTimer += Time.deltaTime;
    }

    private void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag(collisionTag))
        {
            if (damageTimer >= damageInterval)
            {
                // ������ �������� ��������� PlayerHealth
                PlayerHealth playerHealth = coll.gameObject.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    // ��������� �����
                    playerHealth.TakeDamage(collisionDamage);
                    damageTimer = 0f; // �������� ������� ���� ��������� �����
                }
                else
                {
                    Debug.LogWarning("��'��� � ����� " + collisionTag + " �� �� ���������� PlayerHealth.");
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag(collisionTag))
        {
            // �������� ������� ��� ���'������ ���糿
            damageTimer = 0f;
        }
    }
}
