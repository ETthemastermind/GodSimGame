using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Windows.Speech;

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
    // Start is called before the first frame update
    void Start()
    {
        actions.Add("Change this biome to Swamp", Swamp);
        actions.Add("Change this biome to Water", Water);
        actions.Add("Change this biome to Mesa", Mesa);
        actions.Add("Change this biome to Ice", Ice);
        actions.Add("Change this biome to Grass", Grass);
        actions.Add("Change this biome to Hell", Hell);
        actions.Add("Change this biome to Desert", Desert);



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
        
    }

    private void OnTriggerEnter(Collider other)
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

    public void Swamp()
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
    }

    public void Water()
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
    }

    public void Mesa()
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
    }

    public void Ice()
    {
        Debug.Log("Changing biome to Swamp");
        Default_Biome.SetActive(false);
        Swamp_Biome.SetActive(false);
        Water_Biome.SetActive(false);
        Mesa_Biome.SetActive(false);
        Ice_Biome.SetActive(true);
        Grass_Biome.SetActive(false);
        Hell_Biome.SetActive(false);
        Desert_Biome.SetActive(false);
    }

    public void Grass()
    {
        Debug.Log("Changing biome to Swamp");
        Default_Biome.SetActive(false);
        Swamp_Biome.SetActive(false);
        Water_Biome.SetActive(false);
        Mesa_Biome.SetActive(false);
        Ice_Biome.SetActive(false);
        Grass_Biome.SetActive(true);
        Hell_Biome.SetActive(false);
        Desert_Biome.SetActive(false);
    }

    public void Hell()
    {
        Debug.Log("Changing biome to Swamp");
        Default_Biome.SetActive(false);
        Swamp_Biome.SetActive(false);
        Water_Biome.SetActive(false);
        Mesa_Biome.SetActive(false);
        Ice_Biome.SetActive(false);
        Grass_Biome.SetActive(false);
        Hell_Biome.SetActive(true);
        Desert_Biome.SetActive(false);
    }

    public void Desert()
    {
        Debug.Log("Changing biome to Swamp");
        Default_Biome.SetActive(false);
        Swamp_Biome.SetActive(false);
        Water_Biome.SetActive(false);
        Mesa_Biome.SetActive(false);
        Ice_Biome.SetActive(false);
        Grass_Biome.SetActive(false);
        Hell_Biome.SetActive(false);
        Desert_Biome.SetActive(true);
    }

}
