using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentKapatma : MonoBehaviour
{
    public void ParentKapatmaButton()
    {
        GameObject.Find("PanelKapatmaScript").GetComponent<PanelKapatma>().AnaEkrandaPanelKapatma();
        transform.parent.gameObject.SetActive(false);

    }

}
