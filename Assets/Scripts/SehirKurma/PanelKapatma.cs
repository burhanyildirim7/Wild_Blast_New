using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PanelKapatma : MonoBehaviour
{
    [SerializeField] GameObject _playButtonObject, _toDoListButtonObject, _bottomButtonGroup;


    public void AnaEkrandaPanelKapatma()
    {
        _bottomButtonGroup.transform.DOLocalMoveY(_bottomButtonGroup.transform.localPosition.y + 500, .25f)
            .OnComplete(() => ButtonlariGetir());
    }
    private void ButtonlariGetir()
    {
        _playButtonObject.SetActive(true);
        _toDoListButtonObject.SetActive(true);
        _toDoListButtonObject.transform.DOLocalMoveY(_toDoListButtonObject.transform.localPosition.y + 500, .25f);
        _playButtonObject.transform.DOLocalMoveY(_playButtonObject.transform.localPosition.y + 500, .25f);
    }
}
