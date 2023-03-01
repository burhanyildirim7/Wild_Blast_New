using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ToDoListAcma : MonoBehaviour
{
    [SerializeField] GameObject _mapParentObject,_playButtonObject,_toDoListButtonObject;
    // Start is called before the first frame update
    public void ToDoListAcmaButton()
    {

        _mapParentObject.transform.GetChild(1).GetChild(5).gameObject.SetActive(true);
        AnaEkrandaPanelAcma();
    }
    public void AnaEkrandaPanelAcma()
    {

        _playButtonObject.transform.DOLocalMoveY(_playButtonObject.transform.localPosition.y - 500, .5f).OnComplete(() => _playButtonObject.SetActive(false));
        _toDoListButtonObject.transform.DOLocalMoveY(_toDoListButtonObject.transform.localPosition.y - 500, .5f).OnComplete(() => _toDoListButtonObject.SetActive(false));


    }

}
