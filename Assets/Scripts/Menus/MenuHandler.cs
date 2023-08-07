using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public void SwitchMenuState(Menu menu)
    {
        menu.gameObject.SetActive(!menu.gameObject.activeSelf);
        Time.timeScale = menu.gameObject.activeSelf ? 0f : 1f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
}