using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageWindow : MonoBehaviour, IStartable
{
    private Animator anim_window;
    private DemonSO demonSO;
    private GameObject callOnMiniMap;
    [SerializeField] private Button buttonAccept, buttonCancel;

    private void Start()
    {
        anim_window = GetComponent<Animator>();

        buttonAccept.onClick.AddListener(ClickAccept);
        buttonCancel.onClick.AddListener(ClickCancel);
    }

    public void OnStart(DemonSO demonSO, GameObject callOnMiniMap)
    {
        this.demonSO = demonSO;
        this.callOnMiniMap = callOnMiniMap;
    }

    private void ClickAccept()
    {
        anim_window.SetBool("isCallAccept", true);
    }
    private void ClickCancel()
    {
        CallCreator callCreator = GameController.GetInstance().GetComponent<CallCreator>();
        callCreator.GenerateCall_On();

        Destroy(this.gameObject);
    }

    public void ClickText()
    {
        PlayAnimator();
    }

    public void AnimationOver()
    {
        Destroy(this.gameObject, 1.3f);
        callOnMiniMap.SetActive(true);
    }

    public void StopAnimator() => anim_window.enabled = false;
    public void PlayAnimator() => anim_window.enabled = true;
}