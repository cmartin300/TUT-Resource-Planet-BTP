using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] Animator transition;

    public void SwitchToGameScene()
    {
        StartCoroutine(LoadGame(1));
    }

    IEnumerator LoadGame(int sceneIndex)
    {
        transition.SetTrigger("start");

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
