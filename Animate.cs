using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class Animate : MonoBehaviour
{

    public Animator Anim;
    int TransizioneFront = Animator.StringToHash("TransizioneFrontale");
    int TransizioneAlto = Animator.StringToHash("TransizioneAlto");
    int TavoloSiAbbassa = Animator.StringToHash("TavoloSiAbbassa");
    int TavoloSiAlza = Animator.StringToHash("SollevaTavolo");
    int TavoloRuota = Animator.StringToHash("RotazioneTavolo");

    bool SetTextIsClicked = true;
    bool SetTextScalaIsClicked = true;
    bool SetTextRenderingIsClicked = true;
    bool SetScaleIsClicked = true;
    bool SetRenderingIsClicked = true;
    bool OmbrelloneIsOff = false;

    public GameObject game;
    public GameObject light;
    public GameObject Ombrellone;
    public GameObject Ombrellone_Static;
    public GameObject DaScalare;
    public Renderer rend;
    public Material luceombrellone;

    public GameObject buttonvistafrontale;
    public GameObject buttonvistasuperiore;
    public GameObject buttonsolleva;
    public GameObject buttonabbassa;
    public GameObject buttonruota;
    public GameObject buttonluce;
    public GameObject buttonobrellone;
    public GameObject buttonscala;

    public Text luce;
    public Text Ombrelloonoff;
    private string stringa;
    private string stringa2;


    // Start is called before the first frame update
    void Start()
    {
        Anim.GetComponent<Animator>();
        Text textReference = GetComponent<Text>();
        luceombrellone.DisableKeyword("_EMISSION");
    }   

    // Update is called once per frame
    void Update()
    {
        if (Anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !Anim.IsInTransition(0))
        {
            buttonvistafrontale.SetActive(true);
            buttonvistasuperiore.SetActive(true);
            buttonsolleva.SetActive(true);
            buttonabbassa.SetActive(true);
            buttonruota.SetActive(true);
            buttonluce.SetActive(true);
            buttonobrellone.SetActive(true);
            buttonscala.SetActive(true);
        }
        else
        {
            buttonvistafrontale.SetActive(false);
            buttonvistasuperiore.SetActive(false);
            buttonsolleva.SetActive(false);
            buttonabbassa.SetActive(false);
            buttonruota.SetActive(false);
            buttonluce.SetActive(false);
            buttonobrellone.SetActive(false);
            buttonscala.SetActive(false);
        }

        stringa = luce.text;

        if (!Ombrellone.active)
        {
            light.SetActive(false);
        }
        else if(Ombrellone.active && stringa.CompareTo("Luce Off") == 0)
        {
            light.SetActive(true);
        }
        else if (Ombrellone.active && stringa.CompareTo("Luce On") == 0)
        {
            luceombrellone.DisableKeyword("_EMISSION");
        }

        stringa2 = Ombrelloonoff.text;

        if (game.active && stringa2.CompareTo("Ombrellone On") == 0)
        {
            Ombrellone.SetActive(false);
        }
        else if (game.active && stringa2.CompareTo("Ombrellone Off") == 0)
        {
            Ombrellone.SetActive(true);
        }
    }

    public void VistaFrontale()
    {
             Anim.SetTrigger(TransizioneFront);
    }

    public void VistaAlto()
    {
            Anim.SetTrigger(TransizioneAlto);
    }

    public void AbbassaTavolo()
    {
            Anim.SetTrigger(TavoloSiAbbassa);
    }

    public void AlzaTavolo()
    {
            Anim.SetTrigger(TavoloSiAlza);
    }

    public void RuotaTavolo()
    {
            Anim.SetTrigger(TavoloRuota);
    }

    public void SetText(string text)
    {
        if (SetTextIsClicked && game.active) //cambiato//
        {
            Text txt = transform.Find("Text").GetComponent<Text>();
            txt.text = text;
            SetTextIsClicked = false;
        }
        else if(!SetTextIsClicked && game.active)
        {
            Text txt = transform.Find("Text").GetComponent<Text>();
            text = "Ombrellone Off";
            txt.text = text;
            SetTextIsClicked = true;
        }
        else if(SetTextIsClicked && !game.active)
        {
            Text txt = transform.Find("Text").GetComponent<Text>();
            txt.text = text;
            SetTextIsClicked = false;
        }
        else if(!SetTextIsClicked && !game.active)
        {
            Text txt = transform.Find("Text").GetComponent<Text>();
            text = "Ombrellone Off";
            txt.text = text;
            SetTextIsClicked = true;
        }
    }

    public void SetTextScala(string text)
    {
        if (SetTextScalaIsClicked)
        {
            Text txt = transform.Find("Text").GetComponent<Text>();
            txt.text = text;
            SetTextScalaIsClicked = false;
        }
        else
        {
            Text txt = transform.Find("Text").GetComponent<Text>();
            text = "Scala 1:10";
            txt.text = text;
            SetTextScalaIsClicked = true;
        }
    }

    public void ToggleVisibility()
    {
        if (Ombrellone.active)
        {
            Ombrellone.SetActive(false);
            OmbrelloneIsOff = true;
        }
        else if (!game.active && OmbrelloneIsOff) //cambiato//
        {
            Ombrellone_Static.SetActive(true);
            OmbrelloneIsOff = false;
        }
        else if (!game.active && !OmbrelloneIsOff)
        {
            Ombrellone_Static.SetActive(false);
            OmbrelloneIsOff = true;
        }
        else
        {
            Ombrellone.SetActive(true);
            OmbrelloneIsOff = false;
        }

    }

    public void SetRendering() //apre e spegne la luce //
    {
        if (SetRenderingIsClicked && !OmbrelloneIsOff )
        {
            luceombrellone.EnableKeyword("_EMISSION");
            SetRenderingIsClicked = false;
            light.SetActive(true);
        }
        else
        {
            luceombrellone.DisableKeyword("_EMISSION");
            SetRenderingIsClicked = true;
            light.SetActive(false);
        }
    }
    public void SetTextRendering(string text) //setta il testo del pulsante luce on - luce off //
    {
        if (SetTextRenderingIsClicked && Ombrellone.active)
        {
            Text txt = transform.Find("Text").GetComponent<Text>();
            txt.text = text;
            SetTextRenderingIsClicked = false;
        }
        else if (!SetTextRenderingIsClicked && Ombrellone.active)
        {
            Text txt = transform.Find("Text").GetComponent<Text>();
            text = "Luce On";
            txt.text = text;
            SetTextRenderingIsClicked = true;
        }
        else if (!Ombrellone.active)
        {
            Text txt = transform.Find("Text").GetComponent<Text>();
            text = "Luce On";
            txt.text = text;
            SetTextRenderingIsClicked = true;
        }
        else
        {
            Text txt = transform.Find("Text").GetComponent<Text>();
            text = "Luce On";
            txt.text = text;
            SetTextRenderingIsClicked = true;
        }
    }

    public void SetScale()
    {
        if (SetScaleIsClicked)
        {
            DaScalare.SetActive(true);
            game.SetActive(false);
            DaScalare.transform.localScale = new Vector3(2, 2, 2);
            SetScaleIsClicked = false;
            if (OmbrelloneIsOff)
            {
                Ombrellone_Static.SetActive(false);
            }
            else if (!OmbrelloneIsOff)
            {
                Ombrellone_Static.SetActive(true);
            }
        }
        else
        {
            DaScalare.SetActive(false);
            SetScaleIsClicked = true;
            game.SetActive(true);
        }
    }

    public void setButtonScale()
    {
        if (SetScaleIsClicked)
        {
            buttonvistafrontale.SetActive(false);
            buttonvistasuperiore.SetActive(false);
            buttonsolleva.SetActive(false);
            buttonabbassa.SetActive(false);
            buttonruota.SetActive(false);
            buttonluce.SetActive(false);
        }
        else
        {
            buttonvistafrontale.SetActive(true);
            buttonvistasuperiore.SetActive(true);
            buttonsolleva.SetActive(true);
            buttonabbassa.SetActive(true);
            buttonruota.SetActive(true);
            buttonluce.SetActive(true);
        }
            
    }
}
