using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestMessageWindow : MonoBehaviour
{
    private Animator anim_window;

    [SerializeField] private Button buttonAccept;

    private void Start()
    {
        anim_window = GetComponent<Animator>();

        buttonAccept.onClick.AddListener(ClickAccept);
    }

    private void ClickAccept()
    {
        anim_window.SetBool("isCallAccept", true);
    }

    public void ClickText()
    {
        PlayAnimator();
    }

    public void AnimationOver()
    {
        Destroy(this.gameObject, 2.0f);
    }

    public void StopAnimator() => anim_window.enabled = false;
    public void PlayAnimator() => anim_window.enabled = true;
}
