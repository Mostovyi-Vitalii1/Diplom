using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagMob : MonoBehaviour
{
    public int collisionDamage = 10;
    public string collisionTag;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag(collisionTag))
        {
            // ������ �������� ��������� PlayerHealth
            PlayerHealth playerHealth = coll.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                // ��������� �����
                playerHealth.TakeDamage(collisionDamage);
            }
            else
            {
                Debug.LogWarning("��'��� � ����� " + collisionTag + " �� �� ���������� PlayerHealth.");
            }
        }
    }
}
