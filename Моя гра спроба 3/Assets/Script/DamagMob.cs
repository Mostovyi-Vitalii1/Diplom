using UnityEngine;

public class DamagMob : MonoBehaviour
{
    public int collisionDamage = 10;
    public string collisionTag;
    public float damageInterval = 1f; // �������� �� ���������� ����� � ��������

    private float damageTimer = 0f; // �������� ���������

    private void Update()
    {
        damageTimer += Time.deltaTime;
    }

    public float GetDamageTimer()
    {
        return damageTimer;
    }

    public void ResetDamageTimer()
    {
        damageTimer = 0f;
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
                    ResetDamageTimer(); // �������� ������� ���� ��������� �����
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
            ResetDamageTimer();
        }
    }
}
