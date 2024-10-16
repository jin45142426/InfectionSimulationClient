using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSphere : MonoBehaviour
{
    public string _message;
    GameObject _popup;

    private void Awake()
    {
        _message = "<color=#FF0000>격리 환자를 이송 중 입니다.\n가까이 접근하지 마세요.</color>";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("MyPlayer"))
            return;

        _popup = Managers.UI.CreateSystemPopup("PopupNotice", _message, UIManager.PopupType.ManualDestroy);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("MyPlayer"))
            return;

        if (_popup != null)
            _popup.GetComponent<SystemPopup>().AutoDestroy(0);
    }

    private void OnDisable()
    {
        Managers.UI.DestroyUI(_popup);
    }
}
