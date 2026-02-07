@echo off
cd /d "%~dp0"
echo Starting TemplateManager API...
echo Current directory: %CD%
echo.
dotnet run --launch-profile https
pause

