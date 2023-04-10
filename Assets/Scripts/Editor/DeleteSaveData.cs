using System.IO;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
   public class DeleteSaveData : Editor
   {
      [MenuItem("Tools/Delete save data")]
      public static void DeleteAllSavedData()
      {
         DirectoryInfo dataDir = new DirectoryInfo(Application.persistentDataPath);
         dataDir.Delete(true);
      }
   }
}