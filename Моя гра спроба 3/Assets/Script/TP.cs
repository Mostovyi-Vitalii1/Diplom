using UnityEngine;
using UnityEngine.SceneManagement;

public class TP : MonoBehaviour
{
    // ������� ����� ��� ������� ������� �����
    public int sceneIndex;

    // �����, ���� �����������, ���� ����� ��'��� ������� � ������
    private void OnTriggerEnter(Collider other)
    {
        // ����������, �� ��'���, �� ������� � ������, � �������
        if (other.CompareTag("Player"))
        {
            // ����������, �� ������������ ���������� ������ �����
            if (sceneIndex >= 0)
            {
                SceneManager.LoadScene(sceneIndex);
            }
            else
            {
                Debug.LogError("Scene index is not set correctly in the SceneChangeTrigger script.");
            }
        }
    }
}
