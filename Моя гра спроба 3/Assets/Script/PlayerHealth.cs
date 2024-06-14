using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int sceneIndex;
    public TMP_Text GoldText;

    private void Start()
    {
        currentHealth = maxHealth; // ������������ ��������� ������'� ����� �������������
    }

    public void ChangeHealse()
    {
        if (Int32.Parse(GoldText.text) >= 10)
        {
            maxHealth += 10;
        }
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
