using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonGoTo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string sceneName;
    public void Awake()
    {
        
    }
    public void OnInteract()
    {
        Debug.Log("¡Botón presionado: " + gameObject.name + "!");
        SceneManager.LoadScene(sceneName);
    }
}
