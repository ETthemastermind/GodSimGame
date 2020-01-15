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

    public static bool CameraModeActive = false;
    public static bool EnvironmentModeActive = false;
    public static bool GodModeActive = true;
    public AudioSource audioSource;

    public GameObject CameraModeHud;
    public GameObject EnvironmentModeHud;
    public GameObject GodModeHud;

    private bool SpawnBool = false;
    private bool InterventionBool = false;

    public GameObject EnvGui;
    public GameObject GodGUI;
    public GameObject SpawnGui;
    public GameObject InterventionGUI;
    public GameObject Interventions;
    public GameObject GodSpawn;

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

    public GameObject SpawnLocation;

    
    

    
    


    // Start is called before the first frame update
    void Start()
    {
        
        
        Debug.Log("Script active");
        audioSource = gameObject.GetComponent<AudioSource>();
        actions.Add("Activate Camera Mode", CameraMode);
        actions.Add("Activate Environment Mode", EnvironmentMode);  //rework the spawning mechanic
        actions.Add("Activate God Mode", GodMode);

        actions.Add("Spawn", SpawnItem);
        actions.Add("Tree", SpawnTree);
        actions.Add("Castle", SpawnCastle);
        actions.Add("Pyramid", SpawnPyramid);
        actions.Add("Cactus", SpawnCactus);
        actions.Add("Mountain", SpawnMountain);
        actions.Add("Flower", SpawnFlower);
        actions.Add("Ice Mountain", SpawnIceMountain);
        actions.Add("Palm Tree", SpawnPalmTree);
        actions.Add("Rocks", SpawnRocks);
        actions.Add("Snowy Trees", SpawnSnowyTrees);
        actions.Add("Swamp Tendrils", SpawnSwamp);
        actions.Add("Town", SpawnTown);
        actions.Add("Village", SpawnVillage);
        actions.Add("Human", SpawnHuman);

        actions.Add("Meteor", SpawnMeteor);
        actions.Add("Fire", SpawnFire);
        actions.Add("Tornado", SpawnTornado);
        actions.Add("Horror", SpawnHorror);


        keywordRecogniser = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecogniser.OnPhraseRecognized += RecognisedSpeech;
        keywordRecogniser.Start();

        CameraModeHud.SetActive(false);
        EnvironmentModeHud.SetActive(false);
        GodModeHud.SetActive(true);

        EnvGui.SetActive(false);

        GodMode();
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

        EnvGui.SetActive(false);
        GodGUI.SetActive(false);
        SpawnGui.SetActive(false);
        InterventionGUI.SetActive(false);
        GodSpawn.SetActive(false);









    }
    private void EnvironmentMode()
    {
        Debug.Log("Activating Environment Mode");
        audioSource.PlayOneShot(EnvironmentModeAudio);
    
        CameraModeHud.SetActive(false);
        EnvironmentModeHud.SetActive(true);
        GodModeHud.SetActive(false);

        

        EnvironmentModeActive = true;
        GodModeActive = false;
        CameraModeActive = false;

        EnvGui.SetActive(true);
        GodGUI.SetActive(false);
        GodSpawn.SetActive(false);
        InterventionGUI.SetActive(false);



    }
    private void GodMode()
    {
        Debug.Log("Activating God Mode");
        audioSource.PlayOneShot(GodModeAudio);

        CameraModeHud.SetActive(false);
        EnvironmentModeHud.SetActive(false);
        GodModeHud.SetActive(true);
        

        GodModeActive = true;
        CameraModeActive = false;
        EnvironmentModeActive = false;

        EnvGui.SetActive(false);
        SpawnGui.SetActive(false);
        GodGUI.SetActive(true);
        GodSpawn.SetActive(true);
    }

    private void SpawnItem()
    {
        if (EnvironmentModeActive == true & SpawnBool == false)
        {
            SpawnBool = true;
            EnvGui.SetActive(false);
            SpawnGui.SetActive(true);


        }

        if (GodModeActive == true & InterventionBool == false)
        {
            InterventionBool = true;
            GodGUI.SetActive(true);
            GodSpawn.SetActive(false);
            InterventionGUI.SetActive(true);


        }


    }

    private void SpawnTree()
    {
        if (EnvironmentModeActive == true & SpawnBool == true)
        {
            Debug.Log("Spawning Tree");
            Instantiate(TreePrefab, new Vector3(SpawnLocation.transform.position.x, SpawnLocation.transform.position.y, SpawnLocation.transform.position.z), Quaternion.identity);
            SpawnBool = false;
            EnvGui.SetActive(true);
            SpawnGui.SetActive(false);
        }
    }
    private void SpawnCastle()
    {
        if (EnvironmentModeActive == true & SpawnBool == true)
        {
            Debug.Log("Spawning Castle");
            Instantiate(CastlePrefab, new Vector3(SpawnLocation.transform.position.x, SpawnLocation.transform.position.y, SpawnLocation.transform.position.z), Quaternion.identity);
            SpawnBool = false;

            EnvGui.SetActive(true);
            SpawnGui.SetActive(false);
        }
    }

    private void SpawnPyramid()
    {
        if (EnvironmentModeActive == true & SpawnBool == true)
        {
            Debug.Log("Spawning Pyramid");
            Instantiate(PyramidPrefab, new Vector3(SpawnLocation.transform.position.x, SpawnLocation.transform.position.y, SpawnLocation.transform.position.z), Quaternion.identity);
            SpawnBool = false;

            EnvGui.SetActive(true);
            SpawnGui.SetActive(false);
        }
    }


    private void SpawnCactus()
    {
        if (EnvironmentModeActive == true & SpawnBool == true)
        {
            Debug.Log("Spawning Cactus");
            Instantiate(CactusPrefab, new Vector3(SpawnLocation.transform.position.x, SpawnLocation.transform.position.y, SpawnLocation.transform.position.z), Quaternion.identity);
            SpawnBool = false;

            EnvGui.SetActive(true);
            SpawnGui.SetActive(false);
        }
    }
    private void SpawnMountain()
    {
        if (EnvironmentModeActive == true & SpawnBool == true)
        {
            Debug.Log("Spawning Mountain");
            Instantiate(MountainPrefab, new Vector3(SpawnLocation.transform.position.x, SpawnLocation.transform.position.y, SpawnLocation.transform.position.z), Quaternion.identity);
            SpawnBool = false;

            EnvGui.SetActive(true);
            SpawnGui.SetActive(false);
        }
    }
    private void SpawnFlower()
    {
        if (EnvironmentModeActive == true & SpawnBool == true)
        {
            Debug.Log("Spawning Flower");
            Instantiate(FlowerPrefab, new Vector3(SpawnLocation.transform.position.x, SpawnLocation.transform.position.y, SpawnLocation.transform.position.z), Quaternion.identity);
            SpawnBool = false;

            EnvGui.SetActive(true);
            SpawnGui.SetActive(false);
        }
    }
    private void SpawnIceMountain()
    {
        if (EnvironmentModeActive == true & SpawnBool == true)
        {
            Debug.Log("Spawning Ice Mountain");
            Instantiate(IceMountainPrefab, new Vector3(SpawnLocation.transform.position.x, SpawnLocation.transform.position.y, SpawnLocation.transform.position.z), Quaternion.identity);
            SpawnBool = false;

            EnvGui.SetActive(true);
            SpawnGui.SetActive(false);
        }
    }
    private void SpawnPalmTree()
    {
        if (EnvironmentModeActive == true & SpawnBool == true)
        {
            Debug.Log("Spawning Tree");
            Instantiate(TreePrefab, new Vector3(SpawnLocation.transform.position.x, SpawnLocation.transform.position.y, SpawnLocation.transform.position.z), Quaternion.identity);
            SpawnBool = false;

            EnvGui.SetActive(true);
            SpawnGui.SetActive(false);
        }
    }
    private void SpawnRocks()
    {
        if (EnvironmentModeActive == true & SpawnBool == true)
        {
            Debug.Log("Spawning Rocks");
            Instantiate(RocksPrefab, new Vector3(SpawnLocation.transform.position.x, SpawnLocation.transform.position.y, SpawnLocation.transform.position.z), Quaternion.identity);
            SpawnBool = false;

            EnvGui.SetActive(true);
            SpawnGui.SetActive(false);
        }
    }
    private void SpawnSnowyTrees()
    {
        if (EnvironmentModeActive == true & SpawnBool == true)
        {
            Debug.Log("Spawning Snowy Trees");
            Instantiate(SnowyTreePrefab, new Vector3(SpawnLocation.transform.position.x, SpawnLocation.transform.position.y, SpawnLocation.transform.position.z), Quaternion.identity);
            SpawnBool = false;

            EnvGui.SetActive(true);
            SpawnGui.SetActive(false);
        }
    }
    private void SpawnSwamp()
    {
        if (EnvironmentModeActive == true & SpawnBool == true)
        {
            Debug.Log("Spawning Swamp");
            Instantiate(SwampPrefab, new Vector3(SpawnLocation.transform.position.x, SpawnLocation.transform.position.y, SpawnLocation.transform.position.z), Quaternion.identity);
            SpawnBool = false;

            EnvGui.SetActive(true);
            SpawnGui.SetActive(false);
        }
    }
    private void SpawnTown()
    {
        if (EnvironmentModeActive == true & SpawnBool == true)
        {
            Debug.Log("Spawning Town");
            Instantiate(TownPrefab, new Vector3(SpawnLocation.transform.position.x, SpawnLocation.transform.position.y, SpawnLocation.transform.position.z), Quaternion.identity);
            SpawnBool = false;

            EnvGui.SetActive(true);
            SpawnGui.SetActive(false);
        }
    }
    private void SpawnVillage()
    {
        if (EnvironmentModeActive == true & SpawnBool == true)
        {
            Debug.Log("Spawning Village");
            Instantiate(VillagePrefab, new Vector3(SpawnLocation.transform.position.x, SpawnLocation.transform.position.y, SpawnLocation.transform.position.z), Quaternion.identity);
            SpawnBool = false;

            EnvGui.SetActive(true);
            SpawnGui.SetActive(false);
        }
    }
    private void SpawnHuman()
    {
        if (EnvironmentModeActive == true & SpawnBool == true)
        {
            Debug.Log("Spawning Human");
            Instantiate(HumanPrefab, new Vector3(SpawnLocation.transform.position.x, SpawnLocation.transform.position.y, SpawnLocation.transform.position.z), Quaternion.identity);
            SpawnBool = false;

            EnvGui.SetActive(true);
            SpawnGui.SetActive(false);
        }
    }


    private void SpawnMeteor()
    {
        if (GodModeActive == true)
        {
            Debug.Log("Spawning Meteor");
            Instantiate(Meteor, new Vector3(SpawnLocation.transform.position.x, SpawnLocation.transform.position.y, SpawnLocation.transform.position.z), Quaternion.identity);

            GodSpawn.SetActive(true);
            InterventionGUI.SetActive(false);

            InterventionBool = false;



        }

    }


    private void SpawnFire()
    {
        if (GodModeActive == true)
        {
            Debug.Log("Spawning Fire");
            Instantiate(Firebolt, new Vector3(SpawnLocation.transform.position.x, SpawnLocation.transform.position.y, SpawnLocation.transform.position.z), Quaternion.identity);
            GodSpawn.SetActive(true);
            InterventionGUI.SetActive(false);

            InterventionBool = false;
        }

    }

    private void SpawnTornado()
    {
        if (GodModeActive == true)
        {
            Debug.Log("Spawning Tornado");
            Instantiate(Tornado, new Vector3(SpawnLocation.transform.position.x, SpawnLocation.transform.position.y, SpawnLocation.transform.position.z), Quaternion.identity);
            GodSpawn.SetActive(true);
            InterventionGUI.SetActive(false);

            InterventionBool = false;

            
        }


    }

    private void SpawnHorror()
    {
        if (GodModeActive == true)
        {
            Debug.Log("Spookums Intensifies");
            Instantiate(EldritchHorror, new Vector3(SpawnLocation.transform.position.x, SpawnLocation.transform.position.y, SpawnLocation.transform.position.z), Quaternion.identity);
            GodSpawn.SetActive(true);
            InterventionGUI.SetActive(false);

            InterventionBool = false;


        }


    }

    void Update()
    {
        
    }

    
}


