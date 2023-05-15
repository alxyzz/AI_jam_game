using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static TimeTravelManager;
using Random = UnityEngine.Random;

class TimeSpaceMap
{





}




public class TimeTravelManager : MonoBehaviour
{


    List<List<TimeSpaceTile>> worldMap = new List<List<TimeSpaceTile>>();
    [SerializeField] int xSize = 15;
    [SerializeField] int ySize = 15;

    [SerializeReference] NetworkManager netman;

    int xLoc = 0;
    int yLoc = 0;

    bool canMove;

    [SerializeReference] TextMeshProUGUI txt_Historical;
    [SerializeReference] TextMeshProUGUI txt_Description;



    [SerializeReference] TextMeshProUGUI txt_ManManObjectTimeDimension;
    [SerializeReference] TextMeshProUGUI txt_NatureDimension;
    [SerializeReference] TextMeshProUGUI txt_EnvironmentalMoisture;
    [SerializeReference] TextMeshProUGUI txt_EnvironmentalTemperature;
    [SerializeReference] TextMeshProUGUI txt_heightDimension;

    Image img_Current;
    Sprite sprite_current;




    #region Defines
   


    public enum ManManObjectTimeDimension
    {
        Primeval,
        Neolithic,
        Medieval,
        Modern,
        Futuristic
    }
    public enum heightDimension
    {
        Mountain,
        Highland,
        Cliffy,
        Flat,
        Lowland,
        OceanLevel,
        Underground
    }

    public enum NatureDimension
    {

        Polluted,
        Industrial,
        Overgrown,
        Barren
    }

    public enum EnvironmentalMoisture
    {
        Dry,
        Moist,
        Dank,
        Wet
    }


    public enum EnvironmentalTemperature
    {

        Frozen,
        Cool,
        Chilly,
        Temperate,
        Sweltering,
        Hot,
        Infernal

    }




    #endregion


    void Start()
    {
        GenerateTileMap();



    }


    private List<List<TimeSpaceTile>> GenerateTileMap()
    {

        List<List<TimeSpaceTile>> newMap = new List<List<TimeSpaceTile>>();

        int[] numbers = Enumerable.Range(0, 7 - 0 + 1).ToArray(); //we will use this 

        // Sort the numbers in descending order
        System.Array.Sort(numbers);
        System.Array.Reverse(numbers);


        int startRange = 0;
        int endRange = 7;
        int biasStart = 0;
        int biasEnd = 0;

        for (int i = 0; i < xSize; i++)
        {
            List<TimeSpaceTile> strip = new List<TimeSpaceTile>(); // strips of ySize tiles, xSize wide. initialized. Voila... 
            newMap.Add(strip);
            for (int b = 0; b < ySize; b++)
            {
                TimeSpaceTile g = new TimeSpaceTile(false, getNewHeight());
                newMap[i].Add(g);
            }
        }

        int getNewHeight()
        {
            if (Random.Range(0, 5) == 4)
            {
                biasStart += 1;
            }
            if (Random.Range(0, 5) == 5)
            {
                biasStart -= 1;
            }

            if (Random.Range(0, 5) == 4)
            {
                biasEnd += 1;
            }
            if (Random.Range(0, 5) == 5)
            {
                biasEnd -= 1;
            }

            return Random.Range(Mathf.Clamp((startRange + biasStart), 0, 7), Mathf.Clamp((endRange + biasEnd), 0, 7));
        }

        return newMap;
    }

    void RefreshDisplay()
    {






    }


    void DoImageQuery(string description)
    {


    }

    void DoDescriptionQuery(string description)
    {


        txt_Description.text = "foo";

    }


    void DoHistoricalQuery(string description)
    {


        txt_Historical.text = "foo";
    }










    void MoveWest()
    {
        xLoc = Mathf.Clamp(xLoc + 1, 0, xSize);
        canMove = false;

        RefreshDisplay();

    }


    void MoveEast()
    {
        xLoc = Mathf.Clamp(xLoc - 1, 0, xSize);
        canMove = false;
        RefreshDisplay();

    }
    void MoveSouth()
    {
        xLoc = Mathf.Clamp(xLoc + 1, 0, xSize);
        canMove = false;

        RefreshDisplay();

    }


    void MoveNorth()
    {
        xLoc = Mathf.Clamp(xLoc - 1, 0, xSize);
        canMove = false;

        RefreshDisplay();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            foreach (var item in worldMap)
            {
                Debug.Log(item[0].tilemapName);
            }
        }
        {

        }
    }

}


public class TimeSpaceTile
{
    public ManManObjectTimeDimension descArti;
    public NatureDimension descNature;
    public EnvironmentalMoisture descMoisture;
    public EnvironmentalTemperature descTemp;
    public heightDimension descHeight;

    public string tilemapName;

    public string description
    {
        get
        {
            string b = "";



            switch (descArti)
            {
                case ManManObjectTimeDimension.Primeval:
                    b += "Primeval ";
                    break;
                case ManManObjectTimeDimension.Neolithic:
                    b += "Neolithic ";
                    break;
                case ManManObjectTimeDimension.Medieval:
                    b += "Medieval ";
                    break;
                case ManManObjectTimeDimension.Modern:
                    b += "Modern ";
                    break;
                case ManManObjectTimeDimension.Futuristic:
                    b += "Futuristic ";
                    break;
                default:
                    b += "Primeval ";
                    break;
            }

            switch (descNature)
            {
                case NatureDimension.Polluted:
                    b += "Polluted ";
                    break;
                case NatureDimension.Industrial:
                    b += "Industrial ";
                    break;
                case NatureDimension.Overgrown:
                    b += "Overgrown ";
                    break;
                case NatureDimension.Barren:
                    b += "Barren ";
                    break;
                default:
                    b += "Primeval ";
                    break;
            }


            switch (descMoisture)
            {
                case EnvironmentalMoisture.Dry:
                    b += "Dry ";
                    break;
                case EnvironmentalMoisture.Moist:
                    b += "Moist ";
                    break;
                case EnvironmentalMoisture.Dank:
                    b += "Dank ";
                    break;
                case EnvironmentalMoisture.Wet:
                    b += "Wet ";
                    break;
                default:
                    break;
            }


            switch (descTemp)
            {
                case EnvironmentalTemperature.Frozen:
                    b += "Frozen ";
                    break;
                case EnvironmentalTemperature.Cool:
                    b += "Cool ";
                    break;
                case EnvironmentalTemperature.Chilly:
                    b += "Chilly ";
                    break;
                case EnvironmentalTemperature.Temperate:
                    b += "Temperate ";
                    break;
                case EnvironmentalTemperature.Sweltering:
                    b += "Sweltering ";
                    break;
                case EnvironmentalTemperature.Hot:
                    b += "Hot ";
                    break;
                case EnvironmentalTemperature.Infernal:
                    b += "Infernal ";
                    break;
                default:
                    b += "Primeval ";
                    break;
            }


            switch (descHeight)
            {
                case heightDimension.Mountain:
                    b += "Mountain ";
                    break;
                case heightDimension.Highland:
                    b += "Highland ";
                    break;
                case heightDimension.Cliffy:
                    b += "Cliffy ";
                    break;
                case heightDimension.Flat:
                    b += "Flat ";
                    break;
                case heightDimension.Lowland:
                    b += "Lowland ";
                    break;
                case heightDimension.OceanLevel:
                    b += "OceanLevel ";
                    break;
                case heightDimension.Underground:
                    b += "Underground ";
                    break;
                default:
                    b += "Primeval ";
                    break;
            }


            Debug.LogWarning("Generated string of descriptors => " + b);
            return b;
        }
    }

    public TimeSpaceTile(bool hasTreasure, int Height)
    {
        //we randomize all properties

        descArti = (ManManObjectTimeDimension)Random.Range(0, (int)ManManObjectTimeDimension.GetValues(typeof(ManManObjectTimeDimension)).Cast<ManManObjectTimeDimension>().Last());
        descNature = (NatureDimension)Random.Range(0, (int)NatureDimension.GetValues(typeof(NatureDimension)).Cast<NatureDimension>().Last()); ;
        descMoisture = (EnvironmentalMoisture)Random.Range(0, (int)EnvironmentalMoisture.GetValues(typeof(EnvironmentalMoisture)).Cast<EnvironmentalMoisture>().Last());
        descTemp = (EnvironmentalTemperature)Random.Range(0, (int)EnvironmentalTemperature.GetValues(typeof(EnvironmentalTemperature)).Cast<EnvironmentalTemperature>().Last());
        // descHeight = (heightDimension)Random.Range(0, (int)heightDimension.GetValues(typeof(heightDimension)).Cast<heightDimension>().Last());
        descHeight = (heightDimension)Height;

        Debug.Log("Randomized values to " + (int)descArti + " " + (int)descNature + (int)descMoisture + (int)descTemp + (int)descHeight);
        string alphanumericChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        for (int i = 0; i < 8; i++)
        {
            int randomIndex = Random.Range(0, alphanumericChars.Length);
            char randomChar = alphanumericChars[randomIndex];
            sb.Append(randomChar);
        }


        tilemapName = sb.ToString();
        Debug.LogWarning("Successfully initialized tilemap with name " + tilemapName);



    }


    public void ChangeTime(bool forward)
    {
        if (forward)
        {
            descArti = (ManManObjectTimeDimension)Mathf.Clamp(((int)descArti + 1), 0, 4); ;
        }
        else
        {
            descArti = (ManManObjectTimeDimension)Mathf.Clamp(((int)descArti - 1), 0, 4); ;
        }

    }


}
