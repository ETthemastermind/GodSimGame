using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using UnityEngine.UI;
using TMPro;



public class VoiceTest : MonoBehaviour
{
    private KeywordRecognizer keywordRecogniser;
    private Dictionary<string, System.Action> actions = new Dictionary<string, System.Action>();

    public AudioClip CameraModeAudio;
    public AudioClip EnvironmentModeAudio;
    public AudioClip GodModeAudio;
    public AudioSource audioSource;

    public TextMeshProUGUI CameraModeHud;
    public TextMeshProUGUI EnvironmentModeHud;
    public TextMeshProUGUI GodModeHud;
    



    // Start is called before the first frame update
    void Start()
    {
        
        Debug.Log("Script active");
        audioSource = gameObject.GetComponent<AudioSource>();
        actions.Add("Activate Camera Mode", CameraMode);
        actions.Add("Activate Environment Mode", EnvironmentMode);
        actions.Add("Activate God Mode", GodMode);

        keywordRecogniser = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecogniser.OnPhraseRecognized += RecognisedSpeech;
        keywordRecogniser.Start();


        EnvironmentModeHud.enabled = false;
        GodModeHud.enabled = false;
    }

    // Update is called once per frame
    private void RecognisedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();



    }

    private void CameraMode()
    {
        Debug.Log("Activating Camera Mode");
        audioSource.PlayOneShot(CameraModeAudio);
        CameraModeHud.enabled = true;
        EnvironmentModeHud.enabled = false;
        GodModeHud.enabled = false;
  
    }
    private void EnvironmentMode()
    {
        Debug.Log("Activating Environment Mode");
        audioSource.PlayOneShot(EnvironmentModeAudio);
        CameraModeHud.enabled = false;
        EnvironmentModeHud.enabled = true;
        GodModeHud.enabled = false;

    }
    private void GodMode()
    {
        Debug.Log("Activating God Mode");
        audioSource.PlayOneShot(GodModeAudio);
        CameraModeHud.enabled = false;
        EnvironmentModeHud.enabled = false;
        GodModeHud.enabled = true;

    }
    void Update()
    {
        
    }
}
