using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeTrigger2D : MonoBehaviour
{
    
    public int sceneIndex;
    
    public string triggerTag = "Player";

    // �����, ���� �����������, ���� ����� ��'��� ������� � ������
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered by: " + other.gameObject.name); // ������ ��� �������

        // ����������, �� ��'���, �� ������� � ������, �� ������� ���
        if (other.CompareTag(triggerTag))
        {
            Debug.Log("Player detected, loading scene index: " + sceneIndex); // ������ ��� �������
            // ����������� ����� � �������� ��������
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
