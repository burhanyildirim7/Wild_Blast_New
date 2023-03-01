using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class spriteDuzenlemee : MonoBehaviour
{
    [SerializeField] SpriteRenderer _referans;
    void Start()
    {
        
    }

    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().color = _referans.color;
       // gameObject.GetComponent<SpriteRenderer>().sortingLayerID = transform.parent.gameObject.GetComponent<SpriteRenderer>().sortingLayerID;
        gameObject.GetComponent<SpriteRenderer>().sortingOrder= transform.parent.gameObject.GetComponent<SpriteRenderer>().sortingOrder;
    }
}
