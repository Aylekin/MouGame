using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DandelionMenuUpdate : MonoBehaviour
{
    // Ten skrypt jest przypisany do canvasu MenuGame; pojawia się obraz Dmuchawca w momencie zebrania go w grze. Informacja o zdobyciu przekazywana przez klasę statyczną - będzie trzeba to potem zmienić, by zapisywać gdzieś dane gry na stałe.
    [SerializeField]
    Image CompletedLevel1;
    [SerializeField]
    Image CompletedLevel2;
    [SerializeField]
    Image CompletedLevel3;
    [SerializeField]
    Sprite DandelionSprite1;
    [SerializeField]
    Sprite DandelionSprite2;        //obraz odblokowanego dmuchawca - poziom 2
    [SerializeField]
    Sprite DandelionSprite3;        //obraz odblokowanego dmuchawca - poziom 3

    [SerializeField]
    Button BtnLevel2;
    [SerializeField]
    Button InfoLevel2;
    [SerializeField]
    Image ImageLevel2;
    [SerializeField]
    Text TextUnlock2;

    [SerializeField]
    Button BtnLevel3;
    [SerializeField]
    Button InfoLevel3;
    [SerializeField]
    Button ShowEndStory;
    [SerializeField]
    Image ImageLevel3;
    [SerializeField]
    Text TextUnlock3;

    float intense = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteKey("dandelionLvlName2"); //Jeśli chcesz, żeby Dmuchawiec nie był zebrany, odkomentuj, włącz grę, zakomentuj i włącz jeszcze raz
        //PlayerPrefs.DeleteKey("dandelionLvlName1");
        //PlayerPrefs.DeleteKey("dandelionLvlName3");
        BtnLevel2.interactable = false;
        BtnLevel3.interactable = false;
        DisappearButton(BtnLevel2, true);             // true - jest przezroczysty/niewidoczny, false - pełny kolor 
        DisappearButton(InfoLevel2, true);
        TransparentImage(ImageLevel2, true);
        ShowEndStory.gameObject.SetActive(false);
        DisappearButton(BtnLevel3, true);
        DisappearButton(InfoLevel3, true);
        TransparentImage(ImageLevel3, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.HasKey("dandelionLvlName1"))
        {
            CompletedLevel1.sprite = DandelionSprite1;
            BtnLevel2.interactable = true;
            DisappearButton(BtnLevel2, false);
            DisappearButton(InfoLevel2, false);
            TransparentImage(ImageLevel2, false);
            TextUnlock2.enabled =false;
        }
            
        if (PlayerPrefs.HasKey("dandelionLvlName2"))
        {
            CompletedLevel2.sprite = DandelionSprite2;
            BtnLevel3.interactable = true;
            DisappearButton(BtnLevel3, false);
            DisappearButton(InfoLevel3, false);
            TransparentImage(ImageLevel3, false);
            TextUnlock3.enabled = false;
        }
            
        if (PlayerPrefs.HasKey("dandelionLvlName3"))
        {
            CompletedLevel3.sprite = DandelionSprite3;
            ShowEndStory.gameObject.SetActive(true);
        }
    }
    public void DisappearButton(Button obj, bool transparent)
    {
        float btnIntense = 0f;
        if (transparent == false)
            btnIntense = 1.0f;
        obj.GetComponent<Image>().color = new Color(obj.GetComponent<Image>().color.r, obj.GetComponent<Image>().color.g, obj.GetComponent<Image>().color.b, btnIntense);
    }
    public void TransparentImage(Image obj, bool transparent)
    {
        if (transparent == false)
            intense = 1.0f;
        obj.GetComponent<Image>().color = new Color(obj.GetComponent<Image>().color.r, obj.GetComponent<Image>().color.g, obj.GetComponent<Image>().color.b, intense);
    }
}
