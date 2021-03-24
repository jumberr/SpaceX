using System;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(GameManager))]
    public class GameManagerEditor : UnityEditor.Editor
    {
        private GameManager gameManager;
        
        private bool foldoutSlots;

        private SerializedProperty minHealth;
        private SerializedProperty maxHealth;

        private SerializedProperty numberOfSlots;

        private SerializedProperty items;

        private enum options
        {
            None,
            Gun,
            Engine,
            HpRegenerator,
            Shield
        }
        
        private ISlot.TypeSlotEnum[] slotType;
        private Gun.GunType[][] gunType;
        private Bullet.TypeOfBoost[][] boostType;
        private Bullet.TypeOfShells[][] shellsType;

        private Shield.TypeShield[][] typeShield;

        private HpRegenerator.TypeHpRegenerator[][] typeHpRegenerator;

        private Engine.TypeEngine[][] typeEngine;
        

        private float[] weight;

        private options[][] option;
        public int[] componentAmount;
        private void OnEnable()
        {
            gameManager = (GameManager) target;
            minHealth = serializedObject.FindProperty("minHealth");
            maxHealth = serializedObject.FindProperty("maxHealth");
            numberOfSlots = serializedObject.FindProperty("numberOfSlots");

            items = serializedObject.FindProperty("Items");

            if (gameManager.numberOfSlots >= 0)
            {
                ChangeSizeExternalArray(gameManager.numberOfSlots);
                ChangeSizeInternalArray(1);
            }
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            // health properties
            EditorGUILayout.PropertyField(minHealth);
            EditorGUILayout.PropertyField(maxHealth);
            // number of slots property
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(numberOfSlots);
            if (GUILayout.Button("Apply size"))
            {
                if (gameManager.numberOfSlots >= 0)
                {
                    ChangeSizeExternalArray(gameManager.numberOfSlots);
                    ChangeSizeInternalArray(1);
                }
            }

            EditorGUILayout.EndHorizontal();

            // foldout slots
            foldoutSlots = EditorGUILayout.Foldout(foldoutSlots, "Fill Slots");
            if (foldoutSlots)
            {
                for (var i = 0; i < slotType.Length; i++)
                {
                    EditorGUILayout.LabelField($"Slot #{i + 1}", EditorStyles.boldLabel);
                    EditorGUI.indentLevel += 1;

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("Slot type");
                    EditorGUI.indentLevel += 2;
                    slotType[i] = (ISlot.TypeSlotEnum) EditorGUILayout.EnumPopup(slotType[i]);
                    EditorGUI.indentLevel -= 2;
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.LabelField("Content of slot");
                    EditorGUI.indentLevel += 2;

                    for (var j = 0; j < option[i].Length; j++)
                    {
                        EditorGUILayout.BeginHorizontal();
                        EditorGUILayout.LabelField($"[{j}] Choose content:", EditorStyles.boldLabel);
                        option[i][j] = (options) EditorGUILayout.EnumPopup(option[i][j]);
                        EditorGUILayout.EndHorizontal();

                        if (option[i][j] == options.Gun)
                        {
                            EditorGUILayout.BeginHorizontal();
                            EditorGUILayout.LabelField("Type Gun");
                            gunType[i][j] = (Gun.GunType) EditorGUILayout.EnumPopup(gunType[i][j]);
                            EditorGUILayout.EndHorizontal();

                            EditorGUILayout.BeginHorizontal();
                            EditorGUILayout.LabelField("Type Boost (Bullet)");
                            boostType[i][j] = (Bullet.TypeOfBoost) EditorGUILayout.EnumPopup(boostType[i][j]);
                            EditorGUILayout.EndHorizontal();

                            EditorGUILayout.BeginHorizontal();
                            EditorGUILayout.LabelField("Type Shells (Bullet)");
                            shellsType[i][j] = (Bullet.TypeOfShells) EditorGUILayout.EnumPopup(shellsType[i][j]);
                            EditorGUILayout.EndHorizontal();
                        }

                        if (option[i][j] == options.Shield)
                        {
                            EditorGUILayout.BeginHorizontal();
                            EditorGUILayout.LabelField("Type Shield");
                            typeShield[i][j] = (Shield.TypeShield) EditorGUILayout.EnumPopup(typeShield[i][j]);
                            EditorGUILayout.EndHorizontal();
                        }

                        if (option[i][j] == options.HpRegenerator)
                        {
                            EditorGUILayout.BeginHorizontal();
                            EditorGUILayout.LabelField("Type HP Regenerator");
                            typeHpRegenerator[i][j] =
                                (HpRegenerator.TypeHpRegenerator) EditorGUILayout.EnumPopup(typeHpRegenerator[i][j]);
                            EditorGUILayout.EndHorizontal();
                        }

                        if (option[i][j] == options.Engine)
                        {
                            EditorGUILayout.BeginHorizontal();
                            EditorGUILayout.LabelField("Type Engine");
                            typeEngine[i][j] = (Engine.TypeEngine) EditorGUILayout.EnumPopup(typeEngine[i][j]);
                            EditorGUILayout.EndHorizontal();
                        }
                    }


                    GUILayout.BeginVertical();
                    GUILayout.BeginHorizontal();
                    GUILayout.FlexibleSpace();
                    if (GUILayout.Button("+", GUILayout.Width(30)))
                    {
                        Debug.Log("+1");

                        var lenght = option[i].Length + 1;
                        ChangeSizeInternalArray(lenght);
                    }
                    if (GUILayout.Button("-", GUILayout.Width(30)))
                    {
                        Debug.Log("-1");

                        var lenght = option[i].Length - 1;
                        ChangeSizeInternalArray(lenght);
                    }
                    GUILayout.FlexibleSpace();
                    GUILayout.EndHorizontal();
                    GUILayout.EndVertical();
                    
                    EditorGUILayout.LabelField($"Slot capacity: {0} / {ConstStats.SlotCapacity(slotType[i])}");

                    EditorGUI.indentLevel -= 2;


                    EditorGUI.indentLevel -= 1;
                    EditorGUILayout.Space();
                }
            }

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Create Ship"))
                gameManager.CreateShip();

            if (GUILayout.Button("Reset"))
            {
                gameManager.numberOfSlots = 0;
                ChangeSizeExternalArray(gameManager.numberOfSlots);
            }
            EditorGUILayout.EndHorizontal();

            serializedObject.ApplyModifiedProperties();
        }

        private void ChangeSizeExternalArray(int size)
        {
            
            slotType = new ISlot.TypeSlotEnum[size];
            option = new options[size][];
            gunType = new Gun.GunType[size][];
            boostType = new Bullet.TypeOfBoost[size][];
            shellsType = new Bullet.TypeOfShells[size][];
            typeShield = new Shield.TypeShield[size][];
            typeHpRegenerator = new HpRegenerator.TypeHpRegenerator[size][];
            typeEngine = new Engine.TypeEngine[size][];
        }
        
        private void ChangeSizeInternalArray(int size)
        {
            for (var i = 0; i < gameManager.numberOfSlots; i++) {
                option[i] = new options[size];
                gunType[i] = new Gun.GunType[size];
                boostType[i] = new Bullet.TypeOfBoost[size];
                shellsType[i] = new Bullet.TypeOfShells[size];
                typeShield[i] = new Shield.TypeShield[size];
                typeHpRegenerator[i] = new HpRegenerator.TypeHpRegenerator[size];
                typeEngine[i] = new Engine.TypeEngine[size];
            }
        }
    }
}