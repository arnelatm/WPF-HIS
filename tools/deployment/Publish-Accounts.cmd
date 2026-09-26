@echo off
setlocal
set "AATM_VERSION="
set "AATM_REQUIRED="
set "AATM_REQUIRED_ARGUMENT="
set /p "AATM_VERSION=Enter ClickOnce version (example 1.0.0.8): "
if not defined AATM_VERSION (
    echo No version was entered.
    pause
    exit /b 1
)
set /p "AATM_REQUIRED=Make this update mandatory for all clients? (y/N): "
if /i "%AATM_REQUIRED%"=="Y" set "AATM_REQUIRED_ARGUMENT=-RequiredUpdate"

powershell.exe -NoLogo -NoProfile -ExecutionPolicy Bypass -File "%~dp0Publish-AccountsClickOnce.ps1" -Version "%AATM_VERSION%" %AATM_REQUIRED_ARGUMENT%
set "AATM_EXIT_CODE=%ERRORLEVEL%"
echo.
if not "%AATM_EXIT_CODE%"=="0" echo Publish failed with exit code %AATM_EXIT_CODE%.
pause
exit /b %AATM_EXIT_CODE%
