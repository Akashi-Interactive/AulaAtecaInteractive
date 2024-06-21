using UnityEngine;
using UnityEngine.UI;

public class ColourPickerController : MonoBehaviour
{
    [SerializeField] 
    private int size = 16;

    [SerializeField]
    private float hue, saturation, value;

    [SerializeField]
    private RawImage hueImage, svImage, outputImage;

    [SerializeField]
    private Slider hueSlider;

    private Texture2D hueTexture, svTexture, outputTexture;

    [SerializeField]
    private MeshRenderer objectToChange;

    private void Start()
    {
        CreateHueImage();

        CreateSVImage();

        CreateOutputImage();

        UpdateOutputImage();
    }

    private void CreateHueImage()
    {
        hueTexture = new Texture2D(1, size);
        hueTexture.wrapMode = TextureWrapMode.Clamp;

        for(int i = 0; i < hueTexture.height; i++)
        {
            hueTexture.SetPixel(0, i, Color.HSVToRGB((float)i / hueTexture.height, 1f, 1f));
        }

        hueTexture.Apply();
        hue = 0;

        hueImage.texture = hueTexture;
    }

    private void CreateSVImage()
    {
        svTexture = new Texture2D(size, size);
        svTexture.wrapMode = TextureWrapMode.Clamp;

        for(int y = 0; y < svTexture.height; y++)
        {
            for(int x = 0; x < svTexture.width; x++)
            {
                svTexture.SetPixel(y, x, Color.HSVToRGB(hue, (float) y / svTexture.width, (float)x / svTexture.height));
            }
        }

        svTexture.Apply();
        saturation = 0;
        value = 0;

        svImage.texture = svTexture;
    }

    private void CreateOutputImage()
    {
        outputTexture = new Texture2D(1, size);
        outputTexture.wrapMode = TextureWrapMode.Clamp;

        Color colour = Color.HSVToRGB(hue, saturation, value);

        for(int i = 0; i < outputTexture.height; i++)
        {
            outputTexture.SetPixel(0, i, colour);
        }

        outputTexture.Apply();
        outputImage.texture = outputTexture;
    }

    private void UpdateOutputImage()
    {
        Color colour = Color.HSVToRGB(hue, saturation, value);

        for (int i = 0; i <outputTexture.height; i++)
        {
            outputTexture.SetPixel(0, i, colour);
        }

        outputTexture.Apply();
        
        objectToChange.material.color = colour;
    }

    public void SetSV(float saturation, float value)
    {
        this.saturation = saturation;
        this.value = value;

        UpdateOutputImage();
    }

    public void UpdateSVImage()
    {
        hue = hueSlider.value;

        for(int y = 0; y < svTexture.height; y++)
        {
            for(int x = 0; x < svTexture.width; x++)
            {
                svTexture.SetPixel(x, y, Color.HSVToRGB(hue, (float)x / svTexture.width, (float)y / svTexture.height));
            }
        }

        svTexture.Apply();
        
        UpdateOutputImage();
    }
}