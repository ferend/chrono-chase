using _Project.Scripts.Runner.Utilities;
using UnityEditor;

namespace _Project.Scripts.Runner.Editor
{
    public static class Snapper
    {
        private const string UNDO_SNAP = "snap objects";
        
        // If no object is selected it will be gray in menu
        [MenuItem("DevTools/Snap Object",isValidateFunction:true)]
        public static bool SnapObjectValidate()
        {
            return Selection.gameObjects.Length > 0;
        }
        
        // If user did record the gameobject scene will mark it as changed.
        // Even if it is small iteration recording is expensive.
        
        [MenuItem("DevTools/Snap Object")]
        public static void SnapObject()
        {
            foreach (var go in Selection.gameObjects)
            {
                Undo.RecordObject(go.transform, UNDO_SNAP);
                go.transform.position =  go.transform.position.Round();
            }
        }
        
    }
}