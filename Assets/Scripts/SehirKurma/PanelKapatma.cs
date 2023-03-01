using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PanelKapatma : MonoBehaviour
{
    [SerializeField] GameObject _playButtonObject, _toDoListButtonObject;


    public void AnaEkrandaPanelKapatma()
    {
        _playButtonObject.SetActive(true);
        _toDoListButtonObject.SetActive(true);
        _playButtonObject.transform.DOLocalMoveY(_playButtonObject.transform.localPosition.y + 500, .5f);
        _toDoListButtonObject.transform.DOLocalMoveY(_toDoListButtonObject.transform.localPosition.y + 500, .5f);

       
    }


}
