@echo off
setlocal
set "AATM_VERSION="
set "AATM_OPTIONAL="
set "AATM_OPTIONAL_ARGUMENT="
set /p "AATM_VERSION=Enter ClickOnce version (example 1.0.0.24): "
if not defined AATM_VERSION (
    echo No version was entered.
    pause
    exit /b 1
)
set /p "AATM_OPTIONAL=Make this update optional for clients? (y/N): "
if /i "%AATM_OPTIONAL%"=="Y" set "AATM_OPTIONAL_ARGUMENT=-OptionalUpdate"

powershell.exe -NoLogo -NoProfile -ExecutionPolicy Bypass -File "%~dp0Publish-AccountsClickOnce.ps1" -Version "%AATM_VERSION%" %AATM_OPTIONAL_ARGUMENT%
set "AATM_EXIT_CODE=%ERRORLEVEL%"
echo.
if not "%AATM_EXIT_CODE%"=="0" echo Publish failed with exit code %AATM_EXIT_CODE%.
pause
exit /b %AATM_EXIT_CODE%
