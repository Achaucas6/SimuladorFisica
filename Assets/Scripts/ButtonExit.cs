using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtionExit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnInteract()
    {
        Debug.Log("¡Botón presionado: " + gameObject.name + "!");
        Application.Quit();
    }
}
