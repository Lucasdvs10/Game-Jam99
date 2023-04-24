using System.IO;
using UnityEngine;

namespace GameManager {
    public class CheckIfItsFirstTimePlaying : MonoBehaviour {
        public bool Check() {
            string path = Application.dataPath + $"/JaJogou.json";
            if (!File.Exists(path)) {
                File.Create(path);
                return true;
            }
            return false;
        }

    }
}