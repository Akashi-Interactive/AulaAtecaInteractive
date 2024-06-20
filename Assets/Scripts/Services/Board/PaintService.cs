using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AulaAtecaInteractive.Assets.Scripts.BoardService
{
    public class PaintService : MonoBehaviour
    {
        public Color currentColor = Color.black; // Color actual de pintura
        public Texture2D texture; // Textura sobre la que se pinta
        public RawImage rawImage;

        void Start()
        {
            int textureWidth = 1024; // Aumentar la resolución
            int textureHeight = 1024; // Aumentar la resolución
            texture = new Texture2D(textureWidth, textureHeight);
            rawImage.texture = texture;

            for (int x = 0; x < texture.width; x++)
            {
                for (int y = 0; y < texture.height; y++)
                {
                    texture.SetPixel(x, y, Color.white);
                }
            }
            texture.Apply();
        }

        public void Paint(Vector2 uv)
        {
            int x = (int)(uv.x * texture.width);
            int y = (int)(uv.y * texture.height);

            texture.SetPixel(x, y, currentColor);
            texture.Apply();
        }
    }
}
