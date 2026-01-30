using System;
using TMPro;
using UnityEngine;

public class Exercise2Panel : MonoBehaviour
{
    public Transform posEnemy;
    public Transform posTorrent;
    private TextMeshProUGUI exerciseText;
    private Vector3 vEnemy, vTorrent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        exerciseText = transform.Find("Label").GetComponent<TextMeshProUGUI>();
        if (exerciseText == null)
        {
            throw new System.NullReferenceException(" No se encontro el componente TextMeshProUGUI en Canvas-Label");
        }
        vEnemy = posEnemy.position;
        vTorrent = posTorrent.position;
        Resolve();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Resolve()
    {
        Vector3 dirFire = vEnemy - vTorrent  ;
        Vector3 dirFireXZ = new Vector3(dirFire.x, 0, dirFire.z);
        float a = dirFire.y / dirFireXZ.magnitude;
        exerciseText.text = "Enemy position(E) : " + vEnemy.ToString() + "\n" +
            "Torrent position(T) : " + vTorrent.ToString() + "\n" +
            "D = T - E = " + vEnemy.ToString() + " - "+ vTorrent.ToString() +" = "+ dirFire.ToString()+ "\n" +
            "D(xz) = "+dirFireXZ.ToString() + "\n"+
            "|D(xz)| = \u221A((" + dirFireXZ.x+ ")<sup>2</sup> + (" + dirFireXZ.z+ ")<sup>2</sup>) = \u221A(" + (MathF.Pow(dirFireXZ.x,2)+MathF.Pow(dirFireXZ.z,2))+") = "+dirFireXZ.magnitude + "\n" +
            "tan (a) = Dy / |D(xz)| = "+ dirFire.y +" / "+ dirFireXZ.magnitude +" = "+a+ "\n"+
            "a = arctan( "+ a + " ) = "+MathF.Atan(a)* Mathf.Rad2Deg;

    }
}
