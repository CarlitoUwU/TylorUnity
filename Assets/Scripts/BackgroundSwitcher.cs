using UnityEngine;
using UnityEngine.UI;

public class BackgroundSwitcher : MonoBehaviour
{
    public Image background;
    public Sprite inicioBg;
    public Sprite historiaBg;
    public Sprite indicacionesBg;
    public Sprite creditosBg;

    public void ShowInicio()
    {
        background.sprite = inicioBg;
    }

    public void ShowHistoria()
    {
        background.sprite = historiaBg;
    }

    public void ShowIndicaciones()
    {
        background.sprite = indicacionesBg;
    }

    public void ShowCreditos()
    {
        background.sprite = creditosBg;
    }
}
