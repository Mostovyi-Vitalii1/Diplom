using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int sceneIndex;

    private void Start()
    {
        currentHealth = maxHealth; // ������������ ��������� ������'� ����� �������������
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // �������� ������� ������'� �� �������� ���������� �����

        // ����������, �� ������'� ����� ����� ��� ������� ����
        if (currentHealth <= 0)
        {
            Die(); // ���� ���, ��������� ����� Die()
        }
    }

    void Die()
    {
        // ��� ��� ��� ������� ����� ���������
        Debug.Log("Player died!");

        // ������� �� �������� ����� (������������� �������� ����� � ������� �� ��������� �� build settings)
        SceneManager.LoadScene(sceneIndex);
    }
}
