using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void LoadExercise(string nameExercise)
    {
        SceneManager.LoadScene(nameExercise);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Exit the game........");
    }
}
