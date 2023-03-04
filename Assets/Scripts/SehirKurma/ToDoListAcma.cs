using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ToDoListAcma : MonoBehaviour
{
    [SerializeField] GameObject _mapParentObject,_playButtonObject,_toDoListButtonObject,_bottomButtonGroup;
    // Start is called before the first frame update
    public void ToDoListAcmaButton()
    {

        GameObject.Find("ToDoListPage").transform.GetChild(0).gameObject.SetActive(true);
        AnaEkrandaPanelAcma();
    }
    public void AnaEkrandaPanelAcma()
    {

        _playButtonObject.transform.DOLocalMoveY(_playButtonObject.transform.localPosition.y - 500, .25f)
            .OnComplete(() => _playButtonObject.SetActive(false));

        _toDoListButtonObject.transform.DOLocalMoveY(_toDoListButtonObject.transform.localPosition.y - 500, .25f)
            .OnComplete(() => BottomButtonlariGönder());

    }
    private void BottomButtonlariGönder()
    {
        _toDoListButtonObject.SetActive(false);
        _bottomButtonGroup.transform.DOLocalMoveY(_bottomButtonGroup.transform.localPosition.y - 500, .25f);
    }
}
