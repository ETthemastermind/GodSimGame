using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Windows.Speech;
using UnityEngine.UI;

public class ActiveHex : MonoBehaviour
{
    private KeywordRecognizer keywordRecogniser;
    private Dictionary<string, System.Action> actions = new Dictionary<string, System.Action>();

    public GameObject Biome;

    public GameObject Default_Biome;
    public GameObject Swamp_Biome;
    public GameObject Water_Biome;
    public GameObject Mesa_Biome;
    public GameObject Ice_Biome;
    public GameObject Grass_Biome;
    public GameObject Hell_Biome;
    public GameObject Desert_Biome;

    private bool ChangeBiomeBool = false;

    public GameObject BiomeUI;
    public GameObject EnvUI;



    public Vector3 BiomeChangeOffset;
    // Start is called before the first frame update
    void Start() //make it so the biome resets back down if they player changes mode while the change biome is active

    {
        actions.Add("Change this biome to", ChangeBiome);
        actions.Add("Make this biome a", ChangeBiome);

        actions.Add("Swamp", Swamp);
        actions.Add("Water", Water);
        actions.Add("Mesa", Mesa);
        actions.Add("Ice", Ice);
        actions.Add("Grass", Grass);
        actions.Add("Hell", Hell);
        actions.Add("Desert", Desert);



        keywordRecogniser = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecogniser.OnPhraseRecognized += RecognisedSpeech;
        keywordRecogniser.Start();

        Biome = GameObject.FindGameObjectWithTag("PlaceHolderObject");

        Default_Biome = Biome.transform.GetChild(0).gameObject;
        Swamp_Biome = Biome.transform.GetChild(1).gameObject;
        Water_Biome = Biome.transform.GetChild(2).gameObject;
        Mesa_Biome = Biome.transform.GetChild(3).gameObject;
        Ice_Biome = Biome.transform.GetChild(4).gameObject;
        Grass_Biome = Biome.transform.GetChild(5).gameObject;
        Hell_Biome = Biome.transform.GetChild(6).gameObject;
        Desert_Biome = Biome.transform.GetChild(7).gameObject;

    }

    private void RecognisedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        if (ModeSwitch.EnvironmentModeActive == false & ChangeBiomeBool == true)
        {
            Biome.transform.position = new Vector3(Biome.transform.position.x, Biome.transform.position.y - 0.5f, Biome.transform.position.z);
            ChangeBiomeBool = false;
            BiomeUI.SetActive(false);

        }
        
        
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(gameObject.name + "Active Hex");
        Biome = other.gameObject;

        Default_Biome = Biome.transform.GetChild(0).gameObject;
        Swamp_Biome = Biome.transform.GetChild(1).gameObject;
        Water_Biome = Biome.transform.GetChild(2).gameObject;
        Mesa_Biome = Biome.transform.GetChild(3).gameObject;
        Ice_Biome = Biome.transform.GetChild(4).gameObject;
        Grass_Biome = Biome.transform.GetChild(5).gameObject;
        Hell_Biome = Biome.transform.GetChild(6).gameObject;
        Desert_Biome = Biome.transform.GetChild(7).gameObject;

    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(gameObject.name + "Inactive Hex");
        if (ChangeBiomeBool == true)
        {
            Biome.transform.position = new Vector3(Biome.transform.position.x, Biome.transform.position.y - 0.5f, Biome.transform.position.z);
            ChangeBiomeBool = false;
        }
        
        Biome = GameObject.FindGameObjectWithTag("PlaceHolderObject");

        Default_Biome = Biome.transform.GetChild(0).gameObject;
        Swamp_Biome = Biome.transform.GetChild(1).gameObject;
        Water_Biome = Biome.transform.GetChild(2).gameObject;
        Mesa_Biome = Biome.transform.GetChild(3).gameObject;
        Ice_Biome = Biome.transform.GetChild(4).gameObject;
        Grass_Biome = Biome.transform.GetChild(5).gameObject;
        Hell_Biome = Biome.transform.GetChild(6).gameObject;
        Desert_Biome = Biome.transform.GetChild(7).gameObject;

    }

    public void ChangeBiome()
    {
        if (ModeSwitch.EnvironmentModeActive == true & ChangeBiomeBool == false)
        {
            Debug.Log("Changing Biome");
            ChangeBiomeBool = true;

            BiomeUI.SetActive(true);
            EnvUI.SetActive(false);

            Biome.transform.position = new Vector3(Biome.transform.position.x, Biome.transform.position.y + 0.5f, Biome.transform.position.z);

        }
        
        

    }

    public void Swamp()
    {
        if (ChangeBiomeBool == true & ModeSwitch.EnvironmentModeActive)
        {
            Debug.Log("Changing biome to Swamp");
            Default_Biome.SetActive(false);
            Swamp_Biome.SetActive(true);
            Water_Biome.SetActive(false);
            Mesa_Biome.SetActive(false);
            Ice_Biome.SetActive(false);
            Grass_Biome.SetActive(false);
            Hell_Biome.SetActive(false);
            Desert_Biome.SetActive(false);
            Biome.transform.position = new Vector3(Biome.transform.position.x, Biome.transform.position.y - 0.5f, Biome.transform.position.z);

            BiomeUI.SetActive(false);
            EnvUI.SetActive(true);

            ChangeBiomeBool = false;

        }
        
    }

    public void Water()
    {
        if (ChangeBiomeBool == true & ModeSwitch.EnvironmentModeActive)
        {
            Debug.Log("Changing biome to true");
            Default_Biome.SetActive(false);
            Swamp_Biome.SetActive(false);
            Water_Biome.SetActive(true);
            Mesa_Biome.SetActive(false);
            Ice_Biome.SetActive(false);
            Grass_Biome.SetActive(false);
            Hell_Biome.SetActive(false);
            Desert_Biome.SetActive(false);
            Biome.transform.position = new Vector3(Biome.transform.position.x, Biome.transform.position.y - 0.5f, Biome.transform.position.z);

            BiomeUI.SetActive(false);
            EnvUI.SetActive(true);

            ChangeBiomeBool = false;
        }
        
    }

    public void Mesa()
    {
        if (ChangeBiomeBool == true & ModeSwitch.EnvironmentModeActive)
        {
            Debug.Log("Changing biome to Mesa");
            Default_Biome.SetActive(false);
            Swamp_Biome.SetActive(false);
            Water_Biome.SetActive(false);
            Mesa_Biome.SetActive(true);
            Ice_Biome.SetActive(false);
            Grass_Biome.SetActive(false);
            Hell_Biome.SetActive(false);
            Desert_Biome.SetActive(false);
            Biome.transform.position = new Vector3(Biome.transform.position.x, Biome.transform.position.y - 0.5f, Biome.transform.position.z);

            BiomeUI.SetActive(false);
            EnvUI.SetActive(true);

            ChangeBiomeBool = false;

        }
        
    }

    public void Ice()
    {
        if (ChangeBiomeBool == true & ModeSwitch.EnvironmentModeActive)
        {
            Debug.Log("Changing biome to Ice");
            Default_Biome.SetActive(false);
            Swamp_Biome.SetActive(false);
            Water_Biome.SetActive(false);
            Mesa_Biome.SetActive(false);
            Ice_Biome.SetActive(true);
            Grass_Biome.SetActive(false);
            Hell_Biome.SetActive(false);
            Desert_Biome.SetActive(false);
            Biome.transform.position = new Vector3(Biome.transform.position.x, Biome.transform.position.y - 0.5f, Biome.transform.position.z);

            BiomeUI.SetActive(false);
            EnvUI.SetActive(true);

            ChangeBiomeBool = false;

        }
        
    }

    public void Grass()
    {
        if (ChangeBiomeBool == true & ModeSwitch.EnvironmentModeActive)
        {
            Debug.Log("Changing biome to Grass");
            Default_Biome.SetActive(false);
            Swamp_Biome.SetActive(false);
            Water_Biome.SetActive(false);
            Mesa_Biome.SetActive(false);
            Ice_Biome.SetActive(false);
            Grass_Biome.SetActive(true);
            Hell_Biome.SetActive(false);
            Desert_Biome.SetActive(false);
            Biome.transform.position = new Vector3(Biome.transform.position.x, Biome.transform.position.y - 0.5f, Biome.transform.position.z);

            BiomeUI.SetActive(false);
            EnvUI.SetActive(true);

            ChangeBiomeBool = false;

        }
        
    }

    public void Hell()
    {
        if (ChangeBiomeBool == true & ModeSwitch.EnvironmentModeActive)
        {
            Debug.Log("Changing biome to Hell");
            Default_Biome.SetActive(false);
            Swamp_Biome.SetActive(false);
            Water_Biome.SetActive(false);
            Mesa_Biome.SetActive(false);
            Ice_Biome.SetActive(false);
            Grass_Biome.SetActive(false);
            Hell_Biome.SetActive(true);
            Desert_Biome.SetActive(false);
            Biome.transform.position = new Vector3(Biome.transform.position.x, Biome.transform.position.y - 0.5f, Biome.transform.position.z);

            BiomeUI.SetActive(false);
            EnvUI.SetActive(true);

            ChangeBiomeBool = false;


        }
        
    }

    public void Desert()
    {
        if (ChangeBiomeBool == true & ModeSwitch.EnvironmentModeActive)
        {
            Debug.Log("Changing biome to Desert");
            Default_Biome.SetActive(false);
            Swamp_Biome.SetActive(false);
            Water_Biome.SetActive(false);
            Mesa_Biome.SetActive(false);
            Ice_Biome.SetActive(false);
            Grass_Biome.SetActive(false);
            Hell_Biome.SetActive(false);
            Desert_Biome.SetActive(true);
            Biome.transform.position = new Vector3(Biome.transform.position.x, Biome.transform.position.y - 0.5f, Biome.transform.position.z);

            BiomeUI.SetActive(false);
            EnvUI.SetActive(true);

            ChangeBiomeBool = false;


        }
        
    }

}
