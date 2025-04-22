using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;
using Sirenix.OdinInspector;

namespace UnityRPGEditor.Editor
{
    public class UnityRPGEditorWindow : OdinMenuEditorWindow    // OdinMenuEditorWindow creates a list of editable assets in a new window
    {
        // MenuItem adds our static function to Unity editor windows
        [MenuItem("Tools/RPG Editor Window")]
        private static void OpenEditor()
        {
            // GetWindow will create a window using the selected type
            GetWindow<UnityRPGEditorWindow>();
        }

        protected override OdinMenuTree BuildMenuTree()
        {
            OdinMenuTree tree = new OdinMenuTree();

            List<Type> includedTypes = new List<Type>();
            includedTypes.Add(typeof(CharacterData));
            includedTypes.Add(typeof(ClassData));
            includedTypes.Add(typeof(WeaponData));
            includedTypes.Add(typeof(SkillData));

            foreach (Type type in includedTypes)
            {
                tree.AddAllAssetsAtPath(type.Name, "Assets/", type, true, false);
                tree.Add("New " + type.Name, new CreateNewAsset(type));
            }

            return tree;
        }

        protected override void OnBeginDrawEditors()
        {
            base.OnBeginDrawEditors();

            MenuTree.DrawSearchToolbar();

        }


    }

    public class CreateNewAsset
    {
        private Type _type;
        [SerializeField, InlineEditor(Expanded = true)] private ScriptableObject _data;

        [field: SerializeField]
        public string Name { get; private set; } = "New Data";

        public CreateNewAsset(Type type)
        {
            _type = type;
            _data = ScriptableObject.CreateInstance(_type);
        }

        [Button("Create New")]
        private void CreateNew()
        {
            string path = GetProjectWindowPath();
            AssetDatabase.CreateAsset(_data, path + Name + ".asset");
            AssetDatabase.SaveAssets();
        }

        private string GetProjectWindowPath()
        {
            Type projectWindowUtilType = typeof(ProjectWindowUtil);
            MethodInfo getActiveFolderPath = projectWindowUtilType.GetMethod("GetActiveFolderPath", BindingFlags.Static | BindingFlags.NonPublic);
            object obj = getActiveFolderPath.Invoke(null, new object[0]);
            string path = obj.ToString() + "/";
            return path;
        }
    }
}