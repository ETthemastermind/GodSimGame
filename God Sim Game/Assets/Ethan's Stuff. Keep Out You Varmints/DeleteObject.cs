using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Windows.Speech;

public class DeleteObject : MonoBehaviour
{

    private KeywordRecognizer keywordRecogniser;
    private Dictionary<string, System.Action> actions = new Dictionary<string, System.Action>();

    private bool DeleteBool = false;
    private GameObject[] ObjectToDelete;

    public Collider[] hitColliders;


    // Start is called before the first frame update
    void Start()
    {
        actions.Add("Delete", Delete);
        


        keywordRecogniser = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecogniser.OnPhraseRecognized += RecognisedSpeech;
        keywordRecogniser.Start();
    }

    // Update is called once per frame
    void Update()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(gameObject.transform.position, 0.1f);

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1f);

        Debug.Log(Physics.OverlapSphere(gameObject.transform.position, 1f));
      
        
        
    }

    

    private void RecognisedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    public void Delete()
    {

        DeleteBool = true;
        

    }
}
