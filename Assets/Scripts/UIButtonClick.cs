using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIButtonClick : MonoBehaviour
{
    UIDocument buttonDocumnet;
    Button infoButton;
    Button infoPopupExit;
    VisualElement infoPopupHolder;
    VisualElement infoPopup;

    void OnEnable() 
    {
        buttonDocumnet = GetComponent<UIDocument>();

        if(buttonDocumnet == null){
            Debug.LogError("No UI Documnet Found");
        }
        infoButton = buttonDocumnet.rootVisualElement.Q("InfoButton") as Button;

        // popup window
        infoPopupHolder = buttonDocumnet.rootVisualElement.Q("InfoPopupHolder") as VisualElement;
        infoPopup = buttonDocumnet.rootVisualElement.Q("InfoPopup") as VisualElement;
        infoPopupExit = buttonDocumnet.rootVisualElement.Q("InfoPopupExit") as Button;

        if (infoButton == null){
            Debug.LogError("no Info button found");
        }
        if (infoPopup == null){
            Debug.LogError("no Info popup found");
        }
        if (infoPopupHolder == null){
            Debug.LogError("no Info popup found");
        }
         if (infoPopupExit == null){
            Debug.LogError("no Info popup exit button found");
        }

        infoButton.RegisterCallback<ClickEvent>(OnInfoButtonClick);
        infoPopupExit.RegisterCallback<ClickEvent>(OnInfoExitButtonClick);
        PopUp(false);
    }

    public void OnInfoButtonClick (ClickEvent evt){
        PopUp(true);
    }

    public void OnInfoExitButtonClick (ClickEvent evt){
        PopUp(false);
    }

    void PopUp(bool show){
        infoPopupHolder.visible = show;
        infoPopup.visible = show;
    }




}
