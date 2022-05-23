Console.Write("What do you want the plugin to be named?: ");
string? name = Console.ReadLine();
if (name == null || name == "") name = "PluginName";

Console.Write("Who is gonna be the author of this plugin?: ");
string? author = Console.ReadLine();
if (author == null || author == "") author = "AuthorName";

Console.Write("What is the main class/file gonna be called?: ");
string? main = Console.ReadLine();
if (main == null || main == "")
{
    main = "Main";
}

Console.Write("Where do you want the files and folders to be outputed?: ");
string? path = Console.ReadLine();
if (!Directory.Exists(path))
{
    Console.WriteLine("Directory given does not exist or is wrong");
    Console.ReadKey();
    return;
}
else
{
    string yamltext = "name: " + name + "\nauthor: " + author + "\nversion: 0.0.1\napi: 4.0.0\nmain: " + author + @"\" + name + @"\" + main;
    path = path + @"\" + name;
    Directory.CreateDirectory(path);
    File.WriteAllText(path + @"\plugin.yml", yamltext);

    string maintext = "<?php\n\nnamespace " + author + @"\" + name + ";\n\n" + @"use pocketmine\plugin\PluginBase;" + "\n\nclass " + main + " extends PluginBase {\n\n   public function onEnable():void\n   {\n      \n   }\n\n   public function onDisable():void\n   {\n      \n   }\n}";
    path = path + @"\src\" + author + @"\" + name + @"\";
    Directory.CreateDirectory(path);
    File.WriteAllText(path + main + ".php", maintext);
}