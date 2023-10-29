using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadScene(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadWinScene()
    {
        SceneManager.LoadScene(4);
    }

    //destroy any game object (referenced through animations)
    public void Destroyer()
    {
        Destroy(gameObject);
    }

    //remeber nights survived
    private GameObject nightsSurvivedText;
    private void Start()
    {
        int nightsSurvived = GameObject.FindGameObjectWithTag("Nights Survived").GetComponent<Nights_Survived>().nightsSurvived;
        nightsSurvivedText = GameObject.FindGameObjectWithTag("Nights Survived Text");
        if (nightsSurvivedText)
            nightsSurvivedText.GetComponent<TextMeshProUGUI>().text = "Nights Survived: " + nightsSurvived;
    }
}