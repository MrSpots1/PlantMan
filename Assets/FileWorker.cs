using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Text;
using System;

public class SaveData
{
    public int Level { get; set; }
    public bool collectable1 { get; set; }
    public bool collectable2 { get; set; }
    public bool collectable3 { get; set; }
    public bool collectable4 { get; set; }
    public bool collectable5 { get; set; }
    public bool collectable6 { get; set; }
    public bool collectable7 { get; set; }
    public bool collectable8 { get; set; }
    public bool collectablebonus1 { get; set; }
    public bool collectablebonus2 { get; set; }
    public bool collectablebonus3 { get; set; }
    public bool collectablebonus4 { get; set; }
    public bool bonus1 { get; set; }
    public bool bonus2 { get; set; }
    public bool bonus3 { get; set; }
    public bool bonus4 { get; set; }
}
public class FileWorker
{

    public void WriteContent(string fileName, SaveData saveData)
    {
        using (var writer = new StreamWriter(fileName))
        {
            writer.WriteLine(saveData.Level);
            writer.WriteLine(saveData.collectable1);
            writer.WriteLine(saveData.collectable2);
            writer.WriteLine(saveData.collectable3);
            writer.WriteLine(saveData.collectable4);
            writer.WriteLine(saveData.collectable5);
            writer.WriteLine(saveData.collectable6);
            writer.WriteLine(saveData.collectable7);
            writer.WriteLine(saveData.collectable8);
            writer.WriteLine(saveData.collectablebonus1);
            writer.WriteLine(saveData.collectablebonus2);
            writer.WriteLine(saveData.collectablebonus3);
            writer.WriteLine(saveData.collectablebonus4);
            writer.WriteLine(saveData.bonus1);
            writer.WriteLine(saveData.bonus2);
            writer.WriteLine(saveData.bonus3);
            writer.WriteLine(saveData.bonus4);
            
        }
    }

    public SaveData ReadContent(string fileName)
    {
        var saveData = new SaveData();
        using (var reader = new StreamReader(fileName))
        {
            saveData.Level = Int32.Parse(reader.ReadLine());
            saveData.collectable1 = bool.Parse(reader.ReadLine());
            saveData.collectable2 = bool.Parse(reader.ReadLine());
            saveData.collectable3 = bool.Parse(reader.ReadLine());
            saveData.collectable4 = bool.Parse(reader.ReadLine());
            saveData.collectable5 = bool.Parse(reader.ReadLine());
            saveData.collectable6 = bool.Parse(reader.ReadLine());
            saveData.collectable7 = bool.Parse(reader.ReadLine());
            saveData.collectable8 = bool.Parse(reader.ReadLine());
            saveData.collectablebonus1 = bool.Parse(reader.ReadLine());
            saveData.collectablebonus2 = bool.Parse(reader.ReadLine());
            saveData.collectablebonus3 = bool.Parse(reader.ReadLine());
            saveData.collectablebonus4 = bool.Parse(reader.ReadLine());
            saveData.bonus1 = bool.Parse(reader.ReadLine());
            saveData.bonus2 = bool.Parse(reader.ReadLine());
            saveData.bonus3 = bool.Parse(reader.ReadLine());
            saveData.bonus4 = bool.Parse(reader.ReadLine());

        }

        return saveData;
    }
}
