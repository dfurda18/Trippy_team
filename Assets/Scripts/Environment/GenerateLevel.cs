using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Environment
{
    public class GenerateLevel : MonoBehaviour
    {
        /**
     * The section types
     */
        private static Array sectionTypes = Enum.GetValues(typeof(SectionType));
        /**
     * The section prefabs
     */
        public GameObject[] sections;
        /**
     * The section size
     */
        public int sectionSize = 60;
        /**
     * Value that says if the level is creating a section
     */
        private static bool creatingSection = false;
        /**
     * The map's current position
     */
        private static Vector3 currentPosition;
        /**
     * The map's previous position
     */
        private static Vector3 previousPosition = new Vector3(-1,-1,-1);
        /**
     * the map
     */
        private static Dictionary<Vector3, GameObject> map;
        /**
     * The Object instance
     */
        private static GenerateLevel instance;

        // Start is called before the first frame update
        void Start()
        {
            GenerateLevel.instance = this;
            GenerateLevel.map = new Dictionary<Vector3, GameObject>();
            GenerateLevel.currentPosition = new Vector3(0, 0, 0);
            GenerateLevel.map.Add(GenerateLevel.currentPosition, Instantiate(GenerateLevel.instance.sections[0], GenerateLevel.currentPosition, Quaternion.Euler(0, 0, 0)));
            if (!GenerateLevel.creatingSection)
            {
                GenerateLevel.creatingSection = true;
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
        static IEnumerator GenerateSection ()
        {
            GenerateLevel.SpawnNextSections();
            GenerateLevel.DeletePreviousSections();

            yield return new WaitForSeconds(2);
            creatingSection = false;
        }

        /**
     * Deletes the unused sections
     */
        public static void DeletePreviousSections()
        {
            if(GenerateLevel.map.ContainsKey(GenerateLevel.previousPosition))
            {
                EnvironmentSection previousSectionScript = GenerateLevel.map[GenerateLevel.previousPosition].GetComponent<EnvironmentSection>();
                Vector3 nexPosition;
                foreach (Direction direction in previousSectionScript.GetNextDirections())
                {
                    nexPosition = previousSectionScript.GetNextPosition(direction, GenerateLevel.instance.sectionSize);
                    if (nexPosition != GenerateLevel.currentPosition)
                    {
                        Destroy(GenerateLevel.map[nexPosition]);
                        GenerateLevel.map.Remove(nexPosition);
                    }
                }
                Destroy(GenerateLevel.map[GenerateLevel.previousPosition]);
                GenerateLevel.map.Remove(GenerateLevel.previousPosition);
            }
        }

        /**
     * Returns the array of next sections to create from the current section
     */
        public static void SpawnNextSections()
        {
            EnvironmentSection currentSectionScript = GenerateLevel.map[GenerateLevel.currentPosition].GetComponent<EnvironmentSection>();
            GameObject tempSection;
            SectionType newType;
            foreach (Direction newDirection in currentSectionScript.GetNextDirections())
            {
                newType = GenerateLevel.GetRandomSectionType();
                tempSection = Instantiate(GenerateLevel.instance.sections[(int)newType], currentSectionScript.GetNextPosition(newDirection, GenerateLevel.instance.sectionSize), Quaternion.Euler(0, (int)newDirection, 0));
                tempSection.GetComponent<EnvironmentSection>().type = newType;
                tempSection.GetComponent<EnvironmentSection>().direction = newDirection;
                map.Add(currentSectionScript.GetNextPosition(newDirection, GenerateLevel.instance.sectionSize), tempSection);
            }
        }

        /**
     * Returns a random section type
     */
        public static SectionType GetRandomSectionType()
        {
            return (SectionType)GenerateLevel.sectionTypes.GetValue(UnityEngine.Random.Range(0, GenerateLevel.sectionTypes.Length));
        }

        /**
     * Leads the current section's next sections
     */
        public static void MakeMoreSectionsFrom(Vector3 currentPosition)
        {
            GenerateLevel.previousPosition = GenerateLevel.currentPosition;
            GenerateLevel.currentPosition = currentPosition;
            if (!GenerateLevel.creatingSection)
            {
                GenerateLevel.creatingSection = true;
                GenerateLevel.instance.StartCoroutine(GenerateLevel.GenerateSection());
            }
        }
    }
}