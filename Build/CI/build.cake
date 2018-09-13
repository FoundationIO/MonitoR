#tool nuget:?package=NUnit.ConsoleRunner&version=3.4.0
#addin "Cake.FileHelpers"
#addin "Cake.IIS"
#tool nuget:?package=GitVersion.CommandLine
#tool nuget:?package=Tools.InnoSetup
//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////
const string commandStr = "command";
const string buildStr = "build";
const string cleanStr ="clean";
const string packStr ="pack";
const string setVersionStr ="set-version";


const string gitPullStr = "gitpull";
const string gitPushStr = "gitpush";

const string customCommandStr = "Command";


const string solutionPath = "../../Source/MonitoR.sln";
const string sourcePath ="../../Source/";
const string setupScriptPath = "../Scripts/Windows/setup.iss";

class CommandProcess
{
    public CommandProcess(string commandName, string shortcut1, string shortcut2,string shortcut3, string description)
    {
        this.CommandName = commandName.Trim();
        this.Shortcut1 = shortcut1.Trim();
        this.Shortcut2 = shortcut2.Trim();
        this.Shortcut3 = shortcut3.Trim();        
        this.Description = description.Trim();
    }

    public string CommandName {get; private set;}
    public string Shortcut1 {get; private set;}
    public string Shortcut2 {get; private set;}
    public string Shortcut3 {get; private set;}
    public string Description {get; private set;}

    public string Shortcuts
    {
        get 
        {
            return Shortcut1 + (Shortcut2 == "" ? "" : "," + Shortcut2) +(Shortcut3 == "" ?  "" : "," + Shortcut3);
        }
    }
}

List<CommandProcess> commandList = new List<CommandProcess>()
{
    new CommandProcess(buildStr,"b", "01" , "1","build the monitoR project"),
    new CommandProcess(cleanStr,"c", "" , "","clean obj/bin folders"),
    new CommandProcess(packStr,"pkg", "" , "","Package the application"),    
    new CommandProcess(setVersionStr,"ver", "" , "","Set Version from GIT"),    
};

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var command = Argument(commandStr, "");

var param1 = Argument("param1", "");
var param2 = Argument("param2", "");
var param3 = Argument("param3", "");
var param4 = Argument("param4", "");
var param5 = Argument("param5", "");

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn(customCommandStr);

Task(buildStr)
	//.IsDependentOn(setVersionStr)
    .Does(() =>
{
    Warning("Restoring Nuget Packages:");
    NuGetRestore(solutionPath);

    Warning("Building MonitoR Source:");
    DotNetBuild(solutionPath, settings =>
    settings.SetConfiguration("Release")
        .SetVerbosity(Verbosity.Minimal)
        .WithTarget("Build")
        .WithProperty("TreatWarningsAsErrors","true"));
});


Task(cleanStr)
    .Does(() =>
{
    var path = MakeAbsolute(Directory(sourcePath)).FullPath;
    Warning("Cleaning bin/obj folders from Path " + path);
    CleanDirectories(path + "/**/bin/" + "Debug");
    CleanDirectories(path + "/**/bin/" + "Release");
    CleanDirectories(path + "/**/obj/" + "Debug");   
    CleanDirectories(path + "/**/obj/" + "Release");
});

Task(packStr)
    .IsDependentOn(buildStr)
    .Does(() =>
{
    FilePath innoPath = Context.Tools.Resolve("iscc.exe");
    Warning("Using Innosetup path from - " + innoPath);
    InnoSetup(setupScriptPath, new InnoSetupSettings(){
        ToolPath = innoPath,
    });
});

Task(setVersionStr)
    .Does(() =>
{
     var versionInfo = GitVersion();

    Warning("MajorMinorPatch: {0}", versionInfo.MajorMinorPatch);
    //Warning("FullSemVer: {0}", versionInfo.FullSemVer);
    //Warning("InformationalVersion: {0}", versionInfo.InformationalVersion);
    //Warning("LegacySemVer: {0}", versionInfo.LegacySemVer);
    //Warning("Nuget v1 version: {0}", versionInfo.NuGetVersion);
    //Warning("Nuget v2 version: {0}", versionInfo.NuGetVersionV2);
    //Warning("PreReleaseNumber: {0}", versionInfo.PreReleaseNumber);
    
    FileWriteText("../Source/WindowsService/bin/Release/version_number.txt", versionInfo.MajorMinorPatch+"."+ versionInfo.PreReleaseNumber + " (" + DateTime.Now.ToShortDateString() +  ")");
});

//////////////////////////////////////////////////////////////////////
// GIT RELATED TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task(gitPullStr)
    .Does(() =>
{
    Warning("Displaying any modified files:");
    StartProcess("git", new ProcessSettings{ Arguments = " status --short" });
    Warning("Pulling from source repository... ");
    StartProcess("git", new ProcessSettings{ Arguments = " pull origin dev" });
});

Task(gitPushStr)
    .Does(() =>
{
    Warning("Pushing files to HEAD of current branch:");
    StartProcess("git", new ProcessSettings{ Arguments = " push -u origin HEAD " });
});


//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////


Task(customCommandStr)
    .Does(() =>
{
    var command = Argument<string>(commandStr);
    
    if(command == null || command.Trim() == "")
    {
        if (command.Trim().Length > 0)
            Error("Invalid command");
        else
            Error("No Parameter specified");
        ShowUsage();        
        return;
    }

    command = command.Trim().ToLower();

    var item = commandList.FirstOrDefault(x=> x.CommandName.Trim().ToLower() == command || x.Shortcut1.Trim().ToLower() == command || x.Shortcut2.Trim().ToLower() == command|| x.Shortcut3.Trim().ToLower() == command);
    if (item == null)
    {
        Error("Invalid command - " + command);
        ShowUsage();
        return;
    }

    RunTarget(item.CommandName);

})
.OnError(exception =>
{
    Error("Error when executing command - " + exception.Message + " - ST - "+ exception.StackTrace);
});

void ShowUsage()
{
    Warning("=====");
    Warning("Usage");
    Warning("=====");
    Warning("ci.bat <Command>");
    int commandPadding = 20;
    int shortcutPadding = 10;

    var header = "Command".PadRight(commandPadding,' ')+" - "+"Shortcut".PadRight(shortcutPadding,' ')+" - "+"Description";
    var line = "=".PadRight(header.Length + 30,'=');

    Warning(line);
    Warning(header);
    Warning(line);
    foreach(var item in commandList)
    {
        Warning(item.CommandName.PadRight(commandPadding,' ')+" - "+item.Shortcuts.PadRight(shortcutPadding,' ')+" - "+item.Description);
    }
    Warning(line);
}

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);