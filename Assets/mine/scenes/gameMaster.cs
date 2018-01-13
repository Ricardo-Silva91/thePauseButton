using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameMaster : MonoBehaviour
{

    public AudioClip[] tracks;
    public List<string> tracks_path;
    public GameObject[] record_players;
    public List<int> usedTracks;
    public GameObject player;
    public GameObject pause_menu;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController playerScript;
    public GameObject canvas;

    public bool gamePaused = false;
    public bool songsDone;

    public string[] songList = { "15 min till it kicks in", "acid tripping monk", "ant brain", "ant strength", "apple a day", "apples", "artificial indians", "back to the new school", "bad pill", "bavelier's dogma", "beach", "becoming funcrusher plus", "beetle royale", "binary background", "bits", "bloc mine cover", "blue fanta", "blue match promise", "bone marrow monkey", "booklet for life", "boots", "born to be a skit", "brazillian voudou", "breath", "brocoli", "camomile hangover", "cartoons for adults", "clone", "cloud mask", "coil", "colokia servo", "coma cacera", "compasse", "cows", "curb the friction", "cyber absinthe", "cyber bully", "cybernetic sad thief", "day 2 day", "death is briliant", "downer carnival", "dry eyes", "dry grass", "duk travesi", "easy fingers", "empty schoolbus", "empty space", "end of adz", "ethereal funk", "first flower", "first spiral", "fish plus hook", "footprints", "fragmented anime", "fresh brain, new brain", "fresh wild bass", "frogs", "fruit loops", "furrets", "gears", "glass beach", "golden scrap metal", "grammas pills and apple juice", "grass in a sand cup", "green lab mice", "green waterskin", "grim's vacation", "hat with a feather", "homeless freelancer", "how to see colors", "ice pyramid", "inside cicada", "joji sacrifice", "last cigarrette", "lighter", "like magic markers", "lima palomo", "lime green crytal", "lime white tablet", "lime", "liquid nitrogen flowers", "lost freequencies", "low maintenance", "macalania revisited", "march", "melody missconception", "minefield garden", "mist", "mobile mandragora", "moths", "mouse", "natural talent", "neon puddle", "neon virus", "never ending fall", "nipo sorrow", "nobody said goodnight", "normal living", "northen summertime", "not music", "not smooth, but charming", "nujabes comatose", "nuns", "OD cocktail recipe", "only a few can", "operation paper clip", "opium emporium", "pescription candy", "philter workout", "pill 4 apathy", "popular emo vs happy emo", "purple punk drink", "rabbits", "radimometry", "rain is free", "rattlesnake pie", "real drugs need prescription", "red sprinkles", "sake party", "satir colera", "schizo redneck", "seals", "second option", "seethrough green flea", "shore", "sit up", "skavet politika", "skip trance", "slave songs", "slowly losing humanity", "slum socialite", "small gift", "smiling man march", "smooth gangster", "soft break", "solidus petal", "soviet tryout", "space plantation", "space travel slowly", "speech therapy", "static blue and grey", "steping studder", "still got it", "stolen pill chemistry", "stop helping the handicap", "strange frequencies", "suicide by scissors", "take out the brain", "tegrena brolika", "that j dilla character", "the golden raft", "the green people", "the tribe konducta", "turtle", "underwater cave", "underwater wind", "unsquaring", "vitreo psycosis", "wala tepida", "waves", "weak solos suffer", "wingless", "yander", "yann tiersen on lean", "yellow helicopter", "yet to be seen" };

    // Use this for initialization
    void Start ()
    {
        Debug.Log("1 " + Time.realtimeSinceStartup);
        songsDone = false;
        

    }

    public void ToggleMenu()
    {
        playerScript.enabled = !playerScript.enabled;
        gamePaused = !gamePaused;
        //pause_menu.SetActive(!pause_menu.activeSelf);
        canvas.SetActive(!canvas.activeSelf);
    }

    // Update is called once per frame
    void Update()
    {
        if (songsDone == false && this.GetComponent<god_world_maker>().world_done == true)
        {
            canvas = GameObject.Find("Canvas");
            player = GameObject.Find("Player");
            //pause_menu = GameObject.Find("Pause_menu");
            playerScript = player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
            //pause_menu.SetActive(false);

            tracks_path = new List<string>();
            record_players = GameObject.FindGameObjectsWithTag("record_player");

            Debug.Log("2 " + Time.realtimeSinceStartup + "\n" + Application.dataPath);

            /*
            System.IO.FileInfo[] fileInfo = new System.IO.DirectoryInfo(Application.dataPath + "/Resources/sounds").GetFiles("*.*", System.IO.SearchOption.AllDirectories);

            int count_mp = 0;
            string t = "{";

            foreach (System.IO.FileInfo file in fileInfo)
            {

                // file extension check
                if (file.Extension == ".mp3")
                {
                    count_mp++;
                    tracks_path.Add(System.IO.Path.GetFileNameWithoutExtension(file.ToString()));
                    t += "\"" + System.IO.Path.GetFileNameWithoutExtension(file.ToString()) + "\"" + ",";
                }
            }


            Debug.Log(t);
            */
            

            foreach (GameObject record in record_players)
            {
                int trackToPlay = Random.Range(0, songList.Length - 1);
                //int trackToPlay = Random.Range(0, tracks_path.Count - 1);
                //int trackToPlay = Random.Range(0, Resources.FindObjectsOfTypeAll(typeof(AudioClip)).Length - 1);
                while (usedTracks.Contains(trackToPlay) == true) { trackToPlay = Random.Range(0, songList.Length - 1); }
                //while (usedTracks.Contains(trackToPlay) == true) { trackToPlay = Random.Range(0, tracks_path.Count - 1); }
                //while (usedTracks.Contains(trackToPlay) == true) { trackToPlay = Random.Range(0, Resources.FindObjectsOfTypeAll(typeof(AudioClip)).Length - 1); }

                usedTracks.Add(trackToPlay);

                record.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("sounds/" + songList[trackToPlay]);
                //record.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("sounds/" + tracks_path[trackToPlay]);
                //record.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("sounds/" + Resources.FindObjectsOfTypeAll(typeof(AudioClip))[1].name);
                record.transform.parent.transform.parent.GetComponent<interactable>().touch();
            }
            
            songsDone = true;

            Debug.Log("3 " + Time.realtimeSinceStartup);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //ToggleMenu();
        }

    }
}
