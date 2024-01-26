using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static System.Collections.Specialized.BitVector32;

public class GenerateLevel : MonoBehaviour
{
    /**
     * The section types
     */
    private static Array sectionTypes = Enum.GetValues(typeof(SectionType));
    /**
     * The section prefab
     */
    public GameObject sectionPrefab;
    /**
     * The current z position
     */
    public int zPos = 0;
    /**
     * The current x position
     */
    public int xPos = 0;
    /**
     * The section size
     */
    public int sectionSize = 50;
    /**
     * Value that says if the level is creating a section
     */
    private bool creatingSection = false;
    /**
     * The map's current position
     */
    private Vector3 currentPosition;
    /**
     * the map
     */
    private Dictionary<Vector3, GameObject> map;

    // Start is called before the first frame update
    void Start()
    {
        this.map = new Dictionary<Vector3, GameObject>();
        this.currentPosition = new Vector3(0, 0, 0);
        this.map.Add(this.currentPosition, Instantiate(sectionPrefab, this.currentPosition, Quaternion.Euler(0, 0, 0)));
        if (!creatingSection)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    /**
     * This corutine generates a new section
     */
    IEnumerator GenerateSection ()
    {
        this.spawnNextSections();

        yield return new WaitForSeconds(2);
        creatingSection = false;
    }

    /**
     * Returns the array of next sections to create from the current section
     */
    public void spawnNextSections()
    {
        EnvironmentSection currentSectionScript = this.map[this.currentPosition].GetComponent<EnvironmentSection>();
        GameObject tempSection;
        foreach (Direction newDirection in currentSectionScript.getNextDirections())
        {
            tempSection = Instantiate(sectionPrefab, currentSectionScript.getNextPosition(newDirection, this.sectionSize), Quaternion.Euler(0, (int)newDirection, 0));
            tempSection.GetComponent<EnvironmentSection>().type = GenerateLevel.getRandomSectionType();
            tempSection.GetComponent<EnvironmentSection>().direction = newDirection;
            map.Add(currentSectionScript.getNextPosition(newDirection, this.sectionSize), tempSection);
        }
    }

    /**
     * Returns a random section type
     */
    public static SectionType getRandomSectionType()
    {
        return (SectionType)GenerateLevel.sectionTypes.GetValue(UnityEngine.Random.Range(0, GenerateLevel.sectionTypes.Length));
    }
}
