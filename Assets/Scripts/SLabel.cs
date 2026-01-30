using NUnit.Framework.Constraints;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class SLabel : MonoBehaviour
{
    private TextMeshProUGUI textPosition;
    private Transform player;
    public GameObject labelPrefab;
    public Vector3 offset;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPrefab(labelPrefab);

        textPosition = transform.GetComponentInChildren<TextMeshProUGUI>();
        if (textPosition == null)
        {
            throw new System.NullReferenceException(" No se encontró el componente TextMeshProUGUI en Canvas-Label");
        }

        player = GameObject.FindWithTag("Player").transform;
        if (player == null)
        {
            throw new System.NullReferenceException(" No se encontró el objeto con tag \"Player\"");
        }
    }

    // Update is called once per frame
    void Update()
    {
        textPosition.text = this.gameObject.name + "\n" + this.transform.position.ToString();
        Vector3 vec = transform.rotation.eulerAngles;
        vec.y = player.rotation.eulerAngles.y;
        this.transform.rotation = Quaternion.Euler(vec);
    }
    void SpawnPrefab(GameObject prefab)
    {
       
        Instantiate(prefab, this.transform.position + offset, Quaternion.identity, this.transform);
    }
}
