using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class ModeSwitch : MonoBehaviour
{
    private KeywordRecognizer keywordRecogniser;
    private Dictionary<string, System.Action> actions = new Dictionary<string, System.Action>();

    public AudioClip CameraModeAudio;
    public AudioClip EnvironmentModeAudio;
    public AudioClip GodModeAudio;

    private static bool CameraModeActive = true;
    private static bool EnvironmentModeActive = false;
    private static bool GodModeActive = false;
    public AudioSource audioSource;

    public GameObject CameraModeHud;
    public GameObject EnvironmentModeHud;
    public GameObject GodModeHud;

    public GameObject TreePrefab;
    public GameObject CastlePrefab;
    public GameObject CactusPrefab;
    public GameObject MountainPrefab;
    public GameObject FlowerPrefab;
    public GameObject IceMountainPrefab;
    public GameObject PalmTreePrefab;
    public GameObject PyramidPrefab;
    public GameObject RocksPrefab;
    public GameObject SnowyTreePrefab;
    public GameObject SwampPrefab;
    public GameObject TownPrefab;
    public GameObject VillagePrefab;
    public GameObject HumanPrefab;

    public GameObject Meteor;
    public GameObject Firebolt;
    public GameObject Tornado;
    public GameObject EldritchHorror;

    

    public Animator EnvMenuAnim;
    


    // Start is called before the first frame update
    void Start()
    {
        EnvMenuAnim.enabled = false;
        
        Debug.Log("Script active");
        audioSource = gameObject.GetComponent<AudioSource>();
        actions.Add("Activate Camera Mode", CameraMode);
        actions.Add("Activate Environment Mode", EnvironmentMode);
        actions.Add("Activate God Mode", GodMode);
        actions.Add("Spawn Tree Here", SpawnTree);
        actions.Add("Spawn Castle Here", SpawnCastle);
        actions.Add("Spawn Pyramid Here", SpawnPyramid);
        actions.Add("Spawn Cactus Here", SpawnCactus);
        actions.Add("Spawn Mountain Here", SpawnMountain);
        actions.Add("Spawn Flower Here", SpawnFlower);
        actions.Add("Spawn Ice Mountain Here", SpawnIceMountain);
        actions.Add("Spawn Palm Tree Here", SpawnPalmTree);
        actions.Add("Spawn Rocks Here", SpawnRocks);
        actions.Add("Spawn Snowy Trees Here", SpawnSnowyTrees);
        actions.Add("Spawn Swamp Here", SpawnSwamp);
        actions.Add("Spawn Town Here", SpawnTown);
        actions.Add("Spawn Village Here", SpawnVillage);
        actions.Add("Spawn Human Here", SpawnHuman);
        actions.Add("Spawn Meteor Here", SpawnMeteor);
        actions.Add("Spawn Fire Here", SpawnFire);
        actions.Add("Spawn Tornado Here", SpawnTornado);
        actions.Add("Spawn Eldritch Horror", SpawnHorror);


        keywordRecogniser = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecogniser.OnPhraseRecognized += RecognisedSpeech;
        keywordRecogniser.Start();


        EnvironmentModeHud.SetActive(false);
        GodModeHud.SetActive(false);
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
        CameraModeHud.SetActive(true);
        EnvironmentModeHud.SetActive(false);
        GodModeHud.SetActive(false);

        CameraModeActive = true;
        EnvironmentModeActive = false;
        GodModeActive = false;
        HideMenu();

        
        




    }
    private void EnvironmentMode()
    {
        Debug.Log("Activating Environment Mode");
        audioSource.PlayOneShot(EnvironmentModeAudio);
    
        CameraModeHud.SetActive(false);
        EnvironmentModeHud.SetActive(true);
        GodModeHud.SetActive(false);

        ShowMenu();

        EnvironmentModeActive = true;
        GodModeActive = false;
        CameraModeActive = false;


    }
    private void GodMode()
    {
        Debug.Log("Activating God Mode");
        audioSource.PlayOneShot(GodModeAudio);

        CameraModeHud.SetActive(false);
        EnvironmentModeHud.SetActive(false);
        GodModeHud.SetActive(true);

        HideMenu();

        GodModeActive = true;
        CameraModeActive = false;
        EnvironmentModeActive = false;
    }

    private void SpawnTree()
    {
        if (EnvironmentModeActive == true)
        {
            Debug.Log("Spawning Tree");
            Instantiate(TreePrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
        }
    }
    private void SpawnCastle()
    {
        if (EnvironmentModeActive == true)
        {
            Debug.Log("Spawning Castle");
            Instantiate(CastlePrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
        }
    }

    private void SpawnPyramid()
    {
        if (EnvironmentModeActive == true)
        {
            Debug.Log("Spawning Pyramid");
            Instantiate(PyramidPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
        }
    }


    private void SpawnCactus()
    {
        if (EnvironmentModeActive == true)
        {
            Debug.Log("Spawning Cactus");
            Instantiate(CactusPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
        }
    }
    private void SpawnMountain()
    {
        if (EnvironmentModeActive == true)
        {
            Debug.Log("Spawning Mountain");
            Instantiate(MountainPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
        }
    }
    private void SpawnFlower()
    {
        if (EnvironmentModeActive == true)
        {
            Debug.Log("Spawning Flower");
            Instantiate(FlowerPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
        }
    }
    private void SpawnIceMountain()
    {
        if (EnvironmentModeActive == true)
        {
            Debug.Log("Spawning Ice Mountain");
            Instantiate(IceMountainPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
        }
    }
    private void SpawnPalmTree()
    {
        if (EnvironmentModeActive == true)
        {
            Debug.Log("Spawning Tree");
            Instantiate(TreePrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
        }
    }
    private void SpawnRocks()
    {
        if (EnvironmentModeActive == true)
        {
            Debug.Log("Spawning Rocks");
            Instantiate(RocksPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
        }
    }
    private void SpawnSnowyTrees()
    {
        if (EnvironmentModeActive == true)
        {
            Debug.Log("Spawning Snowy Trees");
            Instantiate(SnowyTreePrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
        }
    }
    private void SpawnSwamp()
    {
        if (EnvironmentModeActive == true)
        {
            Debug.Log("Spawning Swamp");
            Instantiate(SwampPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
        }
    }
    private void SpawnTown()
    {
        if (EnvironmentModeActive == true)
        {
            Debug.Log("Spawning Town");
            Instantiate(TownPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
        }
    }
    private void SpawnVillage()
    {
        if (EnvironmentModeActive == true)
        {
            Debug.Log("Spawning Village");
            Instantiate(VillagePrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
        }
    }
    private void SpawnHuman()
    {
        if (EnvironmentModeActive == true)
        {
            Debug.Log("Spawning Human");
            Instantiate(HumanPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
        }
    }


    private void SpawnMeteor()
    {
        if (GodModeActive == true)
        {
            Debug.Log("Spawning Meteor");
            Instantiate(Meteor, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);


        }

    }


    private void SpawnFire()
    {
        if (GodModeActive == true)
        {
            Debug.Log("Spawning Fire");
            Instantiate(Firebolt, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);

        }

    }

    private void SpawnTornado()
    {
        if (GodModeActive == true)
        {
            Debug.Log("Spawning Tornado");
            Instantiate(Tornado, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);


        }


    }

    private void SpawnHorror()
    {
        if (GodModeActive == true)
        {
            Debug.Log("Spookums Intensifies");
            Instantiate(EldritchHorror, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);


        }


    }

    void Update()
    {
        
    }

    public void ShowMenu()
    {
        EnvMenuAnim.enabled = true;
        EnvMenuAnim.Play("EnvMenuSlide");
    }

    public void HideMenu()
    {
        
        EnvMenuAnim.Play("EnvMenuSlide 0");
    }
}


