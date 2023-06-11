using UnityEngine;
using UnityEngine.UI;

public class ChangeColorRainbow : MonoBehaviour
{
    Outline outline;

    void Start()
    {
        outline = GetComponent<Outline>();
    }

    void Update()
    {
        outline.effectColor = Color.HSVToRGB(Time.time % 1, 1, 0.5f);
    }
}