using System;
using TMPro;

using UnityEngine;
using UnityEngine.UIElements;

public class Exercise3Panel : MonoBehaviour
{
    private TextMeshProUGUI exerciseText;
    public Transform tPointA;
    public Transform tPointB;
    private Vector3 posPointA, posPointB;
    private Vector3 vPoitA, vPoitB;
    private string problemText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        exerciseText = transform.Find("Label").GetComponent<TextMeshProUGUI>();
        if (exerciseText == null)
        {
            throw new System.NullReferenceException(" No se encontro el componente TextMeshProUGUI en Canvas-Label");
        }
        posPointA = tPointA.position;
        posPointB = tPointB.position;
        problemText = "Objeto 1: posición inicial " + posPointA.ToString() + " , velocidad u1= (2,1,0)" + "\n" +
            "Objeto 2: posición inicial " + posPointB.ToString() + " , velocidad u2= (-1,0.1)" + "\n" +
            "Determinar si colisionan." + "\n";

        Resolve();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Resolve()
    {
        exerciseText.text = problemText+ "\n" +
            "u1 = "+posPointA.ToString()+"\n" +
            "u2 = "+posPointB.ToString()+"\n" +
            "R1(t)= (1+2t+t,3)"+"\n" +
           "R2(t)=(5-t,3,1+t)"+"\n" +
           "R1(T)=R2(T)"+"\n" +
           "Componente x:"+"\n" +
           "1+2t = 5-t "+"\n" +
           "3t = 4"+"\n" +
           "t = 4/3"+"\n" +
           "Componente y:"+"\n" +
           "2+t = 3"+"\n" +
           "t = 1"+"\n" +
           "Componente z:"+"\n" +
           "3 = 1+t"+"\n" +
           "2 = t"+"\n"+
           "Los valores son distintos por lo tanto no colisionan";
        //Falta estandarizar la respuesta final
    }
}
