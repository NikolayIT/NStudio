!Include 'MUI.nsh'
!define PRG_NAME "NStudio"
!define PRG_VERSION "0.1 Beta 3"
OutFile "NStudio installer.exe"
Name "${PRG_NAME} ${PRG_VERSION}"
BrandingText "${PRG_NAME} ${PRG_VERSION}"
InstallDir $PROGRAMFILES\NStudio
InstallDirRegKey HKLM "Software\NStudio" "Install_Dir"

;-----------Interface------------
!define MUI_ABORTWARNING
!define MUI_WELCOMEPAGE_TITLE_3LINES
!insertmacro MUI_PAGE_WELCOME
!insertmacro MUI_PAGE_LICENSE "license.txt"
Page custom CustomPageA
!insertmacro MUI_PAGE_COMPONENTS
!insertmacro MUI_PAGE_DIRECTORY
!insertmacro MUI_PAGE_INSTFILES
!define MUI_FINISHPAGE_TITLE_3LINES
!insertmacro MUI_PAGE_FINISH
!insertmacro MUI_UNPAGE_WELCOME
!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_UNPAGE_INSTFILES
!insertmacro MUI_UNPAGE_FINISH
!insertmacro MUI_LANGUAGE "English"
!insertmacro MUI_LANGUAGE "Bulgarian"
!insertmacro MUI_LANGUAGE "Hungarian"
!insertmacro MUI_LANGUAGE "Latvian"
!insertmacro MUI_LANGUAGE "Russian"
ReserveFile "Check.net.ini"
!insertmacro MUI_RESERVEFILE_LANGDLL
!insertmacro MUI_RESERVEFILE_INSTALLOPTIONS
;--------------------------------
InstType "Full"
InstType "Minimum (with plugins)"
InstType "Minimum (with languages)"
InstType "Minimum"

Section "NStudio"
  SectionIn RO
  SetOutPath $INSTDIR
  File "NStudio.exe"
  File "NStudioInterface.dll"
  File "NStudioResources.dll"
  File "WeifenLuo.WinFormsUI.Docking.dll"
  File "ICSharpCode.TextEditor.dll"
  File "ScintillaNET.dll"
  File "SciLexer.dll"
  File "HtmlEditControl.dll"
  File "HISTORY.txt"
  File "README.txt"
  SetOutPath "$INSTDIR\Configuration\"
  File "Configuration\*.*"
  
  WriteRegStr HKLM "Software\NStudio" "Install_Dir" "$INSTDIR"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\NStudio" "DisplayName" "NStudio"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\NStudio" "UninstallString" '"$INSTDIR\uninstall.exe"'
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\NStudio" "NoModify" 1
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\NStudio" "NoRepair" 1
  WriteUninstaller "uninstall.exe"
SectionEnd

SubSection "Plugins"
  Section "CodeSnippet"
	SectionIn 1 2
	SetOutPath "$INSTDIR\Plugins\CodeSnippet\"
	File "Plugins\CodeSnippet\CodeSnippet.dll"
	File "Plugins\CodeSnippet\CppAlgorithms.zip"
	File "Plugins\CodeSnippet\ICSharpCode.SharpZipLib.dll"
  SectionEnd
  Section "FileSearch"
	SectionIn 1 2
	SetOutPath "$INSTDIR\Plugins\FileSearch\"
	File "Plugins\FileSearch\FileSearch.dll"
  SectionEnd
  ; Section "ProEditor"
	; SectionIn 1 2
	; SetOutPath "$INSTDIR\Plugins\ProEditor\"
	; File "Plugins\ProEditor\ProEditor.dll"
  ; SectionEnd
  Section "WindowsMediaPlayer"
	SectionIn 1 2
	SetOutPath "$INSTDIR\Plugins\WindowsMediaPlayer\"
	File "Plugins\WindowsMediaPlayer\AxInterop.WMPLib.dll"
	File "Plugins\WindowsMediaPlayer\Interop.WMPLib.dll"
	File "Plugins\WindowsMediaPlayer\WindowsMediaPlayer.dll"
  SectionEnd
SubSectionEnd

SubSection "Language Files"
  Section "Bulgarian"
	SectionIn 1 3
	SetOutPath "$INSTDIR\Languages\"
	File "Languages\Bulgarian.dll"
  SectionEnd
  Section "Hungarian"
    SectionIn 1 3
    SetOutPath "$INSTDIR\Languages\"
	File "Languages\Hungarian.dll"
  SectionEnd
  Section "Latvian"
    SectionIn 1 3
    SetOutPath "$INSTDIR\Languages\"
	File "Languages\Latvian.dll"
  SectionEnd
  Section "Russian"
    SectionIn 1 3
    SetOutPath "$INSTDIR\Languages\"
	File "Languages\Russian.dll"
  SectionEnd
SubSectionEnd

Section "Start Menu Shortcuts"
  SectionIn 1 2 3 4
  CreateDirectory "$SMPROGRAMS\NStudio"
  CreateShortCut "$SMPROGRAMS\NStudio\NStudio.lnk" "$INSTDIR\NStudio.exe" "" "$INSTDIR\NStudio.exe" 0
  CreateShortCut "$SMPROGRAMS\NStudio\History.lnk" "$INSTDIR\History.txt" "" "$INSTDIR\History.txt" 0
  CreateShortCut "$SMPROGRAMS\NStudio\Readme.lnk" "$INSTDIR\Readme.txt" "" "$INSTDIR\Readme.txt" 0
  CreateShortCut "$SMPROGRAMS\NStudio\Uninstall.lnk" "$INSTDIR\uninstall.exe" "" "$INSTDIR\uninstall.exe" 0
SectionEnd

Section "Desktop Shortcut"
  SectionIn 1 2 3 4
  CreateShortCut "$DESKTOP\NStudio.lnk" "$INSTDIR\NStudio.exe"
SectionEnd

Section "Quick Launch Shortcut"
  SectionIn 1 2 3 4
  CreateShortCut "$QUICKLAUNCH\NStudio.lnk" "$INSTDIR\NStudio.exe"
SectionEnd

Function .onInit
  !insertmacro MUI_LANGDLL_DISPLAY
  !insertmacro MUI_INSTALLOPTIONS_EXTRACT "Check.net.ini"
FunctionEnd

Function CustomPageA
  !insertmacro MUI_HEADER_TEXT "Check requirements" ""
  !insertmacro MUI_INSTALLOPTIONS_DISPLAY "Check.net.ini"
FunctionEnd

;--------------------------------
; Uninstaller
Section "Uninstall"
  ; Remove registry keys
  DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\NStudio"
  DeleteRegKey HKLM SOFTWARE\NStudio
  ; Remove files and uninstaller
  Delete "$INSTDIR\Languages\*.*"
  RMDir  "$INSTDIR\Languages\"
  Delete "$INSTDIR\Plugins\CodeSnippet\*.*"
  RMDir  "$INSTDIR\Plugins\CodeSnippet"
  Delete "$INSTDIR\Plugins\FileSearch\*.*"
  RMDir  "$INSTDIR\Plugins\FileSearch\"
  ; Delete "$INSTDIR\Plugins\ProEditor\*.*"
  ; RMDir  "$INSTDIR\Plugins\ProEditor\"
  Delete "$INSTDIR\Plugins\WindowsMediaPlayer\*.*"
  RMDir  "$INSTDIR\Plugins\WindowsMediaPlayer\"  
  RMDir  "$INSTDIR\Plugins\"
  Delete "$INSTDIR\Configuration\*.*"
  RMDir  "$INSTDIR\Configuration\"  
  Delete "$INSTDIR\*.*"
  RMDir  "$INSTDIR"
  ; Shortcuts
  Delete "$SMPROGRAMS\NStudio\*.*"
  Delete "$DESKTOP\NStudio.lnk"
  Delete "$QUICKLAUNCH\NStudio.lnk"
  RMDir "$SMPROGRAMS\NStudio"  
SectionEnd
;--------------------------------