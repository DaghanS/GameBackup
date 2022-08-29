using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq; // array comparison

public class Inventory : MonoBehaviour
{
    private static Inventory instance = null;
    static int pageInfo = 5; // not implemented yet.
    static int rowAmount = 5;
    static int colAmount = 12;
    public static SlotInfo[,,] InventoryArray = new SlotInfo[5,5,12]; // [pageInfo,rowAmount,colAmount]
    public GameObject parent;
    int debug = 1;
    void Start()
    {
        // load info maybe?
    }
        
    
    private void Awake()
    {
        SceneManager.activeSceneChanged += ChangedActiveScene;
    }
    private void ChangedActiveScene(Scene current, Scene next)
    {
        if (instance == null) // Original Check
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this) // Duplicate Check
        {
            SceneManager.activeSceneChanged -= ChangedActiveScene; // UNSUB
            Destroy(this.gameObject); // DESTROY
            return;
        }


        // test
        string currentName = current.name;
        if (currentName == null)
        {
            // Scene1 has been removed
            currentName = "Replaced";
        }
        Debug.Log("Scenes: " + currentName + ", " + next.name);

        // original code
        if (next.name == "Loadouts") // names are a little confusing on the code, next is currentnewscene
        {
            parent = GameObject.Find("InventoryParent");  // WORKSSSSSSSSSSSSS
            InventoryLoader();

        }
    }
    public void CollectItem(Gear item) // unoptimized
    {
        GearInfo itemInfo = GearInfoConst(item.gearObj,item.rarity,item.level,item.iconvar);
        int[] emptyInfo = FirstEmptyCoord();
        SlotInfo emptySlotInfo = InfoConst(emptyInfo,itemInfo);
        InventoryArray[emptyInfo[0], emptyInfo[1], emptyInfo[2]] = emptySlotInfo; // will be changeeed!!!!!!!!!!!!!!!!!!!!

        debug += 1;
    }
    public int[] FirstEmptyCoord() // unoptimized
    {
        for(int pagei = 0; pagei<pageInfo; pagei++)
        {
            for(int rowi = 0; rowi < rowAmount; rowi++)
            {
                for(int coli = 0; coli<colAmount; coli++)
                {
                    if(InventoryArray[pagei,rowi,coli] == null)
                    {
                        int[] cords = {pagei, rowi, coli};
                        return cords;
                    }
                }
            }
        }
        // error: inventory is full.
        return null;
    }
    public void InventoryLoader()  // VERY UNOPTIMIZED WITH BREAKS
    {
        
        int[] emptycor = FirstEmptyCoord(); // page,row,col
        bool breaker = false;
        for (int pagei = 0; pagei < pageInfo; pagei++)
        {
            for (int rowi = 0; rowi < rowAmount; rowi++)
            {
                for (int coli = 0; coli < colAmount; coli++)
                {
                    int[] thisSlotcord = { pagei, rowi, coli };
                    Slot slotComp = SlotFinder(thisSlotcord); // this is testing, returning a slot var might not be functional. // seems functional
                    GearInfo iteminfo;
                    iteminfo = InventoryArray[pagei, rowi, coli].storedGear;
                    //GearLoader(slotComp.storedGear, iteminfo);
                    slotComp.storedGear = iteminfo;
                    if (emptycor.SequenceEqual(thisSlotcord))
                    {
                        breaker = true;
                        break;
                    }
                }
                if(breaker == true)
                {
                    break;
                }
            }
            if (breaker == true)
            {
                break;
            }
        }
    }
    public Slot SlotFinder(int[] coordinates)
    {
        int[] finderCord = new int[3];
        for(int i =0; i < 3; i++)
        {
            finderCord[i] = coordinates[i]+1;
        }
        //int page = finderCord[0];
        //int row = finderCord[1];
        //int col = finderCord[2];
        // for now, multiple pages are not implemented so I will not look for pages.
        string rowname = "Row" + finderCord[1];
        string colname = "DenemeSlot" + finderCord[2];

        GameObject rowObj = GameObject.Find(rowname);
        GameObject colObj = rowObj.transform.Find(colname).gameObject;
        Slot returnedSlot = colObj.GetComponent<Slot>();
        return returnedSlot;
    }
    public SlotInfo InfoConst(int[] cor, GearInfo item)
    {
        SlotInfo ret = new SlotInfo();
        ret.coordinates = cor;
        ret.storedGear = item;
        return ret;
    }  // SlotInfo CONST
    public GearInfo GearInfoConst(Object typeInfo, string rarinfo, int lvlinfo, Icon iconinfo)
    {
        GearInfo ret = new GearInfo();
        ret.gearObj = typeInfo;
        ret.rarity = rarinfo;
        ret.level = lvlinfo;
        ret.iconvar = iconinfo;
        return ret;
    }
    public void GearLoader(Gear slotGear, GearInfo LoadedInfo)
    {
        slotGear.gearObj = LoadedInfo.gearObj;
        slotGear.rarity = LoadedInfo.rarity;
        slotGear.level = LoadedInfo.level;
        slotGear.iconvar = LoadedInfo.iconvar;
    }

}
