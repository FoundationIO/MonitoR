@ECHO OFF

powershell Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass
REM powershell Unblock-File .\Build\CI\build.ps1
pushd .\Build\CI\

ECHO MonitoR CI Tool

powershell .\build.ps1 -Verbosity Minimal -Command="%1"

popd
popd
popd
popd

@ECHO ON