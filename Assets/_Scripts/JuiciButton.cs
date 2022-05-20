using UnityEngine;
using UnityEngine.UI;

public class JuiciButton : MonoBehaviour
{
    private Color defaultColorButton;
    private Color defaultColorText;
    [SerializeField] private Color colorChangeButton;
    [SerializeField] private Color colorChangeText;

    private void Start()
    {
        defaultColorButton = GetComponent<Image>().color;
        defaultColorText = transform.GetChild(0).GetComponent<Text>().color;
    }

    public void ChangeColor()
    {
        GetComponent<Image>().color = colorChangeButton;
        transform.GetChild(0).GetComponent<Text>().color = colorChangeText;
    }

    public void SetDeafultColor()
    {
        GetComponent<Image>().color = defaultColorButton;
        transform.GetChild(0).GetComponent<Text>().color = defaultColorText;
    }
}
