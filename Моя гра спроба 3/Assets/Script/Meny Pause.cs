using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenyPause : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log(7765);
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        // �������� ����� ����� ����� ������������� ��������� ����
        Resume();
        SceneManager.LoadScene("MainMenu"); // ������ "MainMenu" �������������� ��'� ���� ����� ��������� ����
    }

    public void QuitGame()
    {
        // �������� ����� ����� ����� ������������� ���������� �����
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    // ���������� ��� ����� ��� ����������� ����� ���, ��� ������������, �� ��� �� ���������� � ����
    void OnEnable()
    {
        Resume();
    }
}
