using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Exercise1Panel : MonoBehaviour
{
    public Transform pointA, pointB;

    private TextMeshProUGUI exerciseText;
    private Vector3 a, b;
    private string problemText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        exerciseText= transform.Find("Label").GetComponent<TextMeshProUGUI>();
        if (exerciseText == null)
        {
            throw new System.NullReferenceException(" No se encontró el componente TextMeshProUGUI en Canvas-Label");
        }

        a = pointA.position;
        b = pointB.position;
        problemText= 
            "1. Un personaje de videojuego se desplaza desde el punto A "+pointA.transform.position.ToString()+ " hasta el punto B " + pointB.transform.position.ToString() + ".\n" +
                        "Determinar el vector desplazamiento, la distancia recorrida y la dirección unitaria del movimiento";

        Resolve();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Resolve()
    {
        Vector3 desp = b - a;
        float mod = desp.magnitude;
        exerciseText.text = problemText+ "\n" + 
            "AB = B - A = " + (b - a).ToString() + "\n" +
            "|AB| = \u221A(("+desp.x +")<sup>2</sup> + "+"(" + desp.y + ")<sup>2</sup> + (" + desp.z + ")<sup>2</sup>) = " + mod + "\n" +
            "u = AB / |AB| = (" + desp.x + " / " + mod+" + " +desp.y + " / "+mod+" + "+desp.z + " / "+mod+") = "+desp.normalized;
    }
}
