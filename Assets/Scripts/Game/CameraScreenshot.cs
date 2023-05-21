using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScreenshot : MonoBehaviour
{
    public Sprite GetScreenSprite()
    {
        int cameraWidth = Camera.main.pixelWidth;
        int cameraHeight = Camera.main.pixelHeight;
        int cameraDepth = (int)Camera.main.transform.position.z;

        RenderTexture renderTexture = new RenderTexture(cameraWidth, cameraHeight, cameraDepth);
        Rect rect = new Rect(0, 0, cameraWidth, cameraHeight);
        Texture2D texture2D = new Texture2D(cameraWidth, cameraHeight, TextureFormat.RGBA32, false);

        Camera.main.targetTexture = renderTexture;
        Camera.main.Render();

        RenderTexture currentRenderTexture = RenderTexture.active;
        RenderTexture.active = renderTexture;
        texture2D.ReadPixels(rect, 0, 0);
        texture2D.Apply();

        Camera.main.targetTexture = null;
        RenderTexture.active = currentRenderTexture;
        Destroy(renderTexture);

        Sprite screenSprite = Sprite.Create(texture2D, rect, Vector2.zero);

        return screenSprite;
    }
}
