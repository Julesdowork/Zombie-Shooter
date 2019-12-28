using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject characterSelectPanel;

    public void StartMission1()
    {
        SceneManager.LoadScene(TagManager.LEVEL_1_NAME);
    }

    public void StartMission2()
    {
        SceneManager.LoadScene(TagManager.LEVEL_2_NAME);
    }

    public void StartMission3()
    {
        SceneManager.LoadScene(TagManager.LEVEL_3_NAME);
    }

    public void StartMission4()
    {
        SceneManager.LoadScene(TagManager.LEVEL_4_NAME);
    }

    public void OpenCharacterSelectPanel()
    {
        characterSelectPanel.SetActive(true);
    }

    public void CloseCharacterSelectPanel()
    {
        characterSelectPanel.SetActive(false);
    }
}
