using NUnit.Framework.Constraints;
using TMPro;
using UnityEngine;

public class LabelPosition : MonoBehaviour
{
    private TextMeshProUGUI textPosition;
    private Transform player;

    void Start()
    {

        textPosition = transform.Find("Canvas").Find("Label").GetComponent<TextMeshProUGUI>();
        if (textPosition == null)
        {
            throw new System.NullReferenceException(" No se encontró el componente TextMeshProUGUI en Canvas-Label");
        }

        player = GameObject.FindWithTag("Player").transform;
        if(player == null)
        {
            throw new System.NullReferenceException(" No se encontró el objeto con tag \"Player\"");
        }
    }
    // Update is called once per frame
    void Update()
    {
        textPosition.text = gameObject.name+ "\n" + transform.position.ToString();
        Vector3 vec = transform.rotation.eulerAngles;
        vec.y = player.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Euler(vec);
        Debug.Log(player.rotation.eulerAngles.y);
    }
    
}