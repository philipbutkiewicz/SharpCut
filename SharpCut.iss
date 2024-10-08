; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName                "SharpCut"
;------------------------------------------------------- Check file path and exe file name
#define MyAppVersion             GetVersionNumbersString('SharpCut\bin\x64\Release\SharpCut.exe')
#define MyAppPublisher           "Conflagrate"
#define MyAppURL                 "https://conflagrate.co/sharpcut.html"
#define MyAppExeName             "SharpCut.exe"
#define MyAppAssocName           MyAppName + "/LosslessCut Project File"
#define MyAppAssocExt            ".llc"
#define MyAppAssocKey            StringChange(MyAppAssocName, " ", "") + MyAppAssocExt
#define MyAppCopyrighyStartYear  "2020"
#define MyAppCopyrightEndYear    GetDateTimeString('yyyy','','')
#define MyAppCopyright           MyAppPublisher + " " + MyAppCopyrighyStartYear + "-" + str(MyAppCopyrightEndYear)

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)

AppId={{FF3E4F19-E9F9-4326-A1B6-96385A7E4F23}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppVerName={#MyAppName} {#MyAppVersion}

UninstallDisplayIcon={app}\SharpCut.exe
UninstallDisplayName={#MyAppName}
AppPublisher={#MyAppPublisher}

AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}

VersionInfoDescription={#MyAppName} installer
VersionInfoVersion={#MyAppVersion}
VersionInfoProductName={#MyAppName}
VersionInfoProductVersion={#MyAppVersion}
AppCopyright={#MyAppCopyright} 

WizardStyle=modern
ShowLanguageDialog=yes
UsePreviousLanguage=no

DefaultDirName={autopf}\{#MyAppName}
ChangesAssociations=yes
DisableProgramGroupPage=yes
LicenseFile=LICENSE
; Uncomment the following line to run in non administrative install mode (install for current user only.)
;PrivilegesRequired=lowest
PrivilegesRequiredOverridesAllowed=dialog
OutputBaseFilename=sharpcut_Setup
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "japanese"; MessagesFile: "compiler:Languages\Japanese.isl"
Name: "chinese"; MessagesFile: "ISTranslations\ChineseSimplified.isl"
Name: "italian"; MessagesFile: "compiler:Languages\Italian.isl"
Name: "polish";  MessagesFile: "compiler:Languages\Polish.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "SharpCut\bin\x64\Release\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "SharpCut\bin\x64\Release\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Registry]
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocExt}\OpenWithProgids"; ValueType: string; ValueName: "{#MyAppAssocKey}"; ValueData: ""; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}"; ValueType: string; ValueName: ""; ValueData: "{#MyAppAssocName}"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}\DefaultIcon"; ValueType: string; ValueName: ""; ValueData: "{app}\{#MyAppExeName},0"
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"" ""%1"""
Root: HKA; Subkey: "Software\Classes\Applications\{#MyAppExeName}\SupportedTypes"; ValueType: string; ValueName: ".myp"; ValueData: ""

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall

