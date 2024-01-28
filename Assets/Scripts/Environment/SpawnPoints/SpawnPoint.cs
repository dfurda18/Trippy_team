using UnityEngine;

namespace Environment.SpawnPoints
{
    public abstract class SpawnPoint : MonoBehaviour
    {
        /**
     * The Building prefabs
     */
        public GameObject[] prefabs;
        /**
     * Chance of spawning something
     */
        public int likelihood = 100;

        // Start is called before the first frame update
        void Start()
        {
            bool spawn = UnityEngine.Random.Range(0,100) < likelihood;
            if(spawn)
            {
                (Instantiate(prefabs[UnityEngine.Random.Range(0, prefabs.Length)], this.gameObject.transform.position, Quaternion.Euler(0, (int)this.gameObject.GetComponentInParent<EnvironmentSection>().direction, 0)) as GameObject).transform.parent = this.gameObject.transform;
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        public abstract void OnCollission();
    }
}
