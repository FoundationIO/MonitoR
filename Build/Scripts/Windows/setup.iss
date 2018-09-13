; Script generated by the Inno Script Studio Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "MonitoR"
#define MyAppVersion "1.0"
#define MyAppPublisher "FoundationIO"
#define MyAppURL "http://www.foundation.io/"
#define MyAppExeName "MonitoR.Configurator.exe"
#define ServiceFileName "MonitoR.WindowsService.exe"

[Setup]
AppId={{70718A33-9119-40CA-9857-A4AE950FCDA4}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\FoundationIO MonitoR
DefaultGroupName={#MyAppName}
OutputDir=..\..\output\Windows
OutputBaseFilename=monitoR-setup
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked; OnlyBelowVersion: 0,6.1

[Files]
Source: "..\..\..\Source\WindowsApp\bin\Release\*.*"; DestDir: "{app}"; Flags: ignoreversion;Excludes:*.pdb,*.xml
Source: "C:\work\Desktop\ServiceMonitor\Source\WindowsService\bin\Release\*.*"; DestDir: "{app}"; Flags: ignoreversion;Excludes:*.pdb,*.xml
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: quicklaunchicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

[Code]
#include "servicelib.iss"

function KillProcess(FileName:string):Boolean;
var
  ResultCode:Integer;
begin
  if Exec(ExpandConstant('{sys}\taskkill.exe'), '/im '+ FileName + ' /f /t ', '', SW_HIDE, ewWaitUntilTerminated, ResultCode) = false then  
  begin
    if Exec(ExpandConstant('{sys}\tskill.exe'), FileName + ' /A', '', SW_HIDE, ewWaitUntilTerminated, ResultCode) = false then  
      result := false
    else
      result := true;
  end;
end;

procedure CustomUpdateUnInstallStatus(statusMsg:string);
begin
  if (UninstallProgressForm <> nil) and (UninstallProgressForm.StatusLabel <> nil) then
    UninstallProgressForm.StatusLabel.Caption := statusMsg;
end;

function UnInstallMatchingServices(ServiceFileName:String;IgnoreErrors:Boolean;OnlyStop:boolean):Boolean;
var
  Names: TArrayOfString;
  ServicePath,ServiceName:String;
  I,ServiceCount:Integer;
  DeleteProblem,StopProblem:Boolean;
begin
  result:=true;
  DeleteProblem := false;
  StopProblem := false;

  if RegGetSubkeyNames(HKEY_LOCAL_MACHINE,'System\CurrentControlSet\Services\',Names) then
  begin
    ServiceCount := GetArrayLength(Names);
    for I := 0 to GetArrayLength(Names)-1 do
    begin
      ServicePath := '';
      ServiceName := Names[I];
      if RegQueryStringValue(HKEY_LOCAL_MACHINE, 'System\CurrentControlSet\Services\'+ServiceName,'ImagePath', ServicePath) then
      begin
	  if Pos(ServiceFileName,ServicePath) <> 0 then
	  begin
	    // LogOne('Service Name = ' + ServiceName);
         try
           SimpleStopService(ServiceName,true,true);
         except
           StopProblem := false;
         end;

         if OnlyStop = false then
         begin
           try
             SimpleDeleteService(ServiceName);
           except
             DeleteProblem := false;
           end;
         end;
	  end;
      end;
    end;
  end;
end;


function UnInstallServices(ServiceFileName:string;IgnoreErrors:Boolean):Boolean;
begin
    KillProcess('mmc');
    KillProcess(ServiceFileName);
    Sleep(2000);
    result:= UnInstallMatchingServices(ServiceFileName,IgnoreErrors, false)
end;

function InstallServiceList(serviceName:string;ServiceFileName:string;ServiceDescription:string;ServiceUserName:String;ServiceUserPassword:String):Boolean;
var
    installStatus:boolean;
begin 
    installStatus := SimpleCreateService(serviceName,serviceName,ServiceFileName,SERVICE_AUTO_START,ServiceUserName, ServiceUserPassword,true,true);

    try      
	    if (installStatus = false) then
            installStatus := SimpleCreateService(serviceName,serviceName,ServiceFileName,SERVICE_AUTO_START,'', '',true,true);
    except
        installStatus := false;
    end;

	if (installStatus) then
    begin
	    SimpleStartService(serviceName,false,true);
    end;

    if ( installStatus = false) then
    begin
      UnInstallServices(ServiceFileName,false);
      result:= false;
      exit;
    end;
end;

procedure CurStepChanged(CurStep: TSetupStep);
begin
  if (CurStep=ssPostInstall) then
  begin
    InstallServiceList('MonitoRAgent',ExpandConstant('{app}\{#ServiceFileName}'),'MonitoR service to checking different sensors.','','');
  end;
end;


procedure CurUninstallStepChanged(CurUninstallStep: TUninstallStep);
begin
  if (CurUninstallStep=usUninstall) or (CurUninstallStep=usPostUninstall) then
  begin
    if (CurUninstallStep=usUninstall) then
        CustomUpdateUnInstallStatus('Stopping the services');
    
    UnInstallMatchingServices('{#ServiceFileName}',true,true);
    KillApp('mmc');
    KillApp('{#ServiceFileName}');
  end;

  if (CurUninstallStep=usPostUninstall) then
  begin
    UnInstallServices('{#ServiceFileName}',false);
  end;
end;
