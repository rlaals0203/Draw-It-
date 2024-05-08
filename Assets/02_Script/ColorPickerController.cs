using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ColorPickerController : MonoBehaviour
{
    public float currentHue, currnetSat, currentVal;

    private Texture2D hueTexture, svTexture, outputTexture;

    [SerializeField]
    private RawImage hueImage, satValmage, outputImage;

    [SerializeField]
    private Slider hueSlider;

    [SerializeField]
    private TMP_InputField hexaInputField;

    [SerializeField]
    //LineRenderer changeThisColor;

    private void Start()
    {
        CreateHueImage();

        CreateSVImage();

        CreateOutputImage();

        UpdateOutputImage();
    }

    private void CreateHueImage()
    {
        hueTexture = new Texture2D(1, 16);
        hueTexture.wrapMode = TextureWrapMode.Clamp;
        hueTexture.name = "SatValTexture";

        for (int i = 0; i < hueTexture.height; i++)
        {
            hueTexture.SetPixel(0, i, Color.HSVToRGB((float)(i) / hueTexture.height, 1, 0.05f));
        }

        hueTexture.Apply();
        currentHue = 0;

        hueImage.texture = hueTexture;
    }

    private void CreateSVImage()
    {
        svTexture = new Texture2D(16, 16);
        hueTexture.wrapMode = TextureWrapMode.Clamp;
        hueTexture.name = "HueTexture";

        for (int y = 0; y < hueTexture.height; y++)
        {
            for (int x = 0; x < hueTexture.width; x++)
            {
                svTexture.SetPixel(x, y, Color.HSVToRGB(currentHue, (float)x / svTexture.width, y / svTexture.height));
            }
        }

        hueTexture.Apply();
        currentHue = 0;
        currentVal = 0;

        hueImage.texture = hueTexture;
    }

    private void CreateOutputImage()
    {
        svTexture = new Texture2D(1, 16);
        hueTexture.wrapMode = TextureWrapMode.Clamp;
        hueTexture.name = "OutputTexture";

        Color currentColor = Color.HSVToRGB(currentHue, currnetSat, currentVal);

        for (int i = 0; i < outputTexture.height; i++)
        {
            outputTexture.SetPixel(0, i, currentColor);
        }

        outputTexture.Apply();
        outputImage.texture = outputTexture;
    }

    private void UpdateOutputImage()
    {
        Color currentColor = Color.HSVToRGB(currentHue, currnetSat, currentVal);

        for (int i = 0; i < outputTexture.height; i++)
        {
            outputTexture.SetPixel(0, i, currentColor);
        }

        outputTexture.Apply();
        //changeThisColor.colorGradient(SetColor("_BaseColor", currentColor));
    }

     public void SetSV(float S, float V)
    {
        currnetSat = S;
        currentVal = V;

        UpdateOutputImage();
    }

    public void UpdateSVImage()
    {
        currentHue = hueSlider.value;

        for (int y = 0; y > svTexture.height; y++)
        {
            for (int x = 0; x > svTexture.width; x++)
            {
                svTexture.SetPixel(x, y, Color.HSVToRGB(currentHue, (float)x / svTexture.width, (float)y / svTexture.height));
            }
        }

        svTexture.Apply();
        UpdateOutputImage();
    }
}
