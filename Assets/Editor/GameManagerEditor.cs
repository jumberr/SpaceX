using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Classes;
using Classes.EquipmentClass;
using Classes.GunClass;
using Classes.ItemClass;
using UnityEditor;
using UnityEngine;
using TypeSlotEnum = Classes.SlotClass.ISlot.TypeSlotEnum;
using GunType = Classes.GunClass.Gun.GunType;
using TypeOfBoost = Classes.BulletClass.Ammo.TypeOfBoost;
//using TypeOfShells = Classes.BulletClass.Ammo.TypeOfShells;
using TypeShield = Classes.EquipmentClass.Shield.TypeShield;
using TypeHpRegenerator = Classes.EquipmentClass.HpRegenerator.TypeHpRegenerator;
using TypeEngine = Classes.EquipmentClass.Engine.TypeEngine;

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

        private enum Options
        {
            None,
            Gun,
            Engine,
            HpRegenerator,
            Shield
        }

        private TypeSlotEnum[] slotType;
        private GunType[][] gunType;
        private int[][] gunType1;

        private TypeOfBoost[][] boostType;

        //private TypeOfShells[][] shellsType;
        private int[][] shellsType1;

        private TypeShield[][] typeShield;

        private TypeHpRegenerator[][] typeHpRegenerator;

        private TypeEngine[][] typeEngine;

        private float[] weight;

        private Options[][] option;

        private List<Item> shipItems;

        //private List<Type> gunTypes;
        //private string[] gunTypesString;
        private Dictionary<string, Type> gunTypeDict = new Dictionary<string, Type>();

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
                for (var i = 0; i < option.Length; i++)
                {
                    ChangeSizeInternalArray(i, 1);
                }
            }

            GetInheritedClasses(typeof(Gun)).ToList().ForEach(x => gunTypeDict.Add(x.ToString(), x));
            //gunTypesString = gunTypes.Select(type => type.ToString()).ToArray();
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
                    for (var i = 0; i < option.Length; i++)
                    {
                        ChangeSizeInternalArray(i, 1);
                    }
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
                    slotType[i] = (TypeSlotEnum) EditorGUILayout.EnumPopup(slotType[i]);
                    EditorGUI.indentLevel -= 2;
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.LabelField("Content of slot");
                    EditorGUI.indentLevel += 2;

                    var weightSlot = 0f;
                    for (var j = 0; j < option[i].Length; j++)
                    {
                        EditorGUILayout.BeginHorizontal();
                        EditorGUILayout.LabelField($"[{j}] Choose content:", EditorStyles.boldLabel);
                        option[i][j] = (Options) EditorGUILayout.EnumPopup(option[i][j]);
                        EditorGUILayout.EndHorizontal();

                        EditorGUI.indentLevel += 2;

                        switch (option[i][j])
                        {
                            case Options.Gun:
                            {
                                EditorGUILayout.BeginHorizontal();
                                EditorGUILayout.LabelField("Type Gun");


                                gunType1[i][j] = EditorGUILayout.Popup(gunType1[i][j], gunTypeDict.Keys.ToArray());
                                //gunType[i][j] = (GunType) EditorGUILayout.EnumPopup(gunType[i][j]);
                                EditorGUILayout.EndHorizontal();

                                EditorGUILayout.BeginHorizontal();
                                EditorGUILayout.LabelField("Type Boost (Bullet)");
                                boostType[i][j] = (TypeOfBoost) EditorGUILayout.EnumPopup(boostType[i][j]);
                                EditorGUILayout.EndHorizontal();

                                EditorGUILayout.BeginHorizontal();
                                EditorGUILayout.LabelField("Type Shells (Bullet)");

                                var type = gunTypeDict[gunTypeDict.Keys.ToList()[gunType1[i][j]]];
                                Debug.Log("nameof(Gun.AvailableAmmoTypes): " + nameof(Gun.AvailableAmmoTypes));
                                var listOfShells = InvokeMethodByTypeAndName<List<Type>>(type,
                                    nameof(Gun.AvailableAmmoTypes), null, null);

                                Debug.Log(listOfShells[0]);

                                //shellsType[i][j] = (TypeOfShells) EditorGUILayout.EnumPopup(shellsType[i][j]);
                                shellsType1[i][j] = EditorGUILayout.Popup(shellsType1[i][j],
                                    listOfShells.Select(type => type.ToString()).ToArray());
                                EditorGUILayout.EndHorizontal();

                                weightSlot += ConstStats.GunWeight(gunType[i][j]);
                                break;
                            }
                            case Options.Shield:
                            {
                                EditorGUILayout.BeginHorizontal();
                                EditorGUILayout.LabelField("Type Shield");
                                typeShield[i][j] = (TypeShield) EditorGUILayout.EnumPopup(typeShield[i][j]);
                                EditorGUILayout.EndHorizontal();

                                weightSlot += ConstStats.ShieldWeight(typeShield[i][j]);
                                break;
                            }
                            case Options.Engine:
                            {
                                EditorGUILayout.BeginHorizontal();
                                EditorGUILayout.LabelField("Type Engine");
                                typeEngine[i][j] = (TypeEngine) EditorGUILayout.EnumPopup(typeEngine[i][j]);
                                EditorGUILayout.EndHorizontal();

                                weightSlot += ConstStats.EngineWeight(typeEngine[i][j]);
                                break;
                            }
                            case Options.HpRegenerator:
                            {
                                EditorGUILayout.BeginHorizontal();
                                EditorGUILayout.LabelField("Type HP Regenerator");
                                typeHpRegenerator[i][j] =
                                    (TypeHpRegenerator) EditorGUILayout.EnumPopup(typeHpRegenerator[i][j]);
                                EditorGUILayout.EndHorizontal();

                                weightSlot += ConstStats.HpRegeneratorWeight(typeHpRegenerator[i][j]);
                                break;
                            }
                        }

                        EditorGUI.indentLevel -= 2;

                        weight[i] = weightSlot;
                    }


                    GUILayout.BeginVertical();
                    GUILayout.BeginHorizontal();
                    GUILayout.FlexibleSpace();
                    if (GUILayout.Button("+", GUILayout.Width(30)))
                    {
                        var lenght = option[i].Length + 1;
                        ChangeSizeInternalArray(i, lenght);
                    }

                    if (GUILayout.Button("-", GUILayout.Width(30)))
                    {
                        var lenght = option[i].Length - 1;
                        if (lenght >= 0)
                            ChangeSizeInternalArray(i, lenght);
                    }

                    GUILayout.FlexibleSpace();
                    GUILayout.EndHorizontal();
                    GUILayout.EndVertical();

                    EditorGUILayout.LabelField($"Slot capacity: {weight[i]} / {ConstStats.SlotCapacity(slotType[i])}");

                    EditorGUI.indentLevel -= 2;


                    EditorGUI.indentLevel -= 1;
                    EditorGUILayout.Space();
                }
            }

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Create Ship"))
            {
                CreateItems();
                gameManager.CreateShip();
            }

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
            gunType1 = new int[size][];
            shellsType1 = new int[size][];
            weight = new float[size];
            slotType = new TypeSlotEnum[size];
            option = new Options[size][];
            gunType = new GunType[size][];
            boostType = new TypeOfBoost[size][];
            //shellsType = new TypeOfShells[size][];
            typeShield = new TypeShield[size][];
            typeHpRegenerator = new TypeHpRegenerator[size][];
            typeEngine = new TypeEngine[size][];
        }


        private void ChangeSizeInternalArray(int i, int size)
        {
            gunType1[i] = new int[size];
            shellsType1[i] = new int[size];
            option[i] = new Options[size];
            gunType[i] = new GunType[size];
            boostType[i] = new TypeOfBoost[size];
            //shellsType[i] = new TypeOfShells[size];
            typeShield[i] = new TypeShield[size];
            typeHpRegenerator[i] = new TypeHpRegenerator[size];
            typeEngine[i] = new TypeEngine[size];
        }

        private IEnumerable<Type> GetInheritedClasses(Type myType)
        {
            return Assembly.GetAssembly(myType).GetTypes().Where(theType =>
                theType.IsClass && !theType.IsAbstract && theType.IsSubclassOf(myType));
        }

        private void CreateItems()
        {
            // shipItems = new List<Item>();
            // for (int i = 0; i < slotType.Length; i++)
            // {
            //     var tempItems = new List<Item>();
            //     for (var j = 0; j < option[i].Length; j++)
            //     {
            //         Item item;
            //         switch (option[i][j])
            //         {
            //             case Options.None:
            //                 break;
            //             case Options.Gun:
            //                 break;
            //             case Options.Engine:
            //                 item = new Engine(weight[i], typeEngine[]);
            //                 break;
            //             case Options.HpRegenerator:
            //                 break;
            //             case Options.Shield:
            //                 break;
            //         }
            //         tempItems.Add(item);
            //     }
            //     shipItems.Add(tempItems);
            // }
        }
        
        private TR InvokeMethodByTypeAndName<TR>(Type t, string method, object obj = null, params object[] parameters)
            => (TR) t.GetMethod(method)?.Invoke(obj, parameters);
    }
}