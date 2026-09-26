@echo off
setlocal
set "AATM_VERSION="
set /p "AATM_VERSION=Enter staged ClickOnce version to deploy (example 1.0.0.8): "
if not defined AATM_VERSION (
    echo No version was entered.
    pause
    exit /b 1
)

powershell.exe -NoLogo -NoProfile -ExecutionPolicy Bypass -File "%~dp0Deploy-AccountsClickOnce.ps1" -Version "%AATM_VERSION%"
set "AATM_EXIT_CODE=%ERRORLEVEL%"
echo.
if not "%AATM_EXIT_CODE%"=="0" echo Deployment failed with exit code %AATM_EXIT_CODE%.
pause
exit /b %AATM_EXIT_CODE%
