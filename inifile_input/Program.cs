// See https://aka.ms/new-console-template for more information
using inifile_input;

Console.WriteLine("Hello, World!");

string filePath = "file.ini";
IniFile iniFile = new IniFile();
iniFile.Load(filePath);

// 値の取得例
string section = "test";
string key = "key1";
string value = iniFile.GetValue(section, key);
if (value != null)
{
    Console.WriteLine($"[{section}] {key} = {value}");
}
else
{
    Console.WriteLine($"[{section}] {key} not found.");
}