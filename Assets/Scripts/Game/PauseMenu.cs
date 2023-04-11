using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image imageBack;

    [SerializeField] private Shader blurShader;
    private Material blurMaterial;

    private void Start()
    {
        blurMaterial = new Material(blurShader);
        imageBack.material = blurMaterial;
    }

    private void OnEnable()
    {
        Sprite spriteToBack = Camera.main.GetComponent<CameraScreenshot>().GetCreenSprite();
        imageBack.sprite = spriteToBack;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
