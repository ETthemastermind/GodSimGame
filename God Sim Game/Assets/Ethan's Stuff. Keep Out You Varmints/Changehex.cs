using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Windows.Speech;

public class Changehex : MonoBehaviour
{
    private KeywordRecognizer keywordRecogniser;
    private Dictionary<string, System.Action> actions = new Dictionary<string, System.Action>();

    private bool BiomeChanged = false;

    public GameObject DefaultHex;
    public GameObject SwampHex;
    public GameObject WaterHex;
    public GameObject MesaHex;
    public GameObject IceHex;
    public GameObject GrassHex;
    public GameObject HellHex;
    public GameObject DesertHex;


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

    public void Swamp()
    {
        Debug.Log("Changing biome to Swamp");
        DefaultHex.SetActive(false);
        SwampHex.SetActive(true);
        WaterHex.SetActive(false);
        MesaHex.SetActive(false);
        IceHex.SetActive(false);
        GrassHex.SetActive(false);
        HellHex.SetActive(false);
        DesertHex.SetActive(false);
    }

    public void Water()
    {
        Debug.Log("Changing biome to Water");
        DefaultHex.SetActive(false);
        SwampHex.SetActive(false);
        WaterHex.SetActive(true);
        MesaHex.SetActive(false);
        IceHex.SetActive(false);
        GrassHex.SetActive(false);
        HellHex.SetActive(false);
        DesertHex.SetActive(false);

    }
    public void Mesa()
    {
        Debug.Log("Changing biome to Mesa");
        DefaultHex.SetActive(false);
        SwampHex.SetActive(false);
        WaterHex.SetActive(false);
        MesaHex.SetActive(true);
        IceHex.SetActive(false);
        GrassHex.SetActive(false);
        HellHex.SetActive(false);
        DesertHex.SetActive(false);


    }
    public void Ice()
    {
        Debug.Log("Changing biome to Ice");
        DefaultHex.SetActive(false);
        SwampHex.SetActive(false);
        WaterHex.SetActive(false);
        MesaHex.SetActive(false);
        IceHex.SetActive(true);
        GrassHex.SetActive(false);
        HellHex.SetActive(false);
        DesertHex.SetActive(false);

    }
    public void Hell()
    {
        Debug.Log("Changing biome to Hell");
        DefaultHex.SetActive(false);
        SwampHex.SetActive(false);
        WaterHex.SetActive(false);
        MesaHex.SetActive(false);
        IceHex.SetActive(false);
        GrassHex.SetActive(false);
        HellHex.SetActive(true);
        DesertHex.SetActive(false);


    }
    public void Grass()
    {
        Debug.Log("Changing biome to Grass");
        DefaultHex.SetActive(false);
        SwampHex.SetActive(false);
        WaterHex.SetActive(false);
        MesaHex.SetActive(false);
        IceHex.SetActive(false);
        GrassHex.SetActive(true);
        HellHex.SetActive(false);
        DesertHex.SetActive(false);

    }
    public void Desert()
    {
        Debug.Log("Changing biome to Desert");
        DefaultHex.SetActive(false);
        SwampHex.SetActive(false);
        WaterHex.SetActive(false);
        MesaHex.SetActive(false);
        IceHex.SetActive(false);
        GrassHex.SetActive(false);
        HellHex.SetActive(false);
        DesertHex.SetActive(true);


    }
}
