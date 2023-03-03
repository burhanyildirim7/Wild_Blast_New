using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BinaKurma : MonoBehaviour
{

    [SerializeField] public int _binaNo,_haritaNo;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //BOŞ ALAN FONKSİYONU
    public void BosAlanButtonFonk()
    {

        GameObject.Find("Building_Choice_Panel").transform.GetChild(0).gameObject.SetActive(true);
        PlayerPrefs.SetInt("SecilenBina", _binaNo);
        //PlayerPrefs.SetInt("BinaBosAlan"+_haritaNo+_binaNo,1);
        GameObject.Find("ToDoListButton").GetComponent<ToDoListAcma>().AnaEkrandaPanelAcma();
    }


    public void TamBinaButtonFonk()
    {
        GameObject.Find("Bina_"+_binaNo+"_Panel").transform.GetChild(0).gameObject.SetActive(true);
        GameObject.Find("ToDoListButton").GetComponent<ToDoListAcma>().AnaEkrandaPanelAcma();

    }

}
