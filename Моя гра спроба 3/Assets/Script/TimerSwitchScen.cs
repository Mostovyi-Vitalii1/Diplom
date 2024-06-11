using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerSwitchScen : MonoBehaviour
{
    // ��������� ������� � ��������
    public float timerDuration = 10f;

    // ������ ����� ��� ������������
    public int sceneToLoadIndex;

    // UI ������� ��� ����������� �������
    public TMP_Text  timerText;

    private float timeRemaining;

    void Start()
    {
        // ����������� ����������� ����
        timeRemaining = timerDuration;
    }

    void Update()
    {
        // ³��� ����
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerUI();
        }
        else
        {
            // ������������ ���� �����, ���� ������ ���������
            SceneManager.LoadScene(sceneToLoadIndex);
        }
    }

    void UpdateTimerUI()
    {
        // ��������� UI �������
        if (timerText != null)
        {
            timerText.text = Mathf.Ceil(timeRemaining).ToString();
        }
    }
}
