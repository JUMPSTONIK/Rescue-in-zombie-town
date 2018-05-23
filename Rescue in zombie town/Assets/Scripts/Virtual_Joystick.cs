using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class Virtual_Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler,IPointerDownHandler {

    private Image bgImg;
    private Image JoystickImg;
    private Vector3 inputVector;

    // Use this for initialization
    void Start () {

        bgImg = GetComponent <Image>();
        JoystickImg = transform.GetChild(0).GetComponent<Image>();
	}

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform, eventData.position,eventData.pressEventCamera,out pos))
        {
            pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);

            inputVector = new Vector3(pos.x * 2,0, pos.y*2);
            inputVector = (inputVector.magnitude > 1.0f)?inputVector.normalized : inputVector;
            Debug.Log(inputVector);
            //move joystick IMG
            JoystickImg.rectTransform.anchoredPosition = (new Vector3(inputVector.x * (bgImg.rectTransform.sizeDelta.x / 3), inputVector.z * (bgImg.rectTransform.sizeDelta.y / 3)));

        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector3.zero;
        JoystickImg.rectTransform.anchoredPosition = Vector3.zero;
    }

    public float Horizontal()
    {
        if (inputVector.x != 0)
        {
            return inputVector.x;
        }
        else
        {
            return Input.GetAxis("Horizontal");
        }
    }
    public float Vertical()
    {
        if (inputVector.z != 0)
        {
            return inputVector.z;
        }
        else
        {
            return Input.GetAxis("Vertical");
        }
    }
}
