using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Range(0f, 1f)] // �������� �� 0 �� 1
    public float AlphaLevel = 1f; // ����������� �������� �����-������, ������� ������ ����� ����� ��������, �� ������� ������� ������, ����� ������������ �������
    private Image bt; // �������� ����� ������ � Image � �� � Button

    [SerializeField] private GameObject buttonStroke;
    private Image btStImage;
    private Color hoverColor;
    private Color normalColor;

    private void Start()
    {
        bt = gameObject.GetComponent<Image>();
        bt.alphaHitTestMinimumThreshold = AlphaLevel; // �������� alphaHitTestMinimumThreshold ��� ��� � �������� �� ��, ����� ����������� ������� ������������ ������ ���� � ����� ��������, ����� ��� ����� ���������� �������.

        btStImage = buttonStroke.GetComponentInChildren<Image>();
        normalColor = btStImage.color;
        hoverColor = new Color(normalColor.r, normalColor.g + 0.7f, normalColor.b);
    }



    public void OnPointerEnter(PointerEventData eventData)
    {
        btStImage.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        btStImage.color = normalColor;
    }

    public void SetNormalColor()
    {
        btStImage.color = normalColor;
    }
}